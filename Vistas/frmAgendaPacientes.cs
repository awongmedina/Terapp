using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Terapp.UI.Controladores.Controladores;
using Terapp.UI.Controladores;
using Terapp.UI.Helpers;
using Terapp.UI.Vistas;

namespace Terapp.UI
{
    public partial class frmAgendaPacientes : Form
    {

        public PACIENTE paciente;
        public frmAgendaPacientes()
        {
            InitializeComponent();
            timer1.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Today.ToShortDateString();
            lblHora.Text = DateTime.Now.ToShortTimeString();
        }


        private void btnBuscar_Click(object sender, EventArgs e)
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
                paciente = unitOfWork.pacientes.ObtenerPorCondicion(p => p.Nombre.Contains(txtNombre.Text));
            }

            if (paciente == null)
            {
                msg = new frmMensaje("NO HAY PACIENTES REGISTRADOS CON ESE NOMBRE", true);
                msg.ShowDialog();
            }
            else
            {
                LlenarDatosPaciente(paciente);
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (paciente == null)
                {
                    new frmMensaje("NO HAY INFORMACIÓN DEL PACIENTE PARA GUARDAR", true).ShowDialog();
                    return;
                }

                using (var unitOfWork = new UnitOfWork(new TerapiModel()))
                {
                    var dbService = new TerapiService(unitOfWork);

                    // Buscar si el paciente ya existe en la base de datos
                    var pacienteExistente = dbService.ObtenerPacientePorNombre(paciente.Nombre);

                    bool operacionExitosa;

                    if (pacienteExistente != null)
                    {
                        // Si el paciente ya existe, actualizar su información
                        operacionExitosa = dbService.ActualizarPaciente(paciente);
                    }
                    else
                    {
                        // Si el paciente no existe, guardarlo como nuevo
                        operacionExitosa = dbService.GuardarPaciente(paciente);
                    }

                    // Mostrar mensaje según el tipo de operación realizada
                    frmMensaje msg = operacionExitosa
                        ? new frmMensaje(pacienteExistente != null ? "DATOS DEL PACIENTE ACTUALIZADOS!" : "PACIENTE GUARDADO CON ÉXITO!", true)
                        : new frmMensaje("ERROR AL GUARDAR EL PACIENTE, FAVOR DE REVISAR.", true);

                    msg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                new frmMensaje($"ERROR AL GUARDAR EL PACIENTE: {ex.Message}", true).ShowDialog();
                Console.WriteLine(ex.ToString());
            }
        }



        private void LlenarDatosPaciente(PACIENTE pac)
        {
            this.txtNombre.Text = pac.Nombre;
            this.txtEdad.Text = UIHelper.CalcularEdad(pac.FechaNacimiento).ToString();
            this.dtpFechaNacimiento.Text = pac.FechaNacimiento.ToString();
            this.txtOcupacion.Text = pac.Ocupacion;
            this.txtTelefono.Text = pac.Telefono;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.txtNombre.Text = "";
            this.txtEdad.Text = "";
            this.dtpFechaNacimiento.Text = DateTime.Today.ToString();
            this.txtOcupacion.Text = "";
            this.txtTelefono.Text = "";
        }

        private void frmAgendaPacientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (paciente != null)
                this.DialogResult = DialogResult.OK;
        }
    }
}
