namespace Terapp.UI
{
    partial class frmAgenda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgenda));
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.flwCitas = new System.Windows.Forms.FlowLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgregarCita = new System.Windows.Forms.Button();
            this.btnAgendaMensual = new System.Windows.Forms.Button();
            this.btnPacienteSinCita = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.Controls.Add(this.lblFecha);
            this.flowLayoutPanel2.Controls.Add(this.lblHora);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(389, 44);
            this.flowLayoutPanel2.TabIndex = 7;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(3, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(58, 21);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "label4";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(67, 0);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(58, 21);
            this.lblHora.TabIndex = 1;
            this.lblHora.Text = "label5";
            // 
            // flwCitas
            // 
            this.flwCitas.Location = new System.Drawing.Point(12, 140);
            this.flwCitas.Name = "flwCitas";
            this.flwCitas.Size = new System.Drawing.Size(1252, 533);
            this.flwCitas.TabIndex = 8;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "PACIENTES AGENDADOS PARA HOY";
            // 
            // btnAgregarCita
            // 
            this.btnAgregarCita.BackgroundImage = global::Terapp.UI.Properties.Resources.agregar_cita;
            this.btnAgregarCita.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAgregarCita.Location = new System.Drawing.Point(988, 89);
            this.btnAgregarCita.Name = "btnAgregarCita";
            this.btnAgregarCita.Size = new System.Drawing.Size(75, 45);
            this.btnAgregarCita.TabIndex = 13;
            this.btnAgregarCita.UseVisualStyleBackColor = true;
            this.btnAgregarCita.Click += new System.EventHandler(this.btnAgregarCita_Click);
            // 
            // btnAgendaMensual
            // 
            this.btnAgendaMensual.BackgroundImage = global::Terapp.UI.Properties.Resources.calendario;
            this.btnAgendaMensual.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAgendaMensual.Location = new System.Drawing.Point(481, 89);
            this.btnAgendaMensual.Name = "btnAgendaMensual";
            this.btnAgendaMensual.Size = new System.Drawing.Size(75, 45);
            this.btnAgendaMensual.TabIndex = 12;
            this.btnAgendaMensual.UseVisualStyleBackColor = true;
            this.btnAgendaMensual.Click += new System.EventHandler(this.btnAgendaMensual_Click);
            // 
            // btnPacienteSinCita
            // 
            this.btnPacienteSinCita.BackgroundImage = global::Terapp.UI.Properties.Resources.paciente;
            this.btnPacienteSinCita.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPacienteSinCita.Location = new System.Drawing.Point(765, 89);
            this.btnPacienteSinCita.Name = "btnPacienteSinCita";
            this.btnPacienteSinCita.Size = new System.Drawing.Size(75, 45);
            this.btnPacienteSinCita.TabIndex = 11;
            this.btnPacienteSinCita.UseVisualStyleBackColor = true;
            this.btnPacienteSinCita.Click += new System.EventHandler(this.btnPacienteSinCita_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Terapp.UI.Properties.Resources.Terapi;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(1134, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 74);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(423, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 21);
            this.label2.TabIndex = 14;
            this.label2.Text = "ABRIR AGENDA MENSUAL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(716, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 21);
            this.label3.TabIndex = 15;
            this.label3.Text = "ATENDER PACIENTE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(962, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 21);
            this.label4.TabIndex = 16;
            this.label4.Text = "AGENDAR CITA";
            // 
            // frmAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(166)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(1287, 687);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAgregarCita);
            this.Controls.Add(this.btnAgendaMensual);
            this.Controls.Add(this.btnPacienteSinCita);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flwCitas);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAgenda";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Terapi || AGENDA DEL DIA";
            this.Load += new System.EventHandler(this.frmAgenda_Load);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.FlowLayoutPanel flwCitas;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnPacienteSinCita;
        private System.Windows.Forms.Button btnAgendaMensual;
        private System.Windows.Forms.Button btnAgregarCita;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}