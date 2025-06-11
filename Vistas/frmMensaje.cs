using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Terapp.UI.Vistas
{
    public partial class frmMensaje : Form
    {
        public bool Confirmado { get; private set; } = false;

        public frmMensaje()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mensaje">El mensaje a mostrar</param>
        /// /// <param name="okOnly">TRUE para mostrar unicamente el boton OK</param>
        public frmMensaje(string mensaje, bool okOnly)
        {
            InitializeComponent();

            lblMensaje.Text = mensaje;
            lblMensaje.AutoSize = true;
            lblMensaje.MaximumSize = new Size(462, 202);

            if (okOnly)
            {
                Button btnOk = new Button
                {
                    Text = "OK",
                    Size = new Size(110,60),
                    Location = new Point(205, 211),
                    Font = new Font("Franklin Gothic Book", 12, FontStyle.Bold),
                    BackColor = Color.White,
                    DialogResult = DialogResult.OK
                };
                btnOk.Click += (s, e) =>
                {
                    Confirmado = true;
                    this.Close();
                };

                this.Controls.Add(btnOk);

            }
            else 
            {
                Button btnCancelar = new Button
                {
                    Text = "CANCELAR",
                    Size = new Size(110, 60),
                    Location = new Point(303, 211),
                    Font = new Font("Franklin Gothic Book", 12, FontStyle.Bold),
                    BackColor = Color.White,
                    DialogResult = DialogResult.No
                };
                btnCancelar.Click += (s, e) => this.Close();


                Button btnOk = new Button
                {
                    Text = "OK",
                    Size = new Size(110, 60),
                    Location = new Point(90, 211),
                    Font = new Font("Franklin Gothic Book", 12, FontStyle.Bold),
                    BackColor = Color.White,
                    DialogResult = DialogResult.OK
                };
                btnOk.Click += (s, e) =>
                {
                    Confirmado = true;
                    this.Close();
                };

                this.Controls.Add(btnOk);                

                this.Controls.Add(btnCancelar);

            }

        }


    }
}
