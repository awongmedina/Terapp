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
    public partial class ucCitaPaciente : UserControl
    {

        public ucCitaPaciente()
        {
            InitializeComponent();
        }

        #region Getter y Setter
        private string _nombre;
        private string _hora;

        [Category("Custom props")]
        public string Nombre 
        {
            get { return _nombre; }
            set { _nombre = value;  lblNombrePaciente.Text = value; }
        }

        [Category("Custom props")]
        public string Hora 
        {
            get { return _hora; }
            set { _hora = value; lblHoraCita.Text = value; }
        }      


        #endregion

        private void ucCitaPaciente_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(111, 166, 234);
        }

        private void ucCitaPaciente_MouseLeave(object sender, EventArgs e)
        {            

            this.BackColor = SystemColors.Control;
        }
    }
}
