using iText.Layout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Terapp.UI.Properties;

namespace Terapp.UI
{
    public partial class frmConsulta : Form
    {
        // Propiedades generales
        private int _escalaSeleccionada;
        private CONSULTA _consulta;
        private PACIENTE _paciente;
        private List<TIPO_TRATAMIENTO> _tipo_tratamientos = new List<TIPO_TRATAMIENTO>();
        private List<TRATAMIENTO> _tratamientos = new List<TRATAMIENTO>();
        private List<TRATAMIENTOS_AGREGADOS> _tratamientos_agregados = new List<TRATAMIENTOS_AGREGADOS>();
        private List<Point> puntosTratamientoSeleccionado;
        int timerError = 0;
        string _nombreArchivo;
        string _rutaArchivo;
        string _extensionArchivo;

        // Propiedades para los dibujos del tab MOTIVO DE CONSULTA
        Graphics graficoMotivoConsulta;
        Boolean motivoCursorMoving = false;
        Pen motivoCursorPen;
        int motivoCursorX = -1;
        int motivoCursorY = -1;
        string trazosMotivoConsulta = "";

        // Propiedades para los dibujos del tab TRATAMIENTO
        Graphics graficoTratamiento;
        Boolean tratamientoCursorMoving = false;
        Pen tratamientoCursorPen;
        int tratamientoCursorX = -1;
        int tratamientoCursorY = -1;
        string trazosTratamiento = "";

