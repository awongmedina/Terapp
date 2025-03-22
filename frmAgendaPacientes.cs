using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Terapp.UI
{
    public partial class frmAgendaPacientes : Form
    {
        int timeError = 0;
        private PACIENTE paciente;
        public frmAgendaPacientes()
        {
            InitializeComponent();
            lblError.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Today.ToShortDateString();
            lblHora.Text = DateTime.Now.ToShortTimeString();
        }

        private void timerError_Tick(object sender, EventArgs e)
        {
            if (timeError < 20)
            {
                timeError++;
            }
            else
            {
                lblError.Visible = false;
                timeError = 0;
                timerError.Stop();
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == null)
            {
                lblError.Text = "NO HAS INGRESADO UN NOMBRE PARA BUSQUEDA";
                lblError.ForeColor = Color.Red;
                lblError.Visible = true;
                return;
            }


            using (TerapiModel db = new TerapiModel())
            {

                paciente = new PACIENTE();
                paciente = db.PACIENTES.FirstOrDefault(x => x.Nombre == txtNombre.Text);
                if (paciente != null)
                {
                    txtOcupacion.Text = paciente.Ocupacion.ToString();
                    txtTelefono.Text = paciente.Telefono.ToString();
                    txtEdad.Text = (DateTime.Today.Year - paciente.FechaNacimiento.Year).ToString();
                    dtpFechaNacimiento.Text = paciente.FechaNacimiento.ToString();
                    lblError.Visible = false;
                }
                else
                {
                    lblError.Text = "NO SE ENCONTRO EL PACIENTE";
                    lblError.ForeColor = Color.Red;
                    lblError.Visible = true;
                    timerError.Start();

                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (TerapiModel db = new TerapiModel()) 
            {
                if (paciente == null)
                {
                    paciente = new PACIENTE();
                    paciente.Nombre = this.txtNombre.Text;
                    paciente.Ocupacion = this.txtOcupacion.Text;
                    paciente.FechaNacimiento = this.dtpFechaNacimiento.Value;
                    paciente.Telefono = this.txtTelefono.Text;

                    db.PACIENTES.Add(paciente);
                    db.SaveChanges();

                    lblError.Text = "PACIENTE GUARDADO CON EXITO!";
                    lblError.ForeColor = Color.Green;
                    lblError.Visible = true;
                    timerError.Start();
                }
            }
                
        }
    }
}
