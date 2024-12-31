using System;
using System.Data.Entity;
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
        frmConsulta _consulta;
        public PACIENTE _paciente;
        DateTime _fechaConsulta;
        public frmAgregarCita()
        {
            InitializeComponent();
        }

        public frmAgregarCita(PACIENTE paciente)
        {
            InitializeComponent();

            this._paciente = paciente;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _fechaConsulta = FormatearHora();

            using (TerapiModel db = new TerapiModel()) 
            {
               
               

                CONSULTA consulta = new CONSULTA();
                consulta.FechaConsulta = _fechaConsulta;
                consulta.PacienteID = _paciente.ID;

                db.CONSULTAS.Add(consulta);
                db.SaveChanges();

                lblError.Text = "CITA AGREGADA CON EXITO!";
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.DarkGreen;

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
    }
}
