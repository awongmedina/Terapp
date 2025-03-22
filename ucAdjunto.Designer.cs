namespace Terapp.UI
{
    partial class ucAdjunto
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNombreArchivo = new System.Windows.Forms.Label();
            this.lblExtensionArchivo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre del archivo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Extension del archivo:";
            // 
            // lblNombreArchivo
            // 
            this.lblNombreArchivo.AutoSize = true;
            this.lblNombreArchivo.Location = new System.Drawing.Point(370, 15);
            this.lblNombreArchivo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNombreArchivo.Name = "lblNombreArchivo";
            this.lblNombreArchivo.Size = new System.Drawing.Size(189, 24);
            this.lblNombreArchivo.TabIndex = 2;
            this.lblNombreArchivo.Text = "Nombre del archivo:";
            // 
            // lblExtensionArchivo
            // 
            this.lblExtensionArchivo.AutoSize = true;
            this.lblExtensionArchivo.Location = new System.Drawing.Point(377, 61);
            this.lblExtensionArchivo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblExtensionArchivo.Name = "lblExtensionArchivo";
            this.lblExtensionArchivo.Size = new System.Drawing.Size(189, 24);
            this.lblExtensionArchivo.TabIndex = 3;
            this.lblExtensionArchivo.Text = "Nombre del archivo:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Terapp.UI.Properties.Resources.adjuntar;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(13, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 82);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // ucAdjunto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblExtensionArchivo);
            this.Controls.Add(this.lblNombreArchivo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Franklin Gothic Book", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "ucAdjunto";
            this.Size = new System.Drawing.Size(711, 110);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNombreArchivo;
        private System.Windows.Forms.Label lblExtensionArchivo;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
