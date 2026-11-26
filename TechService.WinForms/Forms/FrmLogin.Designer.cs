namespace TechService.WinForms.Forms
{
    partial class FrmLogin
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
            pnlHeader = new Panel();
            btnCerrar = new Button();
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblContrasena = new Label();
            txtContrasena = new TextBox();
            btnVerPass = new Button();
            chkMostrarContrasena = new CheckBox();
            lblMensaje = new Label();
            btnIniciarSesion = new Button();
            lblFooter = new Label();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(15, 23, 42);
            pnlHeader.Controls.Add(btnCerrar);
            pnlHeader.Controls.Add(lblSubtitulo);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(420, 110);
            pnlHeader.TabIndex = 0;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(380, 8);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(32, 32);
            btnCerrar.TabIndex = 2;
            btnCerrar.Text = "✕";
            btnCerrar.UseVisualStyleBackColor = true;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtitulo.ForeColor = Color.FromArgb(148, 163, 184);
            lblSubtitulo.Location = new Point(12, 60);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(396, 25);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Acceso al Sistema";
            lblSubtitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(12, 22);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(396, 35);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "TECHSERVICE POS";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsuario.ForeColor = Color.FromArgb(15, 23, 42);
            lblUsuario.Location = new Point(45, 140);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(133, 17);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Nombre de Usuario:";
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsuario.Location = new Point(45, 165);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(330, 27);
            txtUsuario.TabIndex = 2;
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblContrasena.ForeColor = Color.FromArgb(15, 23, 42);
            lblContrasena.Location = new Point(45, 215);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(81, 17);
            lblContrasena.TabIndex = 3;
            lblContrasena.Text = "Contraseña:";
            // 
            // txtContrasena
            // 
            txtContrasena.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContrasena.Location = new Point(45, 240);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(288, 27);
            txtContrasena.TabIndex = 4;
            txtContrasena.UseSystemPasswordChar = true;
            // 
            // btnVerPass
            // 
            btnVerPass.BackColor = Color.White;
            btnVerPass.Cursor = Cursors.Hand;
            btnVerPass.FlatStyle = FlatStyle.Flat;
            btnVerPass.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnVerPass.ForeColor = Color.Black;
            btnVerPass.Location = new Point(337, 240);
            btnVerPass.Name = "btnVerPass";
            btnVerPass.Size = new Size(38, 27);
            btnVerPass.TabIndex = 5;
            btnVerPass.Text = "👁";
            btnVerPass.UseVisualStyleBackColor = false;
            // 
            // chkMostrarContrasena
            // 
            chkMostrarContrasena.AutoSize = true;
            chkMostrarContrasena.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkMostrarContrasena.ForeColor = Color.FromArgb(71, 85, 105);
            chkMostrarContrasena.Location = new Point(45, 280);
            chkMostrarContrasena.Name = "chkMostrarContrasena";
            chkMostrarContrasena.Size = new Size(128, 19);
            chkMostrarContrasena.TabIndex = 6;
            chkMostrarContrasena.Text = "Mostrar contraseña";
            chkMostrarContrasena.UseVisualStyleBackColor = true;
            // 
            // lblMensaje
            // 
            lblMensaje.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMensaje.ForeColor = Color.FromArgb(220, 38, 38);
            lblMensaje.Location = new Point(45, 310);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(330, 20);
            lblMensaje.TabIndex = 7;
            lblMensaje.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.BackColor = Color.FromArgb(13, 110, 253);
            btnIniciarSesion.Cursor = Cursors.Hand;
            btnIniciarSesion.FlatAppearance.BorderSize = 0;
            btnIniciarSesion.FlatStyle = FlatStyle.Flat;
            btnIniciarSesion.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIniciarSesion.ForeColor = Color.White;
            btnIniciarSesion.Location = new Point(45, 340);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(330, 42);
            btnIniciarSesion.TabIndex = 8;
            btnIniciarSesion.Text = "Iniciar Sesión";
            btnIniciarSesion.UseVisualStyleBackColor = false;
            // 
            // lblFooter
            // 
            lblFooter.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFooter.ForeColor = Color.FromArgb(148, 163, 184);
            lblFooter.Location = new Point(12, 440);
            lblFooter.Name = "lblFooter";
            lblFooter.Size = new Size(396, 20);
            lblFooter.TabIndex = 9;
            lblFooter.Text = "TechService Solution v1.0 • Sistema Taller & POS";
            lblFooter.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(420, 470);
            Controls.Add(lblFooter);
            Controls.Add(btnIniciarSesion);
            Controls.Add(lblMensaje);
            Controls.Add(chkMostrarContrasena);
            Controls.Add(btnVerPass);
            Controls.Add(txtContrasena);
            Controls.Add(lblContrasena);
            Controls.Add(txtUsuario);
            Controls.Add(lblUsuario);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TechService - Inicio de Sesión";
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Button btnCerrar;
        private Label lblUsuario;
        public TextBox txtUsuario;
        private Label lblContrasena;
        public TextBox txtContrasena;
        private Button btnVerPass;
        private CheckBox chkMostrarContrasena;
        private Label lblMensaje;
        private Button btnIniciarSesion;
        private Label lblFooter;
    }
}
