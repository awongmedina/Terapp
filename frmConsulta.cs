using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        private List<Form> trazoMotivoConsulta = new List<Form>();
        private List<Form> trazoValoracion = new List<Form>();
        private List<Form> trazoTratamiento = new List<Form>();
        private string _afeccion;
        private int _tiempo;
        private string _tratamiento;
        private string _comentariosTratamiento;



        //propiedades para los dibujos del tab MOTIVO DE CONSULTA
        Graphics graficoMotivoConsulta;
        Boolean motivoCursorMoving = false;
        Pen motivoCursorPen;
        int motivoCursorX = -1;
        int motivoCursorY = -1;
        

        //propiedades para los dibujos del tab VALORACION
        Graphics graficoValoracion;
        Boolean valoracionCursorMoving = false;
        Pen valoracionCursorPen;
        int valoracionCursorX = -1;
        int valoracionCursorY = -1;
        


        //propiedades para los dibujos del tab TRATAMIENTO
        Graphics graficoTratamiento;
        Boolean tratamientoCursorMoving = false;
        Pen tratamientoCursorPen;
        int tratamientoCursorX = -1;
        int tratamientoCursorY = -1;
        


        public frmConsulta()
        {
            InitializeComponent();

            InicializarCanvas();
        }

        public frmConsulta(frmAgenda frmAgenda, string nombre)
        {
            InitializeComponent();

            InicializarCanvas();

            this.txtNombrePaciente.Text = nombre;
            _frmAgenda = frmAgenda;
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
                graficoMotivoConsulta.DrawLine(motivoCursorPen, new Point(motivoCursorX, motivoCursorY), e.Location);
                motivoCursorX = e.X;
                motivoCursorY = e.Y;
            }
        }

        private void canvasValoracion_MouseMove(object sender, MouseEventArgs e)
        {
            if (valoracionCursorX != -1 && valoracionCursorY != -1 && valoracionCursorMoving == true)
            {
                graficoValoracion.DrawLine(valoracionCursorPen, new Point(valoracionCursorX, valoracionCursorY), e.Location);
                valoracionCursorX = e.X;
                valoracionCursorY = e.Y;
            }
        }

        private void canvasTratamiento_MouseMove(object sender, MouseEventArgs e)
        {
            if (tratamientoCursorX != -1 && tratamientoCursorY != -1 && tratamientoCursorMoving == true)
            {
                graficoTratamiento.DrawLine(tratamientoCursorPen, new Point(tratamientoCursorX, tratamientoCursorY), e.Location);
                tratamientoCursorX = e.X;
                tratamientoCursorY = e.Y;
            }
        }



        #endregion

        #region GUARDADO y CARGA DE CAMBIOS EN LAS TABS

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabControl = (TabControl)sender;
            
            GuardadoTemporal(tabControl);
        }


        private void GuardadoTemporal(TabControl tab) 
        {
            
        }

        private void CargaTemporales() 
        {

        }

        #endregion

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

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
    }
}
