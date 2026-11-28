using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechService.Application.Dtos;
using TechService.WinForms.Services;

namespace TechService.WinForms.Forms
{
    public partial class FrmOrdenRepuestos : Form
    {
        private readonly TallerApiClient api = new TallerApiClient();

        private List<OrdenRepuestoDto> repuestos = new();
        private List<CatalogoItemDto> catalogo = new();
        private bool cargandoOrdenes = false;

        private sealed class EstadoAprobacionItem
        {
            public int Id { get; set; }
            public string Nombre { get; set; } = string.Empty;
        }

        public FrmOrdenRepuestos()
        {
            InitializeComponent();
            ConfigurarEstadosAprobacion();

            btnCerrar.Click += btnCerrar_Click;
            btnAgregar.Click += async (s, e) => await AgregarAsync();
            btnEditar.Click += async (s, e) => await EditarAsync();
            btnEliminar.Click += async (s, e) => await EliminarAsync();
            dgvRepuestos.CellClick += (s, e) => CargarFilaEnControles();
        }

        private void ConfigurarEstadosAprobacion()
        {
            var estados = new List<EstadoAprobacionItem>
            {
                new EstadoAprobacionItem { Id = 1, Nombre = "PendienteCliente" },
                new EstadoAprobacionItem { Id = 2, Nombre = "Aprobado" },
                new EstadoAprobacionItem { Id = 3, Nombre = "Rechazado" }
            };

            cboEstadoAprobacion.DataSource = estados;
            cboEstadoAprobacion.DisplayMember = "Nombre";
            cboEstadoAprobacion.ValueMember = "Id";
        }

        private async void FrmOrdenRepuestos_Load(object sender, EventArgs e)
        {
            await CargarCatalogoAsync();
            if (IsDisposed || Disposing) return;

            await CargarOrdenesAsync();
            if (IsDisposed || Disposing) return;

            if (cboOrdenes.SelectedValue is int ordenId && ordenId > 0)
            {
                await CargarRepuestosOrdenAsync(ordenId);
            }
        }

        private async Task CargarCatalogoAsync()
        {
            try
            {
                catalogo = await api.ObtenerListaAsync<CatalogoItemDto>("api/catalogo") ?? new();
                if (IsDisposed || Disposing) return;

                cboCatalogo.DisplayMember = "Nombre";
                cboCatalogo.ValueMember = "ItemId";
                cboCatalogo.DataSource = catalogo;
                cboCatalogo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el catálogo: " + ex.Message);
            }
        }

        private async Task CargarOrdenesAsync()
        {
            try
            {
                cargandoOrdenes = true;
                var ordenes = await api.ObtenerListaAsync<OrdenDto>("api/ordenesreparacion") ?? new();

                if (IsDisposed || Disposing) return;

                cboOrdenes.DataSource = ordenes;
                cboOrdenes.DisplayMember = "CodigoTracking";
                cboOrdenes.ValueMember = "OrdenId";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las órdenes: " + ex.Message);
            }
            finally
            {
                cargandoOrdenes = false;
            }
        }

        private async void cboOrdenes_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cargandoOrdenes) return;

