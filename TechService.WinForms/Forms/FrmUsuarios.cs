using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechService.Application.Dtos;
using TechService.WinForms.Models;
using TechService.WinForms.Services;

namespace TechService.WinForms.Forms
{
    public partial class FrmUsuarios : Form
    {
        private readonly TallerApiClient _apiClient = new();
        private List<UsuarioView> _listaUsuariosCompleta = new();
        private List<UsuarioView> _listaUsuariosFiltrada = new();
        private List<RolDto> _listaRoles = new();
        private List<TecnicoView> _listaTecnicos = new();
        private int _usuarioIdSeleccionado = 0;

        #region PAGINACION
        private int PaginaActual = 1;
        private int RecordsPerPage = 10;
        private int RegistrosTotales = 0;
        private int PaginasTotales = 0;
        #endregion

        public FrmUsuarios()
        {
            InitializeComponent();
            InicializarEventos();
        }

        private void InicializarEventos()
        {
            this.Load += FrmUsuarios_Load;

            // Botones de acción
            btnCLose.Click += (s, e) => this.Close();
            btnAgregar.Click += async (s, e) => await AgregarUsuarioAsync();
            btnEditar.Click += async (s, e) => await EditarUsuarioAsync();
            btnCancelar.Click += (s, e) => LimpiarFormulario();

            btnVerContrasena.Click += btnVerContrasena_Click;

            txtContrasena.DoubleClick += (s, e) => btnVerContrasena_Click(s, e);
            btnEliminar.Click += async (s, e) => await EliminarUsuarioSeleccionadoAsync();

            // Cambio de rol -> habilitar o deshabilitar combo de técnico
            cbxRol.SelectedIndexChanged += cbxRol_SelectedIndexChanged;

            // Paginación
            cbxRegistrosPorPagina.SelectedIndexChanged += cbxRegistrosPorPagina_SelectedIndexChanged;
            btnPrimero.Click += (s, e) => NavegarPagina(1);
            btnAnterior.Click += (s, e) => NavegarPagina(PaginaActual - 1);
            btnSiguiente.Click += (s, e) => NavegarPagina(PaginaActual + 1);
            btnUltimo.Click += (s, e) => NavegarPagina(PaginasTotales);

            // DataGridView
            dgvUsuarios.CellClick += dgvUsuarios_CellClick;
        }

        private async void FrmUsuarios_Load(object? sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarOpcionesRegistrosPorPagina();
            LimpiarFormulario();

            await CargarRolesAsync();
            await CargarTecnicosAsync();
            await CargarUsuariosDesdeApiAsync();
        }

        private void ConfigurarGrid()
        {
            dgvUsuarios.AutoGenerateColumns = false;

            colUsuarioId.DataPropertyName = nameof(UsuarioView.UsuarioId);
            colNombreUsuario.DataPropertyName = nameof(UsuarioView.NombreUsuario);
            colNombreCompleto.DataPropertyName = nameof(UsuarioView.NombreCompleto);
            colRol.DataPropertyName = nameof(UsuarioView.RolNombre);
            colTecnico.DataPropertyName = nameof(UsuarioView.TecnicoNombre);
            colActivo.DataPropertyName = nameof(UsuarioView.ActivoTexto);

        }