        #region CONSTRUCTORES
        // Constructor por default
        public frmConsulta()
        {
            InitializeComponent();

            InicializarCanvas();

            LlenarCombos();            

            this.SetStyle(ControlStyles.DoubleBuffer |
              ControlStyles.UserPaint |
              ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }

        //Constructor con parametros PACIENTE y CONSULTA
        public frmConsulta(PACIENTE p, CONSULTA c)
        {
            InitializeComponent();            

            this._consulta = c;
            this._paciente = p;

            InicializarCanvas();

            LlenarCombos();

            LlenarTrazosCanvas();

            RefrescarDGVTratamientos();

            // Llenar informacion del paciente
            this.txtNombrePaciente.Text = p.Nombre;
            this.lblExpediente.Text = p.ID.ToString();
            this.txtEdad.Text = (DateTime.Today.Year - p.FechaNacimiento.Year).ToString();
            this.dtpFechaNacimiento.Text = p.FechaNacimiento.ToString();
            this.txtOcupacion.Text = p.Ocupacion;
            this.txtTelefono.Text = p.Telefono;
                    
            // Llenar informacion de la consulta
            txtMotivoConsulta.Text = c.MotivoConsulta;
            txtValoracion.Text = c.Valoracion;
            escala1_Click(new PictureBox() {Name = "escala" + c.EscalaDolor } ,new EventArgs());


            if (this._consulta.EstatusConsulta == "CERRADA")
                EstatusControles(false);
        }

       
        // Constructor con parametro frmAgenda
        public frmConsulta(frmAgenda frmAgenda)
        {
            InitializeComponent();

            InicializarCanvas();

            LlenarCombos();            

            this._consulta = frmAgenda.consulta;
            this._paciente = frmAgenda.paciente;

            this.txtNombrePaciente.Text = frmAgenda.paciente.Nombre;
            this.lblExpediente.Text = frmAgenda.paciente.ID.ToString();
            this.txtEdad.Text = (DateTime.Today.Year - frmAgenda.paciente.FechaNacimiento.Year).ToString();
            this.dtpFechaNacimiento.Text = frmAgenda.paciente.FechaNacimiento.ToString();
            this.txtOcupacion.Text = frmAgenda.paciente.Ocupacion;
            this.txtTelefono.Text = frmAgenda.paciente.Telefono;


            if (this._consulta.EstatusConsulta == "CERRADA")
                EstatusControles(false);
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
        }

        // Detecta cuando se presiona el boton del mouse para dibujar en el canvas TRATAMIENTO
        private void canvasTratamiento_MouseDown(object sender, MouseEventArgs e)
        {
            tratamientoCursorMoving = true;
            tratamientoCursorX = e.X;
            tratamientoCursorY = e.Y;
        }

        #endregion

        #region METODOS MOUSE UP

        // Detecta cuando se deja de presionar el boton del mouse para dejar de dibujar en el canvas MOTIVO CONSULTA
        private void canvasTratamiento_MouseUp(object sender, MouseEventArgs e)
        {
            tratamientoCursorMoving = false;
            tratamientoCursorX = -1;
            tratamientoCursorY = -1;
        }

        // Detecta cuando se deja de presionar el boton del mouse para dejar de dibujar en el canvas VALORACION

        
        // Detecta cuando se deja de presionar el boton del mouse para dejar de dibujar en el canvas TRATAMIENTO
        private void canvasMotivoConsulta_MouseUp(object sender, MouseEventArgs e)
        {
            motivoCursorMoving = false;
            motivoCursorX = -1;
            motivoCursorY = -1;
        }


        #endregion

        #region METODOS MOUSE MOVE

        //Detecta el movimiento del mousem dentro del canvas MOTIVO CONSULTA
        //y hace el trazo solo cuando esta presionado el click izquierdo
        private void canvasMotivoConsulta_MouseMove(object sender, MouseEventArgs e)
        {            
            
            if (motivoCursorX != -1 && motivoCursorY != -1 && motivoCursorMoving == true)
            {
                Control panel = (Control)sender;
                string nombre = panel.Name;

                graficoMotivoConsulta.DrawLine(motivoCursorPen, new Point(motivoCursorX, motivoCursorY), e.Location);

                GuardarPuntos(nombre, motivoCursorX, motivoCursorY);

                motivoCursorX = e.X;
                motivoCursorY = e.Y;
                
            }            
        }

        //Detecta el movimiento del mousem dentro del canvas TRATAMIENTO
        //y hace el trazo solo cuando esta presionado el click izquierdo
        private void canvasTratamiento_MouseMove(object sender, MouseEventArgs e)
        {
            if (tratamientoCursorX != -1 && tratamientoCursorY != -1 && tratamientoCursorMoving == true)
            {
                Control panel = (Control)sender;
                string nombre = panel.Name;

                graficoTratamiento.DrawLine(tratamientoCursorPen, new Point(tratamientoCursorX, tratamientoCursorY), e.Location);

                GuardarPuntos(nombre, tratamientoCursorX, tratamientoCursorY);

                tratamientoCursorX = e.X;
                tratamientoCursorY = e.Y;
            }
        }


        #endregion

        #region METODOS DE LOS CONTROLES

        // Guarda todos los cambios hechos en la consulta
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (TerapiModel db = new TerapiModel())
            {
                if (_consulta == null)
                    _consulta = new CONSULTA();

                _consulta.MotivoConsulta = txtMotivoConsulta.Text;
                _consulta.EscalaDolor = _escalaSeleccionada;
                _consulta.Valoracion = txtValoracion.Text;
                
                if (_consulta.EstatusConsulta != "CERRADA")
                    _consulta.EstatusConsulta = "ABIERTA";                

                if (_paciente == null)
                {
                    _paciente = new PACIENTE();
                    _paciente.Nombre = this.txtNombrePaciente.Text;
                    _paciente.Ocupacion = this.txtOcupacion.Text;
                    _paciente.FechaNacimiento = this.dtpFechaNacimiento.Value;
                    _paciente.Telefono = this.txtTelefono.Text;

                    db.PACIENTES.Add(_paciente);
                    db.SaveChanges();

                    _paciente = db.PACIENTES.FirstOrDefault(x => x.Nombre == txtNombrePaciente.Text);

                    _consulta.PacienteID = _paciente.ID;
                    _consulta.FechaConsulta = DateTime.Now;
                }
                else
                {
                    _consulta.PacienteID = _paciente.ID;
                }

                db.CONSULTAS.Add(_consulta);
                db.SaveChanges();
               
                //Guarda el tratamiento aplicado y los trazos asociados a cada tratamiento
                foreach (var tratamiento in _tratamientos) 
                {
                    TRATAMIENTO t = new TRATAMIENTO();
                    t.ConsultaID = _consulta.ID;
                    t.TipoTratamiento = tratamiento.TipoTratamiento;
                    t.Comentarios = tratamiento.Comentarios;
                    t.Tiempo = tratamiento.Tiempo;

                    db.TRATAMIENTOS.Add(t);                  
                    
                    db.SaveChanges();
                }

                List<PUNTO> puntosMotivoConsulta = new List<PUNTO>();

                //Generar objetos PUNTO para la tab Motivo Consulta
                if (!string.IsNullOrEmpty(this.trazosMotivoConsulta))
                {
                    PUNTO p = new PUNTO();
                    p.ConsultaID = this._consulta.ID;
                    p.Coordenadas = this.trazosMotivoConsulta;
                    
                    p.TipoPuntos = "MotivoConsulta";
                    puntosMotivoConsulta.Add(p);
                }

                db.SaveChanges();

                IQueryable<ADJUNTO> adj = db.ADJUNTOS.Where(x => x.ConsultaID == this._consulta.ID);

                    ADJUNTO ad = new ADJUNTO();
                    ad.ConsultaID = this._consulta.ID;
                    ad.NombreArchivo = _nombreArchivo;
                    ad.ExtensionArchivo = _extensionArchivo;
                    ad.PathArchivoAdjunto = _rutaArchivo;

                    db.ADJUNTOS.Add(ad);
                    db.SaveChanges();


                GenerarAdjuntos();
            }

            lblError.Text = "CAMBIOS GUARDADOS CON EXITO!";
            lblError.ForeColor = Color.Green;
            lblError.Visible = true;
            lblError2.Visible = true;
            lblError2.ForeColor = lblError.ForeColor;
            lblError2.Text = lblError.Text;
            timeError.Start();

            if (this._consulta.EstatusConsulta == "CERRADA")
                EstatusControles(false);

        }

