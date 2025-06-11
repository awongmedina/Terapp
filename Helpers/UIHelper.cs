using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Terapp.UI.Vistas;

namespace Terapp.UI.Helpers
{
    public static class UIHelper
    {
        public static void EstablecerEstadoControles(Control parent, bool estatus)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox || ctrl is ComboBox || ctrl is Button || ctrl is DateTimePicker || ctrl is Panel)
                {
                    ctrl.Enabled = estatus;
                }
            }
        }

        public static void AbrirArchivo(string rutaArchivo)
        {
            if (File.Exists(rutaArchivo))
            {
                try
                {
                    Process.Start(new ProcessStartInfo()
                    {
                        FileName = rutaArchivo,
                        UseShellExecute = true // Permite abrir el archivo con el programa predeterminado
                    });
                }
                catch (Exception ex)
                {
                    new frmMensaje($"ERROR AL ABRIR EL ARCHIVO: {ex.Message}", true).ShowDialog();
                }
            }
            else
            {
                new frmMensaje("EL ARCHIVO NO EXISTE O HA SIDO MOVIDO.", true).ShowDialog();
                
            }
        }

        public static void CargarTrazosEnPanel(Panel panel, string coordenadasGuardadas)
        {
            List<Point> puntos = !string.IsNullOrEmpty(coordenadasGuardadas)
                ? ConvertirStringAPuntos(coordenadasGuardadas)
                : new List<Point>();

            DibujarTrazosEnPanel(panel, puntos);
        }


        public static void DibujarTrazosEnPanel(Panel panel, List<Point> puntos)
        {
            panel.Invalidate(); // Marca el panel para redibujado
            panel.Refresh(); // Fuerza la actualización visual

            // Asignar los puntos como un campo en el panel para evitar manejadores repetitivos
            panel.Tag = puntos;

            panel.Paint += (sender, e) =>
            {
                using (var lapiz = new Pen(Color.Black, 5))
                {
                    var listaPuntos = (List<Point>)((Panel)sender).Tag; // Recuperar los puntos desde el panel
                    for (int i = 1; i < listaPuntos.Count; i++)
                    {
                        e.Graphics.DrawLine(lapiz, listaPuntos[i - 1], listaPuntos[i]);
                    }
                }
            };

            panel.Invalidate(); // Asegura que el panel se redibuje
        }


        public static List<Point> ConvertirStringAPuntos(string trazos)
        {
            var puntos = new List<Point>();

            if (!string.IsNullOrWhiteSpace(trazos))
            {
                var coordenadas = trazos.Split(';'); // Divide el string en cada coordenada

                foreach (var coordenada in coordenadas)
                {
                    var valores = coordenada.Trim('(', ')').Split(',');

                    if (valores.Length == 2 && int.TryParse(valores[0], out int x) && int.TryParse(valores[1], out int y))
                    {
                        puntos.Add(new Point(x, y));
                    }
                }
            }

            return puntos;

        }

        public static List<Point> ConvertirListaStringAPuntos(List<string> trazos)
        {
            var puntos = new List<Point>();

            foreach (var trazo in trazos) 
            {   
                if (!string.IsNullOrWhiteSpace(trazo))
                {
                    var coordenadas = trazo.Split(';'); // Divide el string en cada coordenada

                    foreach (var coordenada in coordenadas)
                    {
                        var valores = coordenada.Trim('(', ')').Split(',');

                        if (valores.Length == 2 && int.TryParse(valores[0], out int x) && int.TryParse(valores[1], out int y))
                        {
                            puntos.Add(new Point(x, y));
                        }
                    }
                }
            }
            return puntos;
        }

        public static string ConvertirPuntosAString(List<Point> puntos)
        {
            return string.Join(";", puntos.Select(p => $"({p.X},{p.Y})"));
        }

        public static bool VerificarDatosPaciente(TabPage tabPage)
        {
            

            bool textBoxesLlenos = tabPage.Controls.OfType<TextBox>()
                .Any(tb => !string.IsNullOrWhiteSpace(tb.Text));

            bool datePickersLlenos = tabPage.Controls.OfType<DateTimePicker>()
                .Any(dp => dp.Value != dp.MinDate);

            return textBoxesLlenos && datePickersLlenos;
        }

        public static bool VerificarDatosConsulta(TabPage tabPage, int? escalaSeleccionada)
        {            

            bool textBoxesLlenos = tabPage.Controls.OfType<TextBox>()
                .Any(tb => !string.IsNullOrWhiteSpace(tb.Text));

            bool escalaDolor = escalaSeleccionada.HasValue;

            return textBoxesLlenos && escalaDolor;
        }

        public static int CalcularEdad(DateTime fechaNacimiento)
        {
            DateTime fechaActual = DateTime.Today;

            int edad = fechaActual.Year - fechaNacimiento.Year;

            // Verificar si el cumpleaños ya ocurrió este año
            if (fechaActual < fechaNacimiento.AddYears(edad))
            {
                edad--; // Si aún no ha pasado el cumpleaños, restamos un año
            }

            return edad;
        }



    }

} 

