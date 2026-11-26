namespace TechService.WinForms.Forms
{
    partial class FrmClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClientes));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            btnCLose = new Button();
            lblVentanaClientes = new Label();
            pbxIconoClientes = new PictureBox();
            txtBuscarUsuario = new TextBox();
            lblBuscar = new Label();
            pnlCentral = new Panel();
            pnlFooter = new Panel();
            btnSiguiente = new Button();
            btnUltimo = new Button();
            btnAnterior = new Button();
            btnPrimero = new Button();
            lblClientesTotales = new Label();
            lblPaginaActual = new Label();
            cbxRegistrosPorPagina = new ComboBox();
            lblShow = new Label();
            dgvClientes = new DataGridView();
            colClienteId = new DataGridViewTextBoxColumn();
            colDocumento = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colTelefono = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colEliminar = new DataGridViewImageColumn();
            gbxClientes = new GroupBox();
            btnEditar = new Button();
            btnCancelar = new Button();
            btnAgregar = new Button();
            lblClienteId = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtTelefono = new TextBox();
            lblTelefono = new Label();
            txtDocumento = new TextBox();
            lblDocumento = new Label();
            txtNombre = new TextBox();
            lblNombre = new Label();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxIconoClientes).BeginInit();
            pnlCentral.SuspendLayout();
            pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            gbxClientes.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(5, 8, 100);
            pnlHeader.Controls.Add(btnCLose);
            pnlHeader.Controls.Add(lblVentanaClientes);
            pnlHeader.Controls.Add(pbxIconoClientes);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(823, 33);
            pnlHeader.TabIndex = 3;
            // 
            // btnCLose
            // 
            btnCLose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCLose.BackColor = Color.FromArgb(5, 8, 100);
            btnCLose.Cursor = Cursors.Hand;
            btnCLose.FlatAppearance.BorderSize = 0;
            btnCLose.FlatStyle = FlatStyle.Flat;
            btnCLose.Image = (Image)resources.GetObject("btnCLose.Image");
            btnCLose.Location = new Point(791, 0);
            btnCLose.Name = "btnCLose";
            btnCLose.Size = new Size(30, 30);
            btnCLose.TabIndex = 126;
            btnCLose.UseVisualStyleBackColor = false;
            btnCLose.Click += btnCLose_Click;
            // 
            // lblVentanaClientes
            // 
            lblVentanaClientes.AutoSize = true;
            lblVentanaClientes.BackColor = Color.FromArgb(5, 8, 100);
            lblVentanaClientes.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVentanaClientes.ForeColor = Color.White;
            lblVentanaClientes.Location = new Point(36, 3);
            lblVentanaClientes.Name = "lblVentanaClientes";
            lblVentanaClientes.Size = new Size(81, 25);
            lblVentanaClientes.TabIndex = 11;
            lblVentanaClientes.Text = "Clientes";
            // 
            // pbxIconoClientes
            // 
            pbxIconoClientes.Image = Properties.Resources.Clientes;
            pbxIconoClientes.Location = new Point(3, 0);
            pbxIconoClientes.Name = "pbxIconoClientes";
            pbxIconoClientes.Size = new Size(30, 30);
            pbxIconoClientes.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxIconoClientes.TabIndex = 10;
            pbxIconoClientes.TabStop = false;
            // 
            // txtBuscarUsuario
            // 
            txtBuscarUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscarUsuario.Location = new Point(324, 110);
            txtBuscarUsuario.Name = "txtBuscarUsuario";
            txtBuscarUsuario.Size = new Size(201, 23);
            txtBuscarUsuario.TabIndex = 128;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.BackColor = Color.Transparent;
            lblBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBuscar.ForeColor = Color.Black;
            lblBuscar.Location = new Point(223, 118);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(89, 15);
            lblBuscar.TabIndex = 127;
            lblBuscar.Text = "Buscar Cliente:";
            // 
            // pnlCentral
            // 
            pnlCentral.Controls.Add(pnlFooter);
            pnlCentral.Controls.Add(dgvClientes);
            pnlCentral.Controls.Add(gbxClientes);
            pnlCentral.Dock = DockStyle.Fill;
            pnlCentral.Location = new Point(0, 33);
            pnlCentral.Name = "pnlCentral";
            pnlCentral.Size = new Size(823, 596);
            pnlCentral.TabIndex = 4;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.FromArgb(15, 23, 42);
            pnlFooter.Controls.Add(btnSiguiente);
            pnlFooter.Controls.Add(btnUltimo);
            pnlFooter.Controls.Add(btnAnterior);
            pnlFooter.Controls.Add(btnPrimero);
            pnlFooter.Controls.Add(lblClientesTotales);
            pnlFooter.Controls.Add(lblPaginaActual);
            pnlFooter.Controls.Add(cbxRegistrosPorPagina);
            pnlFooter.Controls.Add(lblShow);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 559);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(823, 37);
            pnlFooter.TabIndex = 20;
            // 
            // btnSiguiente
            // 
            btnSiguiente.FlatAppearance.BorderSize = 0;
            btnSiguiente.FlatStyle = FlatStyle.Flat;
            btnSiguiente.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSiguiente.ForeColor = Color.White;
            btnSiguiente.Location = new Point(200, 7);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(23, 25);
            btnSiguiente.TabIndex = 21;
            btnSiguiente.Text = ">";
            btnSiguiente.UseVisualStyleBackColor = true;
            // 
            // btnUltimo
            // 
            btnUltimo.FlatAppearance.BorderSize = 0;
            btnUltimo.FlatStyle = FlatStyle.Flat;
            btnUltimo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUltimo.ForeColor = Color.White;
            btnUltimo.Location = new Point(223, 7);
            btnUltimo.Name = "btnUltimo";
            btnUltimo.Size = new Size(32, 25);
            btnUltimo.TabIndex = 20;
            btnUltimo.Text = ">>";
            btnUltimo.UseVisualStyleBackColor = true;
            // 
            // btnAnterior
            // 
            btnAnterior.FlatAppearance.BorderSize = 0;
            btnAnterior.FlatStyle = FlatStyle.Flat;
            btnAnterior.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAnterior.ForeColor = Color.White;
            btnAnterior.Location = new Point(150, 7);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(23, 25);
            btnAnterior.TabIndex = 19;
            btnAnterior.Text = "<";
            btnAnterior.UseVisualStyleBackColor = true;
            // 
            // btnPrimero
            // 
            btnPrimero.FlatAppearance.BorderSize = 0;
            btnPrimero.FlatStyle = FlatStyle.Flat;
            btnPrimero.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPrimero.ForeColor = Color.White;
            btnPrimero.Location = new Point(123, 7);
            btnPrimero.Name = "btnPrimero";
            btnPrimero.Size = new Size(32, 25);
            btnPrimero.TabIndex = 18;
            btnPrimero.Text = "<<";
            btnPrimero.UseVisualStyleBackColor = true;
            // 
            // lblClientesTotales
            // 
            lblClientesTotales.AutoSize = true;
            lblClientesTotales.BackColor = Color.Transparent;
            lblClientesTotales.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClientesTotales.ForeColor = Color.White;
            lblClientesTotales.Location = new Point(381, 10);
            lblClientesTotales.Name = "lblClientesTotales";
            lblClientesTotales.Size = new Size(93, 15);
            lblClientesTotales.TabIndex = 17;
            lblClientesTotales.Text = "Clientes Totales";
            // 
            // lblPaginaActual
            // 
            lblPaginaActual.AutoSize = true;
            lblPaginaActual.BackColor = Color.Transparent;
            lblPaginaActual.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPaginaActual.ForeColor = Color.White;
            lblPaginaActual.Location = new Point(272, 10);
            lblPaginaActual.Name = "lblPaginaActual";
            lblPaginaActual.Size = new Size(69, 15);
            lblPaginaActual.TabIndex = 16;
            lblPaginaActual.Text = "Page # of #";
            // 
            // cbxRegistrosPorPagina
            // 
            cbxRegistrosPorPagina.FormattingEnabled = true;
            cbxRegistrosPorPagina.Location = new Point(53, 6);
            cbxRegistrosPorPagina.Name = "cbxRegistrosPorPagina";
            cbxRegistrosPorPagina.Size = new Size(46, 23);
            cbxRegistrosPorPagina.TabIndex = 15;
            // 
            // lblShow
            // 
            lblShow.AutoSize = true;
            lblShow.BackColor = Color.Transparent;
            lblShow.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblShow.ForeColor = Color.White;
            lblShow.Location = new Point(3, 10);
            lblShow.Name = "lblShow";
            lblShow.Size = new Size(38, 15);
            lblShow.TabIndex = 14;
            lblShow.Text = "Show";
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(5, 8, 100);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Columns.AddRange(new DataGridViewColumn[] { colClienteId, colDocumento, colNombre, colTelefono, colEmail, colEliminar });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(5, 8, 100);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvClientes.DefaultCellStyle = dataGridViewCellStyle3;
            dgvClientes.Dock = DockStyle.Top;
            dgvClientes.Location = new Point(0, 139);
            dgvClientes.MultiSelect = false;
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.Size = new Size(823, 420);
            dgvClientes.TabIndex = 19;
            // 
            // colClienteId
            // 
            colClienteId.DataPropertyName = "ClienteId";
            colClienteId.HeaderText = "ID";
            colClienteId.Name = "colClienteId";
            colClienteId.ReadOnly = true;
            colClienteId.Visible = false;
            // 
            // colDocumento
            // 
            colDocumento.DataPropertyName = "DocumentoIdentidad";
            colDocumento.HeaderText = "Cédula";
            colDocumento.Name = "colDocumento";
            colDocumento.ReadOnly = true;
            // 
            // colNombre
            // 
            colNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colNombre.DataPropertyName = "Nombre";
            colNombre.HeaderText = "Nombre Completo";
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            // 
            // colTelefono
            // 
            colTelefono.DataPropertyName = "Telefono";
            colTelefono.HeaderText = "Teléfono";
            colTelefono.Name = "colTelefono";
            colTelefono.ReadOnly = true;
            // 
            // colEmail
            // 
            colEmail.DataPropertyName = "Email";
            colEmail.HeaderText = "Email";
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            // 
            // colEliminar
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = "none";
            colEliminar.DefaultCellStyle = dataGridViewCellStyle2;
            colEliminar.HeaderText = "Eliminar";
            colEliminar.Image = Properties.Resources.Eliminar;
            colEliminar.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colEliminar.Name = "colEliminar";
            colEliminar.ReadOnly = true;
            colEliminar.Resizable = DataGridViewTriState.True;
            colEliminar.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // gbxClientes
            // 
            gbxClientes.Controls.Add(txtBuscarUsuario);
            gbxClientes.Controls.Add(lblBuscar);
            gbxClientes.Controls.Add(btnEditar);
            gbxClientes.Controls.Add(btnCancelar);
            gbxClientes.Controls.Add(btnAgregar);
            gbxClientes.Controls.Add(lblClienteId);
            gbxClientes.Controls.Add(txtEmail);
            gbxClientes.Controls.Add(lblEmail);
            gbxClientes.Controls.Add(txtTelefono);
            gbxClientes.Controls.Add(lblTelefono);
            gbxClientes.Controls.Add(txtDocumento);
            gbxClientes.Controls.Add(lblDocumento);
            gbxClientes.Controls.Add(txtNombre);
            gbxClientes.Controls.Add(lblNombre);
            gbxClientes.Dock = DockStyle.Top;
            gbxClientes.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbxClientes.Location = new Point(0, 0);
            gbxClientes.Name = "gbxClientes";
            gbxClientes.Size = new Size(823, 139);
            gbxClientes.TabIndex = 18;
            gbxClientes.TabStop = false;
            gbxClientes.Text = "Agregar/Editar Clientes";
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditar.BackColor = Color.Gold;
            btnEditar.Cursor = Cursors.Hand;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(657, 63);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(140, 28);
            btnEditar.TabIndex = 147;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancelar.BackColor = Color.Red;
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(657, 97);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(140, 28);
            btnCancelar.TabIndex = 146;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregar.BackColor = Color.FromArgb(13, 110, 253);
            btnAgregar.Cursor = Cursors.Hand;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(657, 22);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(140, 28);
            btnAgregar.TabIndex = 145;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            // 
            // lblClienteId
            // 
            lblClienteId.AutoSize = true;
            lblClienteId.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClienteId.ForeColor = Color.Black;
            lblClienteId.Location = new Point(401, 81);
            lblClienteId.Name = "lblClienteId";
            lblClienteId.Size = new Size(13, 17);
            lblClienteId.TabIndex = 144;
            lblClienteId.Text = "-";
            lblClienteId.Visible = false;
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEmail.Font = new Font("Segoe UI", 9.75F);
            txtEmail.Location = new Point(401, 53);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(217, 25);
            txtEmail.TabIndex = 143;
            // 
            // lblEmail
            // 
            lblEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.ForeColor = Color.Black;
            lblEmail.Location = new Point(324, 61);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 17);
            lblEmail.TabIndex = 142;
            lblEmail.Text = "Email:";
            // 
            // txtTelefono
            // 
            txtTelefono.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTelefono.Font = new Font("Segoe UI", 9.75F);
            txtTelefono.Location = new Point(401, 22);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(217, 25);
            txtTelefono.TabIndex = 141;
            // 
            // lblTelefono
            // 
            lblTelefono.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTelefono.ForeColor = Color.Black;
            lblTelefono.Location = new Point(324, 30);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(66, 17);
            lblTelefono.TabIndex = 140;
            lblTelefono.Text = "Teléfono:";
            // 
            // txtDocumento
            // 
            txtDocumento.Font = new Font("Segoe UI", 9.75F);
            txtDocumento.Location = new Point(89, 58);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(217, 25);
            txtDocumento.TabIndex = 139;
            // 
            // lblDocumento
            // 
            lblDocumento.AutoSize = true;
            lblDocumento.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDocumento.ForeColor = Color.Black;
            lblDocumento.Location = new Point(12, 66);
            lblDocumento.Name = "lblDocumento";
            lblDocumento.Size = new Size(54, 17);
            lblDocumento.TabIndex = 138;
            lblDocumento.Text = "Cédula:";
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 9.75F);
            txtNombre.Location = new Point(89, 26);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(217, 25);
            txtNombre.TabIndex = 137;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombre.ForeColor = Color.Black;
            lblNombre.Location = new Point(12, 34);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(62, 17);
            lblNombre.TabIndex = 136;
            lblNombre.Text = "Nombre:";
            // 
            // FrmClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(823, 629);
            Controls.Add(pnlCentral);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmClientes";
            Text = "FrmClientes";
            Load += FrmClientes_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbxIconoClientes).EndInit();
            pnlCentral.ResumeLayout(false);
            pnlFooter.ResumeLayout(false);
            pnlFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            gbxClientes.ResumeLayout(false);
            gbxClientes.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Button btnCLose;
        private Label lblVentanaClientes;
        private PictureBox pbxIconoClientes;
        private Panel pnlCentral;
        private TextBox txtBuscarUsuario;
        public Label lblBuscar;
        private GroupBox gbxClientes;
        private Panel pnlFooter;
        private Button btnSiguiente;
        private Button btnUltimo;
        private Button btnAnterior;
        private Button btnPrimero;
        public Label lblClientesTotales;
        public Label lblPaginaActual;
        private ComboBox cbxRegistrosPorPagina;
        public Label lblShow;
        private DataGridView dgvClientes;
        private Label lblClienteId;
        public TextBox txtEmail;
        private Label lblEmail;
        public TextBox txtTelefono;
        private Label lblTelefono;
        public TextBox txtDocumento;
        private Label lblDocumento;
        public TextBox txtNombre;
        private Label lblNombre;
        private Button btnEditar;
        private Button btnCancelar;
        private Button btnAgregar;
        private DataGridViewTextBoxColumn colClienteId;
        private DataGridViewTextBoxColumn colDocumento;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colTelefono;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewImageColumn colEliminar;
    }
}