using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Terapp.UI
{
    public partial class frmCalendarioMensual : Form
    {

        DateTime hoy = DateTime.Now;
        int _mes = DateTime.Now.Month;
        int _year = DateTime.Now.Year;
        int _dia = DateTime.Now.Day;
        public IQueryable<CONSULTA> consultas;
        public frmCalendarioMensual()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToShortDateString();
            lblHora.Text = DateTime.Now.ToShortTimeString();
        }

        private void frmCalendarioMensual_Load(object sender, EventArgs e)
        {
            mostrarDias(hoy.Month, hoy.Year);
        }

        private void mostrarDias(int mes, int yr)
        {
            flwCalendario.Controls.Clear();

            DateTime inicioMes = new DateTime(yr, mes, 1);

            int dias = DateTime.DaysInMonth(yr, mes);

            int diaSemana = Convert.ToInt32(inicioMes.DayOfWeek.ToString("d"));

            lblMes.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(_mes).ToUpper();
            lblYear.Text = _year.ToString();

            for (int i = 1; i <= diaSemana; i++)
            {
                ucCalVacio ucCalVacio = new ucCalVacio();
                flwCalendario.Controls.Add(ucCalVacio);
            }

            for (int i = 1; i <= dias; i++)
            {      

                using (TerapiModel db = new TerapiModel()) 
                {
                   
                    DateTime d = new DateTime(yr, mes, i);

                    IQueryable<CONSULTA> _consultas = db.CONSULTAS.Where(x => DbFunctions.TruncateTime(x.FechaConsulta) == DbFunctions.TruncateTime(d));

                    ucDiaCalendarioMensual ucCalendario = new ucDiaCalendarioMensual();
                    ucCalendario.Dias(i);
                    ucCalendario.CantidadPacientes(_consultas.Count());
                    flwCalendario.Controls.Add(ucCalendario);

                    ucCalendario.Click += new System.EventHandler(this.ucCalendario_Click);
                    ucCalendario.MouseEnter += new System.EventHandler(this.ucCalendario_MouseEnter);
                    ucCalendario.MouseLeave += new System.EventHandler(this.ucCalendario_MouseLeave);

                }


            }
        }

        private void btnSigMes_Click(object sender, EventArgs e)
        {
            _mes++;
            if (_mes == 13)
            {
                _mes = 01;
                _year++;
            }

            mostrarDias(_mes, _year);
        }

        private void btnMesAnterior_Click(object sender, EventArgs e)
        {
            _mes--;

            if (_mes == 00)
            {
                _mes = 12;
                _year--;
            }

            mostrarDias(_mes, _year);
        }

        private void ucCalendario_Click(object sender, EventArgs e)
        {
            ucDiaCalendarioMensual obj = (ucDiaCalendarioMensual)sender;
            DateTime d = obj.ObtenerFecha(_mes, _year);
            

            using (TerapiModel db = new TerapiModel()) 
            {
               
                consultas = db.CONSULTAS.Where(x => DbFunctions.TruncateTime(x.FechaConsulta) == DbFunctions.TruncateTime(d));

                frmAgenda frmAgenda = new frmAgenda();
                frmAgenda.consultas = consultas;
                frmAgenda.Show();
                this.Close();
            }           
        }

        private void ucCalendario_MouseEnter(object sender, EventArgs e)
        {
            ucDiaCalendarioMensual obj = (ucDiaCalendarioMensual)sender;
            obj.BackColor = SystemColors.Control;
        }

        private void ucCalendario_MouseLeave(object sender, EventArgs e)
        {
            ucDiaCalendarioMensual obj = (ucDiaCalendarioMensual)sender;
            obj.BackColor = Color.FromArgb(111, 166, 234);

        }
    }
}
