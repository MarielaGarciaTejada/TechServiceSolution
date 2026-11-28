namespace TechService.WinForms.Forms
{
    partial class FrmEntregasGarantia
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
            pnlTop = new Panel();
            btnCLose = new Button();
            lblTitulo = new Label();
            lblTracking = new Label();
            txtTracking = new TextBox();
            btnBuscar = new Button();
            lblOrden = new Label();
            comboBox1 = new ComboBox();
            lblClienteT = new Label();
            lblCliente = new Label();
            lblEquipoT = new Label();
            lblEquipo = new Label();
            lblManoObraT = new Label();
            lblManoObra = new Label();
            lblRepuestosT = new Label();
            lblRepuestos = new Label();
            lblTotalT = new Label();
            lblTotal = new Label();
            lblMetodoT = new Label();
            cmbMetodoPago = new ComboBox();
            lblGarantiaT = new Label();
            txtObservacion = new TextBox();
            lblObservacion = new Label();
            nudDiasGarantia = new NumericUpDown();
            btnConfirmar = new Button();
            btnLimpiar = new Button();
            dgvEntregas = new DataGridView();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudDiasGarantia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEntregas).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(5, 8, 100);
            pnlTop.Controls.Add(btnCLose);
            pnlTop.Controls.Add(lblTitulo);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(805, 50);
            pnlTop.TabIndex = 0;
            // 
            // btnCLose
            // 
            btnCLose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCLose.FlatStyle = FlatStyle.Flat;
            btnCLose.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCLose.ForeColor = Color.White;
            btnCLose.Location = new Point(763, 8);
            btnCLose.Name = "btnCLose";
            btnCLose.Size = new Size(35, 35);
            btnCLose.TabIndex = 2;
            btnCLose.Text = "X";
            btnCLose.UseVisualStyleBackColor = true;
            btnCLose.Click += btnCLose_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(60, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(193, 25);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Entregas y Garantías";
            lblTitulo.Click += label1_Click;
            // 
            // lblTracking
            // 
            lblTracking.AutoSize = true;
            lblTracking.Location = new Point(20, 70);
            lblTracking.Name = "lblTracking";
            lblTracking.Size = new Size(55, 15);
            lblTracking.TabIndex = 1;
            lblTracking.Text = "Tracking:";
            lblTracking.Click += lblTracking_Click;
            // 
            // txtTracking
            // 
            txtTracking.Location = new Point(100, 67);
            txtTracking.Name = "txtTracking";
            txtTracking.Size = new Size(200, 23);
            txtTracking.TabIndex = 2;
            txtTracking.TextChanged += txtTracking_TextChanged;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(310, 65);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(90, 30);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // lblOrden
            // 
            lblOrden.AutoSize = true;
            lblOrden.Location = new Point(20, 110);
            lblOrden.Name = "lblOrden";
            lblOrden.Size = new Size(92, 15);
            lblOrden.TabIndex = 4;
            lblOrden.Text = "Orden reparada:";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(130, 107);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(300, 23);
            comboBox1.TabIndex = 5;
            // 
            // lblClienteT
            // 
            lblClienteT.AutoSize = true;
            lblClienteT.Location = new Point(20, 150);
            lblClienteT.Name = "lblClienteT";
            lblClienteT.Size = new Size(47, 15);
            lblClienteT.TabIndex = 6;
            lblClienteT.Text = "Cliente:";
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(130, 150);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(12, 15);
            lblCliente.TabIndex = 7;
            lblCliente.Text = "-";
            lblCliente.Click += label2_Click;
            // 
            // lblEquipoT
            // 
            lblEquipoT.AutoSize = true;
            lblEquipoT.Location = new Point(20, 180);
            lblEquipoT.Name = "lblEquipoT";
            lblEquipoT.Size = new Size(47, 15);
            lblEquipoT.TabIndex = 9;
            lblEquipoT.Text = "Equipo:";
            // 
            // lblEquipo
            // 
            lblEquipo.AutoSize = true;
            lblEquipo.Location = new Point(130, 180);
            lblEquipo.Name = "lblEquipo";
            lblEquipo.Size = new Size(12, 15);
            lblEquipo.TabIndex = 10;
            lblEquipo.Text = "-";
            // 
            // lblManoObraT
            // 
            lblManoObraT.AutoSize = true;
            lblManoObraT.Location = new Point(20, 210);
            lblManoObraT.Name = "lblManoObraT";
            lblManoObraT.Size = new Size(84, 15);
            lblManoObraT.TabIndex = 11;
            lblManoObraT.Text = "Mano de obra:";
            // 
            // lblManoObra
            // 
            lblManoObra.AutoSize = true;
            lblManoObra.Location = new Point(130, 210);
            lblManoObra.Name = "lblManoObra";
            lblManoObra.Size = new Size(28, 15);
            lblManoObra.TabIndex = 12;
            lblManoObra.Text = "0.00";
            // 
            // lblRepuestosT
            // 
            lblRepuestosT.AutoSize = true;
            lblRepuestosT.Location = new Point(20, 240);
            lblRepuestosT.Name = "lblRepuestosT";
            lblRepuestosT.Size = new Size(123, 15);
            lblRepuestosT.TabIndex = 13;
            lblRepuestosT.Text = "Repuestos aprobados:";
            // 
            // lblRepuestos
            // 
            lblRepuestos.AutoSize = true;
            lblRepuestos.Location = new Point(180, 240);
            lblRepuestos.Name = "lblRepuestos";
            lblRepuestos.Size = new Size(28, 15);
            lblRepuestos.TabIndex = 14;
            lblRepuestos.Text = "0.00";
            // 
            // lblTotalT
            // 
            lblTotalT.AutoSize = true;
            lblTotalT.Location = new Point(20, 270);
            lblTotalT.Name = "lblTotalT";
            lblTotalT.Size = new Size(82, 15);
            lblTotalT.TabIndex = 15;
            lblTotalT.Text = "Total a cobrar:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(180, 270);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(28, 15);
            lblTotal.TabIndex = 16;
            lblTotal.Text = "0.00";
            // 
            // lblMetodoT
            // 
            lblMetodoT.AutoSize = true;
            lblMetodoT.Location = new Point(450, 110);
            lblMetodoT.Name = "lblMetodoT";
            lblMetodoT.Size = new Size(98, 15);
            lblMetodoT.TabIndex = 17;
            lblMetodoT.Text = "Método de pago:";
            // 
            // cmbMetodoPago
            // 
            cmbMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodoPago.FormattingEnabled = true;
            cmbMetodoPago.Location = new Point(570, 107);
            cmbMetodoPago.Name = "cmbMetodoPago";
            cmbMetodoPago.Size = new Size(180, 23);
            cmbMetodoPago.TabIndex = 18;
            // 
            // lblGarantiaT
            // 
            lblGarantiaT.AutoSize = true;
            lblGarantiaT.Location = new Point(450, 150);
            lblGarantiaT.Name = "lblGarantiaT";
            lblGarantiaT.Size = new Size(94, 15);
            lblGarantiaT.TabIndex = 19;
            lblGarantiaT.Text = "Días de garantía:";
            // 
            // txtObservacion
            // 
            txtObservacion.Location = new Point(20, 305);
            txtObservacion.Multiline = true;
            txtObservacion.Name = "txtObservacion";
            txtObservacion.Size = new Size(420, 70);
            txtObservacion.TabIndex = 20;
            txtObservacion.TextChanged += txtObservacion_TextChanged;
            // 
            // lblObservacion
            // 
            lblObservacion.AutoSize = true;
            lblObservacion.Location = new Point(20, 285);
            lblObservacion.Name = "lblObservacion";
            lblObservacion.Size = new Size(102, 15);
            lblObservacion.TabIndex = 21;
            lblObservacion.Text = "Observación final:";
            // 
            // nudDiasGarantia
            // 
            nudDiasGarantia.Location = new Point(570, 148);
            nudDiasGarantia.Maximum = new decimal(new int[] { 365, 0, 0, 0 });
            nudDiasGarantia.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudDiasGarantia.Name = "nudDiasGarantia";
            nudDiasGarantia.Size = new Size(120, 23);
            nudDiasGarantia.TabIndex = 22;
            nudDiasGarantia.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(20, 402);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(92, 23);
            btnConfirmar.TabIndex = 23;
            btnConfirmar.Text = "Confirmar ";
            btnConfirmar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(161, 402);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(92, 23);
            btnLimpiar.TabIndex = 24;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // dgvEntregas
            // 
            dgvEntregas.AllowUserToAddRows = false;
            dgvEntregas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEntregas.Location = new Point(20, 450);
            dgvEntregas.Name = "dgvEntregas";
            dgvEntregas.ReadOnly = true;
            dgvEntregas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEntregas.Size = new Size(760, 130);
            dgvEntregas.TabIndex = 25;
            // 
            // FrmEntregasGarantia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(805, 590);
            Controls.Add(dgvEntregas);
            Controls.Add(btnLimpiar);
            Controls.Add(btnConfirmar);
            Controls.Add(nudDiasGarantia);
            Controls.Add(lblObservacion);
            Controls.Add(txtObservacion);
            Controls.Add(lblGarantiaT);
            Controls.Add(cmbMetodoPago);
            Controls.Add(lblMetodoT);
            Controls.Add(lblTotal);
            Controls.Add(lblTotalT);
            Controls.Add(lblRepuestos);
            Controls.Add(lblRepuestosT);
            Controls.Add(lblManoObra);
            Controls.Add(lblManoObraT);
            Controls.Add(lblEquipo);
            Controls.Add(lblEquipoT);
            Controls.Add(lblCliente);
            Controls.Add(lblClienteT);
            Controls.Add(comboBox1);
            Controls.Add(lblOrden);
            Controls.Add(btnBuscar);
            Controls.Add(txtTracking);
            Controls.Add(lblTracking);
            Controls.Add(pnlTop);
            FormBorderStyle = FormBorderStyle.None;
            Location = new Point(20, 440);
            Name = "FrmEntregasGarantia";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Entregas y Garantías";
            Load += FrmEntregasGarantia_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudDiasGarantia).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEntregas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlTop;
        private Label lblTitulo;
        private Button btnCLose;
        private Label lblTracking;
        private TextBox txtTracking;
        private Button btnBuscar;
        private Label lblOrden;
        private ComboBox comboBox1;
        private Label lblClienteT;
        private Label lblCliente;
        private Label lblEquipoT;
        private Label lblEquipo;
        private Label lblManoObraT;
        private Label lblManoObra;
        private Label lblRepuestosT;
        private Label lblRepuestos;
        private Label lblTotalT;
        private Label lblTotal;
        private Label lblMetodoT;
        private ComboBox cmbMetodoPago;
        private Label lblGarantiaT;
        private TextBox txtObservacion;
        private Label lblObservacion;
        private NumericUpDown nudDiasGarantia;
        private Button btnConfirmar;
        private Button btnLimpiar;
        private DataGridView dgvEntregas;
    }
}