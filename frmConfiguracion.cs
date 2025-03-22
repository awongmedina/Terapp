using System;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Windows.Forms;

namespace Terapp.UI
{
    public partial class frmConfiguracion : Form
    {
        private decimal estatusPadecimiento;
        private decimal estatusTratamiento;
        int timeError = 0;
        public frmConfiguracion()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToShortDateString();
            lblHora.Text = DateTime.Now.ToShortTimeString();
        }

        private void btnGuardarAfeccion_Click(object sender, EventArgs e)
        {
            if (txtNombreAfeccion.Text == "") 
            {
                lblErrorPadecimiento.Text = "VERIFICA QUE TODOS LOS CAMPOS DE TEXTO ESTEN LLENOS";
                lblErrorPadecimiento.Visible = true;
                lblErrorPadecimiento.ForeColor = Color.Red;
                timerError.Start();
                return;
            }

            using (TerapiModel db = new TerapiModel())
            {
                PADECIMIENTO padecimiento = new PADECIMIENTO();
                padecimiento = db.PADECIMIENTOS.FirstOrDefault(x => x.NombrePadecimiento == txtNombreAfeccion.Text);

                if (padecimiento == null)
                {
                    padecimiento.NombrePadecimiento = txtNombreAfeccion.Text;
                    padecimiento.Descripcion = txtDescripcionAfeccion.Text;
                    padecimiento.Activo = estatusPadecimiento;

                    db.PADECIMIENTOS.Add(padecimiento);

                    db.SaveChanges();

                    lblErrorPadecimiento.Text = "PADECIMIENTO GUARDADO CON EXITO!";
                    lblErrorPadecimiento.Visible = true;
                    timerError.Start();
                    lblErrorPadecimiento.ForeColor = Color.Green;
                }
                else 
                {
                    lblErrorPadecimiento.Text = "ESTE PADECIMIENTO YA ESTA REGISTRADO";
                    lblErrorPadecimiento.Visible = true;
                    timerError.Start();
                    lblErrorPadecimiento.ForeColor = Color.Red;
                }

               

            }
        }

        private void chkEstatusAfeccion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEstatusAfeccion.Checked)
            {
                estatusPadecimiento = 1;
            }
            else 
            {
                estatusPadecimiento = 0;    
            }
        }

        private void btnGuardarTipoTratamiento_Click(object sender, EventArgs e)
        {
            if (txtNombreTratamiento.Text == "")
            {
                lblErrorTratamiento.Text = "VERIFICA QUE TODOS LOS CAMPOS DE TEXTO ESTEN LLENOS";
                lblErrorTratamiento.Visible = true;
                timerError.Start();
                lblErrorTratamiento.ForeColor = Color.Red;
                return;
            }

            using (TerapiModel db = new TerapiModel())
            {
                TIPO_TRATAMIENTO tratamiento = new TIPO_TRATAMIENTO();

                tratamiento = db.TIPO_TRATAMIENTO.FirstOrDefault(t => t.TipoTratamiento == txtNombreTratamiento.Text);

                if (tratamiento == null)
                {
                    tratamiento.TipoTratamiento = txtNombreTratamiento.Text;
                    tratamiento.Descripcion = txtDescripcionTratamiento.Text;
                    tratamiento.Activo = estatusTratamiento;

                    db.TIPO_TRATAMIENTO.Add(tratamiento);

                    db.SaveChanges();

                    lblErrorTratamiento.Text = "PADECIMIENTO GUARDADO CON EXITO!";
                    lblErrorTratamiento.Visible = true;
                    timerError.Start();
                    lblErrorTratamiento.ForeColor = Color.Green;
                }
                else 
                {                    
                    lblErrorTratamiento.Text = "ESTE TRATAMIENTO YA ESTA REGISTRADO";
                    lblErrorTratamiento.Visible = true;
                    timerError.Start();
                    lblErrorTratamiento.ForeColor = Color.Red;  
                }



            }
        }

        private void chkEstatusTratamiento_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEstatusTratamiento.Checked)
            {
                estatusTratamiento = 1;
            }
            else
            {
                estatusTratamiento = 0;
            }
        }

        private void btnGuardarCalendario_Click(object sender, EventArgs e)
        {
            if (txtPacientesSimultaneos.Text == "" || txtPacientesSimultaneos.Text == "0") 
            {
                lblErrorPacientes.Text = "NO HAS INGRESADO NINGUN NUMERO, FAVOR DE VERIFICAR";
                lblErrorPacientes.Visible = true;
                timerError.Start();
                return;
            }

            using (TerapiModel db = new TerapiModel()) 
            {
                CONFIGURACION config = db.CONFIGURACIONES.FirstOrDefault();
                config.CantidadPacientes = Convert.ToInt16(txtPacientesSimultaneos.Text);

                db.SaveChanges();

                lblErrorPacientes.Text = "CONFIGURACION GUARDADA CON EXITO";
                lblErrorPacientes.Visible = true;
                timerError.Start();
                lblErrorPacientes.ForeColor = Color.Green;

            }

        }

        private void txtPacientesSimultaneos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

            }
            else
            {
                lblErrorPacientes.Visible = false;
                timerError.Stop();
                timeError = 0;
            }
        }

        private void timerError_Tick(object sender, EventArgs e)
        {
            if (timeError < 20)
            {
                timeError++;
            }
            else 
            {
                lblErrorPacientes.Visible = false;
                lblErrorPadecimiento.Visible = false;
                lblErrorTratamiento.Visible = false;
                timerError.Stop();
                timeError = 0;
            }
        }

        private void txtNombreAfeccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblErrorPadecimiento.Visible = false;
            timerError.Stop();
            timeError = 0;
        }

        private void txtNombreTratamiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblErrorTratamiento.Visible = false;
            timerError.Stop();
            timeError = 0;
        }
    }
}
