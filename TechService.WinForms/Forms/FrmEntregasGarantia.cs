
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechService.Application.Dtos;
using TechService.WinForms.Services;

namespace TechService.WinForms.Forms
{
    public partial class FrmEntregasGarantia : Form
    {
        private readonly TallerApiClient api = new TallerApiClient();

        private List<OrdenDto> todasOrdenes = new();
        private List<OrdenDto> ordenesReparadas = new();
        private decimal totalManoObra;
        private decimal totalRepuesto;
        private bool cargandoOrdenes = false;

        private sealed class MetodoPagoItem
        {
            public int Id { get; set; }
            public string Nombre { get; set; } = string.Empty;
        }

        public FrmEntregasGarantia()
        {
            InitializeComponent();
            ConfigurarMetodosPago();

            btnBuscar.Click += (s, e) => BuscarPorTracking();
            btnConfirmar.Click += async (s, e) => await ConfirmarEntregaAsync();
            btnLimpiar.Click += (s, e) => LimpiarFormulario();
            comboBox1.SelectedIndexChanged += async (s, e) => await OrdenSeleccionadaAsync();
        }

        private void ConfigurarMetodosPago()
        {
            var metodos = new List<MetodoPagoItem>
            {
                new MetodoPagoItem { Id = 1, Nombre = "Efectivo" },
                new MetodoPagoItem { Id = 2, Nombre = "Tarjeta" },
                new MetodoPagoItem { Id = 3, Nombre = "Transferencia" }
            };

            cmbMetodoPago.DisplayMember = "Nombre";
            cmbMetodoPago.ValueMember = "Id";
            cmbMetodoPago.DataSource = metodos;
        }

        private async void FrmEntregasGarantia_Load(object sender, EventArgs e)
        {
            await CargarOrdenesAsync();
            if (IsDisposed || Disposing) return;

            await CargarEntregasAsync();
        }

