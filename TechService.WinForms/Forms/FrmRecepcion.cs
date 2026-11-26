using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechService.WinForms.Models;
using TechService.WinForms.Services;

namespace TechService.WinForms.Forms
{
    public partial class FrmRecepcion : Form
    {
        private readonly TallerApiClient apiClient = new();
        private List<ClienteView> listaClientes = new();
        private List<TipoEquipoView> listaTiposEquipo = new();
        private string? codigoTicketActual = null;

        private readonly Color ColorBotonHabilitado = Color.FromArgb(5, 8, 100);
        private readonly Color ColorBotonDeshabilitado = Color.FromArgb(180, 185, 200);
        private readonly Color ColorTextoDeshabilitado = Color.FromArgb(100, 105, 125);

        public FrmRecepcion()
        {
            InitializeComponent();
            ConfigurarEventos();
        }

        private void ConfigurarEventos()
        {
            this.Load += FrmRecepcion_Load;
            this.btnRegistrar.Click += btnRegistrar_Click;
            this.cbClientes.SelectedIndexChanged += (s, e) => ActualizarEstadoTicketYRegistro();
            this.cbTipoEquipo.SelectedIndexChanged += (s, e) => ActualizarEstadoTicketYRegistro();
        }

        private async void FrmRecepcion_Load(object? sender, EventArgs e)
        {
            PrepararValoresIniciales();
            await CargarDatosInicialesAsync();
            if (IsDisposed || Disposing) return;
            ActualizarEstadoTicketYRegistro();
        }

        private void PrepararValoresIniciales()
        {
            chkEnciende.Checked = false;
            chkPantallaRota.Checked = false;
            chkMojado.Checked = false;
            chkCargador.Checked = false;
            numManoObra.Value = 300.00m;

            ActualizarEstadoTicketYRegistro();
        }

        private void ActualizarEstadoTicketYRegistro()
        {
            bool clienteValido = cbClientes.SelectedItem is ClienteView c && c.ClienteId > 0;
            bool tipoValido = cbTipoEquipo.SelectedItem is TipoEquipoView t && t.TipoEquipoId > 0;

            if (clienteValido && tipoValido)
            {
                if (string.IsNullOrEmpty(codigoTicketActual))
                {
                    codigoTicketActual = GenerarCodigoTrackingSugerido();
                }

                lblTrackingGenerado.Text = $"Ticket Sugerido: {codigoTicketActual}";
                lblTrackingGenerado.Visible = true;

                btnRegistrar.Enabled = true;
                btnRegistrar.BackColor = ColorBotonHabilitado;
                btnRegistrar.ForeColor = Color.White;
                btnRegistrar.Cursor = Cursors.Hand;
            }
            else
            {
                codigoTicketActual = null;
                lblTrackingGenerado.Text = string.Empty;
                lblTrackingGenerado.Visible = false;

                btnRegistrar.Enabled = false;
                btnRegistrar.BackColor = ColorBotonDeshabilitado;
                btnRegistrar.ForeColor = ColorTextoDeshabilitado;
                btnRegistrar.Cursor = Cursors.Default;
            }
        }

