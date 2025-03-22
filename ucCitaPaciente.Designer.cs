namespace Terapp.UI
{
    partial class ucCitaPaciente
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
            this.lblNombrePaciente = new System.Windows.Forms.Label();
            this.lblHoraCita = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombrePaciente
            // 
            this.lblNombrePaciente.AutoSize = true;
            this.lblNombrePaciente.Font = new System.Drawing.Font("Franklin Gothic Book", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombrePaciente.Location = new System.Drawing.Point(111, 18);
            this.lblNombrePaciente.Name = "lblNombrePaciente";
            this.lblNombrePaciente.Size = new System.Drawing.Size(120, 18);
            this.lblNombrePaciente.TabIndex = 0;
            this.lblNombrePaciente.Text = "NombrePaciente";
            this.lblNombrePaciente.MouseEnter += new System.EventHandler(this.ucCitaPaciente_MouseEnter);
            this.lblNombrePaciente.MouseLeave += new System.EventHandler(this.ucCitaPaciente_MouseLeave);
            // 
            // lblHoraCita
            // 
            this.lblHoraCita.AutoSize = true;
            this.lblHoraCita.Font = new System.Drawing.Font("Franklin Gothic Book", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoraCita.Location = new System.Drawing.Point(133, 58);
            this.lblHoraCita.Name = "lblHoraCita";
            this.lblHoraCita.Size = new System.Drawing.Size(66, 18);
            this.lblHoraCita.TabIndex = 1;
            this.lblHoraCita.Text = "HoraCita";
            this.lblHoraCita.MouseEnter += new System.EventHandler(this.ucCitaPaciente_MouseEnter);
            this.lblHoraCita.MouseLeave += new System.EventHandler(this.ucCitaPaciente_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Terapp.UI.Properties.Resources.calendario;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(-2, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(107, 88);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseEnter += new System.EventHandler(this.ucCitaPaciente_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.ucCitaPaciente_MouseLeave);
            // 
            // ucCitaPaciente
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblHoraCita);
            this.Controls.Add(this.lblNombrePaciente);
            this.Name = "ucCitaPaciente";
            this.Size = new System.Drawing.Size(300, 100);
            this.MouseEnter += new System.EventHandler(this.ucCitaPaciente_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ucCitaPaciente_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombrePaciente;
        private System.Windows.Forms.Label lblHoraCita;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
