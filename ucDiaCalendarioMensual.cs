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
    public partial class ucDiaCalendarioMensual : UserControl
    {
        public ucDiaCalendarioMensual()
        {
            InitializeComponent();
        }

        private void ucDiaCalendarioMensual_Load(object sender, EventArgs e)
        {

        }

        public void Dias(int numDias) 
        { 
            lblDiaDelMes.Text = numDias + "";
        }
    }
}
