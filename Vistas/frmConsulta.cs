using iText.Layout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Terapp.UI.Controladores;
using Terapp.UI.Controladores.Controladores;
using Terapp.UI.Helpers;
using Terapp.UI.Properties;
using Terapp.UI.Vistas;

namespace Terapp.UI
{
    public partial class frmConsulta : Form
    {
        // Propiedades generales
        private int? _escalaSeleccionada;
        private CONSULTA _consulta;
        private PACIENTE _paciente;
        private List<TIPO_TRATAMIENTO> _tratamientos_medicos = new List<TIPO_TRATAMIENTO>();
        private List<TIPO_TRATAMIENTO> _ejercicios = new List<TIPO_TRATAMIENTO>();
        private List<Point> puntosTratamientoSeleccionado = new List<Point>();
        private List<Point> puntosMotivoConsulta = new List<Point>();



        // Propiedades para los dibujos del tab MOTIVO DE CONSULTA
        Graphics graficoMotivoConsulta;
        Boolean motivoCursorMoving = false;
        Pen motivoCursorPen;
        int motivoCursorX = -1;
        int motivoCursorY = -1;
        private List<string> trazosMotivoConsulta = new List<string>();
        private string trazosActualesMotivo;
        


        // Propiedades para los dibujos del tab TRATAMIENTO
        Graphics graficoTratamiento;
        Boolean tratamientoCursorMoving = false;
        Pen tratamientoCursorPen;
        int tratamientoCursorX = -1;
        int tratamientoCursorY = -1;
        private List<string> trazosTratamiento = new List<string>();
        private string trazosActualesTratamiento;

        #region CONSTRUCTORES
        // Constructor por default
        public frmConsulta()
        {
            InitializeComponent();

            InicializarCanvas();

            LlenarCombos();            
        }

        //Constructor con parametros PACIENTE y CONSULTA
        public frmConsulta(PACIENTE p, CONSULTA c)
        {
            InitializeComponent();            

            this._consulta = c;
            this._paciente = p;

            InicializarCanvas();

            LlenarCombos();

            RefrescarDGVTratamientos();

           LlenarDatosPacienteConsulta(p, c);

           escala1_Click(new PictureBox() {Name = "escala" + c.EscalaDolor } ,new EventArgs());


            if (this._consulta.EstatusConsulta == "CERRADA")
                UIHelper.EstablecerEstadoControles(this, false);

            DibujarTrazosGuardados(c.ID);

            CargarAdjuntosConsulta(c.ID);

            RefrescarDGVTratamientos();

           
        }



        #endregion

        #region ASIGNACION DE ESCALA DE DOLOR

        private void escala1_Click(object sender, EventArgs e)
        {
            PictureBox escalaSeleccionada = (PictureBox)sender;
            
            escalaSeleccionada.BorderStyle = BorderStyle.Fixed3D;
            _escalaSeleccionada = escalaSeleccionada.Name.Length - 1;

            foreach (PictureBox control in flwEscaladolor.Controls)
            {
                if (control.Name != escalaSeleccionada.Name)
                    control.BorderStyle = BorderStyle.None;                    
            }
        }

        #endregion

