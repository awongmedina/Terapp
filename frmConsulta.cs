using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Terapp.UI
{
    public partial class frmConsulta : Form
    {
        // Propiedades generales
        private int _escalaSeleccionada;
        private CONSULTA _consulta;
        private PACIENTE _paciente;
        private List<PADECIMIENTO> padecimientos = new List<PADECIMIENTO>();
        private List<TIPO_TRATAMIENTO> tipo_tratamientos = new List<TIPO_TRATAMIENTO>();
        private List<TRATAMIENTO> tratamientos = new List<TRATAMIENTO>();
        private List<TRATAMIENTOS_AGREGADOS> tratamientos_agregados = new List<TRATAMIENTOS_AGREGADOS>();



        // Propiedades para los dibujos del tab MOTIVO DE CONSULTA
        Graphics graficoMotivoConsulta;
        Boolean motivoCursorMoving = false;
        Pen motivoCursorPen;
        int motivoCursorX = -1;
        int motivoCursorY = -1;
        string trazosMotivoBlack = "";
        string trazosMotivoGreen = "";
        string trazosMotivoYellow = "";
        string trazosMotivoRed = "";


        // Propiedades para los dibujos del tab VALORACION
        Graphics graficoValoracion;
        Boolean valoracionCursorMoving = false;
        Pen valoracionCursorPen;
        int valoracionCursorX = -1;
        int valoracionCursorY = -1;
        string trazosValoracionBlack = "";
        string trazosValoracionGreen = "";
        string trazosValoracionYellow = "";
        string trazosValoracionRed = "";



        // Propiedades para los dibujos del tab TRATAMIENTO
        Graphics graficoTratamiento;
        Boolean tratamientoCursorMoving = false;
        Pen tratamientoCursorPen;
        int tratamientoCursorX = -1;
        int tratamientoCursorY = -1;
        string trazosTratamiento = "";



        public frmConsulta()
        {
            InitializeComponent();

            InicializarCanvas();

            LlenarCombos();
        }

        public frmConsulta(PACIENTE p, CONSULTA c)
        {
            InitializeComponent();

            InicializarCanvas();

            LlenarCombos();

            LlenarTrazosCanvas();


            this._consulta = c;
            this._paciente = p;

            // Llenar informacion del paciente
            this.txtNombrePaciente.Text = p.Nombre;
            this.lblExpediente.Text = p.ID.ToString();
            this.txtEdad.Text = (DateTime.Today.Year - p.FechaNacimiento.Year).ToString();
            this.dtpFechaNacimiento.Text = p.FechaNacimiento.ToString();
            this.txtOcupacion.Text = p.Ocupacion;
            this.txtTelefono.Text = p.Telefono;
                    
            // Llenar informacion de la consulta
            txtMotivoConsulta.Text = c.MotivoConsulta;
            //cboPadecimiento.SelectedValue = c.Valoracion;
            escala1_Click(new PictureBox() {Name = "escala" + c.EscalaDolor } ,new EventArgs());



            btnBuscar.Visible = false;
            txtEdad.Enabled = false;
            txtNombrePaciente.Enabled = false;
            txtOcupacion.Enabled = false;
            dtpFechaNacimiento.Enabled = false;
        }

        private void LlenarTrazosCanvas()
        {
            canvasTratamiento.Invalidate();

            canvasMotivoConsulta.Invalidate();

            canvasTratamiento.Invalidate();

            List<PUNTO> trazosMotivoR = new List<PUNTO>();
            List<PUNTO> trazosMotivoY = new List<PUNTO>();
            List<PUNTO> trazosMotivoG = new List<PUNTO>();
            List<PUNTO> trazosMotivoB = new List<PUNTO>();

            List<PUNTO> trazosValoracionR = new List<PUNTO>();
            List<PUNTO> trazosValoracionY = new List<PUNTO>();
            List<PUNTO> trazosValoracionG = new List<PUNTO>();
            List<PUNTO> trazosValoracionB = new List<PUNTO>();

            List<PUNTO> trazosTratamiento = new List<PUNTO>();


            using (TerapiModel db = new TerapiModel()) 
            {
                IQueryable<PUNTO> puntos = db.PUNTOS.Where(x => x.ConsultaID == _consulta.ID);

                foreach (var p in puntos) 
                {
                    //TODO: Hay quue generar una funcionalidad para guardar los trazos a la DB.
                }

            }

        }

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
            
            
            btnBuscar.Visible = false;
            txtEdad.Enabled = false;
            txtNombrePaciente.Enabled = false; 
            txtOcupacion.Enabled = false;
            dtpFechaNacimiento.Enabled = false;
        }

        private void frmConsulta_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(800, 1200);
        }

        #region ASIGNACION DE ESCALA DE DOLOR

        private void escala1_Click(object sender, EventArgs e)
        {
            PictureBox escalaSeleccionada = (PictureBox)sender;
            
            escalaSeleccionada.BorderStyle = BorderStyle.Fixed3D;
            _consulta.EscalaDolor = escalaSeleccionada.Name.Length - 1;

            foreach (PictureBox control in flwEscaladolor.Controls)
            {
                if (control.Name != escalaSeleccionada.Name)
                    control.BorderStyle = BorderStyle.None;
                    
            }
        }

        #endregion

        #region ASIGNACION DE COLORES DE LAS PLUMAS

        private void motivoRed_Click(object sender, EventArgs e)
        {
            PictureBox color = (PictureBox)sender;
            motivoCursorPen.Color = color.BackColor;
        }

        private void valoracionRed_Click(object sender, EventArgs e)
        {
            PictureBox color = (PictureBox)sender;
            valoracionCursorPen.Color = color.BackColor;
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

            //inicializa las propiedades del dibujo, VALORACION
            graficoValoracion = canvasValoracion.CreateGraphics();
            valoracionCursorPen = new Pen(Color.Black, 5);
            graficoValoracion.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            valoracionCursorPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            valoracionCursorPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            //inicializa las propiedades del dibujo, TRATAMIENTO
            graficoTratamiento = canvasTratamiento.CreateGraphics();
            tratamientoCursorPen = new Pen(Color.Black, 5);
            graficoTratamiento.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            tratamientoCursorPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            tratamientoCursorPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        #endregion

        #region METODOS MOUSE DOWN
        private void canvasMotivoConsulta_MouseDown(object sender, MouseEventArgs e)
        {
            motivoCursorMoving = true;
            motivoCursorX = e.X;
            motivoCursorY = e.Y;
        }

        private void canvasValoracion_MouseDown(object sender, MouseEventArgs e)
        {
            valoracionCursorMoving = true;
            valoracionCursorX= e.X;
            valoracionCursorY = e.Y;
        }

        private void canvasTratamiento_MouseDown(object sender, MouseEventArgs e)
        {
            tratamientoCursorMoving = true;
            tratamientoCursorX = e.X;
            tratamientoCursorY = e.Y;
        }

        #endregion

        #region METODOS MOUSE UP

        private void canvasTratamiento_MouseUp(object sender, MouseEventArgs e)
        {
            tratamientoCursorMoving = false;
            tratamientoCursorX = -1;
            tratamientoCursorY = -1;
        }

        private void canvasValoracion_MouseUp(object sender, MouseEventArgs e)
        {
            valoracionCursorMoving = false;
            valoracionCursorX = -1;
            valoracionCursorY = -1;
        }

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

                GuardarPuntos(motivoCursorPen.Color, nombre, motivoCursorX, motivoCursorY);

                motivoCursorX = e.X;
                motivoCursorY = e.Y;

                
            }            
        }

        //Detecta el movimiento del mousem dentro del canvas VALORACION
        //y hace el trazo solo cuando esta presionado el click izquierdo
        private void canvasValoracion_MouseMove(object sender, MouseEventArgs e)
        {
            if (valoracionCursorX != -1 && valoracionCursorY != -1 && valoracionCursorMoving == true)
            {
                Control panel = (Control)sender;
                string nombre = panel.Name;

                graficoValoracion.DrawLine(valoracionCursorPen, new Point(valoracionCursorX, valoracionCursorY), e.Location);

                GuardarPuntos(valoracionCursorPen.Color, nombre, valoracionCursorX, valoracionCursorY);

                valoracionCursorX = e.X;
                valoracionCursorY = e.Y;
                

               

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

                GuardarPuntos(tratamientoCursorPen.Color, nombre, tratamientoCursorX, tratamientoCursorY);

                tratamientoCursorX = e.X;
                tratamientoCursorY = e.Y;

                

            }
        }

        //Guarda los puntos de cada canvas en un string especifico para cada canvas y color dentro del canvas
        private void GuardarPuntos(Color color, string panel, int X, int Y)
        {
            if (panel == "canvasMotivoConsulta")
            {
                switch (color.Name)
                {
                    case "Red":
                        trazosMotivoRed = trazosMotivoRed + $"{X},{Y};";
                        break;
                    case "Yellow":
                        trazosMotivoYellow = trazosMotivoYellow + $"{X},{Y};";
                        break;
                    case "Green":
                        trazosMotivoGreen = trazosMotivoGreen + $"{X},{Y};";
                        break;
                    case "Black":
                        trazosMotivoBlack = trazosMotivoBlack + $"{X},{Y};";
                        break;
                }
            }

            if (panel == "canvasValoracion")
            {
                switch (color.Name)
                {
                    case "Red":
                        trazosValoracionRed = trazosValoracionRed + $"{X},{Y};";
                        break;
                    case "Yellow":
                        trazosValoracionYellow = trazosValoracionYellow + $"{X},{Y};";
                        break;
                    case "Green":
                        trazosValoracionGreen = trazosValoracionGreen + $"{X},{Y};";
                        break;
                    case "Black":
                        trazosValoracionBlack = trazosValoracionBlack + $"{X},{Y};";
                        break;
                }
            }

            if (panel == "canvasTratamiento")
            {
                trazosTratamiento = trazosTratamiento + $"{X},{Y};";
            }
        }


        #endregion

        #region METODOS EXTRA

        // Guarda todos los cambios hechos en la consulta
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_consulta == null)
                _consulta = new CONSULTA();

            _consulta.MotivoConsulta = txtMotivoConsulta.Text;
            _consulta.EscalaDolor = _escalaSeleccionada;
            _consulta.Valoracion = cboPadecimiento.SelectedValue.ToString();


            using (TerapiModel db = new TerapiModel()) 
            {
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
                    _consulta.FechaConsulta = DateTime.Today;

                    db.CONSULTAS.Add(_consulta);    
                    
                }                

                db.SaveChanges();
            }

        }

        // Hace la busqueda del paciente
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtNombrePaciente.Text == null) return;

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
                }
                else 
                {
                    lblError.Visible = true;
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
            frmRecibo frmRecibo = new frmRecibo();
            frmRecibo.ShowDialog();
        }

        // Detecta cuando se cambia de pestaña y re-dibuja los trazos ya hechos
        // unicamente en la pestaña seleccionada
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name == "tabTratamiento")
                canvasTratamiento.Invalidate();
            
            if (tabControl.SelectedTab.Name == "tabMotivoConsulta")
                canvasMotivoConsulta.Invalidate();

            if (tabControl.SelectedTab.Name == "tabValoracion")
                canvasValoracion.Invalidate();
        }
        
        // Sobrecarga del metodo ON PAINT para re-dibujar los trazos hechos en cada canvas
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
                 
            // Canvas MOTIVO D CONSULTA
            if (tabControl.SelectedTab.Name == "tabMotivoConsulta")
            {
                using (Graphics g = canvasMotivoConsulta.CreateGraphics())
                {

                    List<Point> motivoPointBlack = ConvertirStringAListaDePuntos(trazosMotivoBlack); 
                    List<Point> motivoPointRed = ConvertirStringAListaDePuntos(trazosMotivoRed); 
                    List<Point> motivoPointYellow = ConvertirStringAListaDePuntos(trazosMotivoYellow); 
                    List<Point> motivoPointGreen = ConvertirStringAListaDePuntos(trazosMotivoGreen); 

                    // MOTIVO BLACK
                    for (int i = 0; motivoPointBlack.ToArray().Length > i; i++)
                    {
                        if ((motivoPointBlack.ToArray().Length) - 1 > i)
                        {
                            g.DrawLine(new Pen(Color.Black, 5), motivoPointBlack.ToArray()[i], motivoPointBlack.ToArray()[i + 1]);
                        }
                        else
                        {
                            g.DrawLine(new Pen(Color.Black, 5), motivoPointBlack.ToArray()[i], motivoPointBlack.ToArray()[i]);
                        }
                    }

                    // MOTIVO RED
                    for (int i = 0; motivoPointRed.ToArray().Length > i; i++)
                    {
                        if ((motivoPointRed.ToArray().Length) - 1 > i)
                        {
                            g.DrawLine(new Pen(Color.Red, 5), motivoPointRed.ToArray()[i], motivoPointRed.ToArray()[i + 1]);
                        }
                        else
                        {
                            g.DrawLine(new Pen(Color.Red, 5), motivoPointRed.ToArray()[i], motivoPointRed.ToArray()[i]);
                        }
                    }

                    // MOTIVO YELLOW
                    for (int i = 0; motivoPointYellow.ToArray().Length > i; i++)
                    {
                        if ((motivoPointYellow.ToArray().Length) - 1 > i)
                        {
                            g.DrawLine(new Pen(Color.Yellow, 5), motivoPointYellow.ToArray()[i], motivoPointYellow.ToArray()[i + 1]);
                        }
                        else
                        {
                            g.DrawLine(new Pen(Color.Yellow, 5), motivoPointYellow.ToArray()[i], motivoPointYellow.ToArray()[i]);
                        }
                    }

                    // MOTIVO GREEN
                    for (int i = 0; motivoPointGreen.ToArray().Length > i; i++)
                    {
                        if ((motivoPointGreen.ToArray().Length) - 1 > i)
                        {
                            g.DrawLine(new Pen(Color.Green, 5), motivoPointGreen.ToArray()[i], motivoPointGreen.ToArray()[i + 1]);
                        }
                        else
                        {
                            g.DrawLine(new Pen(Color.Green, 5), motivoPointGreen.ToArray()[i], motivoPointGreen.ToArray()[i]);
                        }
                    }
                }
            }
             
            if (tabControl.SelectedTab.Name == "tabValoracion")
            {
                using (Graphics g = canvasValoracion.CreateGraphics())
                {
                    // Canvas VALORACION
                    List<Point> valoracionPointBlack = ConvertirStringAListaDePuntos(trazosValoracionBlack);
                    List<Point> valoracionPointRed = ConvertirStringAListaDePuntos(trazosValoracionRed); 
                    List<Point> valoracionPointYellow = ConvertirStringAListaDePuntos(trazosValoracionYellow);
                    List<Point> valoracionPointGreen = ConvertirStringAListaDePuntos(trazosValoracionGreen); 

                    // VALORACION BLACK
                    for (int i = 0; valoracionPointBlack.ToArray().Length > i; i++)
                    {
                        if ((valoracionPointBlack.ToArray().Length) - 1 > i)
                        {
                            g.DrawLine(new Pen(Color.Black, 5), valoracionPointBlack.ToArray()[i], valoracionPointBlack.ToArray()[i + 1]);
                        }
                        else
                        {
                            g.DrawLine(new Pen(Color.Black, 5), valoracionPointBlack.ToArray()[i], valoracionPointBlack.ToArray()[i]);
                        }
                    }

                    // VALORACION RED
                    for (int i = 0; valoracionPointRed.ToArray().Length > i; i++)
                    {
                        if ((valoracionPointRed.ToArray().Length) - 1 > i)
                        {
                            g.DrawLine(new Pen(Color.Red, 5), valoracionPointRed.ToArray()[i], valoracionPointRed.ToArray()[i + 1]);
                        }
                        else
                        {
                            g.DrawLine(new Pen(Color.Red, 5), valoracionPointRed.ToArray()[i], valoracionPointRed.ToArray()[i]);
                        }
                    }

                    // VALORACION YELLOW
                    for (int i = 0; valoracionPointYellow.ToArray().Length > i; i++)
                    {
                        if ((valoracionPointYellow.ToArray().Length) - 1 > i)
                        {
                            g.DrawLine(new Pen(Color.Yellow, 5), valoracionPointYellow.ToArray()[i], valoracionPointYellow.ToArray()[i + 1]);
                        }
                        else
                        {
                            g.DrawLine(new Pen(Color.Yellow, 5), valoracionPointYellow.ToArray()[i], valoracionPointYellow.ToArray()[i]);
                        }
                    }

                    // VALORACION GREEN
                    for (int i = 0; valoracionPointGreen.ToArray().Length > i; i++)
                    {
                        if ((valoracionPointGreen.ToArray().Length) - 1 > i)
                        {
                            g.DrawLine(new Pen(Color.Green, 5), valoracionPointGreen.ToArray()[i], valoracionPointGreen.ToArray()[i + 1]);
                        }
                        else
                        {
                            g.DrawLine(new Pen(Color.Green, 5), valoracionPointGreen.ToArray()[i], valoracionPointGreen.ToArray()[i]);
                        }
                    }
                }
            }

            // Canvas TRATAMIENTO
            if (tabControl.SelectedTab.Name == "tabTratamiento")
            {
                using (Graphics g = canvasTratamiento.CreateGraphics())
                {
                    List<Point> tratamientoPoint = ConvertirStringAListaDePuntos(trazosTratamiento);

                    for (int i = 0; tratamientoPoint.ToArray().Length > i; i++)
                    {
                        if ((tratamientoPoint.ToArray().Length) - 1 > i)
                        {
                            g.DrawLine(new Pen(Color.Black, 5), tratamientoPoint.ToArray()[i], tratamientoPoint.ToArray()[i + 1]);
                        }
                        else
                        {
                            g.DrawLine(new Pen(Color.Black, 5), tratamientoPoint.ToArray()[i], tratamientoPoint.ToArray()[i]);
                        }
                    }
                }
            }
        }        

        // Llena los menus desplegables con los datos de las tablas TIPO_PADECIMIENTO y TRATAMIENTO
        private void LlenarCombos()
        {
            using (TerapiModel db = new TerapiModel()) 
            {
                tipo_tratamientos = db.TIPO_TRATAMIENTO.ToList();
                padecimientos = db.PADECIMIENTOS.ToList();
            }

            cboPadecimiento.DataSource = padecimientos;
            cboPadecimiento.ValueMember = "ID";
            cboPadecimiento.DisplayMember = "NombrePadecimiento";

            
            cboTratamientos.DataSource = tipo_tratamientos;
            cboTratamientos.ValueMember = "ID";
            cboTratamientos.DisplayMember = "TipoTratamiento";

        }

        // Hace refresh del listado de tratamientos ya aplicados en la consulta
        private void RefrescarDGVTratamientos() 
        {             

            using (TerapiModel db = new TerapiModel()) 
            {
                IQueryable<TRATAMIENTO> _tratamientos = db.TRATAMIENTOS.Where(x => x.ConsultaID == this._consulta.ID);

                foreach (var trat in _tratamientos) 
                {
                    TIPO_TRATAMIENTO _tipo = db.TIPO_TRATAMIENTO.FirstOrDefault(x => x.ID.ToString() == trat.TipoTratamiento);


                    TRATAMIENTOS_AGREGADOS agregado = new TRATAMIENTOS_AGREGADOS();

                    agregado.TipoTratamiento = _tipo.TipoTratamiento;
                    agregado.Tiempo = trat.Tiempo;
                    agregado.Comentarios = trat.Comentarios;

                    tratamientos_agregados.Add(agregado);
                }

            }

            dgvTratamientos.DataSource = null;
            dgvTratamientos.DataSource = tratamientos_agregados;

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



        #endregion

        // Guarda solo los tratamientos que se estan aplicando al paciente en la consulta 
        private void btnGuardarTratamiento_Click(object sender, EventArgs e)
        {
            if (txtTiempoTratamiento.Text == "" || txtTiempoTratamiento.Text == null) 
            {
                lblErrorTiempo.Text = "NO HAS INGRESADO EL TIEMPO";
                return;
            }
                

            TRATAMIENTO tratamiento = new TRATAMIENTO();

            tratamiento.TipoTratamiento = cboTratamientos.SelectedValue.ToString();
            tratamiento.Tiempo  = Convert.ToInt16(txtTiempoTratamiento.Text);
            tratamiento.Comentarios = txtComentariosTratamiento.Text;
            tratamiento.ConsultaID = _consulta.ID;

            using (TerapiModel db = new TerapiModel()) 
            {
                db.TRATAMIENTOS.Add(tratamiento);
                db.SaveChanges();
            }



            RefrescarDGVTratamientos();
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
    }

}