        // Guarda solo los tratamientos que se estan aplicando al paciente en la consulta 
        private void btnGuardarTratamiento_Click(object sender, EventArgs e)
        {
            if (txtTiempoTratamiento.Text == "" || txtTiempoTratamiento.Text == null)
            {
                lblErrorTiempo.Text = "NO HAS INGRESADO EL TIEMPO";
                timeError.Start();
                return;
            }          

            TRATAMIENTO tratamiento = new TRATAMIENTO();

            using (TerapiModel db = new TerapiModel()) 
            {
                tratamiento.TipoTratamiento = cboTratamientos.Text;
                tratamiento.Tiempo = Convert.ToInt16(txtTiempoTratamiento.Text);
                tratamiento.Comentarios = txtComentariosTratamiento.Text;
                tratamiento.ConsultaID = this._consulta.ID;
                _tratamientos.Add(tratamiento);

                db.TRATAMIENTOS.Add(tratamiento);
                db.SaveChanges();

                if (!string.IsNullOrEmpty(this.trazosTratamiento))
                {
                    PUNTO p = new PUNTO();
                    p.ConsultaID = this._consulta.ID;
                    p.Coordenadas = this.trazosTratamiento;
                    p.TipoPuntos = "Tratamiento";
                    p.TratamientoID = tratamiento.ID;

                    db.PUNTOS.Add(p);
                    db.SaveChanges();

                    this.trazosTratamiento = "";
                }

                txtTiempoTratamiento.Text = "";
                txtComentariosTratamiento.Text = "";
                cboTratamientos.SelectedIndex = 0;

            } 

            canvasTratamiento.Invalidate();

            RefrescarDGVTratamientos(tratamiento);     
            
        }

