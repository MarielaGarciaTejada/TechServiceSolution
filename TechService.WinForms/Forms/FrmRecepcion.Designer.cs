namespace TechService.WinForms.Forms
{
    partial class FrmRecepcion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRecepcion));
            pnlHeader = new Panel();
            btnCLose = new Button();
            lblVentanillaRecepcion = new Label();
            pbxIcono = new PictureBox();
            pnlCentral = new Panel();
            btnRegistrar = new Button();
            lblTrackingGenerado = new Label();
            numManoObra = new NumericUpDown();
            groupChecklist = new GroupBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            chkEnciende = new CheckBox();
            chkPantallaRota = new CheckBox();
            chkMojado = new CheckBox();
            chkCargador = new CheckBox();
            txtFallo = new TextBox();
            txtPin = new TextBox();
            txtSerialImei = new TextBox();
            txtMarcaModelo = new TextBox();
            lblTipoDispositivo = new Label();
            cbTipoEquipo = new ComboBox();
            lblFalloReportado = new Label();
            lblSerieImei = new Label();
            lblPinPatron = new Label();
            lblEstimado = new Label();
            lblMarcaModelo = new Label();
            cbClientes = new ComboBox();
            lblCliente = new Label();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxIcono).BeginInit();
            pnlCentral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numManoObra).BeginInit();
            groupChecklist.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(5, 8, 100);
            pnlHeader.Controls.Add(btnCLose);
            pnlHeader.Controls.Add(lblVentanillaRecepcion);
            pnlHeader.Controls.Add(pbxIcono);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(823, 31);
            pnlHeader.TabIndex = 2;
            // 
            // btnCLose
            // 
            btnCLose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCLose.BackColor = Color.FromArgb(5, 8, 100);
            btnCLose.Cursor = Cursors.Hand;
            btnCLose.FlatAppearance.BorderSize = 0;
            btnCLose.FlatStyle = FlatStyle.Flat;
            btnCLose.Image = (Image)resources.GetObject("btnCLose.Image");
            btnCLose.Location = new Point(790, -2);
            btnCLose.Name = "btnCLose";
            btnCLose.Size = new Size(30, 30);
            btnCLose.TabIndex = 126;
            btnCLose.UseVisualStyleBackColor = false;
            btnCLose.Click += btnCLose_Click;
            // 
            // lblVentanillaRecepcion
            // 
            lblVentanillaRecepcion.AutoSize = true;
            lblVentanillaRecepcion.BackColor = Color.FromArgb(5, 8, 100);
            lblVentanillaRecepcion.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVentanillaRecepcion.ForeColor = Color.White;
            lblVentanillaRecepcion.Location = new Point(41, 3);
            lblVentanillaRecepcion.Name = "lblVentanillaRecepcion";
            lblVentanillaRecepcion.Size = new Size(391, 25);
            lblVentanillaRecepcion.TabIndex = 11;
            lblVentanillaRecepcion.Text = "Ventanilla | Recepción e Inspección Técnica";
            // 
            // pbxIcono
            // 
            pbxIcono.Image = Properties.Resources.Recepcion;
            pbxIcono.Location = new Point(3, 0);
            pbxIcono.Name = "pbxIcono";
            pbxIcono.Size = new Size(30, 30);
            pbxIcono.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxIcono.TabIndex = 10;
            pbxIcono.TabStop = false;
            // 
            // pnlCentral
            // 
            pnlCentral.Controls.Add(btnRegistrar);
            pnlCentral.Controls.Add(lblTrackingGenerado);
            pnlCentral.Controls.Add(numManoObra);
            pnlCentral.Controls.Add(groupChecklist);
            pnlCentral.Controls.Add(txtFallo);
            pnlCentral.Controls.Add(txtPin);
            pnlCentral.Controls.Add(txtSerialImei);
            pnlCentral.Controls.Add(txtMarcaModelo);
            pnlCentral.Controls.Add(lblTipoDispositivo);
            pnlCentral.Controls.Add(cbTipoEquipo);
            pnlCentral.Controls.Add(lblFalloReportado);
            pnlCentral.Controls.Add(lblSerieImei);
            pnlCentral.Controls.Add(lblPinPatron);
            pnlCentral.Controls.Add(lblEstimado);
            pnlCentral.Controls.Add(lblMarcaModelo);
            pnlCentral.Controls.Add(cbClientes);
            pnlCentral.Controls.Add(lblCliente);
            pnlCentral.Dock = DockStyle.Fill;
            pnlCentral.Location = new Point(0, 31);
            pnlCentral.Name = "pnlCentral";
            pnlCentral.Size = new Size(823, 629);
            pnlCentral.TabIndex = 3;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnRegistrar.BackColor = Color.FromArgb(5, 8, 100);
            btnRegistrar.Cursor = Cursors.Hand;
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.Location = new Point(401, 521);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(377, 48);
            btnRegistrar.TabIndex = 142;
            btnRegistrar.Text = "Registrar Orden y Emitir Ticket";
            btnRegistrar.UseVisualStyleBackColor = false;
            // 
            // lblTrackingGenerado
            // 
            lblTrackingGenerado.AutoSize = true;
            lblTrackingGenerado.BackColor = Color.Transparent;
            lblTrackingGenerado.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTrackingGenerado.ForeColor = Color.FromArgb(5, 8, 100);
            lblTrackingGenerado.Location = new Point(412, 478);
            lblTrackingGenerado.Name = "lblTrackingGenerado";
            lblTrackingGenerado.Size = new Size(206, 17);
            lblTrackingGenerado.TabIndex = 141;
            lblTrackingGenerado.Text = "Ticket: Pendiente de generación";
            // 
            // numManoObra
            // 
            numManoObra.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numManoObra.DecimalPlaces = 2;
            numManoObra.Location = new Point(411, 442);
            numManoObra.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numManoObra.Name = "numManoObra";
            numManoObra.Size = new Size(174, 23);
            numManoObra.TabIndex = 140;
            // 
            // groupChecklist
            // 
            groupChecklist.Controls.Add(flowLayoutPanel1);
            groupChecklist.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupChecklist.Location = new Point(320, 266);
            groupChecklist.Name = "groupChecklist";
            groupChecklist.Size = new Size(247, 147);
            groupChecklist.TabIndex = 139;
            groupChecklist.TabStop = false;
            groupChecklist.Text = "Checklist Inicial de Recepción";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(chkEnciende);
            flowLayoutPanel1.Controls.Add(chkPantallaRota);
            flowLayoutPanel1.Controls.Add(chkMojado);
            flowLayoutPanel1.Controls.Add(chkCargador);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(3, 21);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(241, 123);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // chkEnciende
            // 
            chkEnciende.AutoSize = true;
            chkEnciende.Location = new Point(3, 3);
            chkEnciende.Name = "chkEnciende";
            chkEnciende.Size = new Size(187, 21);
            chkEnciende.TabIndex = 0;
            chkEnciende.Text = "Equipo enciende al recibir";
            chkEnciende.UseVisualStyleBackColor = true;
            // 
            // chkPantallaRota
            // 
            chkPantallaRota.AutoSize = true;
            chkPantallaRota.Location = new Point(3, 30);
            chkPantallaRota.Name = "chkPantallaRota";
            chkPantallaRota.Size = new Size(170, 21);
            chkPantallaRota.TabIndex = 1;
            chkPantallaRota.Text = "Pantalla rota / fisurada";
            chkPantallaRota.UseVisualStyleBackColor = true;
            // 
            // chkMojado
            // 
            chkMojado.AutoSize = true;
            chkMojado.Location = new Point(3, 57);
            chkMojado.Name = "chkMojado";
            chkMojado.Size = new Size(227, 21);
            chkMojado.TabIndex = 2;
            chkMojado.Text = "Evidencia de humedad / mojado";
            chkMojado.UseVisualStyleBackColor = true;
            // 
            // chkCargador
            // 
            chkCargador.AutoSize = true;
            chkCargador.Location = new Point(3, 84);
            chkCargador.Name = "chkCargador";
            chkCargador.Size = new Size(167, 21);
            chkCargador.TabIndex = 3;
            chkCargador.Text = "Deja cargador / fuente";
            chkCargador.UseVisualStyleBackColor = true;
            // 
            // txtFallo
            // 
            txtFallo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtFallo.Font = new Font("Segoe UI", 9.75F);
            txtFallo.Location = new Point(315, 190);
            txtFallo.Multiline = true;
            txtFallo.Name = "txtFallo";
            txtFallo.Size = new Size(349, 55);
            txtFallo.TabIndex = 138;
            // 
            // txtPin
            // 
            txtPin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPin.Font = new Font("Segoe UI", 9.75F);
            txtPin.Location = new Point(314, 156);
            txtPin.Name = "txtPin";
            txtPin.Size = new Size(349, 25);
            txtPin.TabIndex = 137;
            // 
            // txtSerialImei
            // 
            txtSerialImei.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSerialImei.Font = new Font("Segoe UI", 9.75F);
            txtSerialImei.Location = new Point(313, 123);
            txtSerialImei.Name = "txtSerialImei";
            txtSerialImei.Size = new Size(349, 25);
            txtSerialImei.TabIndex = 136;
            // 
            // txtMarcaModelo
            // 
            txtMarcaModelo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMarcaModelo.Font = new Font("Segoe UI", 9.75F);
            txtMarcaModelo.Location = new Point(313, 85);
            txtMarcaModelo.Name = "txtMarcaModelo";
            txtMarcaModelo.Size = new Size(349, 25);
            txtMarcaModelo.TabIndex = 135;
            // 
            // lblTipoDispositivo
            // 
            lblTipoDispositivo.AutoSize = true;
            lblTipoDispositivo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTipoDispositivo.ForeColor = Color.Black;
            lblTipoDispositivo.Location = new Point(125, 57);
            lblTipoDispositivo.Name = "lblTipoDispositivo";
            lblTipoDispositivo.Size = new Size(161, 21);
            lblTipoDispositivo.TabIndex = 134;
            lblTipoDispositivo.Text = "Tipo de Dispositivo:";
            // 
            // cbTipoEquipo
            // 
            cbTipoEquipo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbTipoEquipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTipoEquipo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbTipoEquipo.FormattingEnabled = true;
            cbTipoEquipo.Location = new Point(313, 51);
            cbTipoEquipo.Name = "cbTipoEquipo";
            cbTipoEquipo.Size = new Size(349, 25);
            cbTipoEquipo.TabIndex = 133;
            // 
            // lblFalloReportado
            // 
            lblFalloReportado.AutoSize = true;
            lblFalloReportado.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFalloReportado.ForeColor = Color.Black;
            lblFalloReportado.Location = new Point(126, 190);
            lblFalloReportado.Name = "lblFalloReportado";
            lblFalloReportado.Size = new Size(135, 21);
            lblFalloReportado.TabIndex = 132;
            lblFalloReportado.Text = "Fallo Reportado:";
            // 
            // lblSerieImei
            // 
            lblSerieImei.AutoSize = true;
            lblSerieImei.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSerieImei.ForeColor = Color.Black;
            lblSerieImei.Location = new Point(126, 124);
            lblSerieImei.Name = "lblSerieImei";
            lblSerieImei.Size = new Size(101, 21);
            lblSerieImei.TabIndex = 131;
            lblSerieImei.Text = "Serie / IMEI:";
            // 
            // lblPinPatron
            // 
            lblPinPatron.AutoSize = true;
            lblPinPatron.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPinPatron.ForeColor = Color.Black;
            lblPinPatron.Location = new Point(126, 158);
            lblPinPatron.Name = "lblPinPatron";
            lblPinPatron.Size = new Size(111, 21);
            lblPinPatron.TabIndex = 130;
            lblPinPatron.Text = "PIN o Patrón:";
            // 
            // lblEstimado
            // 
            lblEstimado.AutoSize = true;
            lblEstimado.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEstimado.ForeColor = Color.Black;
            lblEstimado.Location = new Point(126, 439);
            lblEstimado.Name = "lblEstimado";
            lblEstimado.Size = new Size(273, 25);
            lblEstimado.TabIndex = 129;
            lblEstimado.Text = "Estimado Mano de Obra RD$:";
            // 
            // lblMarcaModelo
            // 
            lblMarcaModelo.AutoSize = true;
            lblMarcaModelo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblMarcaModelo.ForeColor = Color.Black;
            lblMarcaModelo.Location = new Point(126, 90);
            lblMarcaModelo.Name = "lblMarcaModelo";
            lblMarcaModelo.Size = new Size(137, 21);
            lblMarcaModelo.TabIndex = 128;
            lblMarcaModelo.Text = "Marca y Modelo:";
            // 
            // cbClientes
            // 
            cbClientes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cbClientes.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbClientes.FormattingEnabled = true;
            cbClientes.Location = new Point(313, 16);
            cbClientes.Name = "cbClientes";
            cbClientes.Size = new Size(349, 25);
            cbClientes.TabIndex = 127;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCliente.ForeColor = Color.Black;
            lblCliente.Location = new Point(126, 21);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(123, 21);
            lblCliente.TabIndex = 126;
            lblCliente.Text = "Cliente Titular:";
            // 
            // FrmRecepcion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(823, 660);
            Controls.Add(pnlCentral);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmRecepcion";
            Text = "FormRecepcion";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbxIcono).EndInit();
            pnlCentral.ResumeLayout(false);
            pnlCentral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numManoObra).EndInit();
            groupChecklist.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Button btnCLose;
        private Label lblVentanillaRecepcion;
        private PictureBox pbxIcono;
        private Panel pnlCentral;
        public ComboBox cbClientes;
        private Label lblCliente;
        private Label lblFalloReportado;
        private Label lblSerieImei;
        private Label lblPinPatron;
        private Label lblEstimado;
        private Label lblMarcaModelo;
        private Label lblTipoDispositivo;
        public ComboBox cbTipoEquipo;
        public TextBox txtFallo;
        public TextBox txtPin;
        public TextBox txtSerialImei;
        public TextBox txtMarcaModelo;
        private GroupBox groupChecklist;
        private FlowLayoutPanel flowLayoutPanel1;
        private CheckBox chkEnciende;
        private CheckBox chkPantallaRota;
        private CheckBox chkMojado;
        private CheckBox chkCargador;
        private NumericUpDown numManoObra;
        private Button btnRegistrar;
        private Label lblTrackingGenerado;
    }
}