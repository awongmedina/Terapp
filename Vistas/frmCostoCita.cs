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
        public frmCostoCita()
        {
            InitializeComponent();
        }


        public frmCostoCita(PACIENTE p, CONSULTA c)
        {
            InitializeComponent();

            this._consulta = c;
            this._paciente = p;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCosto.Text))
            {
                frmRecibo frmRecibo = new frmRecibo(this._paciente.Nombre, this._paciente.ID, this._consulta.MotivoConsulta, this._consulta.Valoracion, this._consulta.FechaConsulta, txtCosto.Text);
                this.Close();
                frmRecibo.ShowDialog();
               
            }            
        }
    }
}
