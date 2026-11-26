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
    public partial class FrmTecnicos : Form
    {
        private readonly TallerApiClient _apiClient = new();
        private List<TecnicoView> _listaTecnicosCompleta = new();
        private List<TecnicoView> _listaTecnicosFiltrada = new();
        private int _tecnicoIdSeleccionado = 0;

        #region PAGINACION
        private int PaginaActual = 1;
        private int RecordsPerPage = 10;
        private int RegistrosTotales = 0;
        private int PaginasTotales = 0;
        #endregion

        public FrmTecnicos()
        {
            InitializeComponent();
            InicializarEventos();
        }

        private void InicializarEventos()
        {
            this.Load += FrmTecnicos_Load;

            // Eventos de botones CRUD y navegación
            btnCLose.Click += (s, e) => this.Close();
            btnAgregar.Click += async (s, e) => await AgregarTecnicoAsync();
            btnEditar.Click += async (s, e) => await EditarTecnicoAsync();
            btnCancelar.Click += (s, e) => LimpiarFormulario();

            // Eventos de búsqueda y paginación
            txtBuscarTecnico.TextChanged += txtBuscarTecnico_TextChanged;
            cbxRegistrosPorPagina.SelectedIndexChanged += cbxRegistrosPorPagina_SelectedIndexChanged;
            btnPrimero.Click += btnPrimero_Click;
            btnAnterior.Click += btnAnterior_Click;
            btnSiguiente.Click += btnSiguiente_Click;
            btnUltimo.Click += btnUltimo_Click;

            // Eventos del DataGridView
            dgvTecnicos.CellClick += dgvTecnicos_CellClick;
            dgvTecnicos.CellFormatting += dgvTecnicos_CellFormatting;
        }

        private async void FrmTecnicos_Load(object? sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarOpcionesRegistrosPorPagina();
            LimpiarFormulario();
            await CargarTecnicosDesdeApiAsync();
        }

        private void ConfigurarGrid()
        {
            dgvTecnicos.AutoGenerateColumns = false;

            colClienteId.DataPropertyName = nameof(TecnicoView.TecnicoId);
            colClienteId.Visible = false;

            colNombre.DataPropertyName = nameof(TecnicoView.Nombre);
            colNombre.HeaderText = "Nombre Completo";

            colDocumento.DataPropertyName = nameof(TecnicoView.Especialidad);
            colDocumento.HeaderText = "Especialidad";

            colTelefono.DataPropertyName = nameof(TecnicoView.ComisionTexto);
            colTelefono.HeaderText = "% Comisión";

            colEmail.DataPropertyName = nameof(TecnicoView.ActivoTexto);
            colEmail.HeaderText = "Estado";

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
            lblClientesTotales.Text = "Total de Técnicos: " + RegistrosTotales;
        }

        private void ActualizarControlesPaginacion()
        {
            btnSiguiente.Enabled = PaginaActual < PaginasTotales;
            btnAnterior.Enabled = PaginaActual > 1;
            btnPrimero.Enabled = PaginaActual > 1;
            btnUltimo.Enabled = PaginaActual < PaginasTotales;
        }

        private void CargarTecnicos()
        {
            string filtro = txtBuscarTecnico.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(filtro))
            {
                _listaTecnicosFiltrada = _listaTecnicosCompleta.ToList();
            }
            else
            {
                _listaTecnicosFiltrada = _listaTecnicosCompleta
                    .Where(t => (!string.IsNullOrEmpty(t.Nombre) && t.Nombre.ToLower().Contains(filtro)) ||
                                (!string.IsNullOrEmpty(t.Especialidad) && t.Especialidad.ToLower().Contains(filtro)) ||
                                t.PorcentajeComision.ToString().Contains(filtro))
                    .ToList();
            }

            RegistrosTotales = _listaTecnicosFiltrada.Count;

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

            List<TecnicoView> datosPagina;
            if (RecordsPerPage == int.MaxValue)
            {
                datosPagina = _listaTecnicosFiltrada;
            }
            else
            {
                datosPagina = _listaTecnicosFiltrada
                    .Skip((PaginaActual - 1) * RecordsPerPage)
                    .Take(RecordsPerPage)
                    .ToList();
            }

            dgvTecnicos.DataSource = null;
            dgvTecnicos.DataSource = datosPagina;

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
            CargarTecnicos();
        }

        private void txtBuscarTecnico_TextChanged(object? sender, EventArgs e)
        {
            PaginaActual = 1;
            CargarTecnicos();
        }

        private void btnPrimero_Click(object? sender, EventArgs e)
        {
            if (PaginaActual > 1)
            {
                PaginaActual = 1;
                CargarTecnicos();
            }
        }

        private void btnAnterior_Click(object? sender, EventArgs e)
        {
            if (PaginaActual > 1)
            {
                PaginaActual--;
                CargarTecnicos();
            }
        }

        private void btnSiguiente_Click(object? sender, EventArgs e)
        {
            if (PaginaActual < PaginasTotales)
            {
                PaginaActual++;
                CargarTecnicos();
            }
        }

        private void btnUltimo_Click(object? sender, EventArgs e)
        {
            if (PaginasTotales > 0)
            {
                PaginaActual = PaginasTotales;
                CargarTecnicos();
            }
        }
        #endregion

        #region OPERACIONES CRUD API
        private async Task CargarTecnicosDesdeApiAsync()
        {
            try
            {
                var lista = await _apiClient.ObtenerListaAsync<TecnicoView>("api/tecnicos");
                _listaTecnicosCompleta = lista ?? new List<TecnicoView>();
                PaginaActual = 1;
                CargarTecnicos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar técnicos desde la API: {ex.Message}", "Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task AgregarTecnicoAsync()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre del técnico.", "Campo Obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDocumento.Text))
            {
                MessageBox.Show("Por favor, ingrese la especialidad del técnico.", "Campo Obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDocumento.Focus();
                return;
            }

            var nuevoTecnico = new TecnicoView
            {
                Nombre = txtNombre.Text.Trim(),
                Especialidad = txtDocumento.Text.Trim(),
                PorcentajeComision = numPorcentajeComision.Value,
                Activo = cbxActivo.Checked
            };

            try
            {
                btnAgregar.Enabled = false;
                var response = await _apiClient.PostAsync("api/tecnicos", nuevoTecnico);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Técnico registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    await CargarTecnicosDesdeApiAsync();
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"No se pudo registrar el técnico: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnAgregar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión al agregar técnico: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnAgregar.Enabled = true;
            }
        }

        private async Task EditarTecnicoAsync()
        {
            if (_tecnicoIdSeleccionado <= 0)
            {
                MessageBox.Show("Por favor seleccione un técnico de la lista para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre del técnico.", "Campo Obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDocumento.Text))
            {
                MessageBox.Show("Por favor, ingrese la especialidad del técnico.", "Campo Obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDocumento.Focus();
                return;
            }

            var tecnicoModificado = new TecnicoView
            {
                TecnicoId = _tecnicoIdSeleccionado,
                Nombre = txtNombre.Text.Trim(),
                Especialidad = txtDocumento.Text.Trim(),
                PorcentajeComision = numPorcentajeComision.Value,
                Activo = cbxActivo.Checked
            };

            try
            {
                btnEditar.Enabled = false;
                var response = await _apiClient.Http.PutAsJsonAsync($"api/tecnicos/{_tecnicoIdSeleccionado}", tecnicoModificado);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Técnico actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    await CargarTecnicosDesdeApiAsync();
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"No se pudo actualizar el técnico: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnEditar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión al actualizar técnico: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnEditar.Enabled = true;
            }
        }

        private async Task EliminarTecnicoAsync(int id)
        {
            try
            {
                var response = await _apiClient.Http.DeleteAsync($"api/tecnicos/{id}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Técnico eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    await CargarTecnicosDesdeApiAsync();
                }
                else
                {
                    MessageBox.Show("No se puede eliminar el técnico porque posee órdenes de reparación o usuarios asignados.", "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region EVENTOS GRID Y FORMULARIO
        private async void dgvTecnicos_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Clic en la columna Eliminar
            if (dgvTecnicos.Columns[e.ColumnIndex] == colEliminar)
            {
                if (dgvTecnicos.Rows[e.RowIndex].DataBoundItem is TecnicoView tecnicoAEliminar)
                {
                    var confirmacion = MessageBox.Show(
                        $"¿Está seguro de que desea eliminar al técnico '{tecnicoAEliminar.Nombre}'?",
                        "Confirmar Eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirmacion == DialogResult.Yes)
                    {
                        await EliminarTecnicoAsync(tecnicoAEliminar.TecnicoId);
                    }
                }
                return;
            }

            // Clic en cualquier otra celda para cargar en el formulario de edición
            if (dgvTecnicos.Rows[e.RowIndex].DataBoundItem is TecnicoView tecnico)
            {
                _tecnicoIdSeleccionado = tecnico.TecnicoId;
                txtNombre.Text = tecnico.Nombre;
                txtDocumento.Text = tecnico.Especialidad;
                numPorcentajeComision.Value = Math.Min(Math.Max(tecnico.PorcentajeComision, numPorcentajeComision.Minimum), numPorcentajeComision.Maximum);
                cbxActivo.Checked = tecnico.Activo;

                btnAgregar.Enabled = false;
                btnEditar.Enabled = true;
            }
        }

        private void dgvTecnicos_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvTecnicos.Columns[e.ColumnIndex] == colEliminar)
            {
                e.Value = Properties.Resources.Eliminar;
            }
        }

        private void LimpiarFormulario()
        {
            _tecnicoIdSeleccionado = 0;
            txtNombre.Clear();
            txtDocumento.Clear();
            numPorcentajeComision.Value = 20.00m;
            cbxActivo.Checked = true;

            btnAgregar.Enabled = true;
            btnEditar.Enabled = false;
            dgvTecnicos.ClearSelection();
            txtNombre.Focus();
        }

        private void cbxActivo_CheckedChanged(object sender, EventArgs e)
        { }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
