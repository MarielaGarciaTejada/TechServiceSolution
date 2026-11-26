namespace TechService.WinForms.Forms
{
    partial class FrmHistorial
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dgvHeader1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvHeader2 = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            btnCLose = new Button();
            lblTitulo = new Label();
            pbxIcono = new PictureBox();
            pnlFiltros = new Panel();
            btnLimpiar = new Button();
            btnBuscar = new Button();
            cbxEstado = new ComboBox();
            lblFiltroEstado = new Label();
            txtBuscar = new TextBox();
            lblBuscar = new Label();
            splitPrincipal = new SplitContainer();
            gbxOrdenes = new GroupBox();
            dgvOrdenes = new DataGridView();
            colTracking = new DataGridViewTextBoxColumn();
            colCliente = new DataGridViewTextBoxColumn();
            colTelefono = new DataGridViewTextBoxColumn();
            colEquipo = new DataGridViewTextBoxColumn();
            colSerial = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            colTecnico = new DataGridViewTextBoxColumn();
            colManoObra = new DataGridViewTextBoxColumn();
            colFechaIngreso = new DataGridViewTextBoxColumn();
            tbDetalles = new TabControl();
            tpEventos = new TabPage();
            dgvEventos = new DataGridView();
            colEventoFecha = new DataGridViewTextBoxColumn();
            colEventoAutor = new DataGridViewTextBoxColumn();
            colEventoOrigen = new DataGridViewTextBoxColumn();
            colEventoMensaje = new DataGridViewTextBoxColumn();
            tpGarantia = new TabPage();
            pnlGarantiaInfo = new Panel();
            lblObsGarantia = new Label();
            lblTotalGarantia = new Label();
            lblVencimientoGarantia = new Label();
            lblDiasGarantia = new Label();
            lblFechaEntregaGarantia = new Label();
            pnlFooter = new Panel();
            lblTotalManoObra = new Label();
            lblTotalOrdenes = new Label();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxIcono).BeginInit();
            pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitPrincipal).BeginInit();
            splitPrincipal.Panel1.SuspendLayout();
            splitPrincipal.Panel2.SuspendLayout();
            splitPrincipal.SuspendLayout();
            gbxOrdenes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrdenes).BeginInit();
            tbDetalles.SuspendLayout();
            tpEventos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEventos).BeginInit();
            tpGarantia.SuspendLayout();
            pnlGarantiaInfo.SuspendLayout();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(5, 8, 100);
            pnlHeader.Controls.Add(btnCLose);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Controls.Add(pbxIcono);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1000, 34);
            pnlHeader.TabIndex = 0;
            // 
            // btnCLose
            // 
            btnCLose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCLose.Cursor = Cursors.Hand;
            btnCLose.FlatAppearance.BorderSize = 0;
            btnCLose.FlatStyle = FlatStyle.Flat;
            btnCLose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCLose.ForeColor = Color.White;
            btnCLose.Location = new Point(965, 3);
            btnCLose.Name = "btnCLose";
            btnCLose.Size = new Size(30, 28);
            btnCLose.TabIndex = 2;
            btnCLose.Text = "✕";
            btnCLose.UseVisualStyleBackColor = false;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(42, 6);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(328, 21);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Historial de Órdenes & Reportes de Taller";
            // 
            // pbxIcono
            // 
            pbxIcono.Image = Properties.Resources.Recepcion;
            pbxIcono.Location = new Point(8, 3);
            pbxIcono.Name = "pbxIcono";
            pbxIcono.Size = new Size(28, 28);
            pbxIcono.SizeMode = PictureBoxSizeMode.Zoom;
            pbxIcono.TabIndex = 0;
            pbxIcono.TabStop = false;
            // 
            // pnlFiltros
            // 
            pnlFiltros.BackColor = Color.White;
            pnlFiltros.Controls.Add(btnLimpiar);
            pnlFiltros.Controls.Add(btnBuscar);
            pnlFiltros.Controls.Add(cbxEstado);
            pnlFiltros.Controls.Add(lblFiltroEstado);
            pnlFiltros.Controls.Add(txtBuscar);
            pnlFiltros.Controls.Add(lblBuscar);
            pnlFiltros.Dock = DockStyle.Top;
            pnlFiltros.Location = new Point(0, 34);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Size = new Size(1000, 48);
            pnlFiltros.TabIndex = 1;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(100, 116, 139);
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(715, 11);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 26);
            btnLimpiar.TabIndex = 5;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.FromArgb(13, 110, 253);
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(625, 11);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(80, 26);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "🔍 Filtrar";
            btnBuscar.UseVisualStyleBackColor = false;
            // 
            // cbxEstado
            // 
            cbxEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxEstado.Font = new Font("Segoe UI", 9F);
            cbxEstado.FormattingEnabled = true;
            cbxEstado.Location = new Point(460, 12);
            cbxEstado.Name = "cbxEstado";
            cbxEstado.Size = new Size(150, 23);
            cbxEstado.TabIndex = 3;
            // 
            // lblFiltroEstado
            // 
            lblFiltroEstado.AutoSize = true;
            lblFiltroEstado.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFiltroEstado.Location = new Point(405, 16);
            lblFiltroEstado.Name = "lblFiltroEstado";
            lblFiltroEstado.Size = new Size(46, 15);
            lblFiltroEstado.TabIndex = 2;
            lblFiltroEstado.Text = "Estado:";
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Segoe UI", 9F);
            txtBuscar.Location = new Point(140, 12);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Tracking, cliente, serial o modelo...";
            txtBuscar.Size = new Size(245, 23);
            txtBuscar.TabIndex = 1;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBuscar.Location = new Point(15, 16);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(116, 15);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Búsqueda Rápida:";
            // 
            // splitPrincipal
            // 
            splitPrincipal.Dock = DockStyle.Fill;
            splitPrincipal.Location = new Point(0, 82);
            splitPrincipal.Name = "splitPrincipal";
            splitPrincipal.Orientation = Orientation.Horizontal;
            // 
            // splitPrincipal.Panel1
            // 
            splitPrincipal.Panel1.Controls.Add(gbxOrdenes);
            splitPrincipal.Panel1.Padding = new Padding(8, 4, 8, 4);
            // 
            // splitPrincipal.Panel2
            // 
            splitPrincipal.Panel2.Controls.Add(tbDetalles);
            splitPrincipal.Panel2.Padding = new Padding(8, 4, 8, 4);
            splitPrincipal.Size = new Size(1000, 488);
            splitPrincipal.SplitterDistance = 270;
            splitPrincipal.TabIndex = 2;
            // 
            // gbxOrdenes
            // 
            gbxOrdenes.Controls.Add(dgvOrdenes);
            gbxOrdenes.Dock = DockStyle.Fill;
            gbxOrdenes.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            gbxOrdenes.Location = new Point(8, 4);
            gbxOrdenes.Name = "gbxOrdenes";
            gbxOrdenes.Padding = new Padding(6);
            gbxOrdenes.Size = new Size(984, 262);
            gbxOrdenes.TabIndex = 0;
            gbxOrdenes.TabStop = false;
            gbxOrdenes.Text = "Órdenes Registradas";
            // 
            // dgvOrdenes
            // 
            dgvOrdenes.AllowUserToAddRows = false;
            dgvOrdenes.AllowUserToDeleteRows = false;
            dgvOrdenes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrdenes.BackgroundColor = Color.White;
            dgvOrdenes.BorderStyle = BorderStyle.None;
            dgvHeader1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvHeader1.BackColor = Color.FromArgb(15, 23, 42);
            dgvHeader1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dgvHeader1.ForeColor = Color.White;
            dgvOrdenes.ColumnHeadersDefaultCellStyle = dgvHeader1;
            dgvOrdenes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrdenes.Columns.AddRange(new DataGridViewColumn[] { colTracking, colCliente, colTelefono, colEquipo, colSerial, colEstado, colTecnico, colManoObra, colFechaIngreso });
            dgvOrdenes.Dock = DockStyle.Fill;
            dgvOrdenes.EnableHeadersVisualStyles = false;
            dgvOrdenes.Location = new Point(6, 24);
            dgvOrdenes.MultiSelect = false;
            dgvOrdenes.Name = "dgvOrdenes";
            dgvOrdenes.ReadOnly = true;
            dgvOrdenes.RowHeadersVisible = false;
            dgvOrdenes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrdenes.Size = new Size(972, 232);
            dgvOrdenes.TabIndex = 0;
            // 
            // colTracking
            // 
            colTracking.DataPropertyName = "CodigoTracking";
            colTracking.FillWeight = 85F;
            colTracking.HeaderText = "Tracking";
            colTracking.Name = "colTracking";
            colTracking.ReadOnly = true;
            // 
            // colCliente
            // 
            colCliente.DataPropertyName = "ClienteNombre";
            colCliente.FillWeight = 110F;
            colCliente.HeaderText = "Cliente";
            colCliente.Name = "colCliente";
            colCliente.ReadOnly = true;
            // 
            // colTelefono
            // 
            colTelefono.DataPropertyName = "ClienteTelefono";
            colTelefono.FillWeight = 85F;
            colTelefono.HeaderText = "Teléfono";
            colTelefono.Name = "colTelefono";
            colTelefono.ReadOnly = true;
            // 
            // colEquipo
            // 
            colEquipo.DataPropertyName = "MarcaModelo";
            colEquipo.FillWeight = 100F;
            colEquipo.HeaderText = "Equipo";
            colEquipo.Name = "colEquipo";
            colEquipo.ReadOnly = true;
            // 
            // colSerial
            // 
            colSerial.DataPropertyName = "NumeroSerieImei";
            colSerial.FillWeight = 85F;
            colSerial.HeaderText = "Serial / IMEI";
            colSerial.Name = "colSerial";
            colSerial.ReadOnly = true;
            // 
            // colEstado
            // 
            colEstado.DataPropertyName = "EstadoNombre";
            colEstado.FillWeight = 85F;
            colEstado.HeaderText = "Estado";
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            // 
            // colTecnico
            // 
            colTecnico.DataPropertyName = "TecnicoNombre";
            colTecnico.FillWeight = 90F;
            colTecnico.HeaderText = "Técnico";
            colTecnico.Name = "colTecnico";
            colTecnico.ReadOnly = true;
            // 
            // colManoObra
            // 
            colManoObra.DataPropertyName = "ManoObraTexto";
            colManoObra.FillWeight = 85F;
            colManoObra.HeaderText = "Mano de Obra";
            colManoObra.Name = "colManoObra";
            colManoObra.ReadOnly = true;
            // 
            // colFechaIngreso
            // 
            colFechaIngreso.DataPropertyName = "FechaIngresoTexto";
            colFechaIngreso.FillWeight = 90F;
            colFechaIngreso.HeaderText = "Fecha Ingreso";
            colFechaIngreso.Name = "colFechaIngreso";
            colFechaIngreso.ReadOnly = true;
            // 
            // tbDetalles
            // 
            tbDetalles.Controls.Add(tpEventos);
            tbDetalles.Controls.Add(tpGarantia);
            tbDetalles.Dock = DockStyle.Fill;
            tbDetalles.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            tbDetalles.Location = new Point(8, 4);
            tbDetalles.Name = "tbDetalles";
            tbDetalles.SelectedIndex = 0;
            tbDetalles.Size = new Size(984, 206);
            tbDetalles.TabIndex = 0;
            // 
            // tpEventos
            // 
            tpEventos.Controls.Add(dgvEventos);
            tpEventos.Location = new Point(4, 24);
            tpEventos.Name = "tpEventos";
            tpEventos.Padding = new Padding(3);
            tpEventos.Size = new Size(976, 178);
            tpEventos.TabIndex = 0;
            tpEventos.Text = "Bitácora de Eventos de la Orden";
            tpEventos.UseVisualStyleBackColor = true;
            // 
            // dgvEventos
            // 
            dgvEventos.AllowUserToAddRows = false;
            dgvEventos.AllowUserToDeleteRows = false;
            dgvEventos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEventos.BackgroundColor = Color.White;
            dgvEventos.BorderStyle = BorderStyle.None;
            dgvHeader2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvHeader2.BackColor = Color.FromArgb(5, 8, 100);
            dgvHeader2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dgvHeader2.ForeColor = Color.White;
            dgvEventos.ColumnHeadersDefaultCellStyle = dgvHeader2;
            dgvEventos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEventos.Columns.AddRange(new DataGridViewColumn[] { colEventoFecha, colEventoAutor, colEventoOrigen, colEventoMensaje });
            dgvEventos.Dock = DockStyle.Fill;
            dgvEventos.EnableHeadersVisualStyles = false;
            dgvEventos.Location = new Point(3, 3);
            dgvEventos.MultiSelect = false;
            dgvEventos.Name = "dgvEventos";
            dgvEventos.ReadOnly = true;
            dgvEventos.RowHeadersVisible = false;
            dgvEventos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEventos.Size = new Size(970, 172);
            dgvEventos.TabIndex = 0;
            // 
            // colEventoFecha
            // 
            colEventoFecha.DataPropertyName = "FechaTexto";
            colEventoFecha.FillWeight = 70F;
            colEventoFecha.HeaderText = "Fecha / Hora";
            colEventoFecha.Name = "colEventoFecha";
            colEventoFecha.ReadOnly = true;
            // 
            // colEventoAutor
            // 
            colEventoAutor.DataPropertyName = "Autor";
            colEventoAutor.FillWeight = 60F;
            colEventoAutor.HeaderText = "Autor";
            colEventoAutor.Name = "colEventoAutor";
            colEventoAutor.ReadOnly = true;
            // 
            // colEventoOrigen
            // 
            colEventoOrigen.DataPropertyName = "Origen";
            colEventoOrigen.FillWeight = 50F;
            colEventoOrigen.HeaderText = "Origen";
            colEventoOrigen.Name = "colEventoOrigen";
            colEventoOrigen.ReadOnly = true;
            // 
            // colEventoMensaje
            // 
            colEventoMensaje.DataPropertyName = "Mensaje";
            colEventoMensaje.FillWeight = 160F;
            colEventoMensaje.HeaderText = "Mensaje / Observación";
            colEventoMensaje.Name = "colEventoMensaje";
            colEventoMensaje.ReadOnly = true;
            // 
            // tpGarantia
            // 
            tpGarantia.Controls.Add(pnlGarantiaInfo);
            tpGarantia.Location = new Point(4, 24);
            tpGarantia.Name = "tpGarantia";
            tpGarantia.Padding = new Padding(3);
            tpGarantia.Size = new Size(976, 178);
            tpGarantia.TabIndex = 1;
            tpGarantia.Text = "Entrega y Garantía";
            tpGarantia.UseVisualStyleBackColor = true;
            // 
            // pnlGarantiaInfo
            // 
            pnlGarantiaInfo.BackColor = Color.FromArgb(248, 250, 252);
            pnlGarantiaInfo.Controls.Add(lblObsGarantia);
            pnlGarantiaInfo.Controls.Add(lblTotalGarantia);
            pnlGarantiaInfo.Controls.Add(lblVencimientoGarantia);
            pnlGarantiaInfo.Controls.Add(lblDiasGarantia);
            pnlGarantiaInfo.Controls.Add(lblFechaEntregaGarantia);
            pnlGarantiaInfo.Dock = DockStyle.Fill;
            pnlGarantiaInfo.Location = new Point(3, 3);
            pnlGarantiaInfo.Name = "pnlGarantiaInfo";
            pnlGarantiaInfo.Padding = new Padding(20);
            pnlGarantiaInfo.Size = new Size(970, 172);
            pnlGarantiaInfo.TabIndex = 0;
            // 
            // lblObsGarantia
            // 
            lblObsGarantia.AutoSize = true;
            lblObsGarantia.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblObsGarantia.Location = new Point(20, 105);
            lblObsGarantia.Name = "lblObsGarantia";
            lblObsGarantia.Size = new Size(183, 17);
            lblObsGarantia.TabIndex = 4;
            lblObsGarantia.Text = "Observación de Entrega: N/A";
            // 
            // lblTotalGarantia
            // 
            lblTotalGarantia.AutoSize = true;
            lblTotalGarantia.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotalGarantia.ForeColor = Color.FromArgb(16, 185, 129);
            lblTotalGarantia.Location = new Point(450, 60);
            lblTotalGarantia.Name = "lblTotalGarantia";
            lblTotalGarantia.Size = new Size(180, 20);
            lblTotalGarantia.TabIndex = 3;
            lblTotalGarantia.Text = "Total Cobrado: RD$ 0.00";
            // 
            // lblVencimientoGarantia
            // 
            lblVencimientoGarantia.AutoSize = true;
            lblVencimientoGarantia.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVencimientoGarantia.Location = new Point(450, 20);
            lblVencimientoGarantia.Name = "lblVencimientoGarantia";
            lblVencimientoGarantia.Size = new Size(177, 17);
            lblVencimientoGarantia.TabIndex = 2;
            lblVencimientoGarantia.Text = "Vencimiento Garantía: N/A";
            // 
            // lblDiasGarantia
            // 
            lblDiasGarantia.AutoSize = true;
            lblDiasGarantia.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDiasGarantia.Location = new Point(20, 60);
            lblDiasGarantia.Name = "lblDiasGarantia";
            lblDiasGarantia.Size = new Size(130, 17);
            lblDiasGarantia.TabIndex = 1;
            lblDiasGarantia.Text = "Días de Garantía: N/A";
            // 
            // lblFechaEntregaGarantia
            // 
            lblFechaEntregaGarantia.AutoSize = true;
            lblFechaEntregaGarantia.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFechaEntregaGarantia.Location = new Point(20, 20);
            lblFechaEntregaGarantia.Name = "lblFechaEntregaGarantia";
            lblFechaEntregaGarantia.Size = new Size(137, 17);
            lblFechaEntregaGarantia.TabIndex = 0;
            lblFechaEntregaGarantia.Text = "Fecha de Entrega: N/A";
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.FromArgb(15, 23, 42);
            pnlFooter.Controls.Add(lblTotalManoObra);
            pnlFooter.Controls.Add(lblTotalOrdenes);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 570);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(1000, 30);
            pnlFooter.TabIndex = 3;
            // 
            // lblTotalManoObra
            // 
            lblTotalManoObra.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalManoObra.AutoSize = true;
            lblTotalManoObra.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalManoObra.ForeColor = Color.FromArgb(16, 185, 129);
            lblTotalManoObra.Location = new Point(720, 7);
            lblTotalManoObra.Name = "lblTotalManoObra";
            lblTotalManoObra.Size = new Size(244, 15);
            lblTotalManoObra.TabIndex = 1;
            lblTotalManoObra.Text = "Total Facturado Mano de Obra: RD$ 0.00";
            // 
            // lblTotalOrdenes
            // 
            lblTotalOrdenes.AutoSize = true;
            lblTotalOrdenes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalOrdenes.ForeColor = Color.White;
            lblTotalOrdenes.Location = new Point(12, 7);
            lblTotalOrdenes.Name = "lblTotalOrdenes";
            lblTotalOrdenes.Size = new Size(120, 15);
            lblTotalOrdenes.TabIndex = 0;
            lblTotalOrdenes.Text = "Total de Órdenes: 0";
            // 
            // FrmHistorial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(1000, 600);
            Controls.Add(splitPrincipal);
            Controls.Add(pnlFooter);
            Controls.Add(pnlFiltros);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmHistorial";
            Text = "Historial y Reportes";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbxIcono).EndInit();
            pnlFiltros.ResumeLayout(false);
            pnlFiltros.PerformLayout();
            splitPrincipal.Panel1.ResumeLayout(false);
            splitPrincipal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitPrincipal).EndInit();
            splitPrincipal.ResumeLayout(false);
            gbxOrdenes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOrdenes).EndInit();
            tbDetalles.ResumeLayout(false);
            tpEventos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEventos).EndInit();
            tpGarantia.ResumeLayout(false);
            pnlGarantiaInfo.ResumeLayout(false);
            pnlGarantiaInfo.PerformLayout();
            pnlFooter.ResumeLayout(false);
            pnlFooter.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitulo;
        private PictureBox pbxIcono;
        private Button btnCLose;
        private Panel pnlFiltros;
        private TextBox txtBuscar;
        private Label lblBuscar;
        private Label lblFiltroEstado;
        private ComboBox cbxEstado;
        private Button btnBuscar;
        private Button btnLimpiar;
        private SplitContainer splitPrincipal;
        private GroupBox gbxOrdenes;
        private DataGridView dgvOrdenes;
        private TabControl tbDetalles;
        private TabPage tpEventos;
        private TabPage tpGarantia;
        private DataGridView dgvEventos;
        private Panel pnlGarantiaInfo;
        private Label lblFechaEntregaGarantia;
        private Label lblDiasGarantia;
        private Label lblVencimientoGarantia;
        private Label lblTotalGarantia;
        private Label lblObsGarantia;
        private Panel pnlFooter;
        private Label lblTotalOrdenes;
        private Label lblTotalManoObra;
        private DataGridViewTextBoxColumn colTracking;
        private DataGridViewTextBoxColumn colCliente;
        private DataGridViewTextBoxColumn colTelefono;
        private DataGridViewTextBoxColumn colEquipo;
        private DataGridViewTextBoxColumn colSerial;
        private DataGridViewTextBoxColumn colEstado;
        private DataGridViewTextBoxColumn colTecnico;
        private DataGridViewTextBoxColumn colManoObra;
        private DataGridViewTextBoxColumn colFechaIngreso;
        private DataGridViewTextBoxColumn colEventoFecha;
        private DataGridViewTextBoxColumn colEventoAutor;
        private DataGridViewTextBoxColumn colEventoOrigen;
        private DataGridViewTextBoxColumn colEventoMensaje;
    }
}