        #region INICIALIZAR TODOS LOS CANVAS
        private void InicializarCanvas() 
        {
            //inicializa las propiedades del dibujo, MOTIVO CONSULTA
            graficoMotivoConsulta = canvasMotivoConsulta.CreateGraphics();
            motivoCursorPen = new Pen(Color.Black, 5);
            graficoMotivoConsulta.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            motivoCursorPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            motivoCursorPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
           

            //inicializa las propiedades del dibujo, TRATAMIENTO
            graficoTratamiento = canvasTratamiento.CreateGraphics();
            tratamientoCursorPen = new Pen(Color.Black, 5);
            graficoTratamiento.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            tratamientoCursorPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            tratamientoCursorPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        #endregion

        #region METODOS MOUSE DOWN

        // Detecta cuando se presiona el boton del mouse para dibujar en el canvas MOTIVO CONSULTA
        private void canvasMotivoConsulta_MouseDown(object sender, MouseEventArgs e)
        {
            motivoCursorMoving = true;
            motivoCursorX = e.X;
            motivoCursorY = e.Y;

            trazosActualesMotivo = "";
        }

        // Detecta cuando se presiona el boton del mouse para dibujar en el canvas TRATAMIENTO
        private void canvasTratamiento_MouseDown(object sender, MouseEventArgs e)
        {
            tratamientoCursorMoving = true;
            tratamientoCursorX = e.X;
            tratamientoCursorY = e.Y;

            trazosActualesTratamiento = "";
        }

        #endregion

        #region METODOS MOUSE UP

        // Detecta cuando se deja de presionar el boton del mouse para dejar de dibujar en el canvas MOTIVO CONSULTA
        private void canvasTratamiento_MouseUp(object sender, MouseEventArgs e)
        {
            tratamientoCursorMoving = false;
            tratamientoCursorX = -1;
            tratamientoCursorY = -1;

            trazosTratamiento.Add(trazosActualesTratamiento.TrimEnd(' ', ';'));

        }

        // Detecta cuando se deja de presionar el boton del mouse para dejar de dibujar en el canvas VALORACION

        
        // Detecta cuando se deja de presionar el boton del mouse para dejar de dibujar en el canvas TRATAMIENTO
        private void canvasMotivoConsulta_MouseUp(object sender, MouseEventArgs e)
        {
            motivoCursorMoving = false;
            motivoCursorX = -1;
            motivoCursorY = -1;

            trazosMotivoConsulta.Add(trazosActualesMotivo.TrimEnd(' ', ';'));
        }


        #endregion

        #region METODOS MOUSE MOVE

        //Detecta el movimiento del mouse dentro del canvas MOTIVO CONSULTA
        //y hace el trazo solo cuando esta presionado el click izquierdo
        private void canvasMotivoConsulta_MouseMove(object sender, MouseEventArgs e)
        {            
            
            if (motivoCursorX != -1 && motivoCursorY != -1 && motivoCursorMoving == true)
            {
                Control panel = (Control)sender;
                string nombre = panel.Name;

                graficoMotivoConsulta.DrawLine(motivoCursorPen, new Point(motivoCursorX, motivoCursorY), e.Location);

                motivoCursorX = e.X;
                motivoCursorY = e.Y;

                trazosActualesMotivo += $"({motivoCursorX},{motivoCursorY});";

            }            
        }

        //Detecta el movimiento del mouse dentro del canvas TRATAMIENTO
        //y hace el trazo solo cuando esta presionado el click izquierdo
        private void canvasTratamiento_MouseMove(object sender, MouseEventArgs e)
        {
            if (tratamientoCursorX != -1 && tratamientoCursorY != -1 && tratamientoCursorMoving == true)
            {
                Control panel = (Control)sender;
                string nombre = panel.Name;

                graficoTratamiento.DrawLine(tratamientoCursorPen, new Point(tratamientoCursorX, tratamientoCursorY), e.Location);

                tratamientoCursorX = e.X;
                tratamientoCursorY = e.Y;

                trazosActualesTratamiento += $"({tratamientoCursorX},{tratamientoCursorY});";
            }
        }


        #endregion

        #region METODOS DE LOS CONTROLES

        // Guarda todos los cambios hechos en la consulta
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar datos del paciente antes de continuar
                if (string.IsNullOrWhiteSpace(txtNombrePaciente.Text) || UIHelper.VerificarDatosPaciente(tabControl.TabPages["tabDatosPaciente"]))
                {
                    new frmMensaje("FALTAN DATOS DEL PACIENTE, FAVOR DE VERIFICAR", true).ShowDialog();
                    return;
                }

                using (var unitOfWork = new UnitOfWork(new TerapiModel()))
                {
                    var dbService = new TerapiService(unitOfWork);

                    if (tabControl.SelectedTab.Name == "tabDatosPaciente")
                    {
                        if(_paciente == null) 
                        {
                            LlenarPaciente();

                            dbService.GuardarPaciente(_paciente);
                        }
                            
                    }
                    else if (tabControl.SelectedTab.Name == "tabMotivoConsulta")
                    {
                        if (!UIHelper.VerificarDatosConsulta(tabControl.TabPages["tabMotivoConsulta"], _escalaSeleccionada))
                        {
                            new frmMensaje("FALTA INFORMACIÓN DE LA CONSULTA, FAVOR DE VERIFICAR", true).ShowDialog();
                            return;
                        }

                        if (_paciente == null)
                        {
                            LlenarPaciente();

                            dbService.GuardarPaciente(_paciente);
                        }

                        if (_consulta == null)
                        {
                            LlenarConsulta();
                        }
                        else 
                        {
                            ActualizarConsulta(_consulta);
                        }

                        if (_consulta.ID != 0)
                        {
                            dbService.ActualizarConsulta(_consulta); // Solo actualizar si ya tiene un ID
                        }
                        else
                        {
                            dbService.GuardarConsulta(_paciente, _consulta); // Solo guardar si es nueva
                        }
                        dbService.GuardarPunto(_consulta.ID, PUNTO.Tipo_Puntos_Enum.MOTIVO_CONSULTA.ToString(), trazosMotivoConsulta, null);
                    }   
                }


                new frmMensaje("INFORMACIÓN GUARDADA CON ÉXITO!", true).ShowDialog();
            }
            catch (Exception ex)
            {
                new frmMensaje($"ERROR AL GUARDAR: {ex.Message}", true).ShowDialog();
            }
        }




