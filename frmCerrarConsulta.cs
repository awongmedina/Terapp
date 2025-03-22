using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Terapp.UI
{
    public partial class frmCerrarConsulta : Form
    {
        public delegate void OpcionSeleccionadaHandler(string opcionSeleccionada);
        public event OpcionSeleccionadaHandler OpcionSeleccionada;

        public frmCerrarConsulta()
        {
            InitializeComponent();

            cboMotivoCierre.DataSource = Enum.GetValues(typeof(CONSULTA.TipoMotivoCierre));
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string opcionSeleccionada = cboMotivoCierre.SelectedItem?.ToString();

            OpcionSeleccionada?.Invoke(opcionSeleccionada);

            this.Close();
        }
    }
}
