using System;
using System.Data.Entity.Hierarchy;
using System.Data.Entity.Migrations.Sql;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Windows.Forms;
using Terapp.UI.Controladores;
using Terapp.UI.Controladores.Controladores;
using Terapp.UI.Helpers;
using Terapp.UI.Properties;
using Terapp.UI.Vistas;

namespace Terapp.UI
{
    public partial class frmConfiguracion : Form
    {
        private decimal estatusPadecimiento;
        private decimal estatusTratamiento;
        public frmConfiguracion()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToShortDateString();
            lblHora.Text = DateTime.Now.ToShortTimeString();
        }

        private void btnGuardarAfeccion_Click(object sender, EventArgs e)
        {
            using (var unitOfWork = new UnitOfWork(new TerapiModel()))
            {
                var dbService = new TerapiService(unitOfWork);

                var pad = dbService.ObtenerPadecimiento(txtNombreAfeccion.Text);

                if (pad == null)
                {
                    if (String.IsNullOrEmpty(txtNombreAfeccion.Text))
                    {
                        new frmMensaje("NO HAY INFORMACION PARA GUARDAR, FAVOR DE REVISAR", true).ShowDialog();
                        return;
                    }

                    pad = new PADECIMIENTO
                    {
                        Padecimiento = txtNombreAfeccion.Text,
                        Descripcion = txtDescripcionAfeccion.Text.Trim(),
                        Activo = estatusPadecimiento
                    };

                    string mensajeNuevo = dbService.GuardarPadecimiento(pad)
                                      ? "PADECIMIENTO CREADO CON ÉXITO"
                                      : "HUBO UN PROBLEMA AL GUARDAR LA INFORMACIÓN, FAVOR DE REVISAR";

                    new frmMensaje(mensajeNuevo, true).ShowDialog();
                    return;
                }

                using (var msg = new frmMensaje("EL PADECIMIENTO YA EXISTE EN LA BASE DE DATOS, ¿DESEAS ACTUALIZARLO?", false))
                {
                    

                    msg.ShowDialog();

                    if (msg.DialogResult != DialogResult.OK) return;

                    pad.Activo = estatusPadecimiento;
                    pad.Padecimiento = txtNombreAfeccion.Text;
                    pad.Descripcion = txtDescripcionAfeccion.Text.Trim();

                    string mensaje = dbService.ActualizarPadecimiento(pad)
                                     ? "PADECIMIENTO GUARDADO CON ÉXITO"
                                     : "HUBO UN PROBLEMA AL GUARDAR LA INFORMACIÓN, FAVOR DE REVISAR";

                    new frmMensaje(mensaje, true).ShowDialog();
                }
            }
        }

