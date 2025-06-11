using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Windows.Forms;
using Terapp.UI.Controladores.Controladores;
using Terapp.UI.Controladores;
using Terapp.UI.Vistas;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Terapp.UI
{
    public partial class frmAgregarCita : Form
    {
        public PACIENTE _paciente;
        public CONSULTA _consulta;
        DateTime _fechaConsulta;
        public frmAgregarCita()
        {
            InitializeComponent();
        }

        public frmAgregarCita(PACIENTE paciente)
        {
            InitializeComponent();

            this._paciente = paciente;

            txtPaciente.Text = _paciente.Nombre;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (var unitOfWork = new UnitOfWork(new TerapiModel()))
            {
                var dbService = new TerapiService(unitOfWork);
                frmMensaje msg;

                if (txtPaciente.Text == "") 
                {
                    new frmMensaje("NO HAY PACIENTE SELECCIONADO", false).ShowDialog();
                    return;
                }


                if (_paciente == null) // primera busqueda de paciente
                {
                    _paciente = dbService.ObtenerPacientePorNombre(txtPaciente.Text);

                    if (_paciente == null) //segunda busqueda de paciente
                    {
                        using (msg = new frmMensaje("EL PACIENTE NO EXISTE EN LA AGENDA, DESEAS AGREGARLO?", false))
                        {
                            if (msg.ShowDialog() == DialogResult.OK)
                            {
                                using (frmAgendaPacientes agenda = new frmAgendaPacientes())
                                {
                                    if (agenda.ShowDialog() == DialogResult.OK)
                                    {
                                        _paciente = agenda.paciente;
                                    }
                                }
                            }
                            else 
                            {
                                new frmMensaje("NO HAY PACIENTE SELECCIONADO PARA AGENDAR, FAVOR DE HACER UNA NUEVA BUSQUEDA O AGREGAR A LA AGENDA DE PACIENTES", true);
                                return;
                            }
                        }
                    }
                    else // se ecnotnro al paciente en la segunda busqueda
                    {
                        int config = dbService.ObtenerPacientesPorHora().CantidadPacientes;

                        var consultas = dbService.ObtenerConsultasPorDia(_fechaConsulta).Count();

                        if (consultas <= config)
                        {
                            _fechaConsulta = FormatearHora();
                            _consulta = new CONSULTA
                            {
                                FechaConsulta = _fechaConsulta,
                                EstatusConsulta = "ABIERTA"
                            };

                            bool guardadoExitoso = dbService.GuardarConsulta(_paciente, _consulta);

                            msg = guardadoExitoso
                                ? new frmMensaje("CONSULTA GUARDADA CON EXITO!", true)
                                : new frmMensaje("ERROR AL GUARDAR LA CONSULTA, FAVOR DE REVISAR.", true);

                            msg.ShowDialog();
                            _paciente = null;
                        }
                        else
                        {
                            new frmMensaje("EL NUMERO MAXIMO DE PACIENTES PERMITIDOS EN ESTA HORA YA HA SIDO ALCANZADO. POR FAVOR, SELECCIONE OTRO HORARIO DISPONIBLE.", true).ShowDialog();
                        }
                    }
                }
                else // se ecnotnro al paciente en la segunda busqueda
                {
                    int config = dbService.ObtenerPacientesPorHora().CantidadPacientes;

                    var consultas = dbService.ObtenerConsultasPorDia(_fechaConsulta).Count();

                    if (consultas < config)
                    {
                        _fechaConsulta = FormatearHora();
                        _consulta = new CONSULTA
                        {
                            FechaConsulta = _fechaConsulta,
                            EstatusConsulta = "ABIERTA"
                        };

                        bool guardadoExitoso = dbService.GuardarConsulta(_paciente, _consulta);

                        msg = guardadoExitoso
                            ? new frmMensaje("CONSULTA GUARDADA CON EXITO!", true)
                            : new frmMensaje("ERROR AL GUARDAR LA CONSULTA, FAVOR DE REVISAR.", true);

                        msg.ShowDialog();
                        _paciente = null;
                    }
                    else
                    {
                        new frmMensaje("$EL NUMERO MAXIMO DE PACIENTES PERMITIDOS EN ESTA HORA YA HA SIDO ALCANZADO. POR FAVOR, SELECCIONE OTRO HORARIO DISPONIBLE.", true).ShowDialog();
                    }
                }
            }
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmMensaje msg;

            if (string.IsNullOrWhiteSpace(txtPaciente.Text))
            {
                msg = new frmMensaje("FAVOR DE INGRESAR UN NOMBRE PARA LA BÚSQUEDA", true);
            }
            else
            {
                using (var unitOfWork = new UnitOfWork(new TerapiModel()))
                {
                    var dbService = new TerapiService(unitOfWork);
                    _paciente = unitOfWork.pacientes.ObtenerPorCondicion(p => p.Nombre.Contains(txtPaciente.Text));
                }

                msg = (_paciente != null)
                    ? new frmMensaje("PACIENTE ENCONTRADO!", true)
                    : new frmMensaje("NO SE HA ENCONTRADO UN PACIENTE CON ESE NOMBRE", true);
            }

            msg.ShowDialog();
        }


    }
}
