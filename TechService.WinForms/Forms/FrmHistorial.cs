using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechService.Application.Dtos;
using TechService.WinForms.Services;

namespace TechService.WinForms.Forms
{
    public partial class FrmHistorial : Form
    {
        private readonly TallerApiClient _apiClient = new();
        private static readonly CultureInfo CulturaRd = new("es-DO");

        private List<OrdenHistorialView> _listaOrdenes = new();
        private List<OrdenHistorialView> _listaFiltrada = new();

        public FrmHistorial()
        {
            InitializeComponent();
            InicializarEventos();
        }

        private void InicializarEventos()
        {
            this.Load += async (s, e) => await CargarHistorialAsync();
            btnCLose.Click += (s, e) => this.Close();

            btnBuscar.Click += (s, e) => AplicarFiltro();
            btnLimpiar.Click += (s, e) => LimpiarFiltros();
            txtBuscar.TextChanged += (s, e) => AplicarFiltro();
            cbxEstado.SelectedIndexChanged += (s, e) => AplicarFiltro();

            dgvOrdenes.CellClick += async (s, e) => await dgvOrdenes_CellClickAsync(e.RowIndex);
            dgvOrdenes.SelectionChanged += async (s, e) =>
            {
                if (dgvOrdenes.CurrentRow != null)
                {
                    await dgvOrdenes_CellClickAsync(dgvOrdenes.CurrentRow.Index);
                }
            };
        }

