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
    public partial class frmAgenda : Form
    {
        private frmMain _frmMain;
        //private Paciente paciente;
        public frmAgenda()
        {
            InitializeComponent();
            timer1.Start();
        }

        /*
        public frmAgenda(string clientes)
        {
            InitializeComponent();
            this.pacientes = clientes;
            timer1.Start();
        }

        */

        public frmAgenda(frmMain frm)
        {
            InitializeComponent();
            _frmMain = frm;
            timer1.Start();
        }
        #region Generar los controles para las citas del dia

        private void GenerarCitasPaciente()            
        {
            flwCitas.Controls.Clear();
            /*
            if ()
            {

            } else 
            {

            }
            */
            string[] nombre = new string[5] { "Pedro Paramo", "Jose Perez", "Juanita Rodriguez", "Pancho Lopez", "Alexis Wong" };
            string[] hora = new string[5] { "Pedro Paramo", "Jose Perez", "Juanita Rodriguez", "Pancho Lopez", "Alexis Wong" };

            ucCitaPaciente[] citas = new ucCitaPaciente[5];

            for (int i = 0; i < citas.Length; i++)
            {
                citas[i] = new ucCitaPaciente();
                citas[i].Nombre = nombre[i];
                citas[i].Hora = hora[i];
                flwCitas.Controls.Add(citas[i]);

                citas[i].Click += new System.EventHandler(this.ucCitaPaciente_Click);
                citas[i].MouseEnter += new System.EventHandler(this.ucCitaPaciente_MouseEnter);
                citas[i].MouseLeave += new System.EventHandler(this.ucCitaPaciente_MouseLeave);

                //citas[i].Controls.
            }

        }

        private void ucCitaPaciente_Click(object sender, EventArgs e) 
        {
            ucCitaPaciente obj = (ucCitaPaciente)sender;
            frmConsulta frmConsulta = new frmConsulta(this, obj.Nombre);
            frmConsulta.Show();
        }

        private void ucCitaPaciente_MouseEnter(object sender, EventArgs e)
        {
            ucCitaPaciente obj = (ucCitaPaciente)sender;
            obj.BackColor = Color.FromArgb(111, 166, 234);
        }

        private void ucCitaPaciente_MouseLeave(object sender, EventArgs e)
        {
            ucCitaPaciente obj = (ucCitaPaciente)sender;    
            obj.BackColor = SystemColors.Control;
        }

        #endregion

        private void frmAgenda_Load(object sender, EventArgs e)
        {
            GenerarCitasPaciente();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Today.ToShortDateString();
            lblHora.Text = DateTime.Now.ToShortTimeString();
        }

        private void btnPacienteSinCita_Click(object sender, EventArgs e)
        {
            frmConsulta consulta = new frmConsulta();
            consulta.Show();
        }

        private void btnAgendaMensual_Click(object sender, EventArgs e)
        {
            frmCalendarioMensual frmCalendarioMensual = new frmCalendarioMensual();
            frmCalendarioMensual.Show();
        }

        private void btnAgregarCita_Click(object sender, EventArgs e)
        {
            frmAgregarCita frm = new frmAgregarCita();
            frm.Show();
        }
    }
}