        private void chkEstatusAfeccion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEstatusAfeccion.Checked)
            {
                estatusPadecimiento = 1;
            }
            else 
            {
                estatusPadecimiento = 0;    
            }
        }

        private void btnGuardarTipoTratamiento_Click(object sender, EventArgs e)
        {
            using (var unitOfWork = new UnitOfWork(new TerapiModel()))
            {
                var dbService = new TerapiService(unitOfWork);

                var trat = dbService.ObtenerTipoTratamiento(txtNombreTratamiento.Text);

                if (trat == null)
                {

                    if (String.IsNullOrEmpty(txtNombreTratamiento.Text)) 
                    {
                        new frmMensaje("NO HAY INFORMACION PARA GUARDAR, FAVOR DE REVISAR", true).ShowDialog();
                        return;
                    }
                        
                    trat = new TIPO_TRATAMIENTO
                    {
                        TipoTratamiento = txtNombreTratamiento.Text,
                        Descripcion = txtDescripcionTratamiento.Text.Trim(),
                        NombreTratamiento = cboTipo.SelectedItem.ToString(),
                        PathImagen = txtImagenEjercicio.Text,
                        Activo = estatusTratamiento
                    };

                    string mensajeNuevo = dbService.GuardarTipoTratamiento(trat)
                                      ? "TRATAMIENTO CREADO CON ÉXITO"
                                      : "HUBO UN PROBLEMA AL GUARDAR LA INFORMACIÓN, FAVOR DE REVISAR";

                    new frmMensaje(mensajeNuevo, true).ShowDialog();
                    return;
                }

                using (var msg = new frmMensaje("EL TRATAMIENTO YA EXISTE EN LA BASE DE DATOS, ¿DESEAS ACTUALIZARLO?", false))
                {
                    msg.ShowDialog();

                    if (msg.DialogResult != DialogResult.OK) return;

                    trat.Activo = estatusTratamiento;
                    trat.TipoTratamiento = txtNombreTratamiento.Text;
                    trat.Descripcion = txtDescripcionTratamiento.Text.Trim();

                    string mensaje = dbService.ActualizarTipoTratamiento(trat)
                                     ? "TRATAMIENTO ACTUALIZADO CON ÉXITO"
                                     : "HUBO UN PROBLEMA AL GUARDAR LA INFORMACIÓN, FAVOR DE REVISAR";

                    new frmMensaje(mensaje, true).ShowDialog();
                }
            }
        }

        private void chkEstatusTratamiento_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEstatusTratamiento.Checked)
            {
                estatusTratamiento = 1;
            }
            else
            {
                estatusTratamiento = 0;
            }
        }

        private void btnGuardarCalendario_Click(object sender, EventArgs e)
        {
            using (var unitOfWork = new UnitOfWork(new TerapiModel()))
            {
                var dbService = new TerapiService(unitOfWork);

                var config = new CONFIGURACION
                {
                    CantidadPacientes = Convert.ToInt16(txtPacientesSimultaneos.Text)
                };

                dbService.GuardarConfiguracion(config);

                new frmMensaje("CONFIGURACION GUARDADA CON EXITO!", true).ShowDialog();

            }
        }

        private void txtPacientesSimultaneos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

            }
        }

        private void btnBuscarPadecimiento_Click(object sender, EventArgs e)
        {
            using (var unitOfWork = new UnitOfWork(new TerapiModel()))
            {
                var dbService = new TerapiService(unitOfWork);

                var pad = dbService.ObtenerPadecimiento(txtNombreAfeccion.Text);

                if (pad == null)
                {
                    using (var msg = new frmMensaje("EL PADECIMIENTO BUSCADO NO EXISTE, DESEAS CREARLO?", false)) 
                    {
                        msg.ShowDialog();

                        if (msg.DialogResult != DialogResult.OK) return;

                        pad = new PADECIMIENTO
                        {
                            Padecimiento = txtNombreAfeccion.Text,
                            Descripcion = txtDescripcionAfeccion.Text.Trim(),
                            Activo = estatusPadecimiento,
                        };

                        string mensaje = dbService.GuardarPadecimiento(pad)
                                     ? "PADECIMIENTO ACTUALIZADO CON ÉXITO"
                                     : "HUBO UN PROBLEMA AL GUARDAR LA INFORMACIÓN, FAVOR DE REVISAR";

                        new frmMensaje(mensaje, true).ShowDialog();
                        return;
                    } 
                
                }

                txtDescripcionAfeccion.Text = pad.Descripcion;
                txtNombreAfeccion.Text = pad.Padecimiento;
                chkEstatusAfeccion.Checked = (pad.Activo == 1);

            }
        }

        private void btnBuscarTratamiento_Click(object sender, EventArgs e)
        {
            using (var unitOfWork = new UnitOfWork(new TerapiModel()))
            {
                var dbService = new TerapiService(unitOfWork);

                var trat = dbService.ObtenerTipoTratamiento(txtNombreTratamiento.Text, cboTipo.SelectedItem.ToString());

                if (trat == null)
                {
                    using (var msg = new frmMensaje("EL TRATAMIENTO BUSCADO NO EXISTE, DESEAS CREARLO?", false))
                    {
                        msg.ShowDialog();

                        if (msg.DialogResult != DialogResult.OK) return;

                        trat = new TIPO_TRATAMIENTO
                        {
                            TipoTratamiento = txtNombreTratamiento.Text,
                            Descripcion = txtDescripcionTratamiento.Text.Trim(),
                            NombreTratamiento = cboTipo.SelectedItem.ToString(),
                            PathImagen = String.IsNullOrEmpty(txtImagenEjercicio.Text)?"": txtImagenEjercicio.Text,
                            Activo = estatusTratamiento,
                        };

                        string mensaje = dbService.GuardarTipoTratamiento(trat)
                                     ? "TRATAMIENTO ACTUALIZADO CON ÉXITO"
                                     : "HUBO UN PROBLEMA AL GUARDAR LA INFORMACIÓN, FAVOR DE REVISAR";

                        new frmMensaje(mensaje, true).ShowDialog();
                        return;
                    }

                }

                txtNombreTratamiento.Text = trat.TipoTratamiento;
                txtDescripcionTratamiento.Text = trat.Descripcion;
                chkEstatusTratamiento.Checked = (trat.Activo == 1);
                txtImagenEjercicio.Text = trat.PathImagen;
                canvasEjercicio.BackgroundImage = String.IsNullOrEmpty(trat.PathImagen) ? Resources.SIN_IMAGEN : Image.FromFile(trat.PathImagen);


            }
        }

        private void btnAgergarImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Seleccionar Archivo";
                ofd.Filter = "Todos los archivos (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string archivoOrigen = ofd.FileName;  // Ruta original del archivo
                    string carpetaDestino = @"C:\Terappi\Ejercicios"; // Ruta donde se copiará

                    // Crear la carpeta si no existe
                    if (!Directory.Exists(carpetaDestino))
                        Directory.CreateDirectory(carpetaDestino);

                    // Obtener solo el nombre del archivo
                    string nombreArchivo = Path.GetFileName(archivoOrigen);
                    string extensionArchivo = Path.GetExtension(archivoOrigen);
                    string archivoDestino = Path.Combine(carpetaDestino, nombreArchivo);

                    // Verificar si el archivo ya existe
                    if (File.Exists(archivoDestino))
                    {
                        new frmMensaje("EL ARCHIVO YA EXISTE EN LA CARPETA DE ADJUNTOS.", true).ShowDialog();
                        return;
                    }

                    // Intentar copiar el archivo con manejo de errores
                    try
                    {
                        using (var unitOfWork = new UnitOfWork(new TerapiModel()))
                        {
                            var dbService = new TerapiService(unitOfWork);

                            File.Copy(archivoOrigen, archivoDestino);                           

                            new frmMensaje("ARCHIVO AGREGADO CON EXITO!", true).ShowDialog();
                            txtImagenEjercicio.Text = archivoDestino;
                            canvasEjercicio.BackgroundImage = Image.FromFile(archivoDestino);
                        }

                    }
                    catch (Exception ex)
                    {
                        new frmMensaje($"HUBO UN PROBLEMA AL ADJUNTAR EL ARCHIVO. ERROR: {ex.Message}", true).ShowDialog();

                    }
                }
            }
        }
    }
}
