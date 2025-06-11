namespace Terapp.UI
{
    partial class frmMain
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnAgenda = new System.Windows.Forms.Button();
            this.btnExpedienteClinico = new System.Windows.Forms.Button();
            this.btnRegistroPaciente = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAgendaPacientes = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgenda
            // 
            this.btnAgenda.BackgroundImage = global::Terapp.UI.Properties.Resources.calendario;
            this.btnAgenda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgenda.Location = new System.Drawing.Point(19, 410);
            this.btnAgenda.Name = "btnAgenda";
            this.btnAgenda.Size = new System.Drawing.Size(149, 160);
            this.btnAgenda.TabIndex = 0;
            this.btnAgenda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgenda.UseVisualStyleBackColor = true;
            this.btnAgenda.Click += new System.EventHandler(this.btnAgenda_Click);
            // 
            // btnExpedienteClinico
            // 
            this.btnExpedienteClinico.BackgroundImage = global::Terapp.UI.Properties.Resources.exp_clinico;
            this.btnExpedienteClinico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExpedienteClinico.Location = new System.Drawing.Point(258, 410);
            this.btnExpedienteClinico.Name = "btnExpedienteClinico";
            this.btnExpedienteClinico.Size = new System.Drawing.Size(149, 160);
            this.btnExpedienteClinico.TabIndex = 1;
            this.btnExpedienteClinico.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExpedienteClinico.UseVisualStyleBackColor = true;
            this.btnExpedienteClinico.Click += new System.EventHandler(this.btnExpedienteClinico_Click);
            // 
            // btnRegistroPaciente
            // 
            this.btnRegistroPaciente.BackgroundImage = global::Terapp.UI.Properties.Resources.registrar_paciente;
            this.btnRegistroPaciente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRegistroPaciente.Location = new System.Drawing.Point(537, 410);
            this.btnRegistroPaciente.Name = "btnRegistroPaciente";
            this.btnRegistroPaciente.Size = new System.Drawing.Size(149, 160);
            this.btnRegistroPaciente.TabIndex = 2;
            this.btnRegistroPaciente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRegistroPaciente.UseVisualStyleBackColor = true;
            this.btnRegistroPaciente.Click += new System.EventHandler(this.btnRegistroPaciente_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.BackgroundImage = global::Terapp.UI.Properties.Resources.config;
            this.btnConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfig.Location = new System.Drawing.Point(1056, 410);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(149, 160);
            this.btnConfig.TabIndex = 3;
            this.btnConfig.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Book", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 583);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "AGENDA DIARIA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Book", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(297, 584);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "PACIENTE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Book", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(553, 584);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "NUEVO INGRESO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Franklin Gothic Book", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1070, 583);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "CONFIGURACION";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.lblFecha);
            this.flowLayoutPanel2.Controls.Add(this.lblHora);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(12, 13);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(287, 44);
            this.flowLayoutPanel2.TabIndex = 6;
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
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Terapp.UI.Properties.Resources.Terapi;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(354, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(529, 275);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnAgendaPacientes
            // 
            this.btnAgendaPacientes.BackgroundImage = global::Terapp.UI.Properties.Resources.agenda_pacientes;
            this.btnAgendaPacientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgendaPacientes.Location = new System.Drawing.Point(794, 410);
            this.btnAgendaPacientes.Name = "btnAgendaPacientes";
            this.btnAgendaPacientes.Size = new System.Drawing.Size(149, 160);
            this.btnAgendaPacientes.TabIndex = 8;
            this.btnAgendaPacientes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgendaPacientes.UseVisualStyleBackColor = true;
            this.btnAgendaPacientes.Click += new System.EventHandler(this.btnAgendaPacientes_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Franklin Gothic Book", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(791, 583);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "AGENDA DE PACIENTES";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(166)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(1258, 660);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAgendaPacientes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.btnRegistroPaciente);
            this.Controls.Add(this.btnExpedienteClinico);
            this.Controls.Add(this.btnAgenda);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Terapi || PAGINA PRINCIPAL";
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAgenda;
        private System.Windows.Forms.Button btnExpedienteClinico;
        private System.Windows.Forms.Button btnRegistroPaciente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAgendaPacientes;
        private System.Windows.Forms.Label label5;
    }
}

