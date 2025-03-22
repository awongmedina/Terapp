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
    public partial class ucAdjunto : UserControl
    {
        public ucAdjunto()
        {
            InitializeComponent();
        }

        #region Getter y Setter
        private string _nombreArchivo;
        private string _extensionArchivo;
        private string _rutaArchivo;

        [Category("Custom props")]
        public string NombreArchivo
        {
            get { return _nombreArchivo; }
            set { _nombreArchivo = value; lblNombreArchivo.Text = value; }
        }

        [Category("Custom props")]
        public string ExtensionArchivo
        {
            get { return _extensionArchivo; }
            set { _extensionArchivo = value; lblExtensionArchivo.Text = value; }
        }

        public string RutaArchivo
        {
            get { return _rutaArchivo; }
            set { _rutaArchivo = value; }
        }


        #endregion

        private void ucAdjunto_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(111, 166, 234);
        }

        private void ucAdjunto_MouseLeave(object sender, EventArgs e)
        {

            this.BackColor = SystemColors.Control;
        }
    }
}
