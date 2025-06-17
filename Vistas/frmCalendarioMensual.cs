using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Terapp.UI.Controladores.Controladores;
using Terapp.UI.Controladores;
using System.Collections.Generic;

namespace Terapp.UI
{
    public partial class frmCalendarioMensual : Form
    {


        DateTime hoy = DateTime.Now;
        int _mes = DateTime.Now.Month;
        int _year = DateTime.Now.Year;
        IQueryable<CONSULTA> consultas;
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

                using (var unitOfWork = new UnitOfWork(new TerapiModel()))
                {
                    var dbService = new TerapiService(unitOfWork);

                    List<CONSULTA> _cons = new List<CONSULTA>();

                    DateTime d = new DateTime(yr, mes, i);

                    IQueryable<CONSULTA> _consultas = dbService.ObtenerConsultasPorDia(d).Where(x => x.EstatusConsulta == "ABIERTA").AsQueryable();

                    ucDiaCalendarioMensual ucCalendario = new ucDiaCalendarioMensual();
                    ucCalendario.Dias(i);
                    ucCalendario.CantidadPacientesPorDia(_consultas.Count());
                    flwCalendario.Controls.Add(ucCalendario);

                    ucCalendario.Click += new EventHandler(this.ucCalendario_Click);
                    ucCalendario.MouseEnter += new EventHandler(this.ucCalendario_MouseEnter);
                    ucCalendario.MouseLeave += new EventHandler(this.ucCalendario_MouseLeave);

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
            using (var unitOfWork = new UnitOfWork(new TerapiModel()))
            {
                var dbService = new TerapiService(unitOfWork);

                consultas = dbService.ObtenerConsultasPorDia(d).AsQueryable();
            }

            frmAgenda frmAgenda = new frmAgenda();
            frmAgenda.consultas = consultas;
            frmAgenda.agenda = true;
            frmAgenda.Show();
            this.Close();
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

        private void frmCalendarioMensual_FormClosed(object sender, FormClosedEventArgs e)
        {
            new frmAgenda().Show();
        }
    }
}
