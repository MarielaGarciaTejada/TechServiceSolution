using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechService.Application.Dtos;
using TechService.WinForms.Services;

namespace TechService.WinForms.Forms
{
    public partial class FrmLogin : Form
    {
        private readonly TallerApiClient _apiClient = new();

        public FrmLogin()
        {
            InitializeComponent();
            InicializarEventos();
        }

        private void InicializarEventos()
        {
            btnCerrar.Click += (s, e) => System.Windows.Forms.Application.Exit();

            btnVerPass.Click += (s, e) => AlternarVisibilidadPassword();
            chkMostrarContrasena.CheckedChanged += (s, e) =>
            {
                txtContrasena.UseSystemPasswordChar = !chkMostrarContrasena.Checked;
                btnVerPass.Text = chkMostrarContrasena.Checked ? "🔒" : "👁";
            };

            btnIniciarSesion.Click += async (s, e) => await EjecutarLoginAsync();

            txtUsuario.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    txtContrasena.Focus();
                }
            };

            txtContrasena.KeyDown += async (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    await EjecutarLoginAsync();
                }
            };

            // Permite arrastrar el formulario desde la cabecera
            pnlHeader.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(Handle, 0xA1, 0x2, 0);
                }
            };
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void AlternarVisibilidadPassword()
        {
            txtContrasena.UseSystemPasswordChar = !txtContrasena.UseSystemPasswordChar;
            chkMostrarContrasena.Checked = !txtContrasena.UseSystemPasswordChar;
            btnVerPass.Text = txtContrasena.UseSystemPasswordChar ? "👁" : "🔒";
            txtContrasena.Refresh();
        }

        private async Task EjecutarLoginAsync()
        {
            lblMensaje.Text = string.Empty;

            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();

            if (string.IsNullOrWhiteSpace(usuario))
            {
                lblMensaje.Text = "Por favor, ingresa tu nombre de usuario.";
                txtUsuario.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(contrasena))
            {
                lblMensaje.Text = "Por favor, ingresa tu contraseña.";
                txtContrasena.Focus();
                return;
            }

            try
            {
                btnIniciarSesion.Enabled = false;
                btnIniciarSesion.Text = "Verificando...";

                var request = new LoginRequestDto
                {
                    NombreUsuario = usuario,
                    Contrasena = contrasena
                };

                var respuesta = await _apiClient.IniciarSesionAsync(request);

                if (respuesta != null && respuesta.Exito && respuesta.Usuario != null)
                {
                    var u = respuesta.Usuario;

                    // Si es Admin, abrir FrmMenuAdmin
                    if (u.RolNombre.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                    {
                        var menuAdmin = new FrmMenuAdmin(u);
                        menuAdmin.Show();
                        menuAdmin.FormClosed += (s, e) => System.Windows.Forms.Application.Exit();
                        this.Hide();
                    }
                    else if (u.RolNombre.Equals("Vendedor", StringComparison.OrdinalIgnoreCase))
                    {
                        var menuVendedor = new FrmMenuVendedor(u);
                        menuVendedor.Show();
                        menuVendedor.FormClosed += (s, e) => System.Windows.Forms.Application.Exit();
                        this.Hide();
                    }
                    else
                    {
                        // Técnico
                        MessageBox.Show($"¡Bienvenido {u.NombreCompleto}!\nComo Técnico, recuerda que puedes gestionar tus órdenes de trabajo directamente desde la App Android de Mesa de Trabajo.",
                                        "Acceso Técnico",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);

                        var menuVendedor = new FrmMenuVendedor(u);
                        menuVendedor.Show();
                        menuVendedor.FormClosed += (s, e) => System.Windows.Forms.Application.Exit();
                        this.Hide();
                    }
                }
                else
                {
                    lblMensaje.Text = respuesta?.Mensaje ?? "Credenciales incorrectas o usuario inactivo.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = $"Error de conexión con la API: {ex.Message}";
            }
            finally
            {
                btnIniciarSesion.Enabled = true;
                btnIniciarSesion.Text = "Iniciar Sesión";
            }
        }
    }
}
