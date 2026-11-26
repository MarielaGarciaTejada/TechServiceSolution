namespace TechService.WinForms.Forms
{
    partial class FrmTecnicos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTecnicos));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            btnCLose = new Button();
            lblVentanaTecnicos = new Label();
            pbxIconoClientes = new PictureBox();
            gbxClientes = new GroupBox();
            cbxActivo = new CheckBox();
            numPorcentajeComision = new NumericUpDown();
            txtBuscarTecnico = new TextBox();
            lblBuscar = new Label();
            btnEditar = new Button();
            btnCancelar = new Button();
            btnAgregar = new Button();
            lblEmail = new Label();
            lblPorcentajeComision = new Label();
            txtDocumento = new TextBox();
            lblEspecialidad = new Label();
            txtNombre = new TextBox();
            lblNombre = new Label();
            dgvTecnicos = new DataGridView();
            colClienteId = new DataGridViewTextBoxColumn();
            colDocumento = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colTelefono = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colEliminar = new DataGridViewImageColumn();
            pnlLineaDiv = new Panel();
            pnlFooter = new Panel();
            btnSiguiente = new Button();
            btnUltimo = new Button();
            btnAnterior = new Button();
            btnPrimero = new Button();
            lblClientesTotales = new Label();
            lblPaginaActual = new Label();
            cbxRegistrosPorPagina = new ComboBox();
            lblShow = new Label();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxIconoClientes).BeginInit();
            gbxClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPorcentajeComision).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTecnicos).BeginInit();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(5, 8, 100);
            pnlHeader.Controls.Add(btnCLose);
            pnlHeader.Controls.Add(lblVentanaTecnicos);
            pnlHeader.Controls.Add(pbxIconoClientes);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(807, 33);
            pnlHeader.TabIndex = 4;
            // 
            // btnCLose
            // 
            btnCLose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCLose.BackColor = Color.FromArgb(5, 8, 100);
            btnCLose.Cursor = Cursors.Hand;
            btnCLose.FlatAppearance.BorderSize = 0;
            btnCLose.FlatStyle = FlatStyle.Flat;
            btnCLose.Image = (Image)resources.GetObject("btnCLose.Image");
            btnCLose.Location = new Point(774, 0);
            btnCLose.Name = "btnCLose";
            btnCLose.Size = new Size(30, 30);
            btnCLose.TabIndex = 126;
            btnCLose.UseVisualStyleBackColor = false;
            btnCLose.Click += btnCLose_Click;
            // 
            // lblVentanaTecnicos
            // 
            lblVentanaTecnicos.AutoSize = true;
            lblVentanaTecnicos.BackColor = Color.FromArgb(5, 8, 100);
            lblVentanaTecnicos.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVentanaTecnicos.ForeColor = Color.White;
            lblVentanaTecnicos.Location = new Point(36, 3);
            lblVentanaTecnicos.Name = "lblVentanaTecnicos";
            lblVentanaTecnicos.Size = new Size(86, 25);
            lblVentanaTecnicos.TabIndex = 11;
            lblVentanaTecnicos.Text = "Técnicos";
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
            // gbxClientes
            // 
            gbxClientes.Controls.Add(cbxActivo);
            gbxClientes.Controls.Add(numPorcentajeComision);
            gbxClientes.Controls.Add(txtBuscarTecnico);
            gbxClientes.Controls.Add(lblBuscar);
            gbxClientes.Controls.Add(btnEditar);
            gbxClientes.Controls.Add(btnCancelar);
            gbxClientes.Controls.Add(btnAgregar);
            gbxClientes.Controls.Add(lblEmail);
            gbxClientes.Controls.Add(lblPorcentajeComision);
            gbxClientes.Controls.Add(txtDocumento);
            gbxClientes.Controls.Add(lblEspecialidad);
            gbxClientes.Controls.Add(txtNombre);
            gbxClientes.Controls.Add(lblNombre);
            gbxClientes.Dock = DockStyle.Top;
            gbxClientes.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbxClientes.Location = new Point(0, 33);
            gbxClientes.Name = "gbxClientes";
            gbxClientes.Size = new Size(807, 139);
            gbxClientes.TabIndex = 19;
            gbxClientes.TabStop = false;
            gbxClientes.Text = "Agregar/Editar Técnicos";
            // 
            // cbxActivo
            // 
            cbxActivo.AutoSize = true;
            cbxActivo.Location = new Point(377, 63);
            cbxActivo.Name = "cbxActivo";
            cbxActivo.Size = new Size(15, 14);
            cbxActivo.TabIndex = 149;
            cbxActivo.UseVisualStyleBackColor = true;
            cbxActivo.CheckedChanged += cbxActivo_CheckedChanged;
            // 
            // numPorcentajeComision
            // 
            numPorcentajeComision.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numPorcentajeComision.DecimalPlaces = 2;
            numPorcentajeComision.Location = new Point(469, 24);
            numPorcentajeComision.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numPorcentajeComision.Name = "numPorcentajeComision";
            numPorcentajeComision.Size = new Size(174, 23);
            numPorcentajeComision.TabIndex = 148;
            // 
            // txtBuscarTecnico
            // 
            txtBuscarTecnico.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscarTecnico.Location = new Point(295, 107);
            txtBuscarTecnico.Name = "txtBuscarTecnico";
            txtBuscarTecnico.Size = new Size(276, 23);
            txtBuscarTecnico.TabIndex = 128;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.BackColor = Color.Transparent;
            lblBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBuscar.ForeColor = Color.Black;
            lblBuscar.Location = new Point(200, 110);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(92, 15);
            lblBuscar.TabIndex = 127;
            lblBuscar.Text = "Buscar Técnico:";
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditar.BackColor = Color.Gold;
            btnEditar.Cursor = Cursors.Hand;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(1264, 63);
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
            btnCancelar.Location = new Point(1264, 97);
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
            btnAgregar.Location = new Point(1264, 22);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(140, 28);
            btnAgregar.TabIndex = 145;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            // 
            // lblEmail
            // 
            lblEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.ForeColor = Color.Black;
            lblEmail.Location = new Point(324, 61);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(47, 17);
            lblEmail.TabIndex = 142;
            lblEmail.Text = "Activo";
            // 
            // lblPorcentajeComision
            // 
            lblPorcentajeComision.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblPorcentajeComision.AutoSize = true;
            lblPorcentajeComision.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPorcentajeComision.ForeColor = Color.Black;
            lblPorcentajeComision.Location = new Point(324, 30);
            lblPorcentajeComision.Name = "lblPorcentajeComision";
            lblPorcentajeComision.Size = new Size(139, 17);
            lblPorcentajeComision.TabIndex = 140;
            lblPorcentajeComision.Text = "Porcentaje Comisión:";
            // 
            // txtDocumento
            // 
            txtDocumento.Font = new Font("Segoe UI", 9.75F);
            txtDocumento.Location = new Point(95, 58);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(217, 25);
            txtDocumento.TabIndex = 139;
            // 
            // lblEspecialidad
            // 
            lblEspecialidad.AutoSize = true;
            lblEspecialidad.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEspecialidad.ForeColor = Color.Black;
            lblEspecialidad.Location = new Point(11, 66);
            lblEspecialidad.Name = "lblEspecialidad";
            lblEspecialidad.Size = new Size(88, 17);
            lblEspecialidad.TabIndex = 138;
            lblEspecialidad.Text = "Especialidad:";
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
            // dgvTecnicos
            // 
            dgvTecnicos.AllowUserToAddRows = false;
            dgvTecnicos.AllowUserToDeleteRows = false;
            dgvTecnicos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(5, 8, 100);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvTecnicos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvTecnicos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTecnicos.Columns.AddRange(new DataGridViewColumn[] { colClienteId, colDocumento, colNombre, colTelefono, colEmail, colEliminar });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(5, 8, 100);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvTecnicos.DefaultCellStyle = dataGridViewCellStyle3;
            dgvTecnicos.Dock = DockStyle.Top;
            dgvTecnicos.Location = new Point(0, 172);
            dgvTecnicos.MultiSelect = false;
            dgvTecnicos.Name = "dgvTecnicos";
            dgvTecnicos.ReadOnly = true;
            dgvTecnicos.RowHeadersVisible = false;
            dgvTecnicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTecnicos.Size = new Size(807, 375);
            dgvTecnicos.TabIndex = 20;
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
            // pnlLineaDiv
            // 
            pnlLineaDiv.Dock = DockStyle.Bottom;
            pnlLineaDiv.Location = new Point(0, 548);
            pnlLineaDiv.Name = "pnlLineaDiv";
            pnlLineaDiv.Size = new Size(807, 5);
            pnlLineaDiv.TabIndex = 24;
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
            pnlFooter.Location = new Point(0, 553);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(807, 37);
            pnlFooter.TabIndex = 23;
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
            lblClientesTotales.Size = new Size(96, 15);
            lblClientesTotales.TabIndex = 17;
            lblClientesTotales.Text = "Técnicos Totales";
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
            // FrmTecnicos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(807, 590);
            Controls.Add(pnlLineaDiv);
            Controls.Add(pnlFooter);
            Controls.Add(dgvTecnicos);
            Controls.Add(gbxClientes);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmTecnicos";
            Text = "FrmTecnicos";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbxIconoClientes).EndInit();
            gbxClientes.ResumeLayout(false);
            gbxClientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPorcentajeComision).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTecnicos).EndInit();
            pnlFooter.ResumeLayout(false);
            pnlFooter.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Button btnCLose;
        private Label lblVentanaTecnicos;
        private PictureBox pbxIconoClientes;
        private GroupBox gbxClientes;
        private TextBox txtBuscarTecnico;
        public Label lblBuscar;
        private Button btnEditar;
        private Button btnCancelar;
        private Button btnAgregar;
        private Label lblEmail;
        private Label lblPorcentajeComision;
        public TextBox txtDocumento;
        private Label lblEspecialidad;
        public TextBox txtNombre;
        private Label lblNombre;
        private DataGridView dgvTecnicos;
        private DataGridViewTextBoxColumn colClienteId;
        private DataGridViewTextBoxColumn colDocumento;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colTelefono;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewImageColumn colEliminar;
        private Panel pnlLineaDiv;
        private Panel pnlFooter;
        private Button btnSiguiente;
        private Button btnUltimo;
        private Button btnAnterior;
        private Button btnPrimero;
        public Label lblClientesTotales;
        public Label lblPaginaActual;
        private ComboBox cbxRegistrosPorPagina;
        public Label lblShow;
        private CheckBox cbxActivo;
        private NumericUpDown numPorcentajeComision;
    }
}