using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechService.WinForms.Models;
using TechService.WinForms.Services;

namespace TechService.WinForms.Forms
{
    public partial class FrmClientes : Form
    {
        private readonly TallerApiClient _apiClient = new();
        private List<ClienteView> _listaClientesCompleta = new();
        private List<ClienteView> _listaClientesFiltrada = new();

        #region PAGINACION
        private int PaginaActual = 1;
        private int RecordsPerPage = 10;
        private int RegistrosTotales = 0;
        private int PaginasTotales = 0;
        #endregion

        public FrmClientes()
        {
            InitializeComponent();
            InicializarEventos();
        }

        private void InicializarEventos()
        {
            // Eventos de botones CRUD y navegación
            btnCLose.Click += (s, e) => this.Close();
            btnAgregar.Click += async (s, e) => await AgregarClienteAsync();
            btnEditar.Click += async (s, e) => await EditarClienteAsync();
            btnCancelar.Click += (s, e) => LimpiarFormulario();

            // Eventos de búsqueda y paginación
            txtBuscarUsuario.TextChanged += txtBuscarUsuario_TextChanged;
            cbxRegistrosPorPagina.SelectedIndexChanged += cbxRegistrosPorPagina_SelectedIndexChanged;
            btnPrimero.Click += btnPrimero_Click;
            btnAnterior.Click += btnAnterior_Click;
            btnSiguiente.Click += btnSiguiente_Click;
            btnUltimo.Click += btnUltimo_Click;

            // Eventos del DataGridView
            dgvClientes.CellClick += dgvClientes_CellClick;
            dgvClientes.CellFormatting += dgvClientes_CellFormatting;
        }

        private async void FrmClientes_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarOpcionesRegistrosPorPagina();
            LimpiarFormulario();
            await CargarClientesDesdeApiAsync();
        }

        private void ConfigurarGrid()
        {
            dgvClientes.AutoGenerateColumns = false;
            colEliminar.DefaultCellStyle.NullValue = Properties.Resources.Eliminar;
        }

        #region FUNCIONES PAGINACION
        private void CargarOpcionesRegistrosPorPagina()
        {
            cbxRegistrosPorPagina.Items.Clear();
            cbxRegistrosPorPagina.Items.Add("Todos");
            cbxRegistrosPorPagina.Items.Add("10");
            cbxRegistrosPorPagina.Items.Add("20");
            cbxRegistrosPorPagina.Items.Add("30");
            cbxRegistrosPorPagina.SelectedIndex = 1; // Selecciona "10" por defecto
        }

        private void ActualizarEtiquetasNavegacion()
        {
            lblPaginaActual.Text = $"Página {PaginaActual} de {PaginasTotales}";
            lblClientesTotales.Text = "Total de Clientes: " + RegistrosTotales;
        }

        private void ActualizarControlesPaginacion()
        {
            btnSiguiente.Enabled = PaginaActual < PaginasTotales;
            btnAnterior.Enabled = PaginaActual > 1;
            btnPrimero.Enabled = PaginaActual > 1;
            btnUltimo.Enabled = PaginaActual < PaginasTotales;
        }

        private void CargarClientes()
        {
            string filtro = txtBuscarUsuario.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(filtro))
            {
                _listaClientesFiltrada = _listaClientesCompleta.ToList();
            }
            else
            {
                _listaClientesFiltrada = _listaClientesCompleta
                    .Where(c => (!string.IsNullOrEmpty(c.Nombre) && c.Nombre.ToLower().Contains(filtro)) ||
                                (!string.IsNullOrEmpty(c.DocumentoIdentidad) && c.DocumentoIdentidad.ToLower().Contains(filtro)) ||
                                (!string.IsNullOrEmpty(c.Telefono) && c.Telefono.ToLower().Contains(filtro)) ||
                                (!string.IsNullOrEmpty(c.Email) && c.Email.ToLower().Contains(filtro)))
                    .ToList();
            }

            RegistrosTotales = _listaClientesFiltrada.Count;

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

            List<ClienteView> datosPagina;
            if (RecordsPerPage == int.MaxValue)
            {
                datosPagina = _listaClientesFiltrada;
            }
            else
            {
                datosPagina = _listaClientesFiltrada
                    .Skip((PaginaActual - 1) * RecordsPerPage)
                    .Take(RecordsPerPage)
                    .ToList();
            }

            dgvClientes.DataSource = null;
            dgvClientes.DataSource = datosPagina;