        private async Task CargarOrdenesAsync()
        {
            try
            {
                cargandoOrdenes = true;
                todasOrdenes = await api.ObtenerListaAsync<OrdenDto>("api/ordenesreparacion") ?? new();
                if (IsDisposed || Disposing) return;

                ordenesReparadas = todasOrdenes
                    .Where(o => string.Equals(o.EstadoNombre, "Reparado", StringComparison.OrdinalIgnoreCase))
                    .ToList();

                comboBox1.DisplayMember = "CodigoTracking";
                comboBox1.ValueMember = "OrdenId";
                comboBox1.DataSource = ordenesReparadas;
                comboBox1.SelectedIndex = -1;
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

        private async Task CargarEntregasAsync()
        {
            try
            {
                var entregas = await api.ObtenerListaAsync<EntregaGarantiaDto>("api/entregasgarantia") ?? new();
                if (IsDisposed || Disposing) return;

                dgvEntregas.DataSource = entregas
                    .OrderByDescending(x => x.EntregaId)
                    .Select(x => new
                    {
                        Orden = todasOrdenes.FirstOrDefault(o => o.OrdenId == x.OrdenId)?.CodigoTracking ?? $"#{x.OrdenId}",
                        Metodo = x.MetodoPagoNombre,
                        FechaEntrega = x.FechaEntrega?.ToString("dd/MM/yyyy") ?? "-",
                        DiasGarantia = x.DiaGarantia,
                        Vence = x.FechaVencimientoGarantia?.ToString("dd/MM/yyyy") ?? "-",
                        TotalCobrado = x.TotalCobrado.ToString("N2")
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las entregas: " + ex.Message);
            }
        }

        private async Task OrdenSeleccionadaAsync()
        {
            if (cargandoOrdenes) return;

            if (comboBox1.SelectedItem is not OrdenDto orden)
            {
                LimpiarDatosOrden();
                return;
            }

            lblCliente.Text = orden.ClienteNombre ?? "-";
            lblEquipo.Text = string.IsNullOrWhiteSpace(orden.MarcaModelo) ? "-" : orden.MarcaModelo;
            totalManoObra = orden.CostoManoObra;

            try
            {
                var repuestos = await api.ObtenerListaAsync<OrdenRepuestoDto>($"api/ordenrepuestos/orden/{orden.OrdenId}") ?? new();
                if (IsDisposed || Disposing) return;
                if (!ReferenceEquals(comboBox1.SelectedItem, orden)) return;

                totalRepuesto = repuestos
                    .Where(r => r.EstadoAprobacionId == 2)
                    .Sum(r => r.Cantidad * r.PrecioUnitario);
            }
            catch (Exception ex)
            {
                totalRepuesto = 0;
                MessageBox.Show("Error al cargar los repuestos de la orden: " + ex.Message);
            }

            MostrarTotales();
        }

        private void MostrarTotales()
        {
            lblManoObra.Text = totalManoObra.ToString("N2");
            lblRepuestos.Text = totalRepuesto.ToString("N2");
            lblTotal.Text = (totalManoObra + totalRepuesto).ToString("N2");
        }

        private void LimpiarDatosOrden()
        {
            lblCliente.Text = "-";
            lblEquipo.Text = "-";
            totalManoObra = 0;
            totalRepuesto = 0;
            MostrarTotales();
        }

        private void BuscarPorTracking()
        {
            string codigo = txtTracking.Text.Trim();
            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("Escribe un código de tracking.");
                txtTracking.Focus();
                return;
            }

            var orden = ordenesReparadas.FirstOrDefault(o =>
                string.Equals(o.CodigoTracking, codigo, StringComparison.OrdinalIgnoreCase));

            if (orden == null)
            {
                MessageBox.Show("No hay una orden en estado Reparado con ese tracking.");
                return;
            }

            comboBox1.SelectedItem = orden;
        }

        private async Task ConfirmarEntregaAsync()
        {
            if (comboBox1.SelectedItem is not OrdenDto orden)
            {
                MessageBox.Show("Selecciona una orden reparada.");
                return;
            }

            if (cmbMetodoPago.SelectedValue is not int metodoId)
            {
                MessageBox.Show("Selecciona un método de pago.");
                return;
            }

            decimal total = totalManoObra + totalRepuesto;

            var confirmar = MessageBox.Show(
                $"¿Registrar la entrega de {orden.CodigoTracking} por {total:N2}?",
                "Confirmar entrega",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (confirmar != DialogResult.Yes) return;

            var dto = new EntregaGarantiaDto
            {
                OrdenId = orden.OrdenId,
                MetodoPagoId = metodoId,
                MetodoPagoNombre = cmbMetodoPago.Text,
                DiaGarantia = (int)nudDiasGarantia.Value,
                TotalManoObra = totalManoObra,
                TotalRepuesto = totalRepuesto,
                TotalCobrado = total,
                ObservacionFinal = txtObservacion.Text.Trim()
            };

            try
            {
                btnConfirmar.Enabled = false;
                var resp = await api.PostAsync("api/entregasgarantia", dto);
                if (IsDisposed || Disposing) return;

                if (resp.IsSuccessStatusCode)
                {
                    MessageBox.Show("Entrega registrada correctamente.");
                    LimpiarFormulario();
                    await CargarOrdenesAsync();
                    if (IsDisposed || Disposing) return;
                    await CargarEntregasAsync();
                }
                else
                {
                    string detalle = await resp.Content.ReadAsStringAsync();
                    MessageBox.Show($"No se pudo registrar ({(int)resp.StatusCode}): {detalle}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la entrega: " + ex.Message);
            }
            finally
            {
                if (!IsDisposed) btnConfirmar.Enabled = true;
            }
        }

        private void LimpiarFormulario()
        {
            txtTracking.Clear();
            comboBox1.SelectedIndex = -1;
            cmbMetodoPago.SelectedIndex = 0;
            nudDiasGarantia.Value = 30;
            txtObservacion.Clear();
            LimpiarDatosOrden();
        }

        // Handlers que el Designer ya tiene conectados: NO borrar
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void txtTracking_TextChanged(object sender, EventArgs e) { }
        private void lblTracking_Click(object sender, EventArgs e) { }
        private void txtObservacion_TextChanged(object sender, EventArgs e) { }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}