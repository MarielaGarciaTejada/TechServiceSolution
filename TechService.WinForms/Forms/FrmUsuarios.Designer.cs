namespace TechService.WinForms.Forms
{
    partial class FrmUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsuarios));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            btnCLose = new Button();
            lblVentanaUsuariosYRoles = new Label();
            pbxIconoClientes = new PictureBox();
            gbxUsuarios = new GroupBox();
            btnEliminar = new Button();
            btnCancelar = new Button();
            btnAgregar = new Button();
            chkActivo = new CheckBox();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtTelefono = new TextBox();
            lblTel = new Label();
            cbxEspecialidad = new ComboBox();
            lblEspecialidadSoloTecnico = new Label();
            cbxRol = new ComboBox();
            lblRoles = new Label();
            txtNombreCompleto = new TextBox();
            lblNomCompleto = new Label();
            btnEditar = new Button();
            lblClienteId = new Label();
            btnVerContrasena = new Button();
            txtContrasena = new TextBox();
            lblContrasena = new Label();
            txtNombreUsuario = new TextBox();
            lblNombreUsuario = new Label();
            dgvUsuarios = new DataGridView();
            colUsuarioId = new DataGridViewTextBoxColumn();
            colNombreUsuario = new DataGridViewTextBoxColumn();
            colNombreCompleto = new DataGridViewTextBoxColumn();
            colRol = new DataGridViewTextBoxColumn();
            colTecnico = new DataGridViewTextBoxColumn();
            colActivo = new DataGridViewTextBoxColumn();
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
            gbxUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(5, 8, 100);
            pnlHeader.Controls.Add(btnCLose);
            pnlHeader.Controls.Add(lblVentanaUsuariosYRoles);
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
            btnCLose.Location = new Point(774, 1);
            btnCLose.Name = "btnCLose";
            btnCLose.Size = new Size(30, 30);
            btnCLose.TabIndex = 126;
            btnCLose.UseVisualStyleBackColor = false;
            // 
            // lblVentanaUsuariosYRoles
            // 
            lblVentanaUsuariosYRoles.AutoSize = true;
            lblVentanaUsuariosYRoles.BackColor = Color.FromArgb(5, 8, 100);
            lblVentanaUsuariosYRoles.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVentanaUsuariosYRoles.ForeColor = Color.White;
            lblVentanaUsuariosYRoles.Location = new Point(36, 3);
            lblVentanaUsuariosYRoles.Name = "lblVentanaUsuariosYRoles";
            lblVentanaUsuariosYRoles.Size = new Size(152, 25);
            lblVentanaUsuariosYRoles.TabIndex = 11;
            lblVentanaUsuariosYRoles.Text = "Usuarios | Roles";
            // 
            // pbxIconoClientes
            // 
            pbxIconoClientes.Image = Properties.Resources.Clientes;
            pbxIconoClientes.Location = new Point(3, 1);
            pbxIconoClientes.Name = "pbxIconoClientes";
            pbxIconoClientes.Size = new Size(30, 30);
            pbxIconoClientes.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxIconoClientes.TabIndex = 10;
            pbxIconoClientes.TabStop = false;
            // 
            // gbxUsuarios
            // 
            gbxUsuarios.Controls.Add(btnEliminar);
            gbxUsuarios.Controls.Add(btnCancelar);
            gbxUsuarios.Controls.Add(btnAgregar);
            gbxUsuarios.Controls.Add(chkActivo);
            gbxUsuarios.Controls.Add(txtEmail);
            gbxUsuarios.Controls.Add(lblEmail);
            gbxUsuarios.Controls.Add(txtTelefono);
            gbxUsuarios.Controls.Add(lblTel);
            gbxUsuarios.Controls.Add(cbxEspecialidad);
            gbxUsuarios.Controls.Add(lblEspecialidadSoloTecnico);
            gbxUsuarios.Controls.Add(cbxRol);
            gbxUsuarios.Controls.Add(lblRoles);
            gbxUsuarios.Controls.Add(txtNombreCompleto);
            gbxUsuarios.Controls.Add(lblNomCompleto);
            gbxUsuarios.Controls.Add(btnEditar);
            gbxUsuarios.Controls.Add(lblClienteId);
            gbxUsuarios.Controls.Add(btnVerContrasena);
            gbxUsuarios.Controls.Add(txtContrasena);
            gbxUsuarios.Controls.Add(lblContrasena);
            gbxUsuarios.Controls.Add(txtNombreUsuario);
            gbxUsuarios.Controls.Add(lblNombreUsuario);
            gbxUsuarios.Dock = DockStyle.Left;
            gbxUsuarios.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbxUsuarios.Location = new Point(0, 33);
            gbxUsuarios.Name = "gbxUsuarios";
            gbxUsuarios.Size = new Size(318, 557);
            gbxUsuarios.TabIndex = 19;
            gbxUsuarios.TabStop = false;
            gbxUsuarios.Text = "Agregar/Editar Usuarios y Roles";
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEliminar.BackColor = Color.Red;
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(190, 475);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 28);
            btnEliminar.TabIndex = 162;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancelar.BackColor = Color.FromArgb(255, 128, 0);
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(190, 509);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 28);
            btnCancelar.TabIndex = 160;
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
            btnAgregar.Location = new Point(23, 475);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(100, 28);
            btnAgregar.TabIndex = 159;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Location = new Point(15, 436);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(107, 19);
            chkActivo.TabIndex = 158;
            chkActivo.Text = "Usuario Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 9.75F);
            txtEmail.Location = new Point(15, 396);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(261, 25);
            txtEmail.TabIndex = 157;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.ForeColor = Color.Black;
            lblEmail.Location = new Point(15, 376);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 17);
            lblEmail.TabIndex = 156;
            lblEmail.Text = "Email:";
            // 
            // txtTelefono
            // 
            txtTelefono.Font = new Font("Segoe UI", 9.75F);
            txtTelefono.Location = new Point(15, 337);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(261, 25);
            txtTelefono.TabIndex = 155;
            // 
            // lblTel
            // 
            lblTel.AutoSize = true;
            lblTel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTel.ForeColor = Color.Black;
            lblTel.Location = new Point(15, 317);
            lblTel.Name = "lblTel";
            lblTel.Size = new Size(66, 17);
            lblTel.TabIndex = 154;
            lblTel.Text = "Télefono:";
            // 
            // cbxEspecialidad
            // 
            cbxEspecialidad.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbxEspecialidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxEspecialidad.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbxEspecialidad.FormattingEnabled = true;
            cbxEspecialidad.Location = new Point(15, 280);
            cbxEspecialidad.Name = "cbxEspecialidad";
            cbxEspecialidad.Size = new Size(285, 25);
            cbxEspecialidad.TabIndex = 153;
            // 
            // lblEspecialidadSoloTecnico
            // 
            lblEspecialidadSoloTecnico.AutoSize = true;
            lblEspecialidadSoloTecnico.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEspecialidadSoloTecnico.ForeColor = Color.Black;
            lblEspecialidadSoloTecnico.Location = new Point(15, 260);
            lblEspecialidadSoloTecnico.Name = "lblEspecialidadSoloTecnico";
            lblEspecialidadSoloTecnico.Size = new Size(210, 17);
            lblEspecialidadSoloTecnico.TabIndex = 152;
            lblEspecialidadSoloTecnico.Text = "Especialidad (Solo si es Técnico):";
            // 
            // cbxRol
            // 
            cbxRol.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbxRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxRol.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbxRol.FormattingEnabled = true;
            cbxRol.Location = new Point(15, 223);
            cbxRol.Name = "cbxRol";
            cbxRol.Size = new Size(169, 25);
            cbxRol.TabIndex = 151;
            // 
            // lblRoles
            // 
            lblRoles.AutoSize = true;
            lblRoles.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRoles.ForeColor = Color.Black;
            lblRoles.Location = new Point(15, 203);
            lblRoles.Name = "lblRoles";
            lblRoles.Size = new Size(118, 17);
            lblRoles.TabIndex = 150;
            lblRoles.Text = "Rol En El Sistema:";
            // 
            // txtNombreCompleto
            // 
            txtNombreCompleto.Font = new Font("Segoe UI", 9.75F);
            txtNombreCompleto.Location = new Point(15, 160);
            txtNombreCompleto.Name = "txtNombreCompleto";
            txtNombreCompleto.Size = new Size(261, 25);
            txtNombreCompleto.TabIndex = 149;
            // 
            // lblNomCompleto
            // 
            lblNomCompleto.AutoSize = true;
            lblNomCompleto.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNomCompleto.ForeColor = Color.Black;
            lblNomCompleto.Location = new Point(15, 140);
            lblNomCompleto.Name = "lblNomCompleto";
            lblNomCompleto.Size = new Size(126, 17);
            lblNomCompleto.TabIndex = 148;
            lblNomCompleto.Text = "Nombre Completo:";
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditar.BackColor = Color.Gold;
            btnEditar.Cursor = Cursors.Hand;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(23, 509);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(100, 28);
            btnEditar.TabIndex = 161;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            // 
            // lblClienteId
            // 
            lblClienteId.AutoSize = true;
            lblClienteId.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClienteId.ForeColor = Color.Black;
            lblClienteId.Location = new Point(401, 81);
            lblClienteId.Name = "lblClienteId";
            lblClienteId.Size = new Size(0, 17);
            lblClienteId.TabIndex = 144;
            lblClienteId.Visible = false;
            // 
            // btnVerContrasena
            // 
            btnVerContrasena.Cursor = Cursors.Hand;
            btnVerContrasena.FlatStyle = FlatStyle.Flat;
            btnVerContrasena.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnVerContrasena.Location = new Point(240, 100);
            btnVerContrasena.Name = "btnVerContrasena";
            btnVerContrasena.Size = new Size(36, 27);
            btnVerContrasena.TabIndex = 140;
            btnVerContrasena.Text = "👁";
            btnVerContrasena.UseVisualStyleBackColor = true;
            // 
            // txtContrasena
            // 
            txtContrasena.Font = new Font("Segoe UI", 9.75F);
            txtContrasena.Location = new Point(15, 101);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(220, 25);
            txtContrasena.TabIndex = 139;
            txtContrasena.UseSystemPasswordChar = true;
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblContrasena.ForeColor = Color.Black;
            lblContrasena.Location = new Point(15, 81);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(81, 17);
            lblContrasena.TabIndex = 138;
            lblContrasena.Text = "Contraseña:";
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Font = new Font("Segoe UI", 9.75F);
            txtNombreUsuario.Location = new Point(15, 47);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(261, 25);
            txtNombreUsuario.TabIndex = 137;
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombreUsuario.ForeColor = Color.Black;
            lblNombreUsuario.Location = new Point(15, 27);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(181, 17);
            lblNombreUsuario.TabIndex = 136;
            lblNombreUsuario.Text = "Nombre de Usuario (Login):";
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(5, 8, 100);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Columns.AddRange(new DataGridViewColumn[] { colUsuarioId, colNombreUsuario, colNombreCompleto, colRol, colTecnico, colActivo });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(5, 8, 100);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvUsuarios.DefaultCellStyle = dataGridViewCellStyle2;
            dgvUsuarios.Dock = DockStyle.Fill;
            dgvUsuarios.Location = new Point(318, 33);
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(489, 557);
            dgvUsuarios.TabIndex = 20;
            // 
            // colUsuarioId
            // 
            colUsuarioId.DataPropertyName = "UsuarioId";
            colUsuarioId.HeaderText = "IDUsuario";
            colUsuarioId.Name = "colUsuarioId";
            colUsuarioId.ReadOnly = true;
            // 
            // colNombreUsuario
            // 
            colNombreUsuario.DataPropertyName = "NombreUsuario";
            colNombreUsuario.HeaderText = "Usuario";
            colNombreUsuario.Name = "colNombreUsuario";
            colNombreUsuario.ReadOnly = true;
            // 
            // colNombreCompleto
            // 
            colNombreCompleto.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colNombreCompleto.DataPropertyName = "NombreCompleto";
            colNombreCompleto.HeaderText = "Nombre Completo";
            colNombreCompleto.Name = "colNombreCompleto";
            colNombreCompleto.ReadOnly = true;
            // 
            // colRol
            // 
            colRol.DataPropertyName = "RolNombre";
            colRol.HeaderText = "Rol";
            colRol.Name = "colRol";
            colRol.ReadOnly = true;
            // 
            // colTecnico
            // 
            colTecnico.DataPropertyName = "TecnicoNombre";
            colTecnico.HeaderText = "IdTecnico";
            colTecnico.Name = "colTecnico";
            colTecnico.ReadOnly = true;
            // 
            // colActivo
            // 
            colActivo.DataPropertyName = "ActivoTexto";
            colActivo.HeaderText = "Activo";
            colActivo.Name = "colActivo";
            colActivo.ReadOnly = true;
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
            pnlFooter.Location = new Point(318, 553);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(489, 37);
            pnlFooter.TabIndex = 21;
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
            lblClientesTotales.Location = new Point(365, 10);
            lblClientesTotales.Name = "lblClientesTotales";
            lblClientesTotales.Size = new Size(96, 15);
            lblClientesTotales.TabIndex = 17;
            lblClientesTotales.Text = "Usuarios Totales";
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
            // FrmUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(807, 590);
            Controls.Add(pnlFooter);
            Controls.Add(dgvUsuarios);
            Controls.Add(gbxUsuarios);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmUsuarios";
            Text = "FrmUsuarios";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbxIconoClientes).EndInit();
            gbxUsuarios.ResumeLayout(false);
            gbxUsuarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            pnlFooter.ResumeLayout(false);
            pnlFooter.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Button btnCLose;
        private Label lblVentanaUsuariosYRoles;
        private PictureBox pbxIconoClientes;
        private GroupBox gbxUsuarios;
        private Button btnEditar;
        private Button btnCancelar;
        private Button btnAgregar;
        private Label lblClienteId;
        public TextBox txtContrasena;
        public Button btnVerContrasena;
        private Label lblContrasena;
        public TextBox txtNombreUsuario;
        private Label lblNombreUsuario;
        private DataGridView dgvUsuarios;
        private DataGridViewTextBoxColumn colUsuarioId;
        private DataGridViewTextBoxColumn colNombreUsuario;
        private DataGridViewTextBoxColumn colNombreCompleto;
        private DataGridViewTextBoxColumn colRol;
        private DataGridViewTextBoxColumn colTecnico;
        private DataGridViewTextBoxColumn colActivo;
        private Panel pnlFooter;
        private Button btnSiguiente;
        private Button btnUltimo;
        private Button btnAnterior;
        private Button btnPrimero;
        public Label lblClientesTotales;
        public Label lblPaginaActual;
        private ComboBox cbxRegistrosPorPagina;
        public Label lblShow;
        private Label lblRoles;
        public TextBox txtNombreCompleto;
        private Label lblNomCompleto;
        public TextBox txtEmail;
        private Label lblEmail;
        public TextBox txtTelefono;
        private Label lblTel;
        public ComboBox cbxEspecialidad;
        private Label lblEspecialidadSoloTecnico;
        public ComboBox cbxRol;
        private CheckBox chkActivo;
        private Button btnEliminar;
    }
}