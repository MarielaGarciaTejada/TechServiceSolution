namespace TechService.WinForms.Forms
{
    partial class FrmDashboard
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
            DataGridViewCellStyle dgvHeaderStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvHeaderStyle2 = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            btnActualizar = new Button();
            lblTitulo = new Label();
            pbxIcono = new PictureBox();
            pnlCards = new TableLayoutPanel();
            pnlCard1 = new Panel();
            lblKpiOrdenesActivas = new Label();
            lblTituloCard1 = new Label();
            pnlCard2 = new Panel();
            lblKpiReparados = new Label();
            lblTituloCard2 = new Label();
            pnlCard3 = new Panel();
            lblKpiClientes = new Label();
            lblTituloCard3 = new Label();
            pnlCard4 = new Panel();
            lblKpiVentas = new Label();
            lblTituloCard4 = new Label();
            pnlContenido = new TableLayoutPanel();
            gbxOrdenes = new GroupBox();
            dgvUltimasOrdenes = new DataGridView();
            colTracking = new DataGridViewTextBoxColumn();
            colCliente = new DataGridViewTextBoxColumn();
            colEquipo = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            colTecnico = new DataGridViewTextBoxColumn();
            colFecha = new DataGridViewTextBoxColumn();
            gbxStock = new GroupBox();
            dgvStockBajo = new DataGridView();
            colSku = new DataGridViewTextBoxColumn();
            colItemNombre = new DataGridViewTextBoxColumn();
            colStock = new DataGridViewTextBoxColumn();
            colAlerta = new DataGridViewTextBoxColumn();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxIcono).BeginInit();
            pnlCards.SuspendLayout();
            pnlCard1.SuspendLayout();
            pnlCard2.SuspendLayout();
            pnlCard3.SuspendLayout();
            pnlCard4.SuspendLayout();
            pnlContenido.SuspendLayout();
            gbxOrdenes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUltimasOrdenes).BeginInit();
            gbxStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStockBajo).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(5, 8, 100);
            pnlHeader.Controls.Add(btnActualizar);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Controls.Add(pbxIcono);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1000, 36);
            pnlHeader.TabIndex = 0;
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnActualizar.BackColor = Color.FromArgb(13, 110, 253);
            btnActualizar.Cursor = Cursors.Hand;
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(870, 5);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(120, 26);
            btnActualizar.TabIndex = 2;
            btnActualizar.Text = "🔄 Actualizar Datos";
            btnActualizar.UseVisualStyleBackColor = false;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(40, 7);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(328, 21);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Dashboard General | Indicadores del Taller";
            // 
            // pbxIcono
            // 
            pbxIcono.Image = Properties.Resources.Dashboard1;
            pbxIcono.Location = new Point(8, 4);
            pbxIcono.Name = "pbxIcono";
            pbxIcono.Size = new Size(28, 28);
            pbxIcono.SizeMode = PictureBoxSizeMode.Zoom;
            pbxIcono.TabIndex = 0;
            pbxIcono.TabStop = false;
            // 
            // pnlCards
            // 
            pnlCards.ColumnCount = 4;
            pnlCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlCards.Controls.Add(pnlCard1, 0, 0);
            pnlCards.Controls.Add(pnlCard2, 1, 0);
            pnlCards.Controls.Add(pnlCard3, 2, 0);
            pnlCards.Controls.Add(pnlCard4, 3, 0);
            pnlCards.Dock = DockStyle.Top;
            pnlCards.Location = new Point(0, 36);
            pnlCards.Name = "pnlCards";
            pnlCards.Padding = new Padding(10);
            pnlCards.RowCount = 1;
            pnlCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlCards.Size = new Size(1000, 110);
            pnlCards.TabIndex = 1;
            // 
            // pnlCard1
            // 
            pnlCard1.BackColor = Color.White;
            pnlCard1.Controls.Add(lblKpiOrdenesActivas);
            pnlCard1.Controls.Add(lblTituloCard1);
            pnlCard1.Dock = DockStyle.Fill;
            pnlCard1.Location = new Point(13, 13);
            pnlCard1.Margin = new Padding(3, 3, 8, 3);
            pnlCard1.Name = "pnlCard1";
            pnlCard1.Padding = new Padding(10);
            pnlCard1.Size = new Size(234, 84);
            pnlCard1.TabIndex = 0;
            // 
            // lblKpiOrdenesActivas
            // 
            lblKpiOrdenesActivas.Dock = DockStyle.Fill;
            lblKpiOrdenesActivas.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblKpiOrdenesActivas.ForeColor = Color.FromArgb(13, 110, 253);
            lblKpiOrdenesActivas.Location = new Point(10, 32);
            lblKpiOrdenesActivas.Name = "lblKpiOrdenesActivas";
            lblKpiOrdenesActivas.Size = new Size(214, 42);
            lblKpiOrdenesActivas.TabIndex = 1;
            lblKpiOrdenesActivas.Text = "0";
            lblKpiOrdenesActivas.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTituloCard1
            // 
            lblTituloCard1.Dock = DockStyle.Top;
            lblTituloCard1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloCard1.ForeColor = Color.FromArgb(100, 116, 139);
            lblTituloCard1.Location = new Point(10, 10);
            lblTituloCard1.Name = "lblTituloCard1";
            lblTituloCard1.Size = new Size(214, 22);
            lblTituloCard1.TabIndex = 0;
            lblTituloCard1.Text = "ÓRDENES ACTIVAS EN TALLER";
            // 
            // pnlCard2
            // 
            pnlCard2.BackColor = Color.White;
            pnlCard2.Controls.Add(lblKpiReparados);
            pnlCard2.Controls.Add(lblTituloCard2);
            pnlCard2.Dock = DockStyle.Fill;
            pnlCard2.Location = new Point(258, 13);
            pnlCard2.Margin = new Padding(3, 3, 8, 3);
            pnlCard2.Name = "pnlCard2";
            pnlCard2.Padding = new Padding(10);
            pnlCard2.Size = new Size(234, 84);
            pnlCard2.TabIndex = 1;
            // 
            // lblKpiReparados
            // 
            lblKpiReparados.Dock = DockStyle.Fill;
            lblKpiReparados.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblKpiReparados.ForeColor = Color.FromArgb(16, 185, 129);
            lblKpiReparados.Location = new Point(10, 32);
            lblKpiReparados.Name = "lblKpiReparados";
            lblKpiReparados.Size = new Size(214, 42);
            lblKpiReparados.TabIndex = 1;
            lblKpiReparados.Text = "0";
            lblKpiReparados.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTituloCard2
            // 
            lblTituloCard2.Dock = DockStyle.Top;
            lblTituloCard2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloCard2.ForeColor = Color.FromArgb(100, 116, 139);
            lblTituloCard2.Location = new Point(10, 10);
            lblTituloCard2.Name = "lblTituloCard2";
            lblTituloCard2.Size = new Size(214, 22);
            lblTituloCard2.TabIndex = 0;
            lblTituloCard2.Text = "EQUIPOS REPARADOS";
            // 
            // pnlCard3
            // 
            pnlCard3.BackColor = Color.White;
            pnlCard3.Controls.Add(lblKpiClientes);
            pnlCard3.Controls.Add(lblTituloCard3);
            pnlCard3.Dock = DockStyle.Fill;
            pnlCard3.Location = new Point(503, 13);
            pnlCard3.Margin = new Padding(3, 3, 8, 3);
            pnlCard3.Name = "pnlCard3";
            pnlCard3.Padding = new Padding(10);
            pnlCard3.Size = new Size(234, 84);
            pnlCard3.TabIndex = 2;
            // 
            // lblKpiClientes
            // 
            lblKpiClientes.Dock = DockStyle.Fill;
            lblKpiClientes.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblKpiClientes.ForeColor = Color.FromArgb(245, 158, 11);
            lblKpiClientes.Location = new Point(10, 32);
            lblKpiClientes.Name = "lblKpiClientes";
            lblKpiClientes.Size = new Size(214, 42);
            lblKpiClientes.TabIndex = 1;
            lblKpiClientes.Text = "0";
            lblKpiClientes.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTituloCard3
            // 
            lblTituloCard3.Dock = DockStyle.Top;
            lblTituloCard3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloCard3.ForeColor = Color.FromArgb(100, 116, 139);
            lblTituloCard3.Location = new Point(10, 10);
            lblTituloCard3.Name = "lblTituloCard3";
            lblTituloCard3.Size = new Size(214, 22);
            lblTituloCard3.TabIndex = 0;
            lblTituloCard3.Text = "TOTAL DE CLIENTES";
            // 
            // pnlCard4
            // 
            pnlCard4.BackColor = Color.White;
            pnlCard4.Controls.Add(lblKpiVentas);
            pnlCard4.Controls.Add(lblTituloCard4);
            pnlCard4.Dock = DockStyle.Fill;
            pnlCard4.Location = new Point(748, 13);
            pnlCard4.Name = "pnlCard4";
            pnlCard4.Padding = new Padding(10);
            pnlCard4.Size = new Size(239, 84);
            pnlCard4.TabIndex = 3;
            // 
            // lblKpiVentas
            // 
            lblKpiVentas.Dock = DockStyle.Fill;
            lblKpiVentas.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblKpiVentas.ForeColor = Color.FromArgb(15, 23, 42);
            lblKpiVentas.Location = new Point(10, 32);
            lblKpiVentas.Name = "lblKpiVentas";
            lblKpiVentas.Size = new Size(219, 42);
            lblKpiVentas.TabIndex = 1;
            lblKpiVentas.Text = "RD$ 0.00";
            lblKpiVentas.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTituloCard4
            // 
            lblTituloCard4.Dock = DockStyle.Top;
            lblTituloCard4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloCard4.ForeColor = Color.FromArgb(100, 116, 139);
            lblTituloCard4.Location = new Point(10, 10);
            lblTituloCard4.Name = "lblTituloCard4";
            lblTituloCard4.Size = new Size(219, 22);
            lblTituloCard4.TabIndex = 0;
            lblTituloCard4.Text = "VENTAS REGISTRADAS";
            // 
            // pnlContenido
            // 
            pnlContenido.ColumnCount = 2;
            pnlContenido.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            pnlContenido.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            pnlContenido.Controls.Add(gbxOrdenes, 0, 0);
            pnlContenido.Controls.Add(gbxStock, 1, 0);
            pnlContenido.Dock = DockStyle.Fill;
            pnlContenido.Location = new Point(0, 146);
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Padding = new Padding(10);
            pnlContenido.RowCount = 1;
            pnlContenido.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlContenido.Size = new Size(1000, 454);
            pnlContenido.TabIndex = 2;
            // 
            // gbxOrdenes
            // 
            gbxOrdenes.Controls.Add(dgvUltimasOrdenes);
            gbxOrdenes.Dock = DockStyle.Fill;
            gbxOrdenes.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbxOrdenes.ForeColor = Color.FromArgb(15, 23, 42);
            gbxOrdenes.Location = new Point(13, 13);
            gbxOrdenes.Name = "gbxOrdenes";
            gbxOrdenes.Padding = new Padding(8);
            gbxOrdenes.Size = new Size(631, 428);
            gbxOrdenes.TabIndex = 0;
            gbxOrdenes.TabStop = false;
            gbxOrdenes.Text = "Órdenes Recientes en Taller";
            // 
            // dgvUltimasOrdenes
            // 
            dgvUltimasOrdenes.AllowUserToAddRows = false;
            dgvUltimasOrdenes.AllowUserToDeleteRows = false;
            dgvUltimasOrdenes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUltimasOrdenes.BackgroundColor = Color.White;
            dgvUltimasOrdenes.BorderStyle = BorderStyle.None;
            dgvHeaderStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvHeaderStyle1.BackColor = Color.FromArgb(15, 23, 42);
            dgvHeaderStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dgvHeaderStyle1.ForeColor = Color.White;
            dgvUltimasOrdenes.ColumnHeadersDefaultCellStyle = dgvHeaderStyle1;
            dgvUltimasOrdenes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUltimasOrdenes.Columns.AddRange(new DataGridViewColumn[] { colTracking, colCliente, colEquipo, colEstado, colTecnico, colFecha });
            dgvUltimasOrdenes.Dock = DockStyle.Fill;
            dgvUltimasOrdenes.EnableHeadersVisualStyles = false;
            dgvUltimasOrdenes.Location = new Point(8, 26);
            dgvUltimasOrdenes.MultiSelect = false;
            dgvUltimasOrdenes.Name = "dgvUltimasOrdenes";
            dgvUltimasOrdenes.ReadOnly = true;
            dgvUltimasOrdenes.RowHeadersVisible = false;
            dgvUltimasOrdenes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUltimasOrdenes.Size = new Size(615, 394);
            dgvUltimasOrdenes.TabIndex = 0;
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
            // colEquipo
            // 
            colEquipo.DataPropertyName = "MarcaModelo";
            colEquipo.FillWeight = 110F;
            colEquipo.HeaderText = "Equipo";
            colEquipo.Name = "colEquipo";
            colEquipo.ReadOnly = true;
            // 
            // colEstado
            // 
            colEstado.DataPropertyName = "EstadoNombre";
            colEstado.FillWeight = 90F;
            colEstado.HeaderText = "Estado";
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            // 
            // colTecnico
            // 
            colTecnico.DataPropertyName = "TecnicoNombre";
            colTecnico.FillWeight = 95F;
            colTecnico.HeaderText = "Técnico";
            colTecnico.Name = "colTecnico";
            colTecnico.ReadOnly = true;
            // 
            // colFecha
            // 
            colFecha.DataPropertyName = "FechaIngresoTexto";
            colFecha.FillWeight = 85F;
            colFecha.HeaderText = "Fecha";
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            // 
            // gbxStock
            // 
            gbxStock.Controls.Add(dgvStockBajo);
            gbxStock.Dock = DockStyle.Fill;
            gbxStock.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbxStock.ForeColor = Color.FromArgb(15, 23, 42);
            gbxStock.Location = new Point(650, 13);
            gbxStock.Name = "gbxStock";
            gbxStock.Padding = new Padding(8);
            gbxStock.Size = new Size(337, 428);
            gbxStock.TabIndex = 1;
            gbxStock.TabStop = false;
            gbxStock.Text = "Alertas de Stock Bajo";
            // 
            // dgvStockBajo
            // 
            dgvStockBajo.AllowUserToAddRows = false;
            dgvStockBajo.AllowUserToDeleteRows = false;
            dgvStockBajo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStockBajo.BackgroundColor = Color.White;
            dgvStockBajo.BorderStyle = BorderStyle.None;
            dgvHeaderStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvHeaderStyle2.BackColor = Color.FromArgb(15, 23, 42);
            dgvHeaderStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dgvHeaderStyle2.ForeColor = Color.White;
            dgvStockBajo.ColumnHeadersDefaultCellStyle = dgvHeaderStyle2;
            dgvStockBajo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStockBajo.Columns.AddRange(new DataGridViewColumn[] { colSku, colItemNombre, colStock, colAlerta });
            dgvStockBajo.Dock = DockStyle.Fill;
            dgvStockBajo.EnableHeadersVisualStyles = false;
            dgvStockBajo.Location = new Point(8, 26);
            dgvStockBajo.MultiSelect = false;
            dgvStockBajo.Name = "dgvStockBajo";
            dgvStockBajo.ReadOnly = true;
            dgvStockBajo.RowHeadersVisible = false;
            dgvStockBajo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStockBajo.Size = new Size(321, 394);
            dgvStockBajo.TabIndex = 0;
            // 
            // colSku
            // 
            colSku.DataPropertyName = "CodigoSku";
            colSku.FillWeight = 70F;
            colSku.HeaderText = "SKU";
            colSku.Name = "colSku";
            colSku.ReadOnly = true;
            // 
            // colItemNombre
            // 
            colItemNombre.DataPropertyName = "Nombre";
            colItemNombre.FillWeight = 140F;
            colItemNombre.HeaderText = "Repuesto / Item";
            colItemNombre.Name = "colItemNombre";
            colItemNombre.ReadOnly = true;
            // 
            // colStock
            // 
            colStock.DataPropertyName = "Stock";
            colStock.FillWeight = 50F;
            colStock.HeaderText = "Stock";
            colStock.Name = "colStock";
            colStock.ReadOnly = true;
            // 
            // colAlerta
            // 
            colAlerta.DataPropertyName = "StockMinimoAlerta";
            colAlerta.FillWeight = 50F;
            colAlerta.HeaderText = "Mín";
            colAlerta.Name = "colAlerta";
            colAlerta.ReadOnly = true;
            // 
            // FrmDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(1000, 600);
            Controls.Add(pnlContenido);
            Controls.Add(pnlCards);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmDashboard";
            Text = "Dashboard General";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbxIcono).EndInit();
            pnlCards.ResumeLayout(false);
            pnlCard1.ResumeLayout(false);
            pnlCard2.ResumeLayout(false);
            pnlCard3.ResumeLayout(false);
            pnlCard4.ResumeLayout(false);
            pnlContenido.ResumeLayout(false);
            gbxOrdenes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUltimasOrdenes).EndInit();
            gbxStock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStockBajo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitulo;
        private PictureBox pbxIcono;
        private Button btnActualizar;
        private TableLayoutPanel pnlCards;
        private Panel pnlCard1;
        private Label lblTituloCard1;
        private Label lblKpiOrdenesActivas;
        private Panel pnlCard2;
        private Label lblTituloCard2;
        private Label lblKpiReparados;
        private Panel pnlCard3;
        private Label lblTituloCard3;
        private Label lblKpiClientes;
        private Panel pnlCard4;
        private Label lblTituloCard4;
        private Label lblKpiVentas;
        private TableLayoutPanel pnlContenido;
        private GroupBox gbxOrdenes;
        private DataGridView dgvUltimasOrdenes;
        private GroupBox gbxStock;
        private DataGridView dgvStockBajo;
        private DataGridViewTextBoxColumn colTracking;
        private DataGridViewTextBoxColumn colCliente;
        private DataGridViewTextBoxColumn colEquipo;
        private DataGridViewTextBoxColumn colEstado;
        private DataGridViewTextBoxColumn colTecnico;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colSku;
        private DataGridViewTextBoxColumn colItemNombre;
        private DataGridViewTextBoxColumn colStock;
        private DataGridViewTextBoxColumn colAlerta;
    }
}
