namespace Terapp.UI
{
    partial class ucDiaCalendarioMensual
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDiaDelMes = new System.Windows.Forms.Label();
            this.lblNumPacientes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDiaDelMes
            // 
            this.lblDiaDelMes.AutoSize = true;
            this.lblDiaDelMes.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDiaDelMes.Font = new System.Drawing.Font("Franklin Gothic Book", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiaDelMes.Location = new System.Drawing.Point(46, 0);
            this.lblDiaDelMes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDiaDelMes.Name = "lblDiaDelMes";
            this.lblDiaDelMes.Size = new System.Drawing.Size(54, 20);
            this.lblDiaDelMes.TabIndex = 0;
            this.lblDiaDelMes.Text = "label1";
            // 
            // lblNumPacientes
            // 
            this.lblNumPacientes.AutoSize = true;
            this.lblNumPacientes.Location = new System.Drawing.Point(31, 53);
            this.lblNumPacientes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumPacientes.Name = "lblNumPacientes";
            this.lblNumPacientes.Size = new System.Drawing.Size(49, 17);
            this.lblNumPacientes.TabIndex = 1;
            this.lblNumPacientes.Text = "label2";
            // 
            // ucDiaCalendarioMensual
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.lblNumPacientes);
            this.Controls.Add(this.lblDiaDelMes);
            this.Font = new System.Drawing.Font("Franklin Gothic Book", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucDiaCalendarioMensual";
            this.Size = new System.Drawing.Size(100, 88);
            this.Load += new System.EventHandler(this.ucDiaCalendarioMensual_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDiaDelMes;
        private System.Windows.Forms.Label lblNumPacientes;
    }
}