        // Detecta el caracter ingresado en el campo de TIEMPO TRATAMIENTO y solo permite numeros.
        private void txtTiempoTratamiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

            }
            else
            {
                lblErrorTiempo.Text = "";
            }
        }

        // Hace la busqueda del paciente
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtNombrePaciente.Text == null) 
            {
                lblError.Text = "NO HAS INGRESADO UN NOMBRE PARA BUSQUEDA";
                lblError.Visible = true;
                return;
            }
                

            using (TerapiModel db = new TerapiModel())
            {

                PACIENTE p = new PACIENTE();
                p = db.PACIENTES.FirstOrDefault(x => x.Nombre == txtNombrePaciente.Text);
                if (p != null)
                {
                    txtOcupacion.Text = p.Ocupacion.ToString();
                    txtTelefono.Text = p.Telefono.ToString();
                    txtEdad.Text = (DateTime.Today.Year - p.FechaNacimiento.Year).ToString();
                    dtpFechaNacimiento.Text = p.FechaNacimiento.ToString();
                    lblError.Visible = false;
                    lblExpediente.Text = p.ID.ToString();
                }
                else
                {
                    lblError.Text = "NO SE ENCONTRO EL PACIENTE";
                    lblError.Visible = true;
                    timeError.Start();

                }

            }
        }

        // Muestra la pantalla AGENDAR CONSULTA
        private void btnAgendarConsulta_Click(object sender, EventArgs e)
        {
            frmAgregarCita agregarCita = new frmAgregarCita(_paciente);
            agregarCita.ShowDialog();
        }

        // Genera el recibo en PDF de la consulta
        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            frmCostoCita costo = new frmCostoCita(_paciente, _consulta);
            costo.ShowDialog();
        }

        // Detecta cuando se cambia de pestaña y re-dibuja los trazos ya hechos
        // unicamente en la pestaña seleccionada
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name == "tabTratamiento")
                canvasTratamiento.Invalidate();
            
            if (tabControl.SelectedTab.Name == "tabMotivoConsulta")
                canvasMotivoConsulta.Invalidate();

        }

        private void txtNombrePaciente_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblError.Visible = false;
            timeError.Stop();
            timerError = 0;
        }

        private void btnCerrarConsulta_Click(object sender, EventArgs e)
        {
            frmCerrarConsulta cerrar = new frmCerrarConsulta();

            cerrar.OpcionSeleccionada += CerrarConsulta_OpcionSeleccionada;

            cerrar.ShowDialog();
        }

        private void timeError_Tick(object sender, EventArgs e)
        {
            if (timerError < 200)
            {
                timerError++;
            }
            else
            {
                lblError.Visible = false;
                lblError2.Visible = false;
                timerError = 0;
                timeError.Stop();
            }
        }

        private void dgvTratamientos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //canvasTratamiento.Paint += CanvasTratamiento_Paint;
            canvasTratamiento.Invalidate();

            int rowIndex = e.RowIndex;
            if (rowIndex < 0) return;

            var tratamientoSeleccionado = ObtenerTratamientoSeleccionado(rowIndex);
            if (tratamientoSeleccionado == null) return;

            puntosTratamientoSeleccionado = ObtenerPuntosDeTratamiento(tratamientoSeleccionado);

            if (puntosTratamientoSeleccionado == null)
            {
                puntosTratamientoSeleccionado = new List<Point>();
            }

            canvasTratamiento.Invalidate();
        }

        private void txtTiempoTratamiento_Enter(object sender, EventArgs e)
        {
            if (dgvTratamientos.SelectedRows.Count > 0) 
            {
                // Limpia la lista de puntos seleccionados
                puntosTratamientoSeleccionado = new List<Point>();                

                // Fuerza la actualización del canvas para reflejar los cambios
                canvasTratamiento.Invalidate();

                if (dgvTratamientos.Rows.Count > 0)
                {
                    dgvTratamientos.ClearSelection();
                    dgvTratamientos.CurrentCell = dgvTratamientos.Rows[0].Cells[0];
                    dgvTratamientos.Rows[0].Selected = true;
                }
            }

        }
        private void btnAdjuntar_Click(object sender, EventArgs e)
        {
            // Abre un diálogo para seleccionar archivos
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Todos los archivos (*.*)|*.*",
                Title = "Seleccionar archivo"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = openFileDialog.FileName;

                // Ruta de destino para guardar el archivo
                string rutaDestino = Path.Combine(@"C:\Terappi\Adjuntos", Path.GetFileName(rutaArchivo));

                try
                {
                    // Copiar el archivo a la carpeta especial
                    File.Copy(rutaArchivo, rutaDestino, true);
                    MessageBox.Show("Archivo guardado correctamente en: " + rutaDestino);
                    _nombreArchivo = Path.GetFileNameWithoutExtension(rutaDestino);
                    _extensionArchivo = Path.GetExtension(rutaDestino);
                    _rutaArchivo = rutaDestino;
                    txtAdjunto.Text = rutaArchivo;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el archivo: " + ex.Message);
                }
            }
        }

        #endregion

        #region METODOS EXTRA

        private void EstatusControles(bool estatus)
        {
            txtNombrePaciente.Enabled = estatus;
            dtpFechaNacimiento.Enabled = estatus;
            txtEdad.Enabled = estatus;
            txtOcupacion.Enabled = estatus;
            txtTelefono.Enabled = estatus;
            txtMotivoConsulta.Enabled = estatus;
            txtValoracion.Enabled = estatus;
            txtTiempoTratamiento.Enabled= estatus;
            txtComentariosTratamiento.Enabled = estatus;
            cboTratamientos.Enabled = estatus;   
            btnAdjuntar.Enabled = estatus;
            txtAdjunto.Enabled = estatus;
            btnGuardarTratamiento.Enabled =estatus;
            canvasMotivoConsulta.Enabled = estatus;
            canvasTratamiento.Enabled = estatus;
            btnCerrarConsulta.Enabled = estatus;
            btnCerrar2.Enabled = estatus;
            btnGuardar.Enabled = estatus;
            btnGuardar2.Enabled = estatus;
        }

        // Rellena los trazos de los canvas con la informacion que se ecuentra en DB
        private void LlenarTrazosCanvas()
        {
            using (TerapiModel db = new TerapiModel())
            {              
             
                IQueryable<PUNTO> trazosMotivo = db.PUNTOS.Where(x => x.ConsultaID == _consulta.ID && x.TipoPuntos == "MotivoConsulta");


                IQueryable<PUNTO> trazosTratamiento = db.PUNTOS.Where(x => x.ConsultaID == _consulta.ID && x.TipoPuntos == "Tratamiento");

                foreach (var p in trazosMotivo.ToList())
                {
                    this.trazosMotivoConsulta = this.trazosMotivoConsulta + p.Coordenadas;
                }
               
                foreach (var p in trazosTratamiento.ToList())
                {
                    this.trazosTratamiento = this.trazosTratamiento + p.Coordenadas;
                }

            }
            canvasTratamiento.Invalidate();

            canvasMotivoConsulta.Invalidate();

        }

        // Llena los menus desplegables con los datos de las tablas TIPO_PADECIMIENTO y TRATAMIENTO
        private void LlenarCombos()
        {
            using (TerapiModel db = new TerapiModel()) 
            {
                _tipo_tratamientos = db.TIPO_TRATAMIENTO.ToList();
            }

            
            cboTratamientos.DataSource = _tipo_tratamientos;
            cboTratamientos.ValueMember = "ID";
            cboTratamientos.DisplayMember = "TipoTratamiento";

        }

        // Hace refresh del listado de tratamientos ya aplicados en la consulta
        private void RefrescarDGVTratamientos(TRATAMIENTO tratamiento) 
        {

            TRATAMIENTOS_AGREGADOS agregado = new TRATAMIENTOS_AGREGADOS();

            agregado.TipoTratamiento = tratamiento.TipoTratamiento;
            agregado.Tiempo = tratamiento.Tiempo;
            agregado.Comentarios = tratamiento.Comentarios;

            _tratamientos_agregados.Add(agregado);


            dgvTratamientos.DataSource = null;
            dgvTratamientos.DataSource = _tratamientos_agregados;

        }

        private void RefrescarDGVTratamientos() 
        {
            using (TerapiModel db = new TerapiModel())
            {
                this._tratamientos = db.TRATAMIENTOS.Where(x => x.ConsultaID == this._consulta.ID).ToList();                


                foreach (var tratamiento in _tratamientos)
                {
                    TRATAMIENTOS_AGREGADOS agregado = new TRATAMIENTOS_AGREGADOS();

                    agregado.TipoTratamiento = tratamiento.TipoTratamiento;
                    agregado.Tiempo = tratamiento.Tiempo;
                    agregado.Comentarios = tratamiento.Comentarios;

                    _tratamientos_agregados.Add(agregado);
                }
            }

            dgvTratamientos.DataSource = null;
            dgvTratamientos.DataSource = _tratamientos_agregados;

        }

        //Guarda los puntos de cada canvas en un string especifico para cada canvas y color dentro del canvas
        private void GuardarPuntos(string panel, int X, int Y)
        {
            if (panel == "canvasMotivoConsulta")
            {
                trazosMotivoConsulta = trazosMotivoConsulta + $"{X},{Y};";
            }

            if (panel == "canvasTratamiento")
            {
                trazosTratamiento = trazosTratamiento + $"{X},{Y};";
            }
        }

        // Convierte el string con los puntos en una lista de objetos POINT
        private List<Point> ConvertirStringAListaDePuntos(string coordenadas) 
        {
            List<Point> puntos = new List<Point>();

            if (coordenadas == "")
                return puntos;

            
            string[] _coordenadas = coordenadas.Split(';');

            foreach (string puntoString in _coordenadas) 
            {
                string[] partes = puntoString.Split(',');

                if (partes[0] == "" || partes[1] == "")
                    break;

                int x = int.Parse(partes[0]); 
                int y = int.Parse(partes[1]);
                puntos.Add(new Point(x, y));

            } 
            return puntos;
        }

        private void CerrarConsulta_OpcionSeleccionada(string opcion)
        {            
           this._consulta.MotivoCierre = opcion;
           this._consulta.EstatusConsulta = "CERRADA";
        }

        private TRATAMIENTOS_AGREGADOS ObtenerTratamientoSeleccionado(int rowIndex)
        {
            return dgvTratamientos.Rows[rowIndex].DataBoundItem as TRATAMIENTOS_AGREGADOS;
        }

        private List<Point> ObtenerPuntosDeTratamiento(TRATAMIENTOS_AGREGADOS ta)
        {
            using (var db = new TerapiModel())
            {
                var tratamiento = db.TRATAMIENTOS.FirstOrDefault(x =>
                    x.Tiempo == ta.Tiempo &&
                    x.Comentarios == ta.Comentarios &&
                    x.TipoTratamiento == ta.TipoTratamiento &&
                    x.ConsultaID == this._consulta.ID);

                if (tratamiento == null) return null;

                var punto = db.PUNTOS.FirstOrDefault(x => x.TratamientoID == tratamiento.ID);
                return punto != null ? ConvertirStringAListaDePuntos(punto.Coordenadas) : null;
            }
        }

        private void DibujarPuntosSeleccionados(Graphics graphics, Color colorLinea)
        {
            if (puntosTratamientoSeleccionado == null || puntosTratamientoSeleccionado.Count == 0) return;

            using (var pen = new Pen(colorLinea, 5))
            {
                for (int i = 0; i < puntosTratamientoSeleccionado.Count - 1; i++)
                {
                    graphics.DrawLine(pen, puntosTratamientoSeleccionado[i], puntosTratamientoSeleccionado[i + 1]);
                }
            }
        }

        private void CanvasTratamiento_Paint(object sender, PaintEventArgs e)
        {
          
            canvasTratamiento.BackgroundImage = Resources.cuerpo_humano;

            if (puntosTratamientoSeleccionado != null && puntosTratamientoSeleccionado.Count > 0)
            {
                using (var pen = new Pen(Color.Black, 5))
                {
                    for (int i = 0; i < puntosTratamientoSeleccionado.Count - 1; i++)
                    {
                        e.Graphics.DrawLine(pen, puntosTratamientoSeleccionado[i], puntosTratamientoSeleccionado[i + 1]);
                    }
                }
            }
        }

        // Sobrecarga del metodo ON PAINT para re-dibujar los trazos hechos en cada canvas 
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            switch (tabControl.SelectedTab.Name)
            {
                case "tabMotivoConsulta":
                    // Dibuja los trazos del motivo de consulta
                    RedibujarCanvas(e.Graphics, canvasMotivoConsulta, trazosMotivoConsulta, Color.Black);
                    break;

                default:
                    break;
            }

            if (puntosTratamientoSeleccionado != null) 
            {
                DibujarPuntosSeleccionados(e.Graphics, Color.Black);
            }
        }

        private void RedibujarCanvas(Graphics graphics, Panel canvas, string trazos, Color colorLinea)
        {
            if (canvas == null || string.IsNullOrEmpty(trazos)) return;

            using (graphics = canvas.CreateGraphics())
            {

                List<Point> puntos = ConvertirStringAListaDePuntos(trazos);


                // MOTIVO BLACK
                for (int i = 0; puntos.ToArray().Length > i; i++)
                {
                    if ((puntos.ToArray().Length) - 1 > i)
                    {
                        graphics.DrawLine(new Pen(Color.Black, 5), puntos.ToArray()[i], puntos.ToArray()[i + 1]);
                    }
                    else
                    {
                        graphics.DrawLine(new Pen(Color.Black, 5), puntos.ToArray()[i], puntos.ToArray()[i]);
                    }
                }

            }
        }

        private void GenerarAdjuntos() 
        {
            flwAdjuntos.Controls.Clear();

            using (TerapiModel db = new TerapiModel())
            {                   

                IQueryable<ADJUNTO> ad = db.ADJUNTOS.Where(b => b.ConsultaID == this._consulta.ID);

                foreach (ADJUNTO adj in ad) 
                {
                    ucAdjunto adjunto = new ucAdjunto();
                    adjunto.NombreArchivo = adj.NombreArchivo;
                    adjunto.ExtensionArchivo = adj.ExtensionArchivo;
                    adjunto.RutaArchivo = adj.PathArchivoAdjunto;
                    flwAdjuntos.Controls.Add(adjunto);

                    adjunto.Click += new System.EventHandler(this.ucAdjunto_Click);
                    adjunto.MouseEnter += new System.EventHandler(this.ucAdjunto_MouseEnter);
                    adjunto.MouseLeave += new System.EventHandler(this.ucAdjunto_MouseLeave);
                }
                
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
    }

}

