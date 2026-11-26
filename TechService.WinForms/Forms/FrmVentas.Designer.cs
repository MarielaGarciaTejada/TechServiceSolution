namespace TechService.WinForms.Forms
{
    partial class FrmVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVentas));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            btnCLose = new Button();
            lblPos = new Label();
            pbxIcono = new PictureBox();
            pnlCentral = new Panel();
            cbMetodoPago = new ComboBox();
            lblMetodoPago = new Label();
            btnVender = new Button();
            btnCancelar = new Button();
            label2 = new Label();
            lblDevolucion = new Label();
            label13 = new Label();
            lblEfectivo = new Label();
            lblTotalPagar = new Label();
            lblTotal = new Label();
            txtEfectivo = new TextBox();
            dgvDetalles = new DataGridView();
            colItemId = new DataGridViewTextBoxColumn();
            colCodigoSku = new DataGridViewTextBoxColumn();
            colArticulo = new DataGridViewTextBoxColumn();
            colPrecioUnitario = new DataGridViewTextBoxColumn();
            colCantidad = new DataGridViewTextBoxColumn();
            colSubtotal = new DataGridViewTextBoxColumn();
            btnEliminar = new Button();
            btnAgregar = new Button();
            numCantidad = new NumericUpDown();
            lblCantidad = new Label();
            cbArticulos = new ComboBox();
            lblArticulo = new Label();
            cbClientes = new ComboBox();
            lblCliente = new Label();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxIcono).BeginInit();
            pnlCentral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(5, 8, 100);
            pnlHeader.Controls.Add(btnCLose);
            pnlHeader.Controls.Add(lblPos);
            pnlHeader.Controls.Add(pbxIcono);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(823, 31);
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
            btnCLose.Location = new Point(790, -1);
            btnCLose.Name = "btnCLose";
            btnCLose.Size = new Size(30, 30);
            btnCLose.TabIndex = 126;
            btnCLose.UseVisualStyleBackColor = false;
            // 
            // lblPos
            // 
            lblPos.AutoSize = true;
            lblPos.BackColor = Color.FromArgb(5, 8, 100);
            lblPos.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPos.ForeColor = Color.White;
            lblPos.Location = new Point(41, 3);
            lblPos.Name = "lblPos";
            lblPos.Size = new Size(388, 25);
            lblPos.TabIndex = 11;
            lblPos.Text = "Punto de Venta (POS) - Caja de Mostrador";
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
            pnlCentral.Controls.Add(cbMetodoPago);
            pnlCentral.Controls.Add(lblMetodoPago);
            pnlCentral.Controls.Add(btnVender);
            pnlCentral.Controls.Add(btnCancelar);
            pnlCentral.Controls.Add(label2);
            pnlCentral.Controls.Add(lblDevolucion);
            pnlCentral.Controls.Add(label13);
            pnlCentral.Controls.Add(lblEfectivo);
            pnlCentral.Controls.Add(lblTotalPagar);
            pnlCentral.Controls.Add(lblTotal);
            pnlCentral.Controls.Add(txtEfectivo);
            pnlCentral.Controls.Add(dgvDetalles);
            pnlCentral.Controls.Add(btnEliminar);
            pnlCentral.Controls.Add(btnAgregar);
            pnlCentral.Controls.Add(numCantidad);
            pnlCentral.Controls.Add(lblCantidad);
            pnlCentral.Controls.Add(cbArticulos);
            pnlCentral.Controls.Add(lblArticulo);
            pnlCentral.Controls.Add(cbClientes);
            pnlCentral.Controls.Add(lblCliente);
            pnlCentral.Dock = DockStyle.Fill;
            pnlCentral.Location = new Point(0, 31);
            pnlCentral.Name = "pnlCentral";
            pnlCentral.Size = new Size(823, 598);
            pnlCentral.TabIndex = 4;
            // 
            // cbMetodoPago
            // 
            cbMetodoPago.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMetodoPago.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbMetodoPago.FormattingEnabled = true;
            cbMetodoPago.Location = new Point(161, 125);
            cbMetodoPago.Name = "cbMetodoPago";
            cbMetodoPago.Size = new Size(183, 25);
            cbMetodoPago.TabIndex = 155;
            cbMetodoPago.SelectedIndexChanged += cbMetodoPago_SelectedIndexChanged;
            // 
            // lblMetodoPago
            // 
            lblMetodoPago.AutoSize = true;
            lblMetodoPago.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblMetodoPago.ForeColor = Color.Black;
            lblMetodoPago.Location = new Point(40, 129);
            lblMetodoPago.Name = "lblMetodoPago";
            lblMetodoPago.Size = new Size(114, 17);
            lblMetodoPago.TabIndex = 154;
            lblMetodoPago.Text = "Método de Pago:";
            // 
            // btnVender
            // 
            btnVender.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnVender.BackColor = Color.ForestGreen;
            btnVender.Cursor = Cursors.Hand;
            btnVender.FlatStyle = FlatStyle.Flat;
            btnVender.ForeColor = Color.White;
            btnVender.Location = new Point(532, 521);
            btnVender.Name = "btnVender";
            btnVender.Size = new Size(140, 28);
            btnVender.TabIndex = 153;
            btnVender.Text = "Vender";
            btnVender.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnCancelar.BackColor = Color.Red;
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(141, 521);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(140, 28);
            btnCancelar.TabIndex = 152;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(348, 477);
            label2.Name = "label2";
            label2.Size = new Size(125, 15);
            label2.TabIndex = 151;
            label2.Text = "CON ITBIS INCLUIDO";
            // 
            // lblDevolucion
            // 
            lblDevolucion.Anchor = AnchorStyles.Bottom;
            lblDevolucion.AutoSize = true;
            lblDevolucion.Location = new Point(647, 420);
            lblDevolucion.Name = "lblDevolucion";
            lblDevolucion.Size = new Size(12, 15);
            lblDevolucion.TabIndex = 150;
            lblDevolucion.Text = "-";
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Bottom;
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label13.Location = new Point(543, 420);
            label13.Name = "label13";
            label13.Size = new Size(86, 15);
            label13.TabIndex = 149;
            label13.Text = "DEVOLUCIÓN:";
            // 
            // lblEfectivo
            // 
            lblEfectivo.Anchor = AnchorStyles.Bottom;
            lblEfectivo.AutoSize = true;
            lblEfectivo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEfectivo.Location = new Point(373, 420);
            lblEfectivo.Name = "lblEfectivo";
            lblEfectivo.Size = new Size(63, 15);
            lblEfectivo.TabIndex = 148;
            lblEfectivo.Text = "EFECTIVO:";
            // 
            // lblTotalPagar
            // 
            lblTotalPagar.Anchor = AnchorStyles.Bottom;
            lblTotalPagar.AutoSize = true;
            lblTotalPagar.Location = new Point(253, 420);
            lblTotalPagar.Name = "lblTotalPagar";
            lblTotalPagar.Size = new Size(12, 15);
            lblTotalPagar.TabIndex = 147;
            lblTotalPagar.Text = "-";
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.Bottom;
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotal.Location = new Point(128, 420);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(99, 15);
            lblTotal.TabIndex = 146;
            lblTotal.Text = "TOTAL A PAGAR:";
            // 
            // txtEfectivo
            // 
            txtEfectivo.Anchor = AnchorStyles.Bottom;
            txtEfectivo.Location = new Point(349, 446);
            txtEfectivo.Name = "txtEfectivo";
            txtEfectivo.Size = new Size(116, 23);
            txtEfectivo.TabIndex = 145;
            txtEfectivo.TextAlign = HorizontalAlignment.Center;
            // 
            // dgvDetalles
            // 
            dgvDetalles.AllowUserToAddRows = false;
            dgvDetalles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(5, 8, 100);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDetalles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Columns.AddRange(new DataGridViewColumn[] { colItemId, colCodigoSku, colArticulo, colPrecioUnitario, colCantidad, colSubtotal });
            dgvDetalles.EnableHeadersVisualStyles = false;
            dgvDetalles.Location = new Point(70, 178);
            dgvDetalles.MultiSelect = false;
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.Size = new Size(694, 215);
            dgvDetalles.TabIndex = 144;
            // 
            // colItemId
            // 
            colItemId.DataPropertyName = "ItemId";
            colItemId.HeaderText = "ItemId";
            colItemId.Name = "colItemId";
            colItemId.Visible = false;
            // 
            // colCodigoSku
            // 
            colCodigoSku.DataPropertyName = "CodigoSku";
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            colCodigoSku.DefaultCellStyle = dataGridViewCellStyle2;
            colCodigoSku.HeaderText = "Código SKU";
            colCodigoSku.Name = "colCodigoSku";
            // 
            // colArticulo
            // 
            colArticulo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colArticulo.DataPropertyName = "Articulo";
            colArticulo.HeaderText = "Artículo";
            colArticulo.Name = "colArticulo";
            // 
            // colPrecioUnitario
            // 
            colPrecioUnitario.DataPropertyName = "PrecioUnitario";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            colPrecioUnitario.DefaultCellStyle = dataGridViewCellStyle3;
            colPrecioUnitario.HeaderText = "Precio Unit";
            colPrecioUnitario.Name = "colPrecioUnitario";
            // 
            // colCantidad
            // 
            colCantidad.DataPropertyName = "Cantidad";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colCantidad.DefaultCellStyle = dataGridViewCellStyle4;
            colCantidad.HeaderText = "Cantidad";
            colCantidad.Name = "colCantidad";
            // 
            // colSubtotal
            // 
            colSubtotal.DataPropertyName = "Subtotal";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            colSubtotal.DefaultCellStyle = dataGridViewCellStyle5;
            colSubtotal.HeaderText = "Subtotal";
            colSubtotal.Name = "colSubtotal";
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEliminar.BackColor = Color.Red;
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(668, 48);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(140, 28);
            btnEliminar.TabIndex = 143;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregar.BackColor = Color.FromArgb(13, 110, 253);
            btnAgregar.Cursor = Cursors.Hand;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(668, 82);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(140, 28);
            btnAgregar.TabIndex = 142;
            btnAgregar.Text = "Agregar a Factura";
            btnAgregar.UseVisualStyleBackColor = false;
            // 
            // numCantidad
            // 
            numCantidad.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numCantidad.Location = new Point(544, 82);
            numCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(72, 23);
            numCantidad.TabIndex = 141;
            numCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblCantidad
            // 
            lblCantidad.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblCantidad.ForeColor = Color.Black;
            lblCantidad.Location = new Point(467, 87);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(67, 17);
            lblCantidad.TabIndex = 132;
            lblCantidad.Text = "Cantidad:";
            // 
            // cbArticulos
            // 
            cbArticulos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbArticulos.DropDownStyle = ComboBoxStyle.DropDownList;
            cbArticulos.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbArticulos.FormattingEnabled = true;
            cbArticulos.Location = new Point(115, 83);
            cbArticulos.Name = "cbArticulos";
            cbArticulos.Size = new Size(343, 25);
            cbArticulos.TabIndex = 131;
            // 
            // lblArticulo
            // 
            lblArticulo.AutoSize = true;
            lblArticulo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblArticulo.ForeColor = Color.Black;
            lblArticulo.Location = new Point(41, 87);
            lblArticulo.Name = "lblArticulo";
            lblArticulo.Size = new Size(61, 17);
            lblArticulo.TabIndex = 130;
            lblArticulo.Text = "Artículo:";
            // 
            // cbClientes
            // 
            cbClientes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cbClientes.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbClientes.FormattingEnabled = true;
            cbClientes.Location = new Point(115, 45);
            cbClientes.Name = "cbClientes";
            cbClientes.Size = new Size(343, 25);
            cbClientes.TabIndex = 129;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblCliente.ForeColor = Color.Black;
            lblCliente.Location = new Point(41, 49);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(55, 17);
            lblCliente.TabIndex = 128;
            lblCliente.Text = "Cliente:";
            // 
            // FrmVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(823, 629);
            Controls.Add(pnlCentral);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmVentas";
            Text = "FormPOS";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbxIcono).EndInit();
            pnlCentral.ResumeLayout(false);
            pnlCentral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Button btnCLose;
        private Label lblPos;
        private PictureBox pbxIcono;
        private Panel pnlCentral;
        public ComboBox cbClientes;
        private Label lblCliente;
        private Label lblCantidad;
        public ComboBox cbArticulos;
        private Label lblArticulo;
        private NumericUpDown numCantidad;
        private Button btnAgregar;
        private Button btnEliminar;
        private DataGridView dgvDetalles;
        private Button btnVender;
        private Button btnCancelar;
        private Label label2;
        private Label lblDevolucion;
        private Label label13;
        private Label lblEfectivo;
        private Label lblTotalPagar;
        private Label lblTotal;
        private TextBox txtEfectivo;
        public ComboBox cbMetodoPago;
        private Label lblMetodoPago;
        private DataGridViewTextBoxColumn colItemId;
        private DataGridViewTextBoxColumn colCodigoSku;
        private DataGridViewTextBoxColumn colArticulo;
        private DataGridViewTextBoxColumn colPrecioUnitario;
        private DataGridViewTextBoxColumn colCantidad;
        private DataGridViewTextBoxColumn colSubtotal;
    }
}