        // Guarda solo los tratamientos que se estan aplicando al paciente en la consulta 
        private void btnGuardarTratamiento_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que hay una consulta válida
                if (_consulta == null)
                {
                    new frmMensaje("NO SE HA GUARDADO LA INFORMACION DE LA CONSULTA", true).ShowDialog();
                    return;
                }

                // Validar el tiempo del tratamiento
                int tiempoTratamiento;
                if (!int.TryParse(txtTiempoTratamiento.Text, out tiempoTratamiento))
                {
                    new frmMensaje("EL TIEMPO DEL TRATAMIENTO DEBE SER UN NÚMERO VÁLIDO", true).ShowDialog();
                    return;
                }

                using (var unitOfWork = new UnitOfWork(new TerapiModel()))
                {
                    var dbService = new TerapiService(unitOfWork);

                    TRATAMIENTO trat = new TRATAMIENTO
                    {
                        ConsultaID = _consulta.ID,
                        Tiempo = tiempoTratamiento,
                        Comentarios = txtComentariosTratamiento.Text,
                        TipoTratamiento = cboTratamientos.Text,
                        NombreTratamiento = dbService.ObtenerTipoTratamiento(cboTratamientos.Text).NombreTratamiento,
                    };

                    bool confirmacion = dbService.GuardarTratamiento(trat);
                    bool confirmacion2 = dbService.GuardarPunto(_consulta.ID, PUNTO.Tipo_Puntos_Enum.TRATAMIENTO.ToString(), trazosTratamiento, trat.ID);

                    string mensaje = (confirmacion && confirmacion2)
                        ? "TRATAMIENTO GUARDADO CON ÉXITO"
                        : "HUBO UN PROBLEMA AL GUARDAR LA INFORMACIÓN, FAVOR DE REVISAR";

                    new frmMensaje(mensaje, true).ShowDialog();
                    trazosActualesTratamiento = "";
                }

                RefrescarDGVTratamientos();
                canvasTratamiento.Invalidate();
            }
            catch (Exception ex)
            {
                // Manejo de errores inesperados
                new frmMensaje($"ERROR AL GUARDAR EL TRATAMIENTO: {ex.Message}", true).ShowDialog();
                
            }
        }


        // Detecta el caracter ingresado en el campo de TIEMPO TRATAMIENTO y solo permite numeros.
        private void txtTiempoTratamiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Hace la busqueda del paciente
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmMensaje msg = null;

            if (string.IsNullOrWhiteSpace(txtNombrePaciente.Text))
            {
                msg = new frmMensaje("NO SE HA INGRESADO UN NOMBRE PARA BUSQUEDA", true);
            }
            else
            {
                using (var unitOfWork = new UnitOfWork(new TerapiModel()))
                {
                    var dbService = new TerapiService(unitOfWork);
                    _paciente = dbService.ObtenerPacientePorNombre(txtNombrePaciente.Text);
                }

                if (_paciente == null)
                {
                    msg = new frmMensaje("NO HAY PACIENTES REGISTRADOS CON ESE NOMBRE", true);
                }
                else
                {                    
                    LlenarDatosPaciente(_paciente);
                }
            }

            msg?.ShowDialog();
        }

        // Muestra la pantalla AGENDAR CONSULTA
        private void btnAgendarConsulta_Click(object sender, EventArgs e)
        {
            
            if (_paciente == null)
            {
                new frmMensaje("DEBES GUARDAR LOS DATOS DEL PACIENTE ANTES DE CONTINUAR", true).ShowDialog();
                return;
            }
            else 
            {
                frmAgregarCita agregarCita = new frmAgregarCita(_paciente);
                agregarCita.ShowDialog();
            }
        }

        // Genera el recibo en PDF de la consulta
        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            if (_consulta == null) 
            {
                new frmMensaje("NO HAY INFORMACION DE CONSULTA PARA GENERAR UN RECIBO, FAVOR DE REVISAR", true).ShowDialog();
                return;
            }

            frmCostoCita costo = new frmCostoCita(_paciente, _consulta);
            costo.ShowDialog();
        }

        // Detecta cuando se cambia de pestaña y re-dibuja los trazos ya hechos
        // unicamente en la pestaña seleccionada
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        { 
                List<Point> puntos;
                puntos = UIHelper.ConvertirListaStringAPuntos(trazosMotivoConsulta);
                UIHelper.DibujarTrazosEnPanel(canvasMotivoConsulta, puntos);
        }

        private void btnCerrarConsulta_Click(object sender, EventArgs e)
        {          

            if (_consulta == null) 
            {
                new frmMensaje("DEBES GUARDAR LA INFORMACION DE LA CONSULTA ANTES DE PODER CERRARLA", true).ShowDialog();
                return;
            }

            frmCerrarConsulta cerrar = new frmCerrarConsulta(_consulta.ID);

            cerrar.ShowDialog();

            this.Invoke(new Action(() => UIHelper.EstablecerEstadoControles(this.tabControl, false)));
        }

        private void btnAdjuntar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_paciente == null && _consulta == null)
                {
                    frmMensaje confirmMsg = new frmMensaje("LA INFORMACION DEL PACIENTE Y LA CONSULTA NO HAN SIDO GUARDADOS, DESEAS GUARDARLA AHORA? SI NO SE GUARDA, PUEDE OCASIONAR ERRORES MAS ADELANTE", false);
                    confirmMsg.ShowDialog();

                    if (confirmMsg.Confirmado)
                    {                       

                        using (var unitOfWork = new UnitOfWork(new TerapiModel()))
                        {
                            var dbService = new TerapiService(unitOfWork);

                            this.LlenarPaciente();

                            dbService.GuardarPaciente(_paciente);

                            this.LlenarConsulta();

                            bool confirmacion = dbService.GuardarConsulta(_paciente, _consulta);

                            if (!confirmacion)                               
                            {
                                new frmMensaje("ERROR AL GUARDAR LOS DATOS. FAVOR DE REVISAR E INTENTAR NUEVAMENTE.", true).ShowDialog();
                                return;
                            }

                            new frmMensaje("INFORMACION GUARDADA CON EXITO!", true).ShowDialog();
                        }  
                    }
                    else
                    {
                        new frmMensaje("DEBES GUARDAR LOS DATOS DEL PACIENTE Y LA CONSULTA ANTES DE CONTINUAR", true).ShowDialog();
                        return;
                    }
                }

                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Title = "Seleccionar Archivo";
                    ofd.Filter = "Todos los archivos (*.*)|*.*";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        string archivoOrigen = ofd.FileName;  // Ruta original del archivo
                        string carpetaDestino = @"C:\Terappi\Adjuntos"; // Ruta donde se copiará

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
                                var adj = new ADJUNTO
                                {
                                    ConsultaID = _consulta.ID,
                                    NombreArchivo = nombreArchivo,
                                    ExtensionArchivo = extensionArchivo,
                                    PathArchivoAdjunto = archivoDestino,
                                };

                                dbService.GuardarAdjunto(adj);

                                new frmMensaje("ARCHIVO AGREGADO CON EXITO!", true).ShowDialog();
                                txtAdjunto.Text = archivoDestino;

                               
                            }
                            
                        }
                        catch (Exception ex)
                        {
                            new frmMensaje($"HUBO UN PROBLEMA AL ADJUNTAR EL ARCHIVO. ERROR: {ex.Message}", true).ShowDialog();
                           
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new frmMensaje($"ERROR GENERAL: {ex.Message}", true).ShowDialog();
                _paciente = null;
                _consulta = null;

            }
        }


        private void ucAdjunto_MouseLeave(object sender, EventArgs e)
        {
            ucAdjunto obj = (ucAdjunto)sender;
            obj.BackColor = SystemColors.Control;
        }

        private void ucAdjunto_MouseEnter(object sender, EventArgs e)
        {
            ucAdjunto obj = (ucAdjunto)sender;
            obj.BackColor = Color.FromArgb(111, 166, 234);
        }

        private void ucAdjunto_Click(object sender, EventArgs e)
        {
            ucAdjunto adj = (ucAdjunto)sender;
            if (File.Exists(adj.RutaArchivo)) // Verifica si el archivo existe
            {
                Process.Start(new ProcessStartInfo(adj.RutaArchivo) { UseShellExecute = true });
            }
            else
            {
                MessageBox.Show("El archivo no existe");
            }
        }

        #endregion

        #region METODOS EXTRA


        private void LlenarPaciente() 
        {
            _paciente = new PACIENTE();
            _paciente.Nombre = txtNombrePaciente.Text;
            _paciente.FechaNacimiento = dtpFechaNacimiento.Value;
            _paciente.Ocupacion = txtOcupacion.Text;
            _paciente.Telefono = txtTelefono.Text;

        }

        private void LlenarConsulta() 
        {
            _consulta = new CONSULTA();
            _consulta.EstatusConsulta = "ABIERTA";
            _consulta.FechaConsulta = DateTime.Now;
            _consulta.Valoracion = txtValoracion.Text;
            _consulta.MotivoConsulta = txtMotivoConsulta.Text;
            _consulta.PacienteID = _paciente.ID;
            _consulta.EscalaDolor = _escalaSeleccionada != 0 ? _escalaSeleccionada : 1;
        }


        private void LlenarDatosPacienteConsulta(PACIENTE pac, CONSULTA cons)
        {
            this.txtNombrePaciente.Text = pac.Nombre;
            this.lblExpediente.Text = pac.ID.ToString();
            this.txtEdad.Text = UIHelper.CalcularEdad(pac.FechaNacimiento).ToString();
            this.dtpFechaNacimiento.Text = pac.FechaNacimiento.ToString();
            this.txtOcupacion.Text = pac.Ocupacion;
            this.txtTelefono.Text = pac.Telefono;
            this.txtMotivoConsulta.Text = cons.MotivoConsulta;
            this.txtValoracion.Text = cons.Valoracion;
        }

        private void LlenarDatosPaciente(PACIENTE pac)
        {
            this.txtNombrePaciente.Text = pac.Nombre;
            this.lblExpediente.Text = pac.ID.ToString();
            this.txtEdad.Text = UIHelper.CalcularEdad(pac.FechaNacimiento).ToString();
            this.dtpFechaNacimiento.Text = pac.FechaNacimiento.ToString();
            this.txtOcupacion.Text = pac.Ocupacion;
            this.txtTelefono.Text = pac.Telefono;
        }

        // Llena los menus desplegables con los datos de las tablas TIPO_PADECIMIENTO y TRATAMIENTO
        private void LlenarCombos()
        {      
            using (var unitOfWork = new UnitOfWork(new TerapiModel())) 
            {
                var dbService = new TerapiService(unitOfWork);
                _tratamientos_medicos = dbService.ObtenerTiposTratamiento();
            }

            cboTratamientos.DataSource = _tratamientos_medicos;
            cboTratamientos.ValueMember = "ID";
            cboTratamientos.DisplayMember = "TipoTratamiento";
        }

        private void DibujarTrazosGuardados(int consultaID) 
        {
            using (var unitOfWork = new UnitOfWork(new TerapiModel()))
            {
                var dbService = new TerapiService(unitOfWork);
                trazosMotivoConsulta = dbService.ObtenerTrazosMotivoConsulta(consultaID);
            }
            foreach (var punto in trazosMotivoConsulta) 
            {
                UIHelper.CargarTrazosEnPanel(canvasMotivoConsulta, punto);
            }
            
        }

        private void CargarAdjuntosConsulta(int consultaID)
        {
            using (var unitOfWork = new UnitOfWork(new TerapiModel()))
            {
                var dbService = new TerapiService(unitOfWork);

                var adjuntos = dbService.ObtenerAdjuntosPorConsulta(consultaID);

                if (adjuntos != null && adjuntos.Count > 0)
                {
                    flwAdjuntos.Controls.Clear(); // Limpiar la pestaña antes de agregar adjuntos

                    foreach (var adjunto in adjuntos)
                    {
                        var controlAdjunto = new ucAdjunto(); // Instancia de tu UserControl
                        controlAdjunto.NombreArchivo = adjunto.NombreArchivo;
                        controlAdjunto.RutaArchivo = adjunto.PathArchivoAdjunto;
                        controlAdjunto.ExtensionArchivo = adjunto.ExtensionArchivo;

                        // Suscribir al evento de click para abrir el archivo
                        controlAdjunto.Click += (sender, e) => UIHelper.AbrirArchivo(adjunto.PathArchivoAdjunto);

                        flwAdjuntos.Controls.Add(controlAdjunto);
                    }
                }
            }
        }


        private void RefrescarDGVTratamientos()
        {
            Task.Run(() =>
            {
                using (var unitOfWork = new UnitOfWork(new TerapiModel()))
                {
                    var dbService = new TerapiService(unitOfWork);
                    int consultaId = _consulta.ID;
                    var tratamientos = dbService.ObtenerTratamientosPorConsulta(consultaId)
                        .Select(t => new { t.ID, t.TipoTratamiento, t.Tiempo, t.Comentarios, t.NombreTratamiento })
                        .ToList();

                    if (this.IsHandleCreated) 
                    {
                        Invoke(new Action(() =>
                        {
                            dgvTratamientos.DataSource = tratamientos;
                            dgvTratamientos.Columns["ID"].Visible = false;
                            dgvTratamientos.Columns["NombreTratamiento"].Visible = false;
                        }));
                    }
                }
            });
        }


        private void dgvTratamientos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTratamientos.SelectedRows.Count > 0)
            {
                var filaSeleccionada = dgvTratamientos.SelectedRows[0];
                int consultaId = _consulta.ID;
                string tipoTratamiento = filaSeleccionada.Cells["TipoTratamiento"].Value.ToString();
                int tratamientoId = (int)filaSeleccionada.Cells["ID"].Value;
                string nombreTratamiento = filaSeleccionada.Cells["NombreTratamiento"].Value.ToString();
                string pathImagen = "";

                canvasTratamiento.Refresh();
                canvasTratamiento.BackgroundImage.Dispose(); // Libera la imagen anterior si existe

                if (nombreTratamiento == "EJERCICIO")
                {
                    using (var unitOfWork = new UnitOfWork(new TerapiModel()))
                    {
                        var dbService = new TerapiService(unitOfWork);

                        pathImagen = dbService.ObtenerTipoTratamiento(tipoTratamiento).PathImagen;
                    }

                    canvasTratamiento.BackgroundImage = Image.FromFile(pathImagen);
                    
                }
                else
                {

                    canvasTratamiento.BackgroundImage = Resources.cuerpo_humano;
                    CargarTrazosPorTratamiento(consultaId, tratamientoId);
                }

                canvasTratamiento.Invalidate();



            }
    
        }

        private void CargarTrazosPorTratamiento(int consultaId, int tratamientoId)
        {
            using (var unitOfWork = new UnitOfWork(new TerapiModel()))
            {
                var dbService = new TerapiService(unitOfWork);
                var puntos = dbService.ObtenerTrazosPorTratamiento(consultaId, PUNTO.Tipo_Puntos_Enum.TRATAMIENTO.ToString(),tratamientoId);
                UIHelper.DibujarTrazosEnPanel(canvasTratamiento, puntos);
            }
        }

        private void ActualizarConsulta(CONSULTA consulta)
        {
            _consulta.EscalaDolor = _escalaSeleccionada.Value;
            _consulta.Valoracion = txtValoracion.Text;
        }


        #endregion
    }

}

