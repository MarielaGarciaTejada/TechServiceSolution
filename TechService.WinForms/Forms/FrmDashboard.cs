using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechService.Application.Dtos;
using TechService.WinForms.Models;
using TechService.WinForms.Services;

namespace TechService.WinForms.Forms
{
    public partial class FrmDashboard : Form
    {
        private readonly TallerApiClient _apiClient = new();
        private static readonly CultureInfo CulturaRd = new("es-DO");

        public FrmDashboard()
        {
            InitializeComponent();
            InicializarEventos();
        }

        private void InicializarEventos()
        {
            this.Load += async (s, e) => await CargarDatosDashboardAsync();
            btnActualizar.Click += async (s, e) => await CargarDatosDashboardAsync();

            // Bordes de acento izquierdo para las tarjetas KPI
            pnlCard1.Paint += (s, e) => DibujarBordeAcento(e.Graphics, pnlCard1, Color.FromArgb(13, 110, 253));
            pnlCard2.Paint += (s, e) => DibujarBordeAcento(e.Graphics, pnlCard2, Color.FromArgb(16, 185, 129));
            pnlCard3.Paint += (s, e) => DibujarBordeAcento(e.Graphics, pnlCard3, Color.FromArgb(245, 158, 11));
            pnlCard4.Paint += (s, e) => DibujarBordeAcento(e.Graphics, pnlCard4, Color.FromArgb(15, 23, 42));
        }

        private void DibujarBordeAcento(Graphics g, Panel panel, Color color)
        {
            using var brush = new SolidBrush(color);
            g.FillRectangle(brush, 0, 0, 5, panel.Height);
        }

        public async Task CargarDatosDashboardAsync()
        {
            try
            {
                btnActualizar.Enabled = false;
                btnActualizar.Text = "Cargando...";

                // Cargar Órdenes
                var ordenes = await _apiClient.ObtenerListaAsync<OrdenDto>("api/ordenesreparacion");
                int totalOrdenesActivas = 0;
                int totalReparados = 0;

                if (ordenes != null)
                {
                    totalOrdenesActivas = ordenes.Count(o => !string.Equals(o.EstadoNombre, "Entregado", StringComparison.OrdinalIgnoreCase));
                    totalReparados = ordenes.Count(o => string.Equals(o.EstadoNombre, "Reparado", StringComparison.OrdinalIgnoreCase));

                    var ultimasOrdenes = ordenes
                        .OrderByDescending(o => o.FechaIngreso)
                        .Take(15)
                        .Select(o => new
                        {
                            o.CodigoTracking,
                            ClienteNombre = o.ClienteNombre ?? "Cliente General",
                            MarcaModelo = o.MarcaModelo ?? "Equipo",
                            EstadoNombre = o.EstadoNombre ?? "Recibido",
                            TecnicoNombre = o.TecnicoNombre ?? "Sin Asignar",
                            FechaIngresoTexto = (o.FechaIngreso ?? DateTime.Now).ToString("dd/MM/yyyy hh:mm tt")
                        })
                        .ToList();

                    dgvUltimasOrdenes.DataSource = null;
                    dgvUltimasOrdenes.DataSource = ultimasOrdenes;
                }

                lblKpiOrdenesActivas.Text = totalOrdenesActivas.ToString();
                lblKpiReparados.Text = totalReparados.ToString();

                // Cargar Clientes
                var clientes = await _apiClient.ObtenerListaAsync<ClienteView>("api/clientes");
                lblKpiClientes.Text = (clientes?.Count ?? 0).ToString();

                // Cargar Ventas
                var ventas = await _apiClient.ObtenerListaAsync<VentaDto>("api/ventas");
                decimal sumaVentas = ventas?.Sum(v => v.TotalVenta) ?? 0;
                lblKpiVentas.Text = string.Format(CulturaRd, "RD$ {0:N2}", sumaVentas);

                // Cargar Alertas de Stock Bajo
                var catalogo = await _apiClient.ObtenerListaAsync<CatalogoItemDto>("api/catalogo");
                if (catalogo != null)
                {
                    var bajoStock = catalogo
                        .Where(i => i.Stock <= i.StockMinimoAlerta)
                        .OrderBy(i => i.Stock)
                        .Select(i => new
                        {
                            i.CodigoSku,
                            i.Nombre,
                            i.Stock,
                            i.StockMinimoAlerta
                        })
                        .ToList();

                    dgvStockBajo.DataSource = null;
                    dgvStockBajo.DataSource = bajoStock;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[Dashboard Error] {ex.Message}");
            }
            finally
            {
                btnActualizar.Enabled = true;
                btnActualizar.Text = "🔄 Actualizar Datos";
            }
        }
    }
}
