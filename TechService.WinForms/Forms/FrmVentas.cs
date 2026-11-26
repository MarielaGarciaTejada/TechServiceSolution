using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechService.Application.Dtos;
using TechService.WinForms.Models;
using TechService.WinForms.Services;

namespace TechService.WinForms.Forms
{
    public partial class FrmVentas : Form
    {
        private readonly TallerApiClient apiClient = new();
        private readonly BindingList<VentaItemRow> listaCarrito = new();
        private List<ClienteView> listaClientes = new();
        private List<CatalogoItemView> listaArticulos = new();

        private decimal montoSubtotal = 0m;
        private decimal montoItbis = 0m;
        private decimal montoTotalPagar = 0m;

        public FrmVentas()
        {
            InitializeComponent();
            ConfigurarEventos();
        }

        private void ConfigurarEventos()
        {
            this.Load += FrmVentas_Load;
            btnAgregar.Click += btnAgregar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnVender.Click += btnVender_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnCLose.Click += btnCLose_Click;
            txtEfectivo.TextChanged += txtEfectivo_TextChanged;
            txtEfectivo.KeyPress += txtEfectivo_KeyPress;
            cbMetodoPago.SelectedIndexChanged += cbMetodoPago_SelectedIndexChanged;
        }

        private async void FrmVentas_Load(object? sender, EventArgs e)
        {
            ConfigurarDgvDetalles();
            CargarMetodosPago();
            await CargarDatosInicialesAsync();
            if (IsDisposed || Disposing) return;
            LimpiarFormulario();
        }

        private void ConfigurarDgvDetalles()
        {
            dgvDetalles.AutoGenerateColumns = false;
            colItemId.DataPropertyName = nameof(VentaItemRow.ItemId);
            colCodigoSku.DataPropertyName = nameof(VentaItemRow.CodigoSku);
            colArticulo.DataPropertyName = nameof(VentaItemRow.Articulo);
            colPrecioUnitario.DataPropertyName = nameof(VentaItemRow.PrecioUnitario);
            colCantidad.DataPropertyName = nameof(VentaItemRow.Cantidad);
            colSubtotal.DataPropertyName = nameof(VentaItemRow.Subtotal);

            colPrecioUnitario.DefaultCellStyle.Format = "\"RD$\" #,##0.00";
            colSubtotal.DefaultCellStyle.Format = "\"RD$\" #,##0.00";

            dgvDetalles.DataSource = listaCarrito;
        }

        private async Task CargarDatosInicialesAsync()
        {
            // Cargar lista de Clientes
            try
            {
                var clientesApi = await apiClient.ObtenerListaAsync<ClienteView>("api/clientes");
                if (IsDisposed || Disposing) return;
                listaClientes = clientesApi ?? new();

                cbClientes.DataSource = null;
                cbClientes.DisplayMember = "Nombre";
                cbClientes.ValueMember = "ClienteId";

                // Agregar opción inicial por defecto: ~ Seleccionar ~
                var clientesCombo = new List<ClienteView>
                {
                    new() { ClienteId = 0, Nombre = "~ Seleccionar ~" }
                };
                clientesCombo.AddRange(listaClientes);

                cbClientes.DataSource = clientesCombo;
                if (cbClientes.Items.Count > 0) cbClientes.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[Error cargando clientes]: {ex.Message}");
            }

            // Cargar Catálogo de Artículos y Accesorios
            await RefrescarCatalogoAsync();
        }

        private async Task RefrescarCatalogoAsync()
        {
            try
            {
                var catalogoApi = await apiClient.ObtenerListaAsync<CatalogoItemView>("api/catalogo");
                if (IsDisposed || Disposing) return;
                listaArticulos = catalogoApi ?? new();

                // Agregar opción inicial por defecto: ~ Seleccionar ~
                var articulosCombo = new List<CatalogoItemView>
                {
                    new() { ItemId = 0, Nombre = "~ Seleccionar ~" }
                };
                articulosCombo.AddRange(listaArticulos);

                cbArticulos.DataSource = null;
                cbArticulos.DisplayMember = "Nombre";
                cbArticulos.ValueMember = "ItemId";
                cbArticulos.DataSource = articulosCombo;
                if (cbArticulos.Items.Count > 0) cbArticulos.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[Error cargando catálogo]: {ex.Message}");
            }
        }

        private void CargarMetodosPago()
        {
            // Agregar opción inicial por defecto: ~ Seleccionar ~
            var metodos = new List<LookupItem>
            {
                new(0, "~ Seleccionar ~"),
                new(1, "Efectivo"),
                new(2, "Tarjeta de Débito / Crédito"),
                new(3, "Transferencia Bancaria")
            };

            cbMetodoPago.DataSource = metodos;
            cbMetodoPago.DisplayMember = "Nombre";
            cbMetodoPago.ValueMember = "Id";
            cbMetodoPago.SelectedIndex = 0;
        }

        private void btnAgregar_Click(object? sender, EventArgs e)
        {
            if (cbArticulos.SelectedItem is not CatalogoItemView articulo || articulo.ItemId == 0)
            {
                MessageBox.Show("Por favor seleccione un artículo válido del catálogo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbArticulos.Focus();
                return;
            }

            int cantidadSolicitada = (int)numCantidad.Value;
            if (cantidadSolicitada <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numCantidad.Focus();
                return;
            }

            // Validar stock disponible
            var existente = listaCarrito.FirstOrDefault(x => x.ItemId == articulo.ItemId);
            int cantidadTotal = cantidadSolicitada + (existente?.Cantidad ?? 0);

            if (articulo.Stock > 0 && cantidadTotal > articulo.Stock)
            {
                MessageBox.Show(
                    $"No hay suficiente inventario disponible para '{articulo.Nombre}'.\n" +
                    $"• Stock en almacén: {articulo.Stock}\n" +
                    $"• Ya agregado al carrito: {existente?.Cantidad ?? 0}\n" +
                    $"• Máximo que puede agregar ahora: {articulo.Stock - (existente?.Cantidad ?? 0)}",
                    "Stock Insuficiente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (existente != null)
            {
                // Si ya está en la factura, aumentamos la cantidad
                existente.Cantidad += cantidadSolicitada;
                listaCarrito.ResetBindings();
            }
            else
            {
                // Si es nuevo, lo agregamos como fila
                listaCarrito.Add(new VentaItemRow
                {
                    ItemId = articulo.ItemId,
                    CodigoSku = articulo.CodigoSku,
                    Articulo = articulo.Nombre,
                    PrecioUnitario = articulo.Precio,
                    Cantidad = cantidadSolicitada
                });
            }

            numCantidad.Value = 1;
            CalcularTotales();
        }

        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            if (dgvDetalles.CurrentRow?.DataBoundItem is VentaItemRow itemSeleccionado)
            {
                listaCarrito.Remove(itemSeleccionado);
                CalcularTotales();
            }
            else
            {
                MessageBox.Show("Seleccione el producto de la tabla que desea remover.", "Eliminar Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CalcularTotales()
        {
            montoTotalPagar = listaCarrito.Sum(item => item.Subtotal);

            // Desglose de ITBIS dominicano 18% incluido
            if (montoTotalPagar > 0)
            {
                montoSubtotal = Math.Round(montoTotalPagar / 1.18m, 2);
                montoItbis = montoTotalPagar - montoSubtotal;
                lblTotalPagar.Text = $"RD$ {montoTotalPagar:N2}";
            }
            else
            {
                montoSubtotal = 0m;
                montoItbis = 0m;
                montoTotalPagar = 0m;
                lblTotalPagar.Text = "-";
            }

            if (cbMetodoPago.SelectedItem is LookupItem metodoSeleccionado && metodoSeleccionado.Id > 1)
            {
                txtEfectivo.Text = montoTotalPagar > 0 ? montoTotalPagar.ToString("N2") : "0.00";
            }

            CalcularDevolucion();
        }

        private void txtEfectivo_TextChanged(object? sender, EventArgs e)
        {
            CalcularDevolucion();
        }

        private void CalcularDevolucion()
        {
            if (cbMetodoPago.SelectedItem is LookupItem metodo && metodo.Id > 1)
            {
                lblDevolucion.Text = "RD$ 0.00";
                lblDevolucion.ForeColor = Color.ForestGreen;
                return;
            }

            if (cbMetodoPago.SelectedItem is LookupItem metodoInvalido && metodoInvalido.Id == 0)
            {
                lblDevolucion.Text = "-";
                lblDevolucion.ForeColor = Color.Black;
                return;
            }

            string texto = txtEfectivo.Text.Replace("RD$", "").Trim();
            if (decimal.TryParse(texto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal efectivoRecibido) ||
                decimal.TryParse(texto, NumberStyles.Any, CultureInfo.CurrentCulture, out efectivoRecibido))
            {
                if (montoTotalPagar > 0)
                {
                    decimal cambio = efectivoRecibido - montoTotalPagar;

                    if (cambio >= 0)
                    {
                        lblDevolucion.Text = $"RD$ {cambio:N2}";
                        lblDevolucion.ForeColor = Color.ForestGreen;
                    }
                    else
                    {
                        lblDevolucion.Text = $"Faltan RD$ {Math.Abs(cambio):N2}";
                        lblDevolucion.ForeColor = Color.Red;
                    }
                }
                else
                {
                    lblDevolucion.Text = "-";
                    lblDevolucion.ForeColor = Color.Black;
                }
            }
            else
            {
                lblDevolucion.Text = "-";
                lblDevolucion.ForeColor = Color.Black;
            }
        }

        private void txtEfectivo_KeyPress(object? sender, KeyPressEventArgs e)
        {
            // Solo permitir dígitos, tecla retroceso y punto decimal
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // Solo permitir un único punto o coma decimal
            if ((e.KeyChar == '.' || e.KeyChar == ',') && (sender as TextBox)?.Text.IndexOfAny(['.', ',']) > -1)
            {
                e.Handled = true;
            }
        }

        private async void btnVender_Click(object? sender, EventArgs e)
        {
            if (listaCarrito.Count == 0)
            {
                MessageBox.Show("No hay artículos agregados en la factura para cobrar.", "Facturación Vacía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbClientes.SelectedItem is not ClienteView clienteSeleccionado || clienteSeleccionado.ClienteId == 0)
            {
                MessageBox.Show("Por favor seleccione un cliente titular válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbClientes.Focus();
                return;
            }

            if (cbMetodoPago.SelectedItem is not LookupItem metodoSeleccionado || metodoSeleccionado.Id == 0)
            {
                MessageBox.Show("Por favor seleccione un método de pago válido.", "Validación de Pago", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbMetodoPago.Focus();
                return;
            }

            int metodoPagoId = metodoSeleccionado.Id;
            bool esEfectivo = metodoPagoId == 1;

            decimal efectivo = 0m;
            if (esEfectivo)
            {
                string textoEfectivo = txtEfectivo.Text.Replace("RD$", "").Trim();
                if (!decimal.TryParse(textoEfectivo, NumberStyles.Any, CultureInfo.InvariantCulture, out efectivo) &&
                    !decimal.TryParse(textoEfectivo, NumberStyles.Any, CultureInfo.CurrentCulture, out efectivo))
                {
                    MessageBox.Show("Ingrese el monto en efectivo entregado por el cliente.", "Validación de Pago", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEfectivo.Focus();
                    return;
                }

                if (efectivo < montoTotalPagar)
                {
                    MessageBox.Show(
                        $"El monto en efectivo ingresado (RD$ {efectivo:N2}) es menor al Total a Pagar (RD$ {montoTotalPagar:N2}).",
                        "Efectivo Insuficiente",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    txtEfectivo.Focus();
                    return;
                }
            }
            else
            {
                efectivo = montoTotalPagar;
            }

            decimal devolucion = efectivo - montoTotalPagar;

            btnVender.Enabled = false;
            btnVender.Text = "Procesando Venta...";

            try
            {
                int clienteId = clienteSeleccionado.ClienteId;

                // Armar solicitud para la API de Ventas
                var payload = new VentaDto
                {
                    ClienteId = clienteId,
                    MetodoPagoId = metodoPagoId,
                    FechaVenta = DateTime.UtcNow,
                    Subtotal = montoSubtotal,
                    Itbis = montoItbis,
                    TotalVenta = montoTotalPagar,
                    Detalles = listaCarrito.Select(i => new DetalleVentaDto
                    {
                        ItemId = i.ItemId,
                        Cantidad = i.Cantidad,
                        PrecioUnitario = i.PrecioUnitario
                    }).ToList()
                };

                var response = await apiClient.PostAsync("api/ventas", payload);

                if (response.IsSuccessStatusCode)
                {
                    string infoDetallePago = esEfectivo
                        ? $"• Efectivo Recibido: RD$ {efectivo:N2}\n• Devolución / Cambio: RD$ {devolucion:N2}\n"
                        : $"• Método de Pago: {metodoSeleccionado.Nombre}\n• Monto Cobrado: RD$ {montoTotalPagar:N2}\n";

                    MessageBox.Show(
                        $"¡Venta registrada exitosamente!\n\n" +
                        $"• Cliente: {clienteSeleccionado.Nombre}\n" +
                        $"• Total Facturado: RD$ {montoTotalPagar:N2}\n" +
                        $"  (Subtotal: RD$ {montoSubtotal:N2} | ITBIS 18%: RD$ {montoItbis:N2})\n" +
                        infoDetallePago + "\n" +
                        $"El stock de los productos vendidos ha sido actualizado.",
                        "Cobro Exitoso - Venta Finalizada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LimpiarFormulario();
                    await RefrescarCatalogoAsync();
                }
                else
                {
                    var mensajeError = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"No se pudo registrar la venta: {mensajeError}", "Error de Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión con la API: {ex.Message}", "Error de Red", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnVender.Enabled = true;
                btnVender.Text = "Vender";
            }
        }

        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            if (listaCarrito.Count > 0)
            {
                var confirmacion = MessageBox.Show(
                    "¿Desea cancelar y limpiar los artículos agregados a esta venta?",
                    "Cancelar Facturación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    LimpiarFormulario();
                }
            }
            else
            {
                LimpiarFormulario();
            }
        }

        private void LimpiarFormulario()
        {
            listaCarrito.Clear();
            txtEfectivo.Clear();
            numCantidad.Value = 1;
            lblTotalPagar.Text = "-";
            lblDevolucion.Text = "-";
            lblDevolucion.ForeColor = Color.Black;

            if (cbClientes.Items.Count > 0)
                cbClientes.SelectedIndex = 0;

            if (cbArticulos.Items.Count > 0)
                cbArticulos.SelectedIndex = 0;

            if (cbMetodoPago.Items.Count > 0)
                cbMetodoPago.SelectedIndex = 0;

            lblEfectivo.Text = "EFECTIVO:";
            txtEfectivo.Enabled = false;

            montoSubtotal = 0m;
            montoItbis = 0m;
            montoTotalPagar = 0m;
        }

        private void btnCLose_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void cbMetodoPago_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbMetodoPago.SelectedItem is LookupItem metodo)
            {
                if (metodo.Id == 1) // 1 = Efectivo
                {
                    lblEfectivo.Text = "EFECTIVO:";
                    txtEfectivo.Enabled = true;
                    txtEfectivo.Clear();
                    lblDevolucion.Text = "-";
                    lblDevolucion.ForeColor = Color.Black;
                    txtEfectivo.Focus();
                }
                else if (metodo.Id > 1) // 2 = Tarjeta, 3 = Transferencia
                {
                    lblEfectivo.Text = "MONTO COBRADO:";
                    txtEfectivo.Text = montoTotalPagar > 0 ? montoTotalPagar.ToString("N2") : "0.00";
                    txtEfectivo.Enabled = false;
                    lblDevolucion.Text = "RD$ 0.00";
                    lblDevolucion.ForeColor = Color.ForestGreen;
                }
                else // 0 = ~ Seleccionar ~
                {
                    lblEfectivo.Text = "EFECTIVO:";
                    txtEfectivo.Text = string.Empty;
                    txtEfectivo.Enabled = false;
                    lblDevolucion.Text = "-";
                    lblDevolucion.ForeColor = Color.Black;
                }
            }
        }
    }
}
