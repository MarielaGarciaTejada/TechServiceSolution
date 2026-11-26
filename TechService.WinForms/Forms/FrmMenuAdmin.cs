using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace TechService.WinForms.Forms
{
    public partial class FrmMenuAdmin : Form
    {
        private readonly Color ColorActivo = Color.FromArgb(34, 21, 114);
        private readonly Color ColorInactivo = Color.FromArgb(15, 23, 42);

        private Form? activeForm = null;

        public FrmMenuAdmin(TechService.Application.Dtos.UsuarioDto? usuario = null)
        {
            InitializeComponent();
            OpenChildForm(new FrmDashboard());
            SetButtonColors(btnDashboard, ColorActivo);

            lblTime.AutoSize = true;
            lblFecha.AutoSize = true;

            if (usuario != null)
            {
                lblNombreCompleto.Text = usuario.NombreCompleto;
                lblRole2.Text = usuario.RolNombre;
                lblNomUsuario2.Text = usuario.NombreUsuario;
            }

            // Mostrar inmediatamente la fecha y hora al iniciar
            ActualizarHoraYFecha();

            // Configurar y encender el timer cada segundo (1000 ms)
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }

        private void ActualizarHoraYFecha()
        {
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
            lblFecha.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy", new CultureInfo("es-ES"));
        }

        private void timer1_Tick(object? sender, EventArgs e)
        {
            ActualizarHoraYFecha();
        }

        private void FrmMenuAdmin_Load(object sender, EventArgs e)
        {

        }

        private void OpenChildForm(Form childForm)
        {
            // Si ya hay un formulario abierto en el panel, ciérralo para no amontonarlos en la memoria
            if (activeForm != null)
                activeForm.Close();

            // Registra el nuevo formulario que vamos a abrir como el formulario "activo"
            activeForm = childForm;

            // Le decimos a Windows que este formulario no es una ventana independiente (TopLevel = false)
            childForm.TopLevel = false;

            // Le quitamos los bordes y la barra superior (donde está la X de cerrar)
            childForm.FormBorderStyle = FormBorderStyle.None;

            // Hacemos que el formulario se expanda para rellenar todo el espacio disponible en el panel
            childForm.Dock = DockStyle.Fill;

            // Agregamos el formulario físicamente adentro de tu panel contenedor (pnlContenedorCentral)
            pnlContenedorCentral.Controls.Add(childForm);

            // Lo traemos al frente para que ningún otro elemento lo tape
            childForm.BringToFront();

            // Finalmente, lo hacemos visible
            childForm.Show();
        }

        private void SetButtonColors(Button btn, Color color)
        {
            btn.BackColor = color;
            btn.ForeColor = Color.White;
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (WindowState.ToString() == "Normal")
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmDashboard());

            // Cambia los colores para indicar visualmente dónde estás
            SetButtonColors(btnDashboard, ColorActivo);
            SetButtonColors(btnRecepcion, ColorInactivo);
            SetButtonColors(btnVentas, ColorInactivo);
            SetButtonColors(btnClientes, ColorInactivo);
            SetButtonColors(btnTecnicos, ColorInactivo);
            SetButtonColors(btnUsuariosRoles, ColorInactivo);
            SetButtonColors(btnHistorial, ColorInactivo);
            SetButtonColors(btnEntregasGarantia, ColorInactivo);
            SetButtonColors(btnOrdenRepuestos, ColorInactivo);
        }

        private void btnRecepcion_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmRecepcion());
            SetButtonColors(btnRecepcion, ColorActivo);

            SetButtonColors(btnDashboard, ColorInactivo);
            SetButtonColors(btnVentas, ColorInactivo);
            SetButtonColors(btnClientes, ColorInactivo);
            SetButtonColors(btnTecnicos, ColorInactivo);
            SetButtonColors(btnUsuariosRoles, ColorInactivo);
            SetButtonColors(btnHistorial, ColorInactivo);
            SetButtonColors(btnEntregasGarantia, ColorInactivo);
            SetButtonColors(btnOrdenRepuestos, ColorInactivo);
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmVentas());
            SetButtonColors(btnVentas, ColorActivo);

            SetButtonColors(btnDashboard, ColorInactivo);
            SetButtonColors(btnRecepcion, ColorInactivo);
            SetButtonColors(btnClientes, ColorInactivo);
            SetButtonColors(btnTecnicos, ColorInactivo);
            SetButtonColors(btnUsuariosRoles, ColorInactivo);
            SetButtonColors(btnHistorial, ColorInactivo);
            SetButtonColors(btnEntregasGarantia, ColorInactivo);
            SetButtonColors(btnOrdenRepuestos, ColorInactivo);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmClientes());
            SetButtonColors(btnClientes, ColorActivo);

            SetButtonColors(btnDashboard, ColorInactivo);
            SetButtonColors(btnRecepcion, ColorInactivo);
            SetButtonColors(btnVentas, ColorInactivo);
            SetButtonColors(btnTecnicos, ColorInactivo);
            SetButtonColors(btnUsuariosRoles, ColorInactivo);
            SetButtonColors(btnHistorial, ColorInactivo);
            SetButtonColors(btnEntregasGarantia, ColorInactivo);
            SetButtonColors(btnOrdenRepuestos, ColorInactivo);
        }

        private void lblTime_Click(object sender, EventArgs e)
        {}

        private void btnTecnicos_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmTecnicos());
            SetButtonColors(btnTecnicos, ColorActivo);

            SetButtonColors(btnDashboard, ColorInactivo);
            SetButtonColors(btnRecepcion, ColorInactivo);
            SetButtonColors(btnVentas, ColorInactivo);
            SetButtonColors(btnClientes, ColorInactivo);
            SetButtonColors(btnUsuariosRoles, ColorInactivo);
            SetButtonColors(btnHistorial, ColorInactivo);
            SetButtonColors(btnEntregasGarantia, ColorInactivo);
            SetButtonColors(btnOrdenRepuestos, ColorInactivo);
        }

        private void btnUsuariosRoles_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmUsuarios());
            SetButtonColors(btnUsuariosRoles, ColorActivo);

            SetButtonColors(btnDashboard, ColorInactivo);
            SetButtonColors(btnRecepcion, ColorInactivo);
            SetButtonColors(btnVentas, ColorInactivo);
            SetButtonColors(btnClientes, ColorInactivo);
            SetButtonColors(btnTecnicos, ColorInactivo);
            SetButtonColors(btnHistorial, ColorInactivo);
            SetButtonColors(btnEntregasGarantia, ColorInactivo);
            SetButtonColors(btnOrdenRepuestos, ColorInactivo);
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmHistorial());
            SetButtonColors(btnHistorial, ColorActivo);

            SetButtonColors(btnDashboard, ColorInactivo);
            SetButtonColors(btnRecepcion, ColorInactivo);
            SetButtonColors(btnVentas, ColorInactivo);
            SetButtonColors(btnClientes, ColorInactivo);
            SetButtonColors(btnTecnicos, ColorInactivo);
            SetButtonColors(btnUsuariosRoles, ColorInactivo);
            SetButtonColors(btnEntregasGarantia, ColorInactivo);
            SetButtonColors(btnOrdenRepuestos, ColorInactivo);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnEntregasGarantia_Click(object sender, EventArgs e)
        {
            // TODO (Luis Enmanuel): descomentar cuando cree FrmEntregasGarantia
            // OpenChildForm(new FrmEntregasGarantia());
            MessageBox.Show("Módulo de Entregas y Garantías en construcción.", "En desarrollo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SetButtonColors(btnEntregasGarantia, ColorActivo);
            SetButtonColors(btnDashboard, ColorInactivo);
            SetButtonColors(btnRecepcion, ColorInactivo);
            SetButtonColors(btnVentas, ColorInactivo);
            SetButtonColors(btnClientes, ColorInactivo);
            SetButtonColors(btnTecnicos, ColorInactivo);
            SetButtonColors(btnUsuariosRoles, ColorInactivo);
            SetButtonColors(btnHistorial, ColorInactivo);
            SetButtonColors(btnOrdenRepuestos, ColorInactivo);
        }

        private void btnOrdenRepuestos_Click(object sender, EventArgs e)
        {
            // TODO (Luis Enmanuel): descomentar cuando cree FrmOrdenRepuestos
            // OpenChildForm(new FrmOrdenRepuestos());
            MessageBox.Show("Módulo de Repuestos por Orden en construcción.", "En desarrollo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SetButtonColors(btnOrdenRepuestos, ColorActivo);
            SetButtonColors(btnDashboard, ColorInactivo);
            SetButtonColors(btnRecepcion, ColorInactivo);
            SetButtonColors(btnVentas, ColorInactivo);
            SetButtonColors(btnClientes, ColorInactivo);
            SetButtonColors(btnTecnicos, ColorInactivo);
            SetButtonColors(btnUsuariosRoles, ColorInactivo);
            SetButtonColors(btnHistorial, ColorInactivo);
            SetButtonColors(btnEntregasGarantia, ColorInactivo);
        }
    }
}
