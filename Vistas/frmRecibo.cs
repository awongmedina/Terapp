using System;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Image;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.Text;

namespace Terapp.UI
{
    public partial class frmRecibo : Form
    {
        public frmRecibo()
        {
            InitializeComponent();
            
        }

        public frmRecibo(PACIENTE pac, CONSULTA cons, List<TRATAMIENTO> trats, string costoConsulta)
        {
            InitializeComponent();

            lblValoracion.AutoSize = true;
            lblValoracion.MaximumSize = new Size(699, 225);

            lblMotivoConsulta.AutoSize = true;
            lblMotivoConsulta.MaximumSize = new Size(699, 225);

            var sb = new StringBuilder();

            foreach (var tratamiento in trats)
            {
                sb.Append($"{tratamiento.TipoTratamiento} , {tratamiento.Tiempo} minutos;     ");
            }

            string valoracion = sb.ToString();


            lblExpediente.Text = pac.ID.ToString();
            lblFecha.Text = cons.FechaConsulta.ToShortDateString();
            lblNombre.Text = pac.Nombre;
            lblMotivoConsulta.Text = cons.MotivoConsulta;
            lblValoracion.Text = valoracion;
            lblTotal.Text = "$" + costoConsulta.ToString();
        }

        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            // Renderiza el Panel como imagen
            Bitmap bitmap = new Bitmap(panel1.Width, panel1.Height);
            panel1.DrawToBitmap(bitmap, new Rectangle(0, 0, panel1.Width, panel1.Height));

            // Configura el documento para impresión
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = lblNombre.Text + "_" + lblFecha.Text;
            printDoc.PrintPage += (s, ev) =>
            {
                // Dibuja la imagen en la página de impresión
                ev.Graphics.DrawImage(bitmap, ev.MarginBounds);
            };

            // Configura el diálogo de impresión
            PrintDialog printDialog = new PrintDialog
            {
                Document = printDoc

            };

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                // Imprime el documento
                printDoc.Print();
            }
        }
    }
}
