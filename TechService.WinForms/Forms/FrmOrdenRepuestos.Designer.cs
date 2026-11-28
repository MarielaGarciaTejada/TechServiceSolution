namespace TechService.WinForms.Forms
{
    partial class FrmOrdenRepuestos
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
            pnlSuperior = new Panel();
            btnCerrar = new Button();
            lblTitulo = new Label();
            lblOrden = new Label();
            cboOrdenes = new ComboBox();
            dgvRepuestos = new DataGridView();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            cboEstadoAprobacion = new ComboBox();
            lblEstado = new Label();
            lblArticulo = new Label();
            cboCatalogo = new ComboBox();
            lblCantidad = new Label();
            nudCantidad = new NumericUpDown();
            pnlSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRepuestos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            SuspendLayout();
            // 
            // pnlSuperior
            // 
            pnlSuperior.BackColor = Color.FromArgb(5, 8, 100);
            pnlSuperior.Controls.Add(btnCerrar);
            pnlSuperior.Controls.Add(lblTitulo);
            pnlSuperior.Dock = DockStyle.Top;
            pnlSuperior.Location = new Point(0, 0);
            pnlSuperior.Name = "pnlSuperior";
            pnlSuperior.Size = new Size(807, 55);
            pnlSuperior.TabIndex = 0;
            // 
            // btnCerrar
            // 
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(765, 8);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(35, 35);
            btnCerrar.TabIndex = 10;
            btnCerrar.Text = "X";
            btnCerrar.UseVisualStyleBackColor = true;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(222, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(318, 24);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Gestión de Repuestos por Orden";
            // 
            // lblOrden
            // 
            lblOrden.AutoSize = true;
            lblOrden.Location = new Point(20, 75);
            lblOrden.Name = "lblOrden";
            lblOrden.Size = new Size(104, 15);
            lblOrden.TabIndex = 1;
            lblOrden.Text = "Seleccionar orden:";
            // 
            // cboOrdenes
            // 
            cboOrdenes.DropDownStyle = ComboBoxStyle.DropDownList;
            cboOrdenes.FormattingEnabled = true;
            cboOrdenes.Location = new Point(150, 72);
            cboOrdenes.Name = "cboOrdenes";
            cboOrdenes.Size = new Size(350, 23);
            cboOrdenes.TabIndex = 2;
            cboOrdenes.SelectedIndexChanged += cboOrdenes_SelectedIndexChanged;
            // 
            // dgvRepuestos
            // 
            dgvRepuestos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRepuestos.Location = new Point(20, 116);
            dgvRepuestos.Name = "dgvRepuestos";
            dgvRepuestos.Size = new Size(760, 250);
            dgvRepuestos.TabIndex = 3;
            dgvRepuestos.CellContentClick += dgvRepuestos_CellContentClick;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(20, 390);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(130, 35);
            btnAgregar.TabIndex = 4;
            btnAgregar.Text = "Agregar repuesto";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(197, 390);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(130, 35);
            btnEditar.TabIndex = 5;
            btnEditar.Text = "Editar repuesto";
            btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(379, 390);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(130, 35);
            btnEliminar.TabIndex = 8;
            btnEliminar.Text = "Eliminar ";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // cboEstadoAprobacion
            // 
            cboEstadoAprobacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstadoAprobacion.FormattingEnabled = true;
            cboEstadoAprobacion.Location = new Point(20, 449);
            cboEstadoAprobacion.Name = "cboEstadoAprobacion";
            cboEstadoAprobacion.Size = new Size(220, 23);
            cboEstadoAprobacion.TabIndex = 9;
            cboEstadoAprobacion.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(20, 430);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(45, 15);
            lblEstado.TabIndex = 10;
            lblEstado.Text = "Estado:";
            // 
            // lblArticulo
            // 
            lblArticulo.AutoSize = true;
            lblArticulo.Location = new Point(270, 430);
            lblArticulo.Name = "lblArticulo";
            lblArticulo.Size = new Size(49, 15);
            lblArticulo.TabIndex = 11;
            lblArticulo.Text = "Articulo";
            // 
            // cboCatalogo
            // 
            cboCatalogo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCatalogo.FormattingEnabled = true;
            cboCatalogo.Location = new Point(270, 449);
            cboCatalogo.Name = "cboCatalogo";
            cboCatalogo.Size = new Size(280, 23);
            cboCatalogo.TabIndex = 12;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(580, 430);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(58, 15);
            lblCantidad.TabIndex = 13;
            lblCantidad.Text = "Cantidad:";
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(580, 449);
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(80, 23);
            nudCantidad.TabIndex = 14;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // FrmOrdenRepuestos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(807, 550);
            Controls.Add(nudCantidad);
            Controls.Add(lblCantidad);
            Controls.Add(cboCatalogo);
            Controls.Add(lblArticulo);
            Controls.Add(lblEstado);
            Controls.Add(cboEstadoAprobacion);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvRepuestos);
            Controls.Add(cboOrdenes);
            Controls.Add(lblOrden);
            Controls.Add(pnlSuperior);
            FormBorderStyle = FormBorderStyle.None;
            Location = new Point(20, 400);
            Name = "FrmOrdenRepuestos";
            Text = "FrmOrdenRepuestos";
            Load += FrmOrdenRepuestos_Load;
            pnlSuperior.ResumeLayout(false);
            pnlSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRepuestos).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlSuperior;
        private Label lblTitulo;
        private Label lblOrden;
        private ComboBox cboOrdenes;
        private DataGridView dgvRepuestos;
        private Button btnAgregar;
        private Button btnEditar;
        private Button btnEliminar;
        private ComboBox cboEstadoAprobacion;
        private Button btnCerrar;
        private Label lblEstado;
        private Label lblArticulo;
        private ComboBox cboCatalogo;
        private Label lblCantidad;
        private NumericUpDown nudCantidad;
    }
}