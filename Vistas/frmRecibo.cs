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

namespace Terapp.UI
{
    public partial class frmRecibo : Form
    {
        public frmRecibo()
        {
            InitializeComponent();
        }

        public frmRecibo(string nombre, int expediente, string motivo, string valoracion, DateTime fecha, string costoCita)
        {
            InitializeComponent();

            lblExpediente.Text = expediente.ToString();
            lblFecha.Text = fecha.ToShortDateString();
            lblNombre.Text = nombre;
            lblMotivoConsulta.Text = motivo;
            lblValoracion.Text = valoracion;
            lblTotal.Text = "$" + costoCita.ToString();
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