            if (cboOrdenes.SelectedValue is int ordenId && ordenId > 0)
            {
                await CargarRepuestosOrdenAsync(ordenId);
            }
        }

        private async Task CargarRepuestosOrdenAsync(int ordenId)
        {
            try
            {
                repuestos = await api.ObtenerListaAsync<OrdenRepuestoDto>($"api/ordenrepuestos/orden/{ordenId}") ?? new();
                if (IsDisposed || Disposing) return;

                var filas = repuestos.Select(r =>
                {
                    var nombrePieza = catalogo.FirstOrDefault(c => c.ItemId == r.ItemId)?.Nombre ?? $"Ítem #{r.ItemId}";
                    return new
                    {
                        r.OrdenRepuestoId,
                        Pieza = nombrePieza,
                        r.Cantidad,
                        r.PrecioUnitario,
                        Subtotal = r.Cantidad * r.PrecioUnitario,
                        Estado = ObtenerNombreEstado(r.EstadoAprobacionId)
                    };
                }).ToList();

                dgvRepuestos.DataSource = filas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los repuestos de la orden: " + ex.Message);
            }
        }

        private static string ObtenerNombreEstado(int estadoId) => estadoId switch
        {
            1 => "PendienteCliente",
            2 => "Aprobado",
            3 => "Rechazado",
            _ => $"Estado {estadoId}"
        };

        // ---------- Selección de fila ----------

        private OrdenRepuestoDto? ObtenerRepuestoSeleccionado()
        {
            if (dgvRepuestos.CurrentRow == null) return null;

            var valor = dgvRepuestos.CurrentRow.Cells["OrdenRepuestoId"].Value;
            if (valor is not int id) return null;

            return repuestos.FirstOrDefault(r => r.OrdenRepuestoId == id);
        }

        private void CargarFilaEnControles()
        {
            var sel = ObtenerRepuestoSeleccionado();
            if (sel == null) return;

            cboEstadoAprobacion.SelectedValue = sel.EstadoAprobacionId;
            cboCatalogo.SelectedValue = sel.ItemId;
            nudCantidad.Value = Math.Clamp(sel.Cantidad, (int)nudCantidad.Minimum, (int)nudCantidad.Maximum);
        }

        // ---------- Agregar ----------

        private async Task AgregarAsync()
        {
            if (cboOrdenes.SelectedValue is not int ordenId || ordenId <= 0)
            {
                MessageBox.Show("Selecciona una orden.");
                return;
            }

            if (cboCatalogo.SelectedItem is not CatalogoItemDto item)
            {
                MessageBox.Show("Selecciona un artículo del catálogo.");
                return;
            }

            if (cboEstadoAprobacion.SelectedValue is not int estadoId)
            {
                MessageBox.Show("Selecciona un estado de aprobación.");
                return;
            }

            var dto = new OrdenRepuestoDto
            {
                OrdenId = ordenId,
                ItemId = item.ItemId,
                EstadoAprobacionId = estadoId,
                EstadoAprobacionNombre = ObtenerNombreEstado(estadoId),
                Cantidad = (int)nudCantidad.Value,
                PrecioUnitario = item.Precio,
                NombreItem = item.Nombre
            };

            try
            {
                btnAgregar.Enabled = false;
                var resp = await api.PostAsync("api/ordenrepuestos", dto);
                if (IsDisposed || Disposing) return;

                if (resp.IsSuccessStatusCode)
                {
                    await CargarRepuestosOrdenAsync(ordenId);
                }
                else
                {
                    string detalle = await resp.Content.ReadAsStringAsync();
                    MessageBox.Show($"No se pudo agregar ({(int)resp.StatusCode}): {detalle}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el repuesto: " + ex.Message);
            }
            finally
            {
                if (!IsDisposed) btnAgregar.Enabled = true;
            }
        }

        // ---------- Editar ----------

        private async Task EditarAsync()
        {
            var sel = ObtenerRepuestoSeleccionado();
            if (sel == null)
            {
                MessageBox.Show("Selecciona primero un repuesto de la tabla.");
                return;
            }

            if (cboCatalogo.SelectedItem is not CatalogoItemDto item)
            {
                MessageBox.Show("Selecciona un artículo del catálogo.");
                return;
            }

            if (cboEstadoAprobacion.SelectedValue is not int estadoId)
            {
                MessageBox.Show("Selecciona un estado de aprobación.");
                return;
            }

            var dto = new OrdenRepuestoDto
            {
                OrdenRepuestoId = sel.OrdenRepuestoId,
                OrdenId = sel.OrdenId,
                ItemId = item.ItemId,
                EstadoAprobacionId = estadoId,
                EstadoAprobacionNombre = ObtenerNombreEstado(estadoId),
                Cantidad = (int)nudCantidad.Value,
                PrecioUnitario = item.ItemId == sel.ItemId ? sel.PrecioUnitario : item.Precio,
                NombreItem = item.Nombre
            };

            try
            {
                btnEditar.Enabled = false;
                var resp = await api.Http.PutAsJsonAsync($"api/ordenrepuestos/{sel.OrdenRepuestoId}", dto);
                if (IsDisposed || Disposing) return;

                if (resp.IsSuccessStatusCode)
                {
                    await CargarRepuestosOrdenAsync(sel.OrdenId);
                }
                else
                {
                    string detalle = await resp.Content.ReadAsStringAsync();
                    MessageBox.Show($"No se pudo editar ({(int)resp.StatusCode}): {detalle}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar el repuesto: " + ex.Message);
            }
            finally
            {
                if (!IsDisposed) btnEditar.Enabled = true;
            }
        }

        // ---------- Eliminar ----------

        private async Task EliminarAsync()
        {
            var sel = ObtenerRepuestoSeleccionado();
            if (sel == null)
            {
                MessageBox.Show("Selecciona primero un repuesto de la tabla.");
                return;
            }

            var nombre = catalogo.FirstOrDefault(c => c.ItemId == sel.ItemId)?.Nombre ?? $"Ítem #{sel.ItemId}";
            var confirmar = MessageBox.Show(
                $"¿Eliminar \"{nombre}\" de esta orden?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (confirmar != DialogResult.Yes) return;

            try
            {
                btnEliminar.Enabled = false;
                var resp = await api.Http.DeleteAsync($"api/ordenrepuestos/{sel.OrdenRepuestoId}");
                if (IsDisposed || Disposing) return;

                if (resp.IsSuccessStatusCode)
                {
                    await CargarRepuestosOrdenAsync(sel.OrdenId);
                }
                else
                {
                    string detalle = await resp.Content.ReadAsStringAsync();
                    MessageBox.Show($"No se pudo eliminar ({(int)resp.StatusCode}): {detalle}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el repuesto: " + ex.Message);
            }
            finally
            {
                if (!IsDisposed) btnEliminar.Enabled = true;
            }
        }

        // ---------- Handlers que el Designer ya tiene conectados: NO borrar ----------

        private void dgvRepuestos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarFilaEnControles();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnCerrar_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}