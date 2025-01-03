using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Terapp.UI
{
    public partial class frmExpClinico : Form
    {
        private CONSULTA consulta = new CONSULTA();
        private PACIENTE paciente = new PACIENTE();
        private List<CONSULTA> consultas;
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

            if (txtNombre.Text == "" || txtNombre.Text == null) 
            {
                lblError.Text = "NO HAS INGRESADO UN NOMBRE";
                return;
            }
                

            using (TerapiModel db = new TerapiModel()) 
            {
                PACIENTE _paciente = db.PACIENTES.FirstOrDefault(x => x.Nombre == txtNombre.Text);

                if (_paciente == null)
                {
                    lblError.Text = "EL PACIENTE NO ESTA REGISTRADO";
                }
                else 
                {
                    lblError.Text = "";

                    IQueryable<CONSULTA> _consultas = db.CONSULTAS.Where(x => x.PacienteID == _paciente.ID);
                    consultas = _consultas.ToList();

                    LlenarDGVConsultas();
                }

            }


        }

        private void LlenarDGVConsultas()
        {
            dgvConsultas.DataSource = null;
            dgvConsultas.DataSource = consultas;

            dgvConsultas.Columns["ID"].Visible = false;
            dgvConsultas.Columns["PacienteID"].Visible = false;


        }

        private void dgvConsultas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                paciente = new PACIENTE();

                int rowIndex = e.RowIndex;
                this.consulta = (CONSULTA)dgvConsultas.Rows[rowIndex].DataBoundItem;

                using (TerapiModel db = new TerapiModel())
                {
                    
                    paciente = db.PACIENTES.FirstOrDefault(x => x.ID == this.consulta.PacienteID);

                }

                frmConsulta frmConsulta = new frmConsulta(this.paciente, this.consulta);
                frmConsulta.ShowDialog();
                this.Close();
               
            }
        }
    }
}
