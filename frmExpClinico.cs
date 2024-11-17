using System;
using System.Windows.Forms;

namespace Terapp.UI
{
    public partial class frmExpClinico : Form
    {
        public frmExpClinico()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Today.ToShortDateString();
            lblHora.Text = DateTime.Now.ToShortTimeString();
        }

    }
}
