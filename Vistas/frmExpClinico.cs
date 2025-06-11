using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Terapp.UI.Controladores;
using Terapp.UI.Controladores.Controladores;
using Terapp.UI.Vistas;

namespace Terapp.UI
{
    public partial class frmExpClinico : Form
    {
        private CONSULTA consulta;
        private PACIENTE paciente;
        private IEnumerable<CONSULTA> consultas;
        public frmExpClinico()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Today.ToShortDateString();
            lblHora.Text = DateTime.Now.ToShortTimeString();
        }

        private void btnBuscarExpediente_Click(object sender, EventArgs e)
        {
            frmMensaje msg;

            if (txtNombre.Text == null || txtNombre.Text == "")
            {
                msg = new frmMensaje("NO SE HA INGRESADO UN NOMBRE PARA BUSQUEDA", true);
                msg.ShowDialog();
                return;
            }

            using (var unitOfWork = new UnitOfWork(new TerapiModel()))
            {
                var dbService = new TerapiService(unitOfWork);
                paciente = unitOfWork.pacientes.ObtenerPorCondicion(p => p.Nombre == txtNombre.Text);

                if (paciente == null)
                {
                    msg = new frmMensaje("NO HAY PACIENTES REGISTRADOS CON ESE NOMBRE", true);
                    msg.ShowDialog();
                }
                else
                {
                    consultas = unitOfWork.consultas.ObtenerTodosPorCondicion(c => c.PacienteID == paciente.ID);
                    LlenarDGVConsultas();
                }

                
            }
        }

        private void LlenarDGVConsultas()
        {
            dgvConsultas.DataSource = null;
            dgvConsultas.DataSource = consultas.ToList();

            dgvConsultas.Columns["ID"].Visible = false;
            dgvConsultas.Columns["PacienteID"].Visible = false;
            dgvConsultas.Columns["EstatusConsulta"].HeaderText = "Estatus de la consulta";
            dgvConsultas.Columns["MotivoCierre"].HeaderText = "Motivo de cierre";

        }

        private void dgvConsultas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int rowIndex = e.RowIndex;
                consulta = (CONSULTA)dgvConsultas.Rows[rowIndex].DataBoundItem;

                frmConsulta frmConsulta = new frmConsulta(this.paciente, this.consulta);
                frmConsulta.Show();
                this.Close();
               
            }
        }
    }
}
