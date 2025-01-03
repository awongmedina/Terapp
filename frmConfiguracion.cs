using System;
using System.Drawing;
using System.Security.Policy;
using System.Windows.Forms;

namespace Terapp.UI
{
    public partial class frmConfiguracion : Form
    {
        private decimal estatusPadecimiento;
        private decimal estatusTratamiento;
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
            if (txtDescripcionAfeccion.Text == "" || txtNombreAfeccion.Text == "") 
            {
                lblErrorPadecimiento.Text = "VERIFICA QUE TODOS LOS CAMPOS DE TEXTO ESTEN LLENOS";
                lblErrorPadecimiento.BackColor = Color.Red;
                return;
            }

            using (TerapiModel db = new TerapiModel())
            {
                PADECIMIENTO padecimiento = new PADECIMIENTO();
                padecimiento.NombrePadecimiento = txtNombreAfeccion.Text;
                padecimiento.Descripcion = txtDescripcionAfeccion.Text;
                padecimiento.Activo = estatusPadecimiento;

                db.PADECIMIENTOS.Add(padecimiento);

                db.SaveChanges();

                lblErrorPadecimiento.Text = "PADECIMIENTO GUARDADO CON EXITO!";
                lblErrorPadecimiento.BackColor = Color.Green;

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
            if (txtDescripcionTratamiento.Text == "" || txtNombreTratamiento.Text == "")
            {
                lblErrorTratamiento.Text = "VERIFICA QUE TODOS LOS CAMPOS DE TEXTO ESTEN LLENOS";
                lblErrorTratamiento.BackColor = Color.Red;
                return;
            }

            using (TerapiModel db = new TerapiModel())
            {
                TIPO_TRATAMIENTO tratamiento = new TIPO_TRATAMIENTO();
                tratamiento.TipoTratamiento = txtNombreTratamiento.Text;
                tratamiento.Descripcion = txtDescripcionTratamiento.Text;
                tratamiento.Activo = estatusTratamiento;

                db.TIPO_TRATAMIENTO.Add(tratamiento);

                db.SaveChanges();

                lblErrorTratamiento.Text = "PADECIMIENTO GUARDADO CON EXITO!";
                lblErrorTratamiento.BackColor = Color.Green;

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
            if (txtPacientesSimultaneos.Text == "") 
            {
                lblErrorPacientes.Text = "NO HAS INGRESADO NINGUN NUMERO, FAVOR DE VERIFICAR";
                return;
            }

            using (TerapiModel db = new TerapiModel()) 
            {
                CONFIGURACION config = new CONFIGURACION();
                config.CantidadPacientes = Convert.ToInt16(txtPacientesSimultaneos.Text);
                
                db.CONFIGURACIONES.Add(config);

                db.SaveChanges();

                lblErrorPacientes.Text = "CONFIGURACION GUARDADA CON EXITO";
                lblErrorPacientes.BackColor = Color.Green;

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
                lblErrorPacientes.Text = "";
            }
        }
    }
}