        private async Task CargarDatosInicialesAsync()
        {
            // Cargar lista de Clientes desde la API
            try
            {
                var clientesApi = await apiClient.ObtenerListaAsync<ClienteView>("api/clientes");
                if (IsDisposed || Disposing) return;
                listaClientes = clientesApi ?? new();

                // Agregar opción inicial
                listaClientes.Insert(0, new ClienteView
                {
                    ClienteId = 0,
                    Nombre = "~ Seleccionar ~"
                });

                cbClientes.DataSource = null;
                cbClientes.DisplayMember = "Nombre";
                cbClientes.ValueMember = "ClienteId";
                cbClientes.DataSource = listaClientes;

                if (cbClientes.Items.Count > 0)
                {
                    cbClientes.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[Error cargando clientes]: {ex.Message}");
            }

            // 2. Cargar Tipos de Dispositivo desde la API (con respaldo local)
            try
            {
                var tiposApi = await apiClient.ObtenerListaAsync<TipoEquipoView>("api/ordenesreparacion/tipos-equipo");
                if (tiposApi != null && tiposApi.Count > 0)
                {
                    listaTiposEquipo = tiposApi;
                }
                else
                {
                    listaTiposEquipo = ObtenerTiposEquipoRespaldo();
                }
            }
            catch
            {
                listaTiposEquipo = ObtenerTiposEquipoRespaldo();
            }

            if (IsDisposed || Disposing) return;

            // Agregar opción inicial
            listaTiposEquipo.Insert(0, new TipoEquipoView
            {
                TipoEquipoId = 0,
                Nombre = "~ Seleccionar ~"
            });

            cbTipoEquipo.DataSource = null;
            cbTipoEquipo.DisplayMember = "Nombre";
            cbTipoEquipo.ValueMember = "TipoEquipoId";
            cbTipoEquipo.DataSource = listaTiposEquipo;

            if (cbTipoEquipo.Items.Count > 0)
            {
                cbTipoEquipo.SelectedIndex = 0;
            }
        }

        private List<TipoEquipoView> ObtenerTiposEquipoRespaldo() =>
        [
            new(1, "Celular"),
            new(2, "Laptop"),
            new(3, "Consola"),
            new(4, "Tablet"),
            new(5, "Universal")
        ];

        private async void btnRegistrar_Click(object? sender, EventArgs e)
        {
            // Validar cliente
            if (cbClientes.SelectedItem is not ClienteView clienteSeleccionado ||
                clienteSeleccionado.ClienteId == 0)
            {
                MessageBox.Show("Por favor seleccione un cliente titular válido.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActualizarEstadoTicketYRegistro();
                cbClientes.Focus();
                return;
            }

            // Validar tipo de dispositivo
            if (cbTipoEquipo.SelectedItem is not TipoEquipoView tipoSeleccionado ||
                tipoSeleccionado.TipoEquipoId == 0)
            {
                MessageBox.Show("Por favor seleccione un tipo de dispositivo.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActualizarEstadoTicketYRegistro();
                cbTipoEquipo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMarcaModelo.Text))
            {
                MessageBox.Show("Ingrese la marca y modelo del dispositivo (ej: Samsung Galaxy S21 o Dell Inspiron 15).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMarcaModelo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSerialImei.Text))
            {
                MessageBox.Show("Ingrese el número de serie o IMEI del dispositivo para su identificación física.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSerialImei.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFallo.Text))
            {
                MessageBox.Show("Describa el fallo o problema reportado por el cliente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFallo.Focus();
                return;
            }

            btnRegistrar.Enabled = false;
            btnRegistrar.Text = "Registrando en Sistema...";

            try
            {
                var codigoGenerado = codigoTicketActual ?? GenerarCodigoTrackingSugerido();

                var nuevaOrden = new OrdenRecepcionView
                {
                    CodigoTracking = codigoGenerado,
                    ClienteId = clienteSeleccionado.ClienteId,
                    TecnicoId = null, // Se asignará en taller
                    TipoEquipoId = tipoSeleccionado.TipoEquipoId,
                    EstadoId = 1, // 1 = Recibido
                    PrioridadId = 1, // 1 = Normal
                    MarcaModelo = txtMarcaModelo.Text.Trim(),
                    NumeroSerieImei = txtSerialImei.Text.Trim(),
                    PinDesbloqueo = string.IsNullOrWhiteSpace(txtPin.Text) ? null : txtPin.Text.Trim(),
                    IngresoEnciende = chkEnciende.Checked,
                    IngresoPantallaRota = chkPantallaRota.Checked,
                    IngresoMojado = chkMojado.Checked,
                    IngresoDejaCargador = chkCargador.Checked,
                    FalloReportado = txtFallo.Text.Trim(),
                    FechaIngreso = DateTime.UtcNow,
                    FechaEntregaEstimada = DateTime.UtcNow.AddDays(3),
                    CostoManoObra = numManoObra.Value,
                    PresupuestoAprobadoCliente = true
                };

                // Enviar petición a la API
                var response = await apiClient.PostAsync("api/ordenesreparacion", nuevaOrden);

                if (response.IsSuccessStatusCode)
                {
                    lblTrackingGenerado.Text = $"Ticket Emitido: {codigoGenerado}";
                    lblTrackingGenerado.Visible = true;

                    MessageBox.Show(
                        $"¡Orden de recepción registrada exitosamente!\n\n" +
                        $"• Ticket / Tracking: {codigoGenerado}\n" +
                        $"• Cliente: {clienteSeleccionado.Nombre}\n" +
                        $"• Dispositivo: {nuevaOrden.MarcaModelo}\n" +
                        $"• Mano de Obra Estimada: RD$ {nuevaOrden.CostoManoObra:N2}\n\n" +
                        $"El cliente puede seguir el avance de su reparación en tiempo real desde el portal web con este código de tracking.",
                        "Recepción Exitosa - Ticket Generado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LimpiarFormulario();
                }
                else
                {
                    var mensajeError = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"No fue posible registrar la orden: {mensajeError}", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de comunicación con el servidor: {ex.Message}", "Error de Red", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnRegistrar.Text = "Registrar Orden y Emitir Ticket";
                ActualizarEstadoTicketYRegistro();
            }
        }

        private void LimpiarFormulario()
        {
            txtMarcaModelo.Clear();
            txtSerialImei.Clear();
            txtPin.Clear();
            txtFallo.Clear();
            chkEnciende.Checked = false;
            chkPantallaRota.Checked = false;
            chkMojado.Checked = false;
            chkCargador.Checked = false;
            numManoObra.Value = 300.00m;

            if (cbClientes.Items.Count > 0)
                cbClientes.SelectedIndex = 0;

            if (cbTipoEquipo.Items.Count > 0)
                cbTipoEquipo.SelectedIndex = 0;

            codigoTicketActual = null;
            ActualizarEstadoTicketYRegistro();
            txtMarcaModelo.Focus();
        }

        private string GenerarCodigoTrackingSugerido()
        {
            var anio = DateTime.Now.Year;
            var random = new Random().Next(1000, 9999);
            return $"TS-{anio}-{random}";
        }

        private void btnCLose_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
