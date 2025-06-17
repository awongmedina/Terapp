using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Terapp.UI.Controladores;
using Terapp.UI.Controladores.Controladores;
using Terapp.UI.Vistas;

namespace Terapp.UI
{
    public partial class frmAgenda : Form
    {
        
        public PACIENTE _paciente;
        public CONSULTA _consulta;
        public IQueryable<CONSULTA> consultas;
        public bool agenda = false;
        public frmAgenda()
        {
            InitializeComponent();
            timer1.Start();
        }

        #region Generar los controles para las citas del dia

        private void GenerarCitasPaciente()
        {
            flwCitas.Controls.Clear();

        }

        private void GenerarCitasPaciente(IQueryable<CONSULTA> consultas)
        {
            flwCitas.Controls.Clear();

            AgregarControles(consultas.AsQueryable());
        }

        private void AgregarControles(IQueryable<CONSULTA> consultas) 
        {
            foreach (var consulta in consultas)
            {
                using (var unitOfWork = new UnitOfWork(new TerapiModel()))
                {
                    var dbService = new TerapiService(unitOfWork);

                    PACIENTE paciente = dbService.ObtenerPacientePorID(consulta.PacienteID);


                    ucCitaPaciente cita = new ucCitaPaciente();
                    cita.Nombre = paciente.Nombre;
                    cita.Consulta = consulta.ID;
                    cita.Hora = consulta.FechaConsulta.Date.ToShortDateString() + " " + consulta.FechaConsulta.TimeOfDay.ToString();
                    flwCitas.Controls.Add(cita);

                    cita.Click += new EventHandler(this.ucCitaPaciente_Click);
                    cita.MouseEnter += new EventHandler(this.ucCitaPaciente_MouseEnter);
                    cita.MouseLeave += new EventHandler(this.ucCitaPaciente_MouseLeave);
                }
            }
        }



        private void ucCitaPaciente_Click(object sender, EventArgs e)
        {
            ucCitaPaciente obj = (ucCitaPaciente)sender;

            using (var unitOfWork = new UnitOfWork(new TerapiModel()))
            {
                var dbService = new TerapiService(unitOfWork);

                // Buscar al paciente por nombre
                _paciente = dbService.ObtenerPacientePorNombre(obj.Nombre);

                if (_paciente == null)
                {
                    new frmMensaje("NO SE ENCONTRÓ UN PACIENTE CON ESE NOMBRE", true).ShowDialog();
                    return;
                }

                // Obtener la consulta usando el ID proporcionado
                _consulta = dbService.ObtenerConsulta(obj.Consulta);

                if (_consulta == null)
                {
                    new frmMensaje("NO SE ENCONTRÓ UNA CONSULTA CON ESE ID", true).ShowDialog();
                    return;
                }
            }

            // Si todo está correcto, abrir el formulario
            frmConsulta frmConsulta = new frmConsulta(_paciente, _consulta);
            frmConsulta.Show();
        }



        private void ucCitaPaciente_MouseEnter(object sender, EventArgs e)
        {
            ucCitaPaciente obj = (ucCitaPaciente)sender;
            obj.BackColor = Color.FromArgb(111, 166, 234);
        }

        private void ucCitaPaciente_MouseLeave(object sender, EventArgs e)
        {
            ucCitaPaciente obj = (ucCitaPaciente)sender;
            obj.BackColor = SystemColors.Control;
        }

        #endregion

        private void frmAgenda_Load(object sender, EventArgs e)
        {
            ObtenerCitasDelDia();

            if (consultas != null)
            {
                GenerarCitasPaciente(consultas);
            }
            else 
            { 
                GenerarCitasPaciente(); 
            }            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Today.ToShortDateString();
            lblHora.Text = DateTime.Now.ToShortTimeString();
        }

        private void btnPacienteSinCita_Click(object sender, EventArgs e)
        {
            frmConsulta consulta = new frmConsulta();
            consulta.Show();
            this.Close();
            
        }

        private void btnAgendaMensual_Click(object sender, EventArgs e)
        {
            frmCalendarioMensual frmCalendarioMensual = new frmCalendarioMensual();
            frmCalendarioMensual.Show();
            this.Close();
            
        }

        private void btnAgregarCita_Click(object sender, EventArgs e)
        {
            frmAgregarCita frm = new frmAgregarCita();
            frm.Show();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            flwCitas.Controls.Clear();
            ObtenerCitasDelDia();
        }

        private void ObtenerCitasDelDia()
        {
            if (!agenda) 
            {
                using (var unitOfWork = new UnitOfWork(new TerapiModel()))
                {
                    var dbService = new TerapiService(unitOfWork);

                    var _consultas = dbService.ObtenerConsultasPorDia(DateTime.Today);
                    if (_consultas == null)
                        return;

                    consultas = _consultas.AsQueryable();
                }
            }
           

            AgregarControles(consultas);
        }
    }
}
