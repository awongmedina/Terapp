using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Terapp.UI.Controladores;
using Terapp.UI.Controladores.Controladores;
using Terapp.UI.Vistas;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Terapp.UI
{
    public partial class frmCerrarConsulta : Form
    {
        private int _consultaId;
        public frmCerrarConsulta(int consultaId)
        {
            _consultaId = consultaId;
            InitializeComponent();

            cboMotivoCierre.DataSource = Enum.GetValues(typeof(CONSULTA.MotivosCierrePredeterminados));
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string opcionSeleccionada = cboMotivoCierre.SelectedItem?.ToString();

            using (var unitOfWork = new UnitOfWork(new TerapiModel()))
            {
                var dbService = new TerapiService(unitOfWork);
                var consulta = dbService.ObtenerConsulta(_consultaId);
                consulta.EstatusConsulta = "CERRADA";
                consulta.MotivoCierre = opcionSeleccionada;

                dbService.ActualizarConsulta(consulta);
            }

                this.Close();

            new frmMensaje("CITA CERRADA CON EXITO!", true).ShowDialog();
        }
    }
}
