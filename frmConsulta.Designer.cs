namespace Terapp.UI
{
    partial class frmConsulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsulta));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabDatosPaciente = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblError = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblExpediente = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOcupacion = new System.Windows.Forms.TextBox();
            this.txtNombrePaciente = new System.Windows.Forms.TextBox();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabMotivoConsulta = new System.Windows.Forms.TabPage();
            this.lblError2 = new System.Windows.Forms.Label();
            this.txtValoracion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMotivoConsulta = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.flwEscaladolor = new System.Windows.Forms.FlowLayoutPanel();
            this.tabTratamiento = new System.Windows.Forms.TabPage();
            this.lblErrorTiempo = new System.Windows.Forms.Label();
            this.cboTratamientos = new System.Windows.Forms.ComboBox();
            this.dgvTratamientos = new System.Windows.Forms.DataGridView();
            this.txtComentariosTratamiento = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTiempoTratamiento = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabAdjunto = new System.Windows.Forms.TabPage();
            this.timeError = new System.Windows.Forms.Timer(this.components);
            this.flwAdjuntos = new System.Windows.Forms.FlowLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAdjunto = new System.Windows.Forms.TextBox();
            this.btnAdjuntar = new System.Windows.Forms.Button();
            this.btnCerrarConsulta = new System.Windows.Forms.Button();
            this.btnGenerarPDF = new System.Windows.Forms.Button();
            this.btnAgendarConsulta = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCerrar2 = new System.Windows.Forms.Button();
            this.btnAgendar2 = new System.Windows.Forms.Button();
            this.btnRecibo2 = new System.Windows.Forms.Button();
            this.btnGuardar2 = new System.Windows.Forms.Button();
            this.escala1 = new System.Windows.Forms.PictureBox();
            this.escala2 = new System.Windows.Forms.PictureBox();
            this.escala3 = new System.Windows.Forms.PictureBox();
            this.escala4 = new System.Windows.Forms.PictureBox();
            this.escala5 = new System.Windows.Forms.PictureBox();
            this.escala6 = new System.Windows.Forms.PictureBox();
            this.escala7 = new System.Windows.Forms.PictureBox();
            this.escala8 = new System.Windows.Forms.PictureBox();
            this.escala9 = new System.Windows.Forms.PictureBox();
            this.escala10 = new System.Windows.Forms.PictureBox();
            this.canvasMotivoConsulta = new System.Windows.Forms.Panel();
            this.btnGuardarTratamiento = new System.Windows.Forms.Button();
            this.canvasTratamiento = new System.Windows.Forms.Panel();
            this.tabControl.SuspendLayout();
            this.tabDatosPaciente.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabMotivoConsulta.SuspendLayout();
            this.flwEscaladolor.SuspendLayout();
            this.tabTratamiento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTratamientos)).BeginInit();
            this.tabAdjunto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.escala1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.escala2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.escala3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.escala4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.escala5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.escala6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.escala7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.escala8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.escala9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.escala10)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabDatosPaciente);
            this.tabControl.Controls.Add(this.tabMotivoConsulta);
            this.tabControl.Controls.Add(this.tabTratamiento);
            this.tabControl.Controls.Add(this.tabAdjunto);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1272, 751);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabDatosPaciente
            // 
            this.tabDatosPaciente.AutoScroll = true;
            this.tabDatosPaciente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(166)))), ((int)(((byte)(234)))));
            this.tabDatosPaciente.Controls.Add(this.panel1);
            this.tabDatosPaciente.Location = new System.Drawing.Point(4, 30);
            this.tabDatosPaciente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabDatosPaciente.Name = "tabDatosPaciente";
            this.tabDatosPaciente.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabDatosPaciente.Size = new System.Drawing.Size(1264, 717);
            this.tabDatosPaciente.TabIndex = 0;
            this.tabDatosPaciente.Text = "DATOS GENERALES";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAdjuntar);
            this.panel1.Controls.Add(this.txtAdjunto);
            this.panel1.Controls.Add(this.btnCerrarConsulta);
            this.panel1.Controls.Add(this.lblError);
            this.panel1.Controls.Add(this.btnGenerarPDF);
            this.panel1.Controls.Add(this.btnAgendarConsulta);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.lblExpediente);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtTelefono);
            this.panel1.Controls.Add(this.dtpFechaNacimiento);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtOcupacion);
            this.panel1.Controls.Add(this.txtNombrePaciente);
            this.panel1.Controls.Add(this.txtEdad);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1218, 698);
            this.panel1.TabIndex = 14;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Franklin Gothic Book", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(438, 60);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(406, 34);
            this.lblError.TabIndex = 16;
            this.lblError.Text = "NO SE ENCONTRO EL PACIENTE";
            this.lblError.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Franklin Gothic Book", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(389, 37);
            this.label5.TabIndex = 4;
            this.label5.Text = "NUMERO DE EXPEDIENTE";
            // 
            // lblExpediente
            // 
            this.lblExpediente.AutoSize = true;
            this.lblExpediente.Font = new System.Drawing.Font("Franklin Gothic Book", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpediente.Location = new System.Drawing.Point(467, 16);
            this.lblExpediente.Name = "lblExpediente";
            this.lblExpediente.Size = new System.Drawing.Size(0, 37);
            this.lblExpediente.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Book", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "NOMBRE";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Franklin Gothic Book", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(349, 377);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(800, 38);
            this.txtTelefono.TabIndex = 8;
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Font = new System.Drawing.Font("Franklin Gothic Book", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(349, 167);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(800, 38);
            this.dtpFechaNacimiento.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Franklin Gothic Book", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 377);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 34);
            this.label4.TabIndex = 3;
            this.label4.Text = "TELEFONO";
            // 
            // txtOcupacion
            // 
            this.txtOcupacion.Font = new System.Drawing.Font("Franklin Gothic Book", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOcupacion.Location = new System.Drawing.Point(349, 307);
            this.txtOcupacion.Name = "txtOcupacion";
            this.txtOcupacion.Size = new System.Drawing.Size(800, 38);
            this.txtOcupacion.TabIndex = 7;
            // 
            // txtNombrePaciente
            // 
            this.txtNombrePaciente.Font = new System.Drawing.Font("Franklin Gothic Book", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombrePaciente.Location = new System.Drawing.Point(349, 97);
            this.txtNombrePaciente.Name = "txtNombrePaciente";
            this.txtNombrePaciente.Size = new System.Drawing.Size(543, 38);
            this.txtNombrePaciente.TabIndex = 5;
            this.txtNombrePaciente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombrePaciente_KeyPress);
            // 
            // txtEdad
            // 
            this.txtEdad.Font = new System.Drawing.Font("Franklin Gothic Book", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEdad.Location = new System.Drawing.Point(349, 238);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(800, 38);
            this.txtEdad.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Book", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 310);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 34);
            this.label2.TabIndex = 1;
            this.label2.Text = "OCUPACION";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Franklin Gothic Book", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(30, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(205, 34);
            this.label6.TabIndex = 9;
            this.label6.Text = "FECHA DE NAC.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Book", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 34);
            this.label3.TabIndex = 2;
            this.label3.Text = "EDAD";
            // 
            // tabMotivoConsulta
            // 
            this.tabMotivoConsulta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(166)))), ((int)(((byte)(234)))));
            this.tabMotivoConsulta.Controls.Add(this.lblError2);
            this.tabMotivoConsulta.Controls.Add(this.txtValoracion);
            this.tabMotivoConsulta.Controls.Add(this.label7);
            this.tabMotivoConsulta.Controls.Add(this.txtMotivoConsulta);
            this.tabMotivoConsulta.Controls.Add(this.label9);
            this.tabMotivoConsulta.Controls.Add(this.label8);
            this.tabMotivoConsulta.Controls.Add(this.flwEscaladolor);
            this.tabMotivoConsulta.Controls.Add(this.btnCerrar2);
            this.tabMotivoConsulta.Controls.Add(this.btnAgendar2);
            this.tabMotivoConsulta.Controls.Add(this.btnRecibo2);
            this.tabMotivoConsulta.Controls.Add(this.btnGuardar2);
            this.tabMotivoConsulta.Controls.Add(this.canvasMotivoConsulta);
            this.tabMotivoConsulta.Location = new System.Drawing.Point(4, 30);
            this.tabMotivoConsulta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabMotivoConsulta.Name = "tabMotivoConsulta";
            this.tabMotivoConsulta.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabMotivoConsulta.Size = new System.Drawing.Size(1264, 717);
            this.tabMotivoConsulta.TabIndex = 1;
            this.tabMotivoConsulta.Text = "MOTIVO DE CONSULTA";
            // 
            // lblError2
            // 
            this.lblError2.AutoSize = true;
            this.lblError2.Font = new System.Drawing.Font("Franklin Gothic Book", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError2.ForeColor = System.Drawing.Color.Red;
            this.lblError2.Location = new System.Drawing.Point(808, 349);
            this.lblError2.Name = "lblError2";
            this.lblError2.Size = new System.Drawing.Size(406, 34);
            this.lblError2.TabIndex = 17;
            this.lblError2.Text = "NO SE ENCONTRO EL PACIENTE";
            this.lblError2.Visible = false;
            // 
            // txtValoracion
            // 
            this.txtValoracion.Location = new System.Drawing.Point(806, 169);
            this.txtValoracion.Multiline = true;
            this.txtValoracion.Name = "txtValoracion";
            this.txtValoracion.Size = new System.Drawing.Size(450, 77);
            this.txtValoracion.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(978, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 21);
            this.label7.TabIndex = 7;
            this.label7.Text = "VALORACION";
            // 
            // txtMotivoConsulta
            // 
            this.txtMotivoConsulta.Location = new System.Drawing.Point(806, 44);
            this.txtMotivoConsulta.Multiline = true;
            this.txtMotivoConsulta.Name = "txtMotivoConsulta";
            this.txtMotivoConsulta.Size = new System.Drawing.Size(450, 77);
            this.txtMotivoConsulta.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(954, 258);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(153, 21);
            this.label9.TabIndex = 3;
            this.label9.Text = "ESCALA DE DOLOR";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(938, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(207, 21);
            this.label8.TabIndex = 2;
            this.label8.Text = "MOTIVO DE LA CONSULTA";
            // 
            // flwEscaladolor
            // 
            this.flwEscaladolor.Controls.Add(this.escala1);
            this.flwEscaladolor.Controls.Add(this.escala2);
            this.flwEscaladolor.Controls.Add(this.escala3);
            this.flwEscaladolor.Controls.Add(this.escala4);
            this.flwEscaladolor.Controls.Add(this.escala5);
            this.flwEscaladolor.Controls.Add(this.escala6);
            this.flwEscaladolor.Controls.Add(this.escala7);
            this.flwEscaladolor.Controls.Add(this.escala8);
            this.flwEscaladolor.Controls.Add(this.escala9);
            this.flwEscaladolor.Controls.Add(this.escala10);
            this.flwEscaladolor.Location = new System.Drawing.Point(811, 289);
            this.flwEscaladolor.Name = "flwEscaladolor";
            this.flwEscaladolor.Size = new System.Drawing.Size(445, 39);
            this.flwEscaladolor.TabIndex = 1;
            // 
            // tabTratamiento
            // 
            this.tabTratamiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(166)))), ((int)(((byte)(234)))));
            this.tabTratamiento.Controls.Add(this.lblErrorTiempo);
            this.tabTratamiento.Controls.Add(this.cboTratamientos);
            this.tabTratamiento.Controls.Add(this.dgvTratamientos);
            this.tabTratamiento.Controls.Add(this.txtComentariosTratamiento);
            this.tabTratamiento.Controls.Add(this.label13);
            this.tabTratamiento.Controls.Add(this.label12);
            this.tabTratamiento.Controls.Add(this.txtTiempoTratamiento);
            this.tabTratamiento.Controls.Add(this.label11);
            this.tabTratamiento.Controls.Add(this.btnGuardarTratamiento);
            this.tabTratamiento.Controls.Add(this.canvasTratamiento);
            this.tabTratamiento.Location = new System.Drawing.Point(4, 30);
            this.tabTratamiento.Name = "tabTratamiento";
            this.tabTratamiento.Padding = new System.Windows.Forms.Padding(3);
            this.tabTratamiento.Size = new System.Drawing.Size(1264, 717);
            this.tabTratamiento.TabIndex = 3;
            this.tabTratamiento.Text = "TRATAMIENTO";
            // 
            // lblErrorTiempo
            // 
            this.lblErrorTiempo.AutoSize = true;
            this.lblErrorTiempo.Font = new System.Drawing.Font("Franklin Gothic Book", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorTiempo.ForeColor = System.Drawing.Color.Red;
            this.lblErrorTiempo.Location = new System.Drawing.Point(570, 98);
            this.lblErrorTiempo.Name = "lblErrorTiempo";
            this.lblErrorTiempo.Size = new System.Drawing.Size(0, 16);
            this.lblErrorTiempo.TabIndex = 10;
            // 
            // cboTratamientos
            // 
            this.cboTratamientos.FormattingEnabled = true;
            this.cboTratamientos.Location = new System.Drawing.Point(1112, 178);
            this.cboTratamientos.Name = "cboTratamientos";
            this.cboTratamientos.Size = new System.Drawing.Size(144, 29);
            this.cboTratamientos.TabIndex = 9;
            this.cboTratamientos.Enter += new System.EventHandler(this.txtTiempoTratamiento_Enter);
            // 
            // dgvTratamientos
            // 
            this.dgvTratamientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTratamientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTratamientos.Location = new System.Drawing.Point(576, 20);
            this.dgvTratamientos.Name = "dgvTratamientos";
            this.dgvTratamientos.Size = new System.Drawing.Size(524, 689);
            this.dgvTratamientos.TabIndex = 7;
            this.dgvTratamientos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTratamientos_CellClick);
            // 
            // txtComentariosTratamiento
            // 
            this.txtComentariosTratamiento.Location = new System.Drawing.Point(1112, 278);
            this.txtComentariosTratamiento.Multiline = true;
            this.txtComentariosTratamiento.Name = "txtComentariosTratamiento";
            this.txtComentariosTratamiento.Size = new System.Drawing.Size(144, 144);
            this.txtComentariosTratamiento.TabIndex = 6;
            this.txtComentariosTratamiento.Enter += new System.EventHandler(this.txtTiempoTratamiento_Enter);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1122, 240);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(123, 21);
            this.label13.TabIndex = 5;
            this.label13.Text = "COMENTARIOS";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1122, 143);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 21);
            this.label12.TabIndex = 3;
            this.label12.Text = "TRATAMIENTO";
            // 
            // txtTiempoTratamiento
            // 
            this.txtTiempoTratamiento.Location = new System.Drawing.Point(1112, 78);
            this.txtTiempoTratamiento.Name = "txtTiempoTratamiento";
            this.txtTiempoTratamiento.Size = new System.Drawing.Size(139, 26);
            this.txtTiempoTratamiento.TabIndex = 2;
            this.txtTiempoTratamiento.Enter += new System.EventHandler(this.txtTiempoTratamiento_Enter);
            this.txtTiempoTratamiento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTiempoTratamiento_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1150, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 21);
            this.label11.TabIndex = 1;
            this.label11.Text = "TIEMPO";
            // 
            // tabAdjunto
            // 
            this.tabAdjunto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(166)))), ((int)(((byte)(234)))));
            this.tabAdjunto.Controls.Add(this.label10);
            this.tabAdjunto.Controls.Add(this.flwAdjuntos);
            this.tabAdjunto.Location = new System.Drawing.Point(4, 30);
            this.tabAdjunto.Name = "tabAdjunto";
            this.tabAdjunto.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdjunto.Size = new System.Drawing.Size(1264, 717);
            this.tabAdjunto.TabIndex = 4;
            this.tabAdjunto.Text = "ADJUNTOS";
            // 
            // timeError
            // 
            this.timeError.Tick += new System.EventHandler(this.timeError_Tick);
            // 
            // flwAdjuntos
            // 
            this.flwAdjuntos.Location = new System.Drawing.Point(8, 96);
            this.flwAdjuntos.Name = "flwAdjuntos";
            this.flwAdjuntos.Size = new System.Drawing.Size(1236, 613);
            this.flwAdjuntos.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Franklin Gothic Book", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(397, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(449, 30);
            this.label10.TabIndex = 1;
            this.label10.Text = "ARCHIVOS ADJUNTOS DE LA CONSULTA";
            // 
            // txtAdjunto
            // 
            this.txtAdjunto.Font = new System.Drawing.Font("Franklin Gothic Book", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdjunto.Location = new System.Drawing.Point(349, 452);
            this.txtAdjunto.Name = "txtAdjunto";
            this.txtAdjunto.Size = new System.Drawing.Size(800, 38);
            this.txtAdjunto.TabIndex = 20;
            // 
            // btnAdjuntar
            // 
            this.btnAdjuntar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdjuntar.Location = new System.Drawing.Point(36, 452);
            this.btnAdjuntar.Name = "btnAdjuntar";
            this.btnAdjuntar.Size = new System.Drawing.Size(188, 40);
            this.btnAdjuntar.TabIndex = 21;
            this.btnAdjuntar.Text = "ADJUNTAR ARCHIVO";
            this.btnAdjuntar.UseVisualStyleBackColor = true;
            this.btnAdjuntar.Click += new System.EventHandler(this.btnAdjuntar_Click);
            // 
            // btnCerrarConsulta
            // 
            this.btnCerrarConsulta.BackgroundImage = global::Terapp.UI.Properties.Resources.cancelar_evento;
            this.btnCerrarConsulta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCerrarConsulta.Location = new System.Drawing.Point(716, 610);
            this.btnCerrarConsulta.Name = "btnCerrarConsulta";
            this.btnCerrarConsulta.Size = new System.Drawing.Size(128, 85);
            this.btnCerrarConsulta.TabIndex = 18;
            this.btnCerrarConsulta.UseVisualStyleBackColor = true;
            this.btnCerrarConsulta.Click += new System.EventHandler(this.btnCerrarConsulta_Click);
            // 
            // btnGenerarPDF
            // 
            this.btnGenerarPDF.BackgroundImage = global::Terapp.UI.Properties.Resources.pdf;
            this.btnGenerarPDF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGenerarPDF.Location = new System.Drawing.Point(1059, 613);
            this.btnGenerarPDF.Name = "btnGenerarPDF";
            this.btnGenerarPDF.Size = new System.Drawing.Size(128, 85);
            this.btnGenerarPDF.TabIndex = 15;
            this.btnGenerarPDF.UseVisualStyleBackColor = true;
            this.btnGenerarPDF.Click += new System.EventHandler(this.btnGenerarPDF_Click);
            // 
            // btnAgendarConsulta
            // 
            this.btnAgendarConsulta.BackgroundImage = global::Terapp.UI.Properties.Resources.agregar_cita;
            this.btnAgendarConsulta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAgendarConsulta.Location = new System.Drawing.Point(372, 613);
            this.btnAgendarConsulta.Name = "btnAgendarConsulta";
            this.btnAgendarConsulta.Size = new System.Drawing.Size(128, 85);
            this.btnAgendarConsulta.TabIndex = 14;
            this.btnAgendarConsulta.UseVisualStyleBackColor = true;
            this.btnAgendarConsulta.Click += new System.EventHandler(this.btnAgendarConsulta_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImage = global::Terapp.UI.Properties.Resources.buscar;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscar.Location = new System.Drawing.Point(1002, 84);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(114, 66);
            this.btnBuscar.TabIndex = 13;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackgroundImage = global::Terapp.UI.Properties.Resources.guardar;
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGuardar.Location = new System.Drawing.Point(36, 610);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(128, 85);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCerrar2
            // 
            this.btnCerrar2.BackgroundImage = global::Terapp.UI.Properties.Resources.cancelar_evento;
            this.btnCerrar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCerrar2.Location = new System.Drawing.Point(821, 555);
            this.btnCerrar2.Name = "btnCerrar2";
            this.btnCerrar2.Size = new System.Drawing.Size(128, 85);
            this.btnCerrar2.TabIndex = 11;
            this.btnCerrar2.UseVisualStyleBackColor = true;
            this.btnCerrar2.Click += new System.EventHandler(this.btnCerrarConsulta_Click);
            // 
            // btnAgendar2
            // 
            this.btnAgendar2.BackgroundImage = global::Terapp.UI.Properties.Resources.calendario;
            this.btnAgendar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAgendar2.Location = new System.Drawing.Point(1079, 405);
            this.btnAgendar2.Name = "btnAgendar2";
            this.btnAgendar2.Size = new System.Drawing.Size(128, 85);
            this.btnAgendar2.TabIndex = 10;
            this.btnAgendar2.UseVisualStyleBackColor = true;
            this.btnAgendar2.Click += new System.EventHandler(this.btnAgendarConsulta_Click);
            // 
            // btnRecibo2
            // 
            this.btnRecibo2.BackgroundImage = global::Terapp.UI.Properties.Resources.pdf;
            this.btnRecibo2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRecibo2.Location = new System.Drawing.Point(1079, 555);
            this.btnRecibo2.Name = "btnRecibo2";
            this.btnRecibo2.Size = new System.Drawing.Size(128, 85);
            this.btnRecibo2.TabIndex = 9;
            this.btnRecibo2.UseVisualStyleBackColor = true;
            this.btnRecibo2.Click += new System.EventHandler(this.btnGenerarPDF_Click);
            // 
            // btnGuardar2
            // 
            this.btnGuardar2.BackgroundImage = global::Terapp.UI.Properties.Resources.guardar;
            this.btnGuardar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGuardar2.Location = new System.Drawing.Point(820, 405);
            this.btnGuardar2.Name = "btnGuardar2";
            this.btnGuardar2.Size = new System.Drawing.Size(128, 85);
            this.btnGuardar2.TabIndex = 8;
            this.btnGuardar2.UseVisualStyleBackColor = true;
            this.btnGuardar2.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // escala1
            // 
            this.escala1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(179)))), ((int)(((byte)(6)))));
            this.escala1.BackgroundImage = global::Terapp.UI.Properties.Resources._1;
            this.escala1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.escala1.Location = new System.Drawing.Point(3, 3);
            this.escala1.Name = "escala1";
            this.escala1.Size = new System.Drawing.Size(38, 30);
            this.escala1.TabIndex = 0;
            this.escala1.TabStop = false;
            this.escala1.Click += new System.EventHandler(this.escala1_Click);
            // 
            // escala2
            // 
            this.escala2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(250)))), ((int)(((byte)(3)))));
            this.escala2.BackgroundImage = global::Terapp.UI.Properties.Resources._2;
            this.escala2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.escala2.Location = new System.Drawing.Point(47, 3);
            this.escala2.Name = "escala2";
            this.escala2.Size = new System.Drawing.Size(38, 30);
            this.escala2.TabIndex = 1;
            this.escala2.TabStop = false;
            this.escala2.Click += new System.EventHandler(this.escala1_Click);
            // 
            // escala3
            // 
            this.escala3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(254)))), ((int)(((byte)(5)))));
            this.escala3.BackgroundImage = global::Terapp.UI.Properties.Resources._3;
            this.escala3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.escala3.Location = new System.Drawing.Point(91, 3);
            this.escala3.Name = "escala3";
            this.escala3.Size = new System.Drawing.Size(38, 30);
            this.escala3.TabIndex = 2;
            this.escala3.TabStop = false;
            this.escala3.Click += new System.EventHandler(this.escala1_Click);
            // 
            // escala4
            // 
            this.escala4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(244)))), ((int)(((byte)(4)))));
            this.escala4.BackgroundImage = global::Terapp.UI.Properties.Resources._4;
            this.escala4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.escala4.Location = new System.Drawing.Point(135, 3);
            this.escala4.Name = "escala4";
            this.escala4.Size = new System.Drawing.Size(38, 30);
            this.escala4.TabIndex = 3;
            this.escala4.TabStop = false;
            this.escala4.Click += new System.EventHandler(this.escala1_Click);
            // 
            // escala5
            // 
            this.escala5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(19)))));
            this.escala5.BackgroundImage = global::Terapp.UI.Properties.Resources._5;
            this.escala5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.escala5.Location = new System.Drawing.Point(179, 3);
            this.escala5.Name = "escala5";
            this.escala5.Size = new System.Drawing.Size(38, 30);
            this.escala5.TabIndex = 4;
            this.escala5.TabStop = false;
            this.escala5.Click += new System.EventHandler(this.escala1_Click);
            // 
            // escala6
            // 
            this.escala6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(41)))));
            this.escala6.BackgroundImage = global::Terapp.UI.Properties.Resources._6;
            this.escala6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.escala6.Location = new System.Drawing.Point(223, 3);
            this.escala6.Name = "escala6";
            this.escala6.Size = new System.Drawing.Size(38, 30);
            this.escala6.TabIndex = 5;
            this.escala6.TabStop = false;
            this.escala6.Click += new System.EventHandler(this.escala1_Click);
            // 
            // escala7
            // 
            this.escala7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(159)))), ((int)(((byte)(1)))));
            this.escala7.BackgroundImage = global::Terapp.UI.Properties.Resources._7;
            this.escala7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.escala7.Location = new System.Drawing.Point(267, 3);
            this.escala7.Name = "escala7";
            this.escala7.Size = new System.Drawing.Size(38, 30);
            this.escala7.TabIndex = 6;
            this.escala7.TabStop = false;
            this.escala7.Click += new System.EventHandler(this.escala1_Click);
            // 
            // escala8
            // 
            this.escala8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(107)))), ((int)(((byte)(2)))));
            this.escala8.BackgroundImage = global::Terapp.UI.Properties.Resources._8;
            this.escala8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.escala8.Location = new System.Drawing.Point(311, 3);
            this.escala8.Name = "escala8";
            this.escala8.Size = new System.Drawing.Size(38, 30);
            this.escala8.TabIndex = 7;
            this.escala8.TabStop = false;
            this.escala8.Click += new System.EventHandler(this.escala1_Click);
            // 
            // escala9
            // 
            this.escala9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(71)))), ((int)(((byte)(18)))));
            this.escala9.BackgroundImage = global::Terapp.UI.Properties.Resources._9;
            this.escala9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.escala9.Location = new System.Drawing.Point(355, 3);
            this.escala9.Name = "escala9";
            this.escala9.Size = new System.Drawing.Size(38, 30);
            this.escala9.TabIndex = 8;
            this.escala9.TabStop = false;
            this.escala9.Click += new System.EventHandler(this.escala1_Click);
            // 
            // escala10
            // 
            this.escala10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(33)))), ((int)(((byte)(1)))));
            this.escala10.BackgroundImage = global::Terapp.UI.Properties.Resources._10;
            this.escala10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.escala10.Location = new System.Drawing.Point(399, 3);
            this.escala10.Name = "escala10";
            this.escala10.Size = new System.Drawing.Size(38, 30);
            this.escala10.TabIndex = 9;
            this.escala10.TabStop = false;
            this.escala10.Click += new System.EventHandler(this.escala1_Click);
            // 
            // canvasMotivoConsulta
            // 
            this.canvasMotivoConsulta.BackgroundImage = global::Terapp.UI.Properties.Resources.cuerpo_humano;
            this.canvasMotivoConsulta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.canvasMotivoConsulta.Location = new System.Drawing.Point(11, 22);
            this.canvasMotivoConsulta.Name = "canvasMotivoConsulta";
            this.canvasMotivoConsulta.Size = new System.Drawing.Size(756, 673);
            this.canvasMotivoConsulta.TabIndex = 4;
            this.canvasMotivoConsulta.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvasMotivoConsulta_MouseDown);
            this.canvasMotivoConsulta.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvasMotivoConsulta_MouseMove);
            this.canvasMotivoConsulta.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvasMotivoConsulta_MouseUp);
            // 
            // btnGuardarTratamiento
            // 
            this.btnGuardarTratamiento.BackgroundImage = global::Terapp.UI.Properties.Resources.anadir;
            this.btnGuardarTratamiento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardarTratamiento.Location = new System.Drawing.Point(1143, 454);
            this.btnGuardarTratamiento.Name = "btnGuardarTratamiento";
            this.btnGuardarTratamiento.Size = new System.Drawing.Size(99, 80);
            this.btnGuardarTratamiento.TabIndex = 8;
            this.btnGuardarTratamiento.UseVisualStyleBackColor = true;
            this.btnGuardarTratamiento.Click += new System.EventHandler(this.btnGuardarTratamiento_Click);
            // 
            // canvasTratamiento
            // 
            this.canvasTratamiento.BackgroundImage = global::Terapp.UI.Properties.Resources.cuerpo_humano;
            this.canvasTratamiento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.canvasTratamiento.Location = new System.Drawing.Point(3, 41);
            this.canvasTratamiento.Name = "canvasTratamiento";
            this.canvasTratamiento.Size = new System.Drawing.Size(542, 647);
            this.canvasTratamiento.TabIndex = 0;
            this.canvasTratamiento.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvasTratamiento_MouseDown);
            this.canvasTratamiento.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvasTratamiento_MouseMove);
            this.canvasTratamiento.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvasTratamiento_MouseUp);
            // 
            // frmConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(166)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(1272, 751);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmConsulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Terapi || CONSULTA";
            this.tabControl.ResumeLayout(false);
            this.tabDatosPaciente.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabMotivoConsulta.ResumeLayout(false);
            this.tabMotivoConsulta.PerformLayout();
            this.flwEscaladolor.ResumeLayout(false);
            this.tabTratamiento.ResumeLayout(false);
            this.tabTratamiento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTratamientos)).EndInit();
            this.tabAdjunto.ResumeLayout(false);
            this.tabAdjunto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.escala1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.escala2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.escala3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.escala4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.escala5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.escala6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.escala7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.escala8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.escala9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.escala10)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabDatosPaciente;
        private System.Windows.Forms.TabPage tabMotivoConsulta;
        private System.Windows.Forms.TabPage tabTratamiento;
        private System.Windows.Forms.FlowLayoutPanel flwEscaladolor;
        private System.Windows.Forms.PictureBox escala1;
        private System.Windows.Forms.PictureBox escala2;
        private System.Windows.Forms.PictureBox escala3;
        private System.Windows.Forms.PictureBox escala4;
        private System.Windows.Forms.PictureBox escala5;
        private System.Windows.Forms.PictureBox escala6;
        private System.Windows.Forms.PictureBox escala7;
        private System.Windows.Forms.PictureBox escala8;
        private System.Windows.Forms.PictureBox escala9;
        private System.Windows.Forms.PictureBox escala10;
        private System.Windows.Forms.TextBox txtMotivoConsulta;
        private System.Windows.Forms.Panel canvasMotivoConsulta;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnGuardarTratamiento;
        private System.Windows.Forms.DataGridView dgvTratamientos;
        private System.Windows.Forms.TextBox txtComentariosTratamiento;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTiempoTratamiento;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel canvasTratamiento;
        private System.Windows.Forms.ComboBox cboTratamientos;
        private System.Windows.Forms.Label lblErrorTiempo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnGenerarPDF;
        private System.Windows.Forms.Button btnAgendarConsulta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblExpediente;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOcupacion;
        private System.Windows.Forms.TextBox txtNombrePaciente;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.TextBox txtValoracion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer timeError;
        private System.Windows.Forms.Button btnCerrarConsulta;
        private System.Windows.Forms.Button btnCerrar2;
        private System.Windows.Forms.Button btnAgendar2;
        private System.Windows.Forms.Button btnRecibo2;
        private System.Windows.Forms.Button btnGuardar2;
        private System.Windows.Forms.Label lblError2;
        private System.Windows.Forms.TabPage tabAdjunto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.FlowLayoutPanel flwAdjuntos;
        private System.Windows.Forms.Button btnAdjuntar;
        private System.Windows.Forms.TextBox txtAdjunto;
    }
}