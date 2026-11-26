namespace TechService.WinForms.Forms
{
    partial class FrmMenuVendedor
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
            components = new System.ComponentModel.Container();
            pnlBarraTituloSup = new Panel();
            btnMinimizar = new Button();
            btnMaximizar = new Button();
            btnCLose = new Button();
            lblSistemaTitulo = new Label();
            pnlMenu = new Panel();
            btnSalir = new Button();
            btnClientes = new Button();
            btnVentas = new Button();
            btnRecepcion = new Button();
            btnDashboard = new Button();
            pnlLogo = new Panel();
            pbxLogo = new PictureBox();
            pnlContenedorCentral = new Panel();
            pnlBarraEstadoUsuario = new Panel();
            lblEstadoSignalR = new Label();
            pbxTime = new PictureBox();
            pbxDate = new PictureBox();
            lblNomUsuario2 = new Label();
            lblNombreCompleto = new Label();
            lblDate = new Label();
            lblRole1 = new Label();
            lblTime = new Label();
            lblRole2 = new Label();
            lblNomUsuario1 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            pnlBarraTituloSup.SuspendLayout();
            pnlMenu.SuspendLayout();
            pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxLogo).BeginInit();
            pnlContenedorCentral.SuspendLayout();
            pnlBarraEstadoUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxTime).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxDate).BeginInit();
            SuspendLayout();
            // 
            // pnlBarraTituloSup
            // 
            pnlBarraTituloSup.BackColor = Color.FromArgb(15, 23, 42);
            pnlBarraTituloSup.Controls.Add(btnMinimizar);
            pnlBarraTituloSup.Controls.Add(btnMaximizar);
            pnlBarraTituloSup.Controls.Add(btnCLose);
            pnlBarraTituloSup.Controls.Add(lblSistemaTitulo);
            pnlBarraTituloSup.Dock = DockStyle.Top;
            pnlBarraTituloSup.Location = new Point(0, 0);
            pnlBarraTituloSup.Name = "pnlBarraTituloSup";
            pnlBarraTituloSup.Size = new Size(1200, 40);
            pnlBarraTituloSup.TabIndex = 2;
            // 
            // btnMinimizar
            // 
            btnMinimizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimizar.BackColor = Color.FromArgb(15, 23, 42);
            btnMinimizar.Cursor = Cursors.Hand;
            btnMinimizar.FlatAppearance.BorderSize = 0;
            btnMinimizar.FlatStyle = FlatStyle.Flat;
            btnMinimizar.Image = Properties.Resources.Minimizar;
            btnMinimizar.Location = new Point(1125, 4);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(32, 32);
            btnMinimizar.TabIndex = 128;
            btnMinimizar.UseVisualStyleBackColor = false;
            btnMinimizar.Click += btnMinimizar_Click;
            // 
            // btnMaximizar
            // 
            btnMaximizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMaximizar.BackColor = Color.FromArgb(15, 23, 42);
            btnMaximizar.Cursor = Cursors.Hand;
            btnMaximizar.FlatAppearance.BorderSize = 0;
            btnMaximizar.FlatStyle = FlatStyle.Flat;
            btnMaximizar.Image = Properties.Resources.Maximizar;
            btnMaximizar.Location = new Point(1085, 4);
            btnMaximizar.Name = "btnMaximizar";
            btnMaximizar.Size = new Size(30, 30);
            btnMaximizar.TabIndex = 127;
            btnMaximizar.UseVisualStyleBackColor = false;
            btnMaximizar.Click += btnMaximizar_Click;
            // 
            // btnCLose
            // 
            btnCLose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCLose.BackColor = Color.FromArgb(15, 23, 42);
            btnCLose.Cursor = Cursors.Hand;
            btnCLose.FlatAppearance.BorderSize = 0;
            btnCLose.FlatStyle = FlatStyle.Flat;
            btnCLose.Image = Properties.Resources.Cancelar;
            btnCLose.Location = new Point(1165, 4);
            btnCLose.Name = "btnCLose";
            btnCLose.Size = new Size(30, 30);
            btnCLose.TabIndex = 126;
            btnCLose.UseVisualStyleBackColor = false;
            btnCLose.Click += btnCLose_Click;
            // 
            // lblSistemaTitulo
            // 
            lblSistemaTitulo.AutoSize = true;
            lblSistemaTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSistemaTitulo.ForeColor = Color.White;
            lblSistemaTitulo.Location = new Point(5, 8);
            lblSistemaTitulo.Name = "lblSistemaTitulo";
            lblSistemaTitulo.Size = new Size(196, 25);
            lblSistemaTitulo.TabIndex = 0;
            lblSistemaTitulo.Text = "TechService Solution";
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.FromArgb(15, 23, 42);
            pnlMenu.Controls.Add(btnSalir);
            pnlMenu.Controls.Add(btnClientes);
            pnlMenu.Controls.Add(btnVentas);
            pnlMenu.Controls.Add(btnRecepcion);
            pnlMenu.Controls.Add(btnDashboard);
            pnlMenu.Controls.Add(pnlLogo);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.ForeColor = SystemColors.ControlText;
            pnlMenu.Location = new Point(0, 40);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(173, 660);
            pnlMenu.TabIndex = 3;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(15, 23, 42);
            btnSalir.BackgroundImageLayout = ImageLayout.Center;
            btnSalir.Cursor = Cursors.Hand;
            btnSalir.Dock = DockStyle.Bottom;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatAppearance.MouseDownBackColor = Color.FromArgb(5, 8, 100);
            btnSalir.FlatAppearance.MouseOverBackColor = Color.FromArgb(3, 6, 39);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.White;
            btnSalir.Image = Properties.Resources.Salida;
            btnSalir.ImageAlign = ContentAlignment.MiddleLeft;
            btnSalir.Location = new Point(0, 623);
            btnSalir.Name = "btnSalir";
            btnSalir.Padding = new Padding(35, 0, 0, 0);
            btnSalir.Size = new Size(173, 37);
            btnSalir.TabIndex = 11;
            btnSalir.Text = "Salir";
            btnSalir.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnClientes
            // 
            btnClientes.BackColor = Color.FromArgb(15, 23, 42);
            btnClientes.BackgroundImageLayout = ImageLayout.Center;
            btnClientes.Cursor = Cursors.Hand;
            btnClientes.Dock = DockStyle.Top;
            btnClientes.FlatAppearance.BorderSize = 0;
            btnClientes.FlatAppearance.MouseDownBackColor = Color.FromArgb(5, 8, 100);
            btnClientes.FlatAppearance.MouseOverBackColor = Color.FromArgb(3, 6, 39);
            btnClientes.FlatStyle = FlatStyle.Flat;
            btnClientes.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClientes.ForeColor = Color.White;
            btnClientes.Image = Properties.Resources.Clientes;
            btnClientes.ImageAlign = ContentAlignment.MiddleLeft;
            btnClientes.Location = new Point(0, 208);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(173, 37);
            btnClientes.TabIndex = 6;
            btnClientes.Text = "Clientes";
            btnClientes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClientes.UseVisualStyleBackColor = false;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnVentas
            // 
            btnVentas.BackColor = Color.FromArgb(15, 23, 42);
            btnVentas.BackgroundImageLayout = ImageLayout.Center;
            btnVentas.Cursor = Cursors.Hand;
            btnVentas.Dock = DockStyle.Top;
            btnVentas.FlatAppearance.BorderSize = 0;
            btnVentas.FlatAppearance.MouseDownBackColor = Color.FromArgb(5, 8, 100);
            btnVentas.FlatAppearance.MouseOverBackColor = Color.FromArgb(3, 6, 39);
            btnVentas.FlatStyle = FlatStyle.Flat;
            btnVentas.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVentas.ForeColor = Color.White;
            btnVentas.Image = Properties.Resources.Ventas;
            btnVentas.ImageAlign = ContentAlignment.MiddleLeft;
            btnVentas.Location = new Point(0, 171);
            btnVentas.Name = "btnVentas";
            btnVentas.Size = new Size(173, 37);
            btnVentas.TabIndex = 5;
            btnVentas.Text = "Caja/Ventas";
            btnVentas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnVentas.UseVisualStyleBackColor = false;
            btnVentas.Click += btnVentas_Click;
            // 
            // btnRecepcion
            // 
            btnRecepcion.BackColor = Color.FromArgb(15, 23, 42);
            btnRecepcion.BackgroundImageLayout = ImageLayout.Center;
            btnRecepcion.Cursor = Cursors.Hand;
            btnRecepcion.Dock = DockStyle.Top;
            btnRecepcion.FlatAppearance.BorderSize = 0;
            btnRecepcion.FlatAppearance.MouseDownBackColor = Color.FromArgb(5, 8, 100);
            btnRecepcion.FlatAppearance.MouseOverBackColor = Color.FromArgb(3, 6, 39);
            btnRecepcion.FlatStyle = FlatStyle.Flat;
            btnRecepcion.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRecepcion.ForeColor = Color.White;
            btnRecepcion.Image = Properties.Resources.Recepcion;
            btnRecepcion.ImageAlign = ContentAlignment.MiddleLeft;
            btnRecepcion.Location = new Point(0, 134);
            btnRecepcion.Name = "btnRecepcion";
            btnRecepcion.Size = new Size(173, 37);
            btnRecepcion.TabIndex = 4;
            btnRecepcion.Text = "Recepción";
            btnRecepcion.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRecepcion.UseVisualStyleBackColor = false;
            btnRecepcion.Click += btnRecepcion_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.FromArgb(15, 23, 42);
            btnDashboard.BackgroundImageLayout = ImageLayout.Center;
            btnDashboard.Cursor = Cursors.Hand;
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatAppearance.MouseDownBackColor = Color.FromArgb(5, 8, 100);
            btnDashboard.FlatAppearance.MouseOverBackColor = Color.FromArgb(3, 6, 39);
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Image = Properties.Resources.Dashboard1;
            btnDashboard.ImageAlign = ContentAlignment.MiddleLeft;
            btnDashboard.Location = new Point(0, 97);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(173, 37);
            btnDashboard.TabIndex = 3;
            btnDashboard.Text = "Dashboard";
            btnDashboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // pnlLogo
            // 
            pnlLogo.AutoSize = true;
            pnlLogo.BackColor = Color.FromArgb(15, 23, 42);
            pnlLogo.Controls.Add(pbxLogo);
            pnlLogo.Dock = DockStyle.Top;
            pnlLogo.Location = new Point(0, 0);
            pnlLogo.Name = "pnlLogo";
            pnlLogo.Size = new Size(173, 97);
            pnlLogo.TabIndex = 2;
            // 
            // pbxLogo
            // 
            pbxLogo.Image = Properties.Resources.logo;
            pbxLogo.Location = new Point(30, 4);
            pbxLogo.Name = "pbxLogo";
            pbxLogo.Size = new Size(117, 90);
            pbxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxLogo.TabIndex = 0;
            pbxLogo.TabStop = false;
            // 
            // pnlContenedorCentral
            // 
            pnlContenedorCentral.Controls.Add(pnlBarraEstadoUsuario);
            pnlContenedorCentral.Dock = DockStyle.Fill;
            pnlContenedorCentral.Location = new Point(173, 40);
            pnlContenedorCentral.Name = "pnlContenedorCentral";
            pnlContenedorCentral.Size = new Size(1027, 660);
            pnlContenedorCentral.TabIndex = 4;
            // 
            // pnlBarraEstadoUsuario
            // 
            pnlBarraEstadoUsuario.BackColor = Color.FromArgb(15, 23, 42);
            pnlBarraEstadoUsuario.Controls.Add(lblEstadoSignalR);
            pnlBarraEstadoUsuario.Controls.Add(pbxTime);
            pnlBarraEstadoUsuario.Controls.Add(pbxDate);
            pnlBarraEstadoUsuario.Controls.Add(lblNomUsuario2);
            pnlBarraEstadoUsuario.Controls.Add(lblNombreCompleto);
            pnlBarraEstadoUsuario.Controls.Add(lblDate);
            pnlBarraEstadoUsuario.Controls.Add(lblRole1);
            pnlBarraEstadoUsuario.Controls.Add(lblTime);
            pnlBarraEstadoUsuario.Controls.Add(lblRole2);
            pnlBarraEstadoUsuario.Controls.Add(lblNomUsuario1);
            pnlBarraEstadoUsuario.Dock = DockStyle.Top;
            pnlBarraEstadoUsuario.Location = new Point(0, 0);
            pnlBarraEstadoUsuario.Name = "pnlBarraEstadoUsuario";
            pnlBarraEstadoUsuario.Size = new Size(1027, 36);
            pnlBarraEstadoUsuario.TabIndex = 5;
            // 
            // lblEstadoSignalR
            // 
            lblEstadoSignalR.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblEstadoSignalR.AutoSize = true;
            lblEstadoSignalR.BackColor = Color.Transparent;
            lblEstadoSignalR.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEstadoSignalR.ForeColor = Color.FromArgb(16, 185, 129);
            lblEstadoSignalR.Location = new Point(912, 11);
            lblEstadoSignalR.Name = "lblEstadoSignalR";
            lblEstadoSignalR.Size = new Size(92, 15);
            lblEstadoSignalR.TabIndex = 12;
            lblEstadoSignalR.Text = "● Conectando...";
            // 
            // pbxTime
            // 
            pbxTime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbxTime.Image = Properties.Resources.Time;
            pbxTime.Location = new Point(773, 2);
            pbxTime.Name = "pbxTime";
            pbxTime.Size = new Size(32, 32);
            pbxTime.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxTime.TabIndex = 11;
            pbxTime.TabStop = false;
            // 
            // pbxDate
            // 
            pbxDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbxDate.Image = Properties.Resources.Date;
            pbxDate.Location = new Point(487, 3);
            pbxDate.Name = "pbxDate";
            pbxDate.Size = new Size(32, 32);
            pbxDate.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxDate.TabIndex = 10;
            pbxDate.TabStop = false;
            // 
            // lblNomUsuario2
            // 
            lblNomUsuario2.AutoSize = true;
            lblNomUsuario2.BackColor = Color.Transparent;
            lblNomUsuario2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNomUsuario2.ForeColor = Color.White;
            lblNomUsuario2.Location = new Point(359, 11);
            lblNomUsuario2.Name = "lblNomUsuario2";
            lblNomUsuario2.Size = new Size(101, 15);
            lblNomUsuario2.TabIndex = 8;
            lblNomUsuario2.Text = "Nombre Usuario:";
            // 
            // lblNombreCompleto
            // 
            lblNombreCompleto.AutoSize = true;
            lblNombreCompleto.BackColor = Color.Transparent;
            lblNombreCompleto.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombreCompleto.ForeColor = Color.White;
            lblNombreCompleto.Location = new Point(10, 11);
            lblNombreCompleto.Name = "lblNombreCompleto";
            lblNombreCompleto.Size = new Size(113, 15);
            lblNombreCompleto.TabIndex = 1;
            lblNombreCompleto.Text = "Nombre Completo:";
            // 
            // lblDate
            // 
            lblDate.BackColor = Color.Transparent;
            lblDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDate.ForeColor = Color.White;
            lblDate.Location = new Point(525, 11);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(188, 15);
            lblDate.TabIndex = 6;
            lblDate.Text = "Fecha:";
            // 
            // lblRole1
            // 
            lblRole1.AutoSize = true;
            lblRole1.BackColor = Color.Transparent;
            lblRole1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRole1.ForeColor = Color.White;
            lblRole1.Location = new Point(149, 11);
            lblRole1.Name = "lblRole1";
            lblRole1.Size = new Size(28, 15);
            lblRole1.TabIndex = 2;
            lblRole1.Text = "Rol:";
            // 
            // lblTime
            // 
            lblTime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTime.BackColor = Color.Transparent;
            lblTime.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTime.ForeColor = Color.White;
            lblTime.Location = new Point(801, 11);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(108, 15);
            lblTime.TabIndex = 7;
            lblTime.Text = "Time:";
            // 
            // lblRole2
            // 
            lblRole2.AutoSize = true;
            lblRole2.BackColor = Color.Transparent;
            lblRole2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRole2.ForeColor = Color.White;
            lblRole2.Location = new Point(188, 11);
            lblRole2.Name = "lblRole2";
            lblRole2.Size = new Size(35, 15);
            lblRole2.TabIndex = 3;
            lblRole2.Text = "Role:";
            // 
            // lblNomUsuario1
            // 
            lblNomUsuario1.AutoSize = true;
            lblNomUsuario1.BackColor = Color.Transparent;
            lblNomUsuario1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNomUsuario1.ForeColor = Color.White;
            lblNomUsuario1.Location = new Point(256, 11);
            lblNomUsuario1.Name = "lblNomUsuario1";
            lblNomUsuario1.Size = new Size(101, 15);
            lblNomUsuario1.TabIndex = 4;
            lblNomUsuario1.Text = "Nombre Usuario:";
            // 
            // FrmMenuVendedor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 700);
            Controls.Add(pnlContenedorCentral);
            Controls.Add(pnlMenu);
            Controls.Add(pnlBarraTituloSup);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmMenuVendedor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmMain";
            Load += FrmMenuVendedor_Load;
            pnlBarraTituloSup.ResumeLayout(false);
            pnlBarraTituloSup.PerformLayout();
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            pnlLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbxLogo).EndInit();
            pnlContenedorCentral.ResumeLayout(false);
            pnlBarraEstadoUsuario.ResumeLayout(false);
            pnlBarraEstadoUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbxTime).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxDate).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlBarraTituloSup;
        private Button btnMinimizar;
        private Button btnMaximizar;
        private Button btnCLose;
        private Label lblSistemaTitulo;
        private Panel pnlMenu;
        private Panel pnlLogo;
        private PictureBox pbxLogo;
        private Button btnDashboard;
        private Button btnVentas;
        private Button btnRecepcion;
        private Button btnClientes;
        private Panel pnlContenedorCentral;
        private System.Windows.Forms.Timer timer1;
        private Panel pnlBarraEstadoUsuario;
        private Label lblEstadoSignalR;
        private PictureBox pbxTime;
        private PictureBox pbxDate;
        public Label lblNomUsuario2;
        public Label lblNombreCompleto;
        public Label lblDate;
        private Label lblRole1;
        public Label lblTime;
        public Label lblRole2;
        public Label lblNomUsuario1;
        private Button btnSalir;
    }
}
