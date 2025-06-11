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

        public void Dias(int numDias)
        {
            lblDiaDelMes.Text = numDias + "";
        }

        public void CantidadPacientes(int pacientes)
        {
            lblNumPacientes.Text = pacientes.ToString();
        }

        public DateTime ObtenerFecha(int mes, int yr)
        {
            DateTime d = new DateTime(ObtenerYr(yr), ObtenerMes(mes), Convert.ToInt16(lblDiaDelMes.Text));

            return d;
        }

        private int ObtenerMes(int mes)
        {
            int m = new DateTime(1, mes, 1).Month;
            return m;
        }

        private int ObtenerYr(int yr) 
        {
            int m = new DateTime(yr, 1, 1).Year;
            return m;
        }        
    }
}
