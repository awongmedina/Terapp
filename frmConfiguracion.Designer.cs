namespace Terapp.UI
{
    partial class frmConfiguracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfiguracion));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabTratamientos = new System.Windows.Forms.TabControl();
            this.tabAfecciones = new System.Windows.Forms.TabPage();
            this.lblErrorPadecimiento = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkEstatusAfeccion = new System.Windows.Forms.CheckBox();
            this.btnGuardarAfeccion = new System.Windows.Forms.Button();
            this.txtDescripcionAfeccion = new System.Windows.Forms.TextBox();
            this.txtNombreAfeccion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblErrorTratamiento = new System.Windows.Forms.Label();
            this.btnGuardarTipoTratamiento = new System.Windows.Forms.Button();
            this.chkEstatusTratamiento = new System.Windows.Forms.CheckBox();
            this.txtDescripcionTratamiento = new System.Windows.Forms.TextBox();
            this.txtNombreTratamiento = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabCalendario = new System.Windows.Forms.TabPage();
            this.lblErrorPacientes = new System.Windows.Forms.Label();
            this.btnGuardarCalendario = new System.Windows.Forms.Button();
            this.txtPacientesSimultaneos = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timerError = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            this.tabTratamientos.SuspendLayout();
            this.tabAfecciones.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabCalendario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblFecha);
            this.flowLayoutPanel1.Controls.Add(this.lblHora);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(13, 13);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(463, 58);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(3, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(58, 21);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "label1";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(67, 0);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(58, 21);
            this.lblHora.TabIndex = 1;
            this.lblHora.Text = "label2";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabTratamientos
            // 
            this.tabTratamientos.Controls.Add(this.tabAfecciones);
            this.tabTratamientos.Controls.Add(this.tabPage2);
            this.tabTratamientos.Controls.Add(this.tabCalendario);
            this.tabTratamientos.Location = new System.Drawing.Point(13, 172);
            this.tabTratamientos.Name = "tabTratamientos";
            this.tabTratamientos.SelectedIndex = 0;
            this.tabTratamientos.Size = new System.Drawing.Size(1258, 629);
            this.tabTratamientos.TabIndex = 2;
            // 
            // tabAfecciones
            // 
            this.tabAfecciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(166)))), ((int)(((byte)(234)))));
            this.tabAfecciones.Controls.Add(this.lblErrorPadecimiento);
            this.tabAfecciones.Controls.Add(this.label4);
            this.tabAfecciones.Controls.Add(this.chkEstatusAfeccion);
            this.tabAfecciones.Controls.Add(this.btnGuardarAfeccion);
            this.tabAfecciones.Controls.Add(this.txtDescripcionAfeccion);
            this.tabAfecciones.Controls.Add(this.txtNombreAfeccion);
            this.tabAfecciones.Controls.Add(this.label3);
            this.tabAfecciones.Controls.Add(this.label2);
            this.tabAfecciones.Location = new System.Drawing.Point(4, 30);
            this.tabAfecciones.Name = "tabAfecciones";
            this.tabAfecciones.Padding = new System.Windows.Forms.Padding(3);
            this.tabAfecciones.Size = new System.Drawing.Size(1250, 595);
            this.tabAfecciones.TabIndex = 0;
            this.tabAfecciones.Text = "AGREGAR PADECIMIENTO";
            // 
            // lblErrorPadecimiento
            // 
            this.lblErrorPadecimiento.AutoSize = true;
            this.lblErrorPadecimiento.Font = new System.Drawing.Font("Franklin Gothic Book", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorPadecimiento.ForeColor = System.Drawing.Color.Red;
            this.lblErrorPadecimiento.Location = new System.Drawing.Point(377, 149);
            this.lblErrorPadecimiento.Name = "lblErrorPadecimiento";
            this.lblErrorPadecimiento.Size = new System.Drawing.Size(0, 28);
            this.lblErrorPadecimiento.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Franklin Gothic Book", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(451, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(389, 37);
            this.label4.TabIndex = 6;
            this.label4.Text = "AGREGAR PADECIMIENTO";
            // 
            // chkEstatusAfeccion
            // 
            this.chkEstatusAfeccion.AutoSize = true;
            this.chkEstatusAfeccion.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.chkEstatusAfeccion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkEstatusAfeccion.Font = new System.Drawing.Font("Franklin Gothic Book", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEstatusAfeccion.Location = new System.Drawing.Point(1064, 92);
            this.chkEstatusAfeccion.Name = "chkEstatusAfeccion";
            this.chkEstatusAfeccion.Size = new System.Drawing.Size(150, 39);
            this.chkEstatusAfeccion.TabIndex = 5;
            this.chkEstatusAfeccion.Text = "ACTIVO ?";
            this.chkEstatusAfeccion.UseVisualStyleBackColor = true;
            this.chkEstatusAfeccion.CheckedChanged += new System.EventHandler(this.chkEstatusAfeccion_CheckedChanged);
            // 
            // btnGuardarAfeccion
            // 
            this.btnGuardarAfeccion.BackgroundImage = global::Terapp.UI.Properties.Resources.guardar;
            this.btnGuardarAfeccion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGuardarAfeccion.Location = new System.Drawing.Point(609, 512);
            this.btnGuardarAfeccion.Name = "btnGuardarAfeccion";
            this.btnGuardarAfeccion.Size = new System.Drawing.Size(107, 67);
            this.btnGuardarAfeccion.TabIndex = 4;
            this.btnGuardarAfeccion.UseVisualStyleBackColor = true;
            this.btnGuardarAfeccion.Click += new System.EventHandler(this.btnGuardarAfeccion_Click);
            // 
            // txtDescripcionAfeccion
            // 
            this.txtDescripcionAfeccion.Location = new System.Drawing.Point(237, 266);
            this.txtDescripcionAfeccion.Multiline = true;
            this.txtDescripcionAfeccion.Name = "txtDescripcionAfeccion";
            this.txtDescripcionAfeccion.Size = new System.Drawing.Size(977, 207);
            this.txtDescripcionAfeccion.TabIndex = 3;
            // 
            // txtNombreAfeccion
            // 
            this.txtNombreAfeccion.Location = new System.Drawing.Point(237, 192);
            this.txtNombreAfeccion.Name = "txtNombreAfeccion";
            this.txtNombreAfeccion.Size = new System.Drawing.Size(977, 26);
            this.txtNombreAfeccion.TabIndex = 2;
            this.txtNombreAfeccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreAfeccion_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "DESCRIPCION";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "NOMBRE CLINICO";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(166)))), ((int)(((byte)(234)))));
            this.tabPage2.Controls.Add(this.lblErrorTratamiento);
            this.tabPage2.Controls.Add(this.btnGuardarTipoTratamiento);
            this.tabPage2.Controls.Add(this.chkEstatusTratamiento);
            this.tabPage2.Controls.Add(this.txtDescripcionTratamiento);
            this.tabPage2.Controls.Add(this.txtNombreTratamiento);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1250, 595);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "AGREGAR TIPO DE TRATAMIENTO";
            // 
            // lblErrorTratamiento
            // 
            this.lblErrorTratamiento.AutoSize = true;
            this.lblErrorTratamiento.Font = new System.Drawing.Font("Franklin Gothic Book", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorTratamiento.ForeColor = System.Drawing.Color.Red;
            this.lblErrorTratamiento.Location = new System.Drawing.Point(377, 149);
            this.lblErrorTratamiento.Name = "lblErrorTratamiento";
            this.lblErrorTratamiento.Size = new System.Drawing.Size(0, 28);
            this.lblErrorTratamiento.TabIndex = 7;
            // 
            // btnGuardarTipoTratamiento
            // 
            this.btnGuardarTipoTratamiento.BackgroundImage = global::Terapp.UI.Properties.Resources.guardar;
            this.btnGuardarTipoTratamiento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGuardarTipoTratamiento.Location = new System.Drawing.Point(643, 507);
            this.btnGuardarTipoTratamiento.Name = "btnGuardarTipoTratamiento";
            this.btnGuardarTipoTratamiento.Size = new System.Drawing.Size(107, 67);
            this.btnGuardarTipoTratamiento.TabIndex = 6;
            this.btnGuardarTipoTratamiento.UseVisualStyleBackColor = true;
            this.btnGuardarTipoTratamiento.Click += new System.EventHandler(this.btnGuardarTipoTratamiento_Click);
            // 
            // chkEstatusTratamiento
            // 
            this.chkEstatusTratamiento.AutoSize = true;
            this.chkEstatusTratamiento.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkEstatusTratamiento.Font = new System.Drawing.Font("Franklin Gothic Book", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEstatusTratamiento.Location = new System.Drawing.Point(1064, 92);
            this.chkEstatusTratamiento.Name = "chkEstatusTratamiento";
            this.chkEstatusTratamiento.Size = new System.Drawing.Size(150, 39);
            this.chkEstatusTratamiento.TabIndex = 5;
            this.chkEstatusTratamiento.Text = "ACTIVO ?";
            this.chkEstatusTratamiento.UseVisualStyleBackColor = true;
            this.chkEstatusTratamiento.CheckedChanged += new System.EventHandler(this.chkEstatusTratamiento_CheckedChanged);
            // 
            // txtDescripcionTratamiento
            // 
            this.txtDescripcionTratamiento.Location = new System.Drawing.Point(237, 266);
            this.txtDescripcionTratamiento.Multiline = true;
            this.txtDescripcionTratamiento.Name = "txtDescripcionTratamiento";
            this.txtDescripcionTratamiento.Size = new System.Drawing.Size(977, 207);
            this.txtDescripcionTratamiento.TabIndex = 4;
            // 
            // txtNombreTratamiento
            // 
            this.txtNombreTratamiento.Location = new System.Drawing.Point(237, 192);
            this.txtNombreTratamiento.Name = "txtNombreTratamiento";
            this.txtNombreTratamiento.Size = new System.Drawing.Size(977, 26);
            this.txtNombreTratamiento.TabIndex = 3;
            this.txtNombreTratamiento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreTratamiento_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 257);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 21);
            this.label7.TabIndex = 2;
            this.label7.Text = "DESCRIPCION";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 21);
            this.label6.TabIndex = 1;
            this.label6.Text = "NOMBRE CLINICO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Franklin Gothic Book", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(378, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(498, 37);
            this.label5.TabIndex = 0;
            this.label5.Text = "AGERGAR TIPO DE TRATAMIENTO";
            // 
            // tabCalendario
            // 
            this.tabCalendario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(166)))), ((int)(((byte)(234)))));
            this.tabCalendario.Controls.Add(this.lblErrorPacientes);
            this.tabCalendario.Controls.Add(this.btnGuardarCalendario);
            this.tabCalendario.Controls.Add(this.txtPacientesSimultaneos);
            this.tabCalendario.Controls.Add(this.label8);
            this.tabCalendario.Location = new System.Drawing.Point(4, 30);
            this.tabCalendario.Name = "tabCalendario";
            this.tabCalendario.Padding = new System.Windows.Forms.Padding(3);
            this.tabCalendario.Size = new System.Drawing.Size(1250, 595);
            this.tabCalendario.TabIndex = 2;
            this.tabCalendario.Text = "CALENDARIO";
            // 
            // lblErrorPacientes
            // 
            this.lblErrorPacientes.AutoSize = true;
            this.lblErrorPacientes.Font = new System.Drawing.Font("Franklin Gothic Book", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorPacientes.ForeColor = System.Drawing.Color.Red;
            this.lblErrorPacientes.Location = new System.Drawing.Point(355, 99);
            this.lblErrorPacientes.Name = "lblErrorPacientes";
            this.lblErrorPacientes.Size = new System.Drawing.Size(0, 28);
            this.lblErrorPacientes.TabIndex = 8;
            // 
            // btnGuardarCalendario
            // 
            this.btnGuardarCalendario.BackgroundImage = global::Terapp.UI.Properties.Resources.guardar;
            this.btnGuardarCalendario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGuardarCalendario.Location = new System.Drawing.Point(577, 330);
            this.btnGuardarCalendario.Name = "btnGuardarCalendario";
            this.btnGuardarCalendario.Size = new System.Drawing.Size(107, 67);
            this.btnGuardarCalendario.TabIndex = 7;
            this.btnGuardarCalendario.UseVisualStyleBackColor = true;
            this.btnGuardarCalendario.Click += new System.EventHandler(this.btnGuardarCalendario_Click);
            // 
            // txtPacientesSimultaneos
            // 
            this.txtPacientesSimultaneos.Font = new System.Drawing.Font("Franklin Gothic Book", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPacientesSimultaneos.Location = new System.Drawing.Point(533, 152);
            this.txtPacientesSimultaneos.Name = "txtPacientesSimultaneos";
            this.txtPacientesSimultaneos.Size = new System.Drawing.Size(186, 32);
            this.txtPacientesSimultaneos.TabIndex = 2;
            this.txtPacientesSimultaneos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPacientesSimultaneos_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Franklin Gothic Book", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(294, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(714, 34);
            this.label8.TabIndex = 1;
            this.label8.Text = "CONFIGURAR NUMERO DE PACIENTES A LA MISMA HORA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Book", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(468, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(498, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "MANTENIMIENTO DE CATALOGOS";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::Terapp.UI.Properties.Resources.Terapi;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(1141, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(130, 74);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // timerError
            // 
            this.timerError.Tick += new System.EventHandler(this.timerError_Tick);
            // 
            // frmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(166)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(1283, 869);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabTratamientos);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmConfiguracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Terapi || REGISTRO DE PACIENTE";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tabTratamientos.ResumeLayout(false);
            this.tabAfecciones.ResumeLayout(false);
            this.tabAfecciones.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabCalendario.ResumeLayout(false);
            this.tabCalendario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabControl tabTratamientos;
        private System.Windows.Forms.TabPage tabAfecciones;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkEstatusAfeccion;
        private System.Windows.Forms.Button btnGuardarAfeccion;
        private System.Windows.Forms.TextBox txtDescripcionAfeccion;
        private System.Windows.Forms.TextBox txtNombreAfeccion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkEstatusTratamiento;
        private System.Windows.Forms.TextBox txtDescripcionTratamiento;
        private System.Windows.Forms.TextBox txtNombreTratamiento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGuardarTipoTratamiento;
        private System.Windows.Forms.TabPage tabCalendario;
        private System.Windows.Forms.TextBox txtPacientesSimultaneos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblErrorPadecimiento;
        private System.Windows.Forms.Label lblErrorTratamiento;
        private System.Windows.Forms.Button btnGuardarCalendario;
        private System.Windows.Forms.Label lblErrorPacientes;
        private System.Windows.Forms.Timer timerError;
    }
}