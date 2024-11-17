using System;
using System.Windows.Forms;

namespace Terapp.UI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Today.ToShortDateString();
            lblHora.Text = DateTime.Now.ToShortTimeString();
        }

        private void btnAgenda_Click(object sender, EventArgs e)
        {
            frmAgenda frmAgenda = new frmAgenda();
            frmAgenda.Show(this);
        }

        private void btnExpedienteClinico_Click(object sender, EventArgs e)
        {
            frmExpClinico frmExpClinico = new frmExpClinico();
            frmExpClinico.Show();
        }

        private void btnRegistroPaciente_Click(object sender, EventArgs e)
        {
            frmConsulta frmRegistro = new frmConsulta();
            frmRegistro.Show();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            frmConfiguracion frmConfiguracion = new frmConfiguracion();
            frmConfiguracion.Show();
        }
    }
}
