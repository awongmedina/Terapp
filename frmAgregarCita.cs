using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Terapp.UI
{
    public partial class frmAgregarCita : Form
    {
        public PACIENTE _paciente;
        DateTime _fechaConsulta;
        int timeError = 0;
        public frmAgregarCita()
        {
            InitializeComponent();
        }

        public frmAgregarCita(PACIENTE paciente)
        {
            InitializeComponent();

            this._paciente = paciente;

            txtPaciente.Text = _paciente.Nombre;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (_paciente == null) 
            {
                lblError.Text = "NO HAS SELECCIONADO UN PACIENTE";
                lblError.Visible = true;
                lblError.ForeColor = Color.Red;
                timerError.Start();
                return;
            }
            _fechaConsulta = FormatearHora();

            using (TerapiModel db = new TerapiModel()) 
            {
                List<CONSULTA> c = db.CONSULTAS.Where(x => x.FechaConsulta == _fechaConsulta).ToList();

                CONFIGURACION config = db.CONFIGURACIONES.FirstOrDefault();

                if (c.Count == config.CantidadPacientes)
                {
                    lblError.Text = "HORARIO OCUPADO";
                    timerError.Start();
                    lblError.Visible = true;
                    lblError.ForeColor = Color.Red;
                    return;
                }
                else 
                {
                    CONSULTA consulta = new CONSULTA();
                    consulta.FechaConsulta = _fechaConsulta;
                    consulta.PacienteID = _paciente.ID;

                    db.CONSULTAS.Add(consulta);
                    db.SaveChanges();

                    lblError.Text = "CITA AGREGADA CON EXITO!";
                    timerError.Start();
                    lblError.Visible = true;
                    lblError.ForeColor = Color.Green;
                }
            }

        }

        private DateTime FormatearHora()
        {
            int hora = Convert.ToInt16(cboHora.SelectedItem.ToString());
            int minutos = Convert.ToInt16(cboMinutos.SelectedItem.ToString());
            string AMPM = cboAMPM.SelectedItem.ToString();

            if (AMPM == "PM")
                hora = hora + 12;

            DateTime time = new DateTime(dtpFecha.Value.Year, dtpFecha.Value.Month, dtpFecha.Value.Day, hora, minutos, 00);

            return time;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtPaciente.Text == "" || txtPaciente.Text == null)
                return;

            using (TerapiModel db = new TerapiModel()) 
            {
                _paciente = db.PACIENTES.FirstOrDefault(x => x.Nombre == txtPaciente.Text);

                if (_paciente == null)
                {
                    lblError.Visible = true;
                }
                else 
                {
                    lblError.Visible = false;
                }
                    
            }
        }

        private void txtPaciente_TextChanged(object sender, EventArgs e)
        {
            lblError.Visible = false;
            timerError.Stop();
            lblError.Visible = false;
        }

        private void timerError_Tick(object sender, EventArgs e)
        {
            if (timeError < 20)
            {
                timeError++;
            }
            else 
            {
                timeError = 0;
                lblError.Visible = false;
                timerError.Stop();
            }
        }
    }
}
