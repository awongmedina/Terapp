using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Terapp.UI
{
    public partial class frmCostoCita : Form
    {

        private PACIENTE _paciente = new PACIENTE();
        private CONSULTA _consulta = new CONSULTA();
        List<TRATAMIENTO> tratamientos = new List<TRATAMIENTO>();
        public frmCostoCita()
        {
            InitializeComponent();
        }


        public frmCostoCita(PACIENTE p, CONSULTA c, List<TRATAMIENTO> t)
        {
            InitializeComponent();

            this._consulta = c;
            this._paciente = p;
            this.tratamientos = t;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCosto.Text))
            {
                frmRecibo frmRecibo = new frmRecibo(this._paciente, this._consulta, this.tratamientos, txtCosto.Text);
                this.Close();
                frmRecibo.ShowDialog();
               
            }            
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
