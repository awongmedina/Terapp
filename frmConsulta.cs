using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Terapp.UI
{
    public partial class frmConsulta : Form
    {
        //propiedades generales
        private frmAgenda _frmAgenda;
        private int _escalaSeleccionada;
        private string _motivoConsulta;
        private string _nombrePaciente;
        private DateTime _fechaNacimiento;
        private string _edad;
        private string _ocupacion;
        private string _telefono;
        private string _padecimiento;
        private int _tiempo;
        private string _tratamiento;
        private string _comentariosTratamiento;



        //propiedades para los dibujos del tab MOTIVO DE CONSULTA
        Graphics graficoMotivoConsulta;
        Boolean motivoCursorMoving = false;
        Pen motivoCursorPen;
        int motivoCursorX = -1;
        int motivoCursorY = -1;
        List<Point> motivoPuntosRed = new List<Point>();
        List<Point> motivoPuntosYellow = new List<Point>();
        List<Point> motivoPuntosGreen = new List<Point>();
        List<Point> motivoPuntosBlack = new List<Point>();


        //propiedades para los dibujos del tab VALORACION
        Graphics graficoValoracion;
        Boolean valoracionCursorMoving = false;
        Pen valoracionCursorPen;
        int valoracionCursorX = -1;
        int valoracionCursorY = -1;
        List<Point> valoracionPuntosRed = new List<Point>();
        List<Point> valoracionPuntosYellow = new List<Point>();
        List<Point> valoracionPuntosGreen = new List<Point>();
        List<Point> valoracionPuntosBlack = new List<Point>();


        //propiedades para los dibujos del tab TRATAMIENTO
        Graphics graficoTratamiento;
        Boolean tratamientoCursorMoving = false;
        Pen tratamientoCursorPen;
        int tratamientoCursorX = -1;
        int tratamientoCursorY = -1;
        List<Point> tratamientoPuntos = new List<Point>();


        public frmConsulta()
        {
            InitializeComponent();

            InicializarCanvas();
        }

        public frmConsulta(frmAgenda frmAgenda)
        {
            InitializeComponent();

            InicializarCanvas();

            this._frmAgenda = frmAgenda;

            this.txtNombrePaciente.Text = _frmAgenda.paciente.Nombre;
            this.lblExpediente.Text = _frmAgenda.paciente.ID.ToString();
            this.txtEdad.Text = (DateTime.Today.Year - _frmAgenda.paciente.FechaNacimiento.Year).ToString();
            this.dtpFechaNacimiento.Text = _frmAgenda.paciente.FechaNacimiento.ToString();
            this.txtOcupacion.Text = _frmAgenda.paciente.Ocupacion;
            this.txtTelefono.Text = _frmAgenda.paciente.Telefono;
            
            
            btnBuscar.Visible = false;
            btnGuardar.Visible = false;
            txtEdad.Enabled = false;
            txtMotivoConsulta.Enabled = false;
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
            _escalaSeleccionada = escalaSeleccionada.Name.Length - 1;

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

        private void canvasMotivoConsulta_MouseMove(object sender, MouseEventArgs e)
        {            
            
            if (motivoCursorX != -1 && motivoCursorY != -1 && motivoCursorMoving == true)
            {
                Control panel = (Control)sender;
                string nombre = panel.Name;

                graficoMotivoConsulta.DrawLine(motivoCursorPen, new Point(motivoCursorX, motivoCursorY), e.Location);
                motivoCursorX = e.X;
                motivoCursorY = e.Y;

                GuardarPuntos(nombre, valoracionCursorPen.Color, e.Location);

            }            
        }

        private void canvasValoracion_MouseMove(object sender, MouseEventArgs e)
        {
            if (valoracionCursorX != -1 && valoracionCursorY != -1 && valoracionCursorMoving == true)
            {
                Control panel = (Control)sender;
                string nombre = panel.Name;

                graficoValoracion.DrawLine(valoracionCursorPen, new Point(valoracionCursorX, valoracionCursorY), e.Location);
                valoracionCursorX = e.X;
                valoracionCursorY = e.Y;

                GuardarPuntos(nombre,valoracionCursorPen.Color,e.Location);
            }
        }

        private void canvasTratamiento_MouseMove(object sender, MouseEventArgs e)
        {
            if (tratamientoCursorX != -1 && tratamientoCursorY != -1 && tratamientoCursorMoving == true)
            {
                Control panel = (Control)sender;
                string nombre = panel.Name;

                graficoTratamiento.DrawLine(tratamientoCursorPen, new Point(tratamientoCursorX, tratamientoCursorY), e.Location);
                tratamientoCursorX = e.X;
                tratamientoCursorY = e.Y;

                GuardarPuntos(nombre, tratamientoCursorPen.Color, e.Location);
            }
        }

        private void GuardarPuntos(string panel, Color color, Point punto)
        {
            switch (panel)
            {
                case "canvasMotivoConsulta":
                    switch (color.Name.ToString())
                    {
                        case "Black":
                            motivoPuntosBlack.Add(punto);
                            break;
                        case "Red":
                            motivoPuntosRed.Add(punto);
                            break;
                        case "Yellow":
                            motivoPuntosYellow.Add(punto);
                            break;
                        case "Green":
                            motivoPuntosGreen.Add(punto);
                            break;
                    }
                    break;
                case "canvasValoracion":
                    switch (color.Name.ToString())
                    {
                        case "Black":
                            valoracionPuntosBlack.Add(punto);
                            break;
                        case "Red":
                            valoracionPuntosRed.Add(punto);
                            break;
                        case "Yellow":
                            valoracionPuntosYellow.Add(punto);
                            break;
                        case "Green":
                            valoracionPuntosGreen.Add(punto);
                            break;
                    }
                    break;
                case "canvasTratamiento":
                    tratamientoPuntos.Add(punto);   
                    break;
            }
        }

        #endregion

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

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
                }

            }
        }

        private void btnAgendarConsulta_Click(object sender, EventArgs e)
        {
            frmAgregarCita frmAgregarCita = new frmAgregarCita();
            frmAgregarCita.ShowDialog();
        }

        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            frmRecibo frmRecibo = new frmRecibo();
            frmRecibo.ShowDialog();
        }

        private void txtMotivoConsulta_TextChanged(object sender, EventArgs e)
        {
            this._motivoConsulta = txtMotivoConsulta.Text;
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
           TabControl tc = (TabControl)sender;
            if(tc.TabIndex != 0)
                DrawLines(new PaintEventArgs(graficoMotivoConsulta,new Rectangle()), tc.SelectedTab.Name);

        }

        public void DrawLines(PaintEventArgs e, string panel)
        {
            
            // Create a pen.
            Pen blackPen = new Pen(Color.Black, 5);
            Pen redPen = new Pen(Color.Red, 5);
            Pen yellowPen = new Pen(Color.Yellow, 5);
            Pen greenPen = new Pen(Color.Green, 5);

            // Convert the list of points to an array.
            Point[] motivoPointBlack = motivoPuntosBlack.ToArray();
            Point[] motivoPointRed = motivoPuntosRed.ToArray();
            Point[] motivoPointYellow = motivoPuntosYellow.ToArray();
            Point[] motivoPointsGreen = motivoPuntosGreen.ToArray();

            Point[] valoracionPointBlack = valoracionPuntosBlack.ToArray();
            Point[] valoracionPointRed = valoracionPuntosRed.ToArray();
            Point[] valoracionPointYellow = valoracionPuntosYellow.ToArray();
            Point[] valoracionPointGreen = valoracionPuntosGreen.ToArray();

            Point[] tratamientoPoint = tratamientoPuntos.ToArray();

            // Draw lines connecting the points.
            switch (panel) 
            {
                case ("tabMotivoConsulta"):
                    e.Graphics.DrawLines(blackPen, motivoPointBlack);
                    e.Graphics.DrawLines(redPen, motivoPointRed);
                    e.Graphics.DrawLines(yellowPen, motivoPointYellow);
                    e.Graphics.DrawLines(greenPen, motivoPointsGreen);
                    break;
                case ("tabValoracion"):
                    e.Graphics.DrawLines(blackPen, valoracionPointBlack);
                    e.Graphics.DrawLines(redPen, valoracionPointRed);
                    e.Graphics.DrawLines(yellowPen, valoracionPointYellow);
                    e.Graphics.DrawLines(greenPen, valoracionPointGreen);
                    break;
                case ("tabTratamiento"):
                    e.Graphics.DrawLines(blackPen, tratamientoPoint);
                    break;
            }



        }

    }
}