        private async Task CargarHistorialAsync()
        {
            CargarComboEstados();

            try
            {
                var ordenes = await _apiClient.ObtenerListaAsync<OrdenDto>("api/ordenesreparacion");
                if (ordenes != null)
                {
                    _listaOrdenes = ordenes.Select(o => new OrdenHistorialView
                    {
                        OrdenId = o.OrdenId,
                        CodigoTracking = o.CodigoTracking,
                        ClienteNombre = o.ClienteNombre ?? "Cliente General",
                        ClienteTelefono = o.ClienteTelefono ?? "N/A",
                        MarcaModelo = o.MarcaModelo ?? "Equipo",
                        NumeroSerieImei = o.NumeroSerieImei ?? "N/A",
                        EstadoNombre = o.EstadoNombre ?? "Recibido",
                        TecnicoNombre = o.TecnicoNombre ?? "Sin Asignar",
                        CostoManoObra = o.CostoManoObra,
                        ManoObraTexto = string.Format(CulturaRd, "RD$ {0:N2}", o.CostoManoObra),
                        FechaIngreso = o.FechaIngreso ?? DateTime.Now,
                        FechaIngresoTexto = (o.FechaIngreso ?? DateTime.Now).ToString("dd/MM/yyyy hh:mm tt")
                    }).ToList();

                    AplicarFiltro();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar historial: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarComboEstados()
        {
            cbxEstado.Items.Clear();
            cbxEstado.Items.Add("Todos los Estados");
            cbxEstado.Items.Add("Recibido");
            cbxEstado.Items.Add("RevisionPlaca");
            cbxEstado.Items.Add("EsperandoAprobacion");
            cbxEstado.Items.Add("CambioPieza");
            cbxEstado.Items.Add("PruebasEncendido");
            cbxEstado.Items.Add("Reparado");
            cbxEstado.Items.Add("Entregado");
            cbxEstado.SelectedIndex = 0;
        }

        private void AplicarFiltro()
        {
            string busqueda = txtBuscar.Text.Trim().ToLower();
            string estado = cbxEstado.SelectedItem?.ToString() ?? "Todos los Estados";

            _listaFiltrada = _listaOrdenes.Where(o =>
            {
                bool coincideTexto = string.IsNullOrWhiteSpace(busqueda) ||
                    (!string.IsNullOrEmpty(o.CodigoTracking) && o.CodigoTracking.ToLower().Contains(busqueda)) ||
                    (!string.IsNullOrEmpty(o.ClienteNombre) && o.ClienteNombre.ToLower().Contains(busqueda)) ||
                    (!string.IsNullOrEmpty(o.MarcaModelo) && o.MarcaModelo.ToLower().Contains(busqueda)) ||
                    (!string.IsNullOrEmpty(o.NumeroSerieImei) && o.NumeroSerieImei.ToLower().Contains(busqueda));

                bool coincideEstado = estado == "Todos los Estados" ||
                    string.Equals(o.EstadoNombre, estado, StringComparison.OrdinalIgnoreCase);

                return coincideTexto && coincideEstado;
            }).OrderByDescending(o => o.FechaIngreso).ToList();

            dgvOrdenes.DataSource = null;
            dgvOrdenes.DataSource = _listaFiltrada;

            lblTotalOrdenes.Text = $"Total de Órdenes: {_listaFiltrada.Count}";
            decimal totalManoObra = _listaFiltrada.Sum(o => o.CostoManoObra);
            lblTotalManoObra.Text = string.Format(CulturaRd, "Total Facturado Mano de Obra: RD$ {0:N2}", totalManoObra);

            if (_listaFiltrada.Count > 0)
            {
                dgvOrdenes.Rows[0].Selected = true;
            }
            else
            {
                dgvEventos.DataSource = null;
                LimpiarDetallesGarantia();
            }
        }

        private void LimpiarFiltros()
        {
            txtBuscar.Clear();
            cbxEstado.SelectedIndex = 0;
            AplicarFiltro();
        }

        private async Task dgvOrdenes_CellClickAsync(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= _listaFiltrada.Count) return;

            var orden = _listaFiltrada[rowIndex];

            // Cargar Eventos
            try
            {
                var eventos = await _apiClient.ObtenerListaAsync<HistorialEventoDto>($"api/historialordeneventos/orden/{orden.OrdenId}");
                dgvEventos.DataSource = null;
                if (eventos != null)
                {
                    var eventosView = eventos.Select(e => new
                    {
                        FechaTexto = (e.FechaHora ?? DateTime.Now).ToString("dd/MM/yyyy hh:mm tt"),
                        e.Autor,
                        e.Origen,
                        e.Mensaje
                    }).ToList();
                    dgvEventos.DataSource = eventosView;
                }
            }
            catch
            {
                dgvEventos.DataSource = null;
            }

            // Cargar Garantía si existe
            try
            {
                var response = await _apiClient.Http.GetAsync($"api/entregasgarantia/orden/{orden.OrdenId}");
                if (response.IsSuccessStatusCode)
                {
                    var entrega = await response.Content.ReadFromJsonAsync<EntregaGarantiaDto>();
                    if (entrega != null)
                    {
                        string fechaEntregaTexto = entrega.FechaEntrega.HasValue
                            ? entrega.FechaEntrega.Value.ToString("dd/MM/yyyy hh:mm tt")
                            : "N/A";
                        string vencimientoTexto = entrega.FechaVencimientoGarantia.HasValue
                            ? entrega.FechaVencimientoGarantia.Value.ToString("dd/MM/yyyy")
                            : "N/A";

                        lblFechaEntregaGarantia.Text = $"Fecha de Entrega: {fechaEntregaTexto}";
                        lblDiasGarantia.Text = $"Días de Garantía: {entrega.DiaGarantia} días";
                        lblVencimientoGarantia.Text = $"Vencimiento Garantía: {vencimientoTexto}";
                        lblTotalGarantia.Text = string.Format(CulturaRd, "Total Cobrado: RD$ {0:N2}", entrega.TotalCobrado);
                        lblObsGarantia.Text = $"Observación de Entrega: {entrega.ObservacionFinal}";
                        return;
                    }
                }
                LimpiarDetallesGarantia();
            }
            catch
            {
                LimpiarDetallesGarantia();
            }
        }

        private void LimpiarDetallesGarantia()
        {
            lblFechaEntregaGarantia.Text = "Fecha de Entrega: Pendiente de entrega";
            lblDiasGarantia.Text = "Días de Garantía: 30 días (estándar)";
            lblVencimientoGarantia.Text = "Vencimiento Garantía: No aplica aún";
            lblTotalGarantia.Text = "Total Cobrado: RD$ 0.00";
            lblObsGarantia.Text = "Observación de Entrega: Orden no entregada o sin registro de garantía final.";
        }

        private class OrdenHistorialView
        {
            public int OrdenId { get; set; }
            public string CodigoTracking { get; set; } = string.Empty;
            public string ClienteNombre { get; set; } = string.Empty;
            public string ClienteTelefono { get; set; } = string.Empty;
            public string MarcaModelo { get; set; } = string.Empty;
            public string NumeroSerieImei { get; set; } = string.Empty;
            public string EstadoNombre { get; set; } = string.Empty;
            public string TecnicoNombre { get; set; } = string.Empty;
            public decimal CostoManoObra { get; set; }
            public string ManoObraTexto { get; set; } = string.Empty;
            public DateTime FechaIngreso { get; set; }
            public string FechaIngresoTexto { get; set; } = string.Empty;
        }
    }
}