        private async Task CargarRolesAsync()
        {
            try
            {
                var roles = await _apiClient.ObtenerRolesAsync();
                if (roles != null && roles.Count > 0)
                {
                    _listaRoles = roles;
                    cbxRol.DataSource = null;
                    cbxRol.DataSource = _listaRoles;
                    cbxRol.DisplayMember = nameof(RolDto.Nombre);
                    cbxRol.ValueMember = nameof(RolDto.RolId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar roles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async Task CargarTecnicosAsync()
        {
            try
            {
                var tecnicos = await _apiClient.ObtenerListaAsync<TecnicoView>("api/tecnicos");
                if (tecnicos != null)
                {
                    _listaTecnicos = tecnicos.Where(t => t.Activo).ToList();
                    cbxEspecialidad.DataSource = null;
                    cbxEspecialidad.DataSource = _listaTecnicos;
                    cbxEspecialidad.DisplayMember = nameof(TecnicoView.EspecialidadConTecnico);
                    cbxEspecialidad.ValueMember = nameof(TecnicoView.TecnicoId);
                    cbxEspecialidad.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar técnicos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbxRol_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbxRol.SelectedItem is RolDto rolSeleccionado)
            {
                bool esTecnico = rolSeleccionado.Nombre.Equals("Tecnico", StringComparison.OrdinalIgnoreCase);
                cbxEspecialidad.Enabled = esTecnico;
                lblEspecialidadSoloTecnico.Enabled = esTecnico;
                if (!esTecnico)
                {
                    cbxEspecialidad.SelectedIndex = -1;
                }
            }
            else
            {
                cbxEspecialidad.Enabled = false;
                cbxEspecialidad.SelectedIndex = -1;
            }
        }

        #region PAGINACIÓN Y CARGA DE DATOS
        private void CargarOpcionesRegistrosPorPagina()
        {
            cbxRegistrosPorPagina.Items.Clear();
            cbxRegistrosPorPagina.Items.Add("Todos");
            cbxRegistrosPorPagina.Items.Add("10");
            cbxRegistrosPorPagina.Items.Add("20");
            cbxRegistrosPorPagina.Items.Add("30");
            cbxRegistrosPorPagina.SelectedIndex = 1;
        }

        public async Task CargarUsuariosDesdeApiAsync()
        {
            try
            {
                var dtos = await _apiClient.ObtenerUsuariosAsync();
                if (dtos != null)
                {
                    _listaUsuariosCompleta = dtos.Select(u => new UsuarioView
                    {
                        UsuarioId = u.UsuarioId,
                        NombreUsuario = u.NombreUsuario,
                        Contrasena = u.Contrasena ?? string.Empty,
                        NombreCompleto = u.NombreCompleto,
                        Email = u.Email ?? string.Empty,
                        Telefono = u.Telefono ?? string.Empty,
                        RolId = u.RolId,
                        RolNombre = u.RolNombre,
                        TecnicoId = u.TecnicoId,
                        TecnicoNombre = !string.IsNullOrEmpty(u.TecnicoNombre) ? u.TecnicoNombre : "(null)",
                        Activo = u.Activo
                    }).ToList();

                    CargarUsuarios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios de la API: {ex.Message}", "Conexión API", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarUsuarios()
        {
            _listaUsuariosFiltrada = _listaUsuariosCompleta.ToList();
            RegistrosTotales = _listaUsuariosFiltrada.Count;

            if (RecordsPerPage == int.MaxValue || RecordsPerPage <= 0)
            {
                PaginasTotales = 1;
            }
            else
            {
                PaginasTotales = (int)Math.Ceiling((double)RegistrosTotales / RecordsPerPage);
                if (PaginasTotales == 0) PaginasTotales = 1;
            }

            if (PaginaActual > PaginasTotales) PaginaActual = PaginasTotales;
            if (PaginaActual < 1) PaginaActual = 1;

            List<UsuarioView> datosPagina;
            if (RecordsPerPage == int.MaxValue)
            {
                datosPagina = _listaUsuariosFiltrada;
            }
            else
            {
                datosPagina = _listaUsuariosFiltrada
                    .Skip((PaginaActual - 1) * RecordsPerPage)
                    .Take(RecordsPerPage)
                    .ToList();
            }

            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = datosPagina;

            lblPaginaActual.Text = $"Página {PaginaActual} de {PaginasTotales}";
            lblClientesTotales.Text = "Total de Usuarios: " + RegistrosTotales;

            btnSiguiente.Enabled = PaginaActual < PaginasTotales;
            btnAnterior.Enabled = PaginaActual > 1;
            btnPrimero.Enabled = PaginaActual > 1;
            btnUltimo.Enabled = PaginaActual < PaginasTotales;
        }

        private void NavegarPagina(int nuevaPagina)
        {
            if (nuevaPagina >= 1 && nuevaPagina <= PaginasTotales)
            {
                PaginaActual = nuevaPagina;
                CargarUsuarios();
            }
        }

        private void cbxRegistrosPorPagina_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbxRegistrosPorPagina.SelectedItem == null) return;

            string selectedValue = cbxRegistrosPorPagina.SelectedItem.ToString()!;
            RecordsPerPage = selectedValue == "Todos" ? int.MaxValue : int.Parse(selectedValue);

            PaginaActual = 1;
            CargarUsuarios();
        }
        #endregion

        #region OPERACIONES CRUD
        private async Task AgregarUsuarioAsync()
        {
            if (!ValidarCampos(esNuevo: true)) return;

            var dto = new UsuarioDto
            {
                UsuarioId = 0,
                NombreUsuario = txtNombreUsuario.Text.Trim(),
                Contrasena = txtContrasena.Text.Trim(),
                NombreCompleto = txtNombreCompleto.Text.Trim(),
                RolId = (int)cbxRol.SelectedValue!,
                TecnicoId = cbxEspecialidad.Enabled && cbxEspecialidad.SelectedValue != null ? (int)cbxEspecialidad.SelectedValue : null,
                Telefono = txtTelefono.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Activo = chkActivo.Checked
            };

            try
            {
                btnAgregar.Enabled = false;
                var res = await _apiClient.GuardarUsuarioAsync(dto);
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Usuario registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    await CargarUsuariosDesdeApiAsync();
                }
                else
                {
                    var errorMsg = await res.Content.ReadAsStringAsync();
                    MessageBox.Show($"No se pudo registrar el usuario: {errorMsg}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la API: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnAgregar.Enabled = true;
            }
        }

        private async Task EditarUsuarioAsync()
        {
            if (_usuarioIdSeleccionado <= 0)
            {
                MessageBox.Show("Por favor, seleccione un usuario de la lista para editar.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidarCampos(esNuevo: false)) return;

            var dto = new UsuarioDto
            {
                UsuarioId = _usuarioIdSeleccionado,
                NombreUsuario = txtNombreUsuario.Text.Trim(),
                Contrasena = string.IsNullOrWhiteSpace(txtContrasena.Text) || txtContrasena.Text.Contains("•") ? null : txtContrasena.Text.Trim(),
                NombreCompleto = txtNombreCompleto.Text.Trim(),
                RolId = (int)cbxRol.SelectedValue!,
                TecnicoId = cbxEspecialidad.Enabled && cbxEspecialidad.SelectedValue != null ? (int)cbxEspecialidad.SelectedValue : null,
                Telefono = txtTelefono.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Activo = chkActivo.Checked
            };

            try
            {
                btnEditar.Enabled = false;
                var res = await _apiClient.GuardarUsuarioAsync(dto);
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Usuario actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    await CargarUsuariosDesdeApiAsync();
                }
                else
                {
                    var errorMsg = await res.Content.ReadAsStringAsync();
                    MessageBox.Show($"No se pudo actualizar el usuario: {errorMsg}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la API: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnEditar.Enabled = true;
            }
        }

        private async Task EliminarUsuarioSeleccionadoAsync()
        {
            if (_usuarioIdSeleccionado <= 0)
            {
                MessageBox.Show("Por favor, seleccione un usuario de la lista para eliminar.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show($"¿Está seguro de que desea eliminar al usuario '{txtNombreUsuario.Text.Trim()}'?",
                                          "Confirmar Eliminación",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                var res = await _apiClient.EliminarUsuarioAsync(_usuarioIdSeleccionado);
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Usuario eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    await CargarUsuariosDesdeApiAsync();
                }
                else
                {
                    var errorMsg = await res.Content.ReadAsStringAsync();
                    MessageBox.Show($"No se pudo eliminar el usuario: {errorMsg}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar usuario: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos(bool esNuevo)
        {
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
            {
                MessageBox.Show("El nombre de usuario es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreUsuario.Focus();
                return false;
            }

            if (esNuevo && string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MessageBox.Show("La contraseña es obligatoria para nuevos usuarios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContrasena.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombreCompleto.Text))
            {
                MessageBox.Show("El nombre completo es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreCompleto.Focus();
                return false;
            }

            if (cbxRol.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un rol.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxRol.Focus();
                return false;
            }

            return true;
        }

        private void LimpiarFormulario()
        {
            _usuarioIdSeleccionado = 0;
            lblClienteId.Text = string.Empty;
            txtNombreUsuario.Clear();
            txtContrasena.Clear();

            txtContrasena.UseSystemPasswordChar = true;

            btnVerContrasena.Text = "👁";
            txtNombreCompleto.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            chkActivo.Checked = true;

            if (cbxRol.Items.Count > 0) cbxRol.SelectedIndex = 0;
            cbxEspecialidad.SelectedIndex = -1;
            cbxEspecialidad.Enabled = false;

            btnAgregar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            txtNombreUsuario.Focus();
        }

        private void dgvUsuarios_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var usuario = dgvUsuarios.Rows[e.RowIndex].DataBoundItem as UsuarioView;
            if (usuario == null) return;

            // Cargar en los campos para edición
            _usuarioIdSeleccionado = usuario.UsuarioId;
            lblClienteId.Text = usuario.UsuarioId.ToString();
            txtNombreUsuario.Text = usuario.NombreUsuario;
            txtContrasena.Text = usuario.Contrasena;

            txtContrasena.UseSystemPasswordChar = true;

            btnVerContrasena.Text = "👁";
            txtNombreCompleto.Text = usuario.NombreCompleto;
            txtTelefono.Text = usuario.Telefono;
            txtEmail.Text = usuario.Email;
            chkActivo.Checked = usuario.Activo;

            if (usuario.RolId > 0)
            {
                cbxRol.SelectedValue = usuario.RolId;
            }

            if (usuario.TecnicoId.HasValue && usuario.TecnicoId > 0)
            {
                cbxEspecialidad.SelectedValue = usuario.TecnicoId.Value;
            }
            else
            {
                cbxEspecialidad.SelectedIndex = -1;
            }

            btnAgregar.Enabled = false;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void btnVerContrasena_Click(object? sender, EventArgs e)
        {
            if (txtContrasena.UseSystemPasswordChar)
            {
                txtContrasena.UseSystemPasswordChar = false;
                txtContrasena.PasswordChar = '\0';
                btnVerContrasena.Text = "🔒";
            }
            else
            {
                txtContrasena.UseSystemPasswordChar = true;
                btnVerContrasena.Text = "👁";
            }
            txtContrasena.Refresh();
        }

        #endregion
    }
}
