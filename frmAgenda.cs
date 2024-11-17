using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Terapp.UI
{
    public partial class frmAgenda : Form
    {
        private frmMain _frmMain;
        public PACIENTE paciente;
        public CONSULTA consulta;
        public IQueryable<CONSULTA> consultas;
        public frmAgenda()
        {
            InitializeComponent();
            timer1.Start();
        }


        public frmAgenda(frmMain frm)
        {
            InitializeComponent();
            _frmMain = frm;
            timer1.Start();
        }
        #region Generar los controles para las citas del dia

        private void GenerarCitasPaciente()
        {
            flwCitas.Controls.Clear();

            using (TerapiModel db = new TerapiModel())
            {
                IQueryable<CONSULTA> consultas = db.CONSULTAS.Where(x => x.FechaConsulta.Year == DateTime.Today.Year
                        && x.FechaConsulta.Month == DateTime.Today.Month
                        && x.FechaConsulta.Day == DateTime.Today.Day);
                consultas.OrderByDescending(b => b.FechaConsulta.Hour);

                foreach (var consulta in consultas)
                {
                    PACIENTE paciente = new PACIENTE();

                    paciente = db.PACIENTES.Where(b => b.ID == consulta.PacienteID).FirstOrDefault();

                    ucCitaPaciente cita = new ucCitaPaciente();
                    cita.Nombre = paciente.Nombre;
                    cita.Consulta = consulta.ID;
                    cita.Hora = consulta.FechaConsulta.Date.ToShortDateString() + " " + consulta.FechaConsulta.TimeOfDay.ToString();
                    flwCitas.Controls.Add(cita);



                    cita.Click += new System.EventHandler(this.ucCitaPaciente_Click);
                    cita.MouseEnter += new System.EventHandler(this.ucCitaPaciente_MouseEnter);
                    cita.MouseLeave += new System.EventHandler(this.ucCitaPaciente_MouseLeave);

                }
            }

        }

        private void GenerarCitasPaciente(IQueryable<CONSULTA> consultas)
        {
            flwCitas.Controls.Clear();

            using (TerapiModel db = new TerapiModel())
            {
                foreach (var consulta in consultas)
                {
                    PACIENTE paciente = new PACIENTE();

                    paciente = db.PACIENTES.Where(b => b.ID == consulta.PacienteID).FirstOrDefault();

                    ucCitaPaciente cita = new ucCitaPaciente();
                    cita.Nombre = paciente.Nombre;
                    cita.Consulta = consulta.ID;
                    cita.Hora = consulta.FechaConsulta.Date.ToShortDateString() + " " + consulta.FechaConsulta.TimeOfDay.ToString();
                    flwCitas.Controls.Add(cita);

                    cita.Click += new System.EventHandler(this.ucCitaPaciente_Click);
                    cita.MouseEnter += new System.EventHandler(this.ucCitaPaciente_MouseEnter);
                    cita.MouseLeave += new System.EventHandler(this.ucCitaPaciente_MouseLeave);
                }
            }
        }

        

        private void ucCitaPaciente_Click(object sender, EventArgs e)
        {
            using (TerapiModel db = new TerapiModel())
            {
                ucCitaPaciente obj = (ucCitaPaciente)sender;
                paciente = db.PACIENTES.FirstOrDefault(x => x.Nombre == obj.Nombre);
                consulta = db.CONSULTAS.FirstOrDefault(x => x.ID == obj.Consulta);

                frmConsulta frmConsulta = new frmConsulta(this);
                frmConsulta.Show();
            }

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
        }

        private void btnAgendaMensual_Click(object sender, EventArgs e)
        {
            frmCalendarioMensual frmCalendarioMensual = new frmCalendarioMensual();
            frmCalendarioMensual.Show();
        }

        private void btnAgregarCita_Click(object sender, EventArgs e)
        {
            frmAgregarCita frm = new frmAgregarCita();
            frm.Show();
        }
    }
}