            ActualizarEtiquetasNavegacion();
            ActualizarControlesPaginacion();
        }

        private void cbxRegistrosPorPagina_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbxRegistrosPorPagina.SelectedItem == null) return;

            string selectedValue = cbxRegistrosPorPagina.SelectedItem.ToString()!;
            if (selectedValue == "Todos")
            {
                RecordsPerPage = int.MaxValue;
            }
            else
            {
                RecordsPerPage = int.Parse(selectedValue);
            }

            PaginaActual = 1;
            CargarClientes();
        }

        private void txtBuscarUsuario_TextChanged(object? sender, EventArgs e)
        {
            PaginaActual = 1;
            CargarClientes();
        }

        private void btnPrimero_Click(object? sender, EventArgs e)
        {
            if (PaginaActual > 1)
            {
                PaginaActual = 1;
                CargarClientes();
            }
        }

        private void btnAnterior_Click(object? sender, EventArgs e)
        {
            if (PaginaActual > 1)
            {
                PaginaActual--;
                CargarClientes();
            }
        }

        private void btnSiguiente_Click(object? sender, EventArgs e)
        {
            if (PaginaActual < PaginasTotales)
            {
                PaginaActual++;
                CargarClientes();
            }
        }

        private void btnUltimo_Click(object? sender, EventArgs e)
        {
            if (PaginasTotales > 0)
            {
                PaginaActual = PaginasTotales;
                CargarClientes();
            }
        }
        #endregion

        #region OPERACIONES CRUD API
        private async Task CargarClientesDesdeApiAsync()
        {
            try
            {
                var lista = await _apiClient.ObtenerListaAsync<ClienteView>("api/clientes");
                _listaClientesCompleta = lista ?? new List<ClienteView>();
                PaginaActual = 1;
                CargarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar clientes desde la API: {ex.Message}", "Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task AgregarClienteAsync()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre del cliente.", "Campo Obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDocumento.Text))
            {
                MessageBox.Show("Por favor, ingrese la cédula o documento del cliente.", "Campo Obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDocumento.Focus();
                return;
            }

            var nuevoCliente = new ClienteView
            {
                Nombre = txtNombre.Text.Trim(),
                DocumentoIdentidad = txtDocumento.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                FechaRegistro = DateTime.Now
            };

            try
            {
                btnAgregar.Enabled = false;
                var response = await _apiClient.PostAsync("api/clientes", nuevoCliente);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cliente registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    await CargarClientesDesdeApiAsync();
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"No se pudo registrar el cliente: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnAgregar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnAgregar.Enabled = true;
            }
        }

        private async Task EditarClienteAsync()
        {
            if (!int.TryParse(lblClienteId.Text, out int id) || id <= 0)
            {
                MessageBox.Show("Por favor seleccione un cliente de la lista para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre del cliente.", "Campo Obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDocumento.Text))
            {
                MessageBox.Show("Por favor, ingrese la cédula o documento del cliente.", "Campo Obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDocumento.Focus();
                return;
            }

            var clienteModificado = new ClienteView
            {
                ClienteId = id,
                Nombre = txtNombre.Text.Trim(),
                DocumentoIdentidad = txtDocumento.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                FechaRegistro = DateTime.Now
            };

            try
            {
                btnEditar.Enabled = false;
                var response = await _apiClient.Http.PutAsJsonAsync($"api/clientes/{id}", clienteModificado);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cliente actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    await CargarClientesDesdeApiAsync();
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"No se pudo actualizar el cliente: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnEditar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnEditar.Enabled = true;
            }
        }

        private async Task EliminarClienteAsync(int id)
        {
            try
            {
                var response = await _apiClient.Http.DeleteAsync($"api/clientes/{id}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cliente eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    await CargarClientesDesdeApiAsync();
                }
                else
                {
                    MessageBox.Show("No se puede eliminar el cliente porque posee órdenes de reparación o ventas registradas en el sistema.", "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region EVENTOS GRID Y FORMULARIO
        private async void dgvClientes_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Clic en la columna Eliminar
            if (dgvClientes.Columns[e.ColumnIndex] == colEliminar)
            {
                if (dgvClientes.Rows[e.RowIndex].DataBoundItem is ClienteView clienteAEliminar)
                {
                    var confirmacion = MessageBox.Show(
                        $"¿Está seguro de que desea eliminar al cliente '{clienteAEliminar.Nombre}'?",
                        "Confirmar Eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirmacion == DialogResult.Yes)
                    {
                        await EliminarClienteAsync(clienteAEliminar.ClienteId);
                    }
                }
                return;
            }

            // Clic en cualquier otra celda para cargar en el formulario de edición
            if (dgvClientes.Rows[e.RowIndex].DataBoundItem is ClienteView cliente)
            {
                lblClienteId.Text = cliente.ClienteId.ToString();
                txtNombre.Text = cliente.Nombre;
                txtDocumento.Text = cliente.DocumentoIdentidad;
                txtTelefono.Text = cliente.Telefono;
                txtEmail.Text = cliente.Email;

                btnAgregar.Enabled = false;
                btnEditar.Enabled = true;
            }
        }

        private void dgvClientes_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvClientes.Columns[e.ColumnIndex] == colEliminar)
            {
                e.Value = Properties.Resources.Eliminar;
            }
        }

        private void LimpiarFormulario()
        {
            lblClienteId.Text = "-";
            txtNombre.Clear();
            txtDocumento.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();

            btnAgregar.Enabled = true;
            btnEditar.Enabled = false;
            dgvClientes.ClearSelection();
            txtNombre.Focus();
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
