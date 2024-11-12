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
    public partial class frmAgregarCita : Form
    {

        frmConsulta _consulta;
        string _nombre;
        DateTime _fechaConsulta;
        public frmAgregarCita()
        {
            InitializeComponent();
        }

        public frmAgregarCita(frmConsulta consulta, string nombre)
        {
            InitializeComponent();

            this._consulta = consulta;
            this._nombre = nombre;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _fechaConsulta = FormatearHora();

        }

        private DateTime FormatearHora() 
        {
            int hora = Convert.ToInt16(cboHora.SelectedItem.ToString()); 
            int minutos = Convert.ToInt16(cboMinutos.SelectedItem.ToString());
            string AMPM = cboAMPM.SelectedItem.ToString();

            if (AMPM == "PM")
                hora = hora + 12;

            DateTime time = new DateTime(dtpFecha.Value.Year, dtpFecha.Value.Month, dtpFecha.Value.Day, hora, minutos, 00);

            return time;
        }
    }
}
