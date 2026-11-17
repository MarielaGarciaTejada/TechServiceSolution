using Microsoft.EntityFrameworkCore;
using TechService.Infrastructure.Models;

namespace TechService.Infrastructure.Data;

/// <summary>
/// Inserta catálogos y datos de prueba si las tablas están vacías.
/// Se ejecuta automáticamente al iniciar la aplicación.
/// </summary>
public static class DataSeeder
{
    public static async Task SeedAsync(TechServiceDbContext db)
    {
        // ── CATÁLOGOS BASE ───────────────────────────────────────────────
        if (!await db.Estados.AnyAsync())
        {
            db.Estados.AddRange(
                new() { Nombre = "Recibido" },
                new() { Nombre = "RevisionPlaca" },
                new() { Nombre = "EsperandoAprobacion" },
                new() { Nombre = "CambioPieza" },
                new() { Nombre = "PruebasEncendido" },
                new() { Nombre = "Reparado" },
                new() { Nombre = "Entregado" }
            );
            await db.SaveChangesAsync();
        }

        if (!await db.Prioridades.AnyAsync())
        {
            db.Prioridades.AddRange(
                new() { Nombre = "Normal" },
                new() { Nombre = "Express24h" },
                new() { Nombre = "Garantia" }
            );
            await db.SaveChangesAsync();
        }

        if (!await db.TiposEquipos.AnyAsync())
        {
            db.TiposEquipos.AddRange(
                new() { Nombre = "Celular" },
                new() { Nombre = "Laptop" },
                new() { Nombre = "Consola" },
                new() { Nombre = "Tablet" },
                new() { Nombre = "Universal" }
            );
            await db.SaveChangesAsync();
        }

        if (!await db.MetodosPagos.AnyAsync())
        {
            db.MetodosPagos.AddRange(
                new() { Nombre = "Efectivo" },
                new() { Nombre = "Tarjeta" },
                new() { Nombre = "Transferencia" }
            );
            await db.SaveChangesAsync();
        }

        if (!await db.EstadosAprobacions.AnyAsync())
        {
            db.EstadosAprobacions.AddRange(
                new() { Nombre = "PendienteCliente" },
                new() { Nombre = "Aprobado" },
                new() { Nombre = "Rechazado" }
            );
            await db.SaveChangesAsync();
        }

        if (!await db.TiposItems.AnyAsync())
        {
            db.TiposItems.AddRange(
                new() { Nombre = "AccesorioPOS" },
                new() { Nombre = "RepuestoInterno" },
                new() { Nombre = "TarifaServicio" }
            );
            await db.SaveChangesAsync();
        }

        // Catálogo de Roles
        if (!await db.Roles.AnyAsync())
        {
            db.Roles.AddRange(
                new() { Nombre = "Admin", Descripcion = "Acceso total al sistema, gestión de usuarios, roles y reportes" },
                new() { Nombre = "Vendedor", Descripcion = "Recepción de equipos en ventanilla, entrega de garantías y facturación POS" },
                new() { Nombre = "Tecnico", Descripcion = "Acceso a la App Android para diagnóstico en mesa y cambio de estados" }
            );
            await db.SaveChangesAsync();
        }

        // ── TÉCNICOS ─────────────────────────────────────────────────────
        if (!await db.Tecnicos.AnyAsync())
        {
            var tecnicos = new List<Tecnico>
            {
                new() { Nombre = "Carlos Mendoza", Especialidad = "Celulares y Microsoldadura", PorcentajeComision = 25, Activo = true },
                new() { Nombre = "Laura Ramirez",  Especialidad = "Laptops y Consolas",         PorcentajeComision = 20, Activo = true },
                new() { Nombre = "Jorge Pereira",  Especialidad = "Consolas",                   PorcentajeComision = 15, Activo = true },
            };
            db.Tecnicos.AddRange(tecnicos);
            await db.SaveChangesAsync();
        }

        // ── USUARIOS (LOGIN WINFORMS Y ANDROID) ──────────────────────────
        if (!await db.Usuarios.AnyAsync())
        {
            var rolAdmin = await db.Roles.FirstAsync(r => r.Nombre == "Admin");
            var rolVendedor = await db.Roles.FirstAsync(r => r.Nombre == "Vendedor");
            var rolTecnico = await db.Roles.FirstAsync(r => r.Nombre == "Tecnico");

            var primerTecnico = await db.Tecnicos.FirstOrDefaultAsync(t => t.Nombre == "Carlos Mendoza");

            db.Usuarios.AddRange(
                new()
                {
                    NombreUsuario = "admin",
                    Contrasena = "admin123",
                    NombreCompleto = "Mariela García",
                    Email = "admin@techservice.com",
                    Telefono = "809-555-0100",
                    RolId = rolAdmin.RolId,
                    TecnicoId = null,
                    Activo = true
                },
                new()
                {
                    NombreUsuario = "vendedor1",
                    Contrasena = "ventas123",
                    NombreCompleto = "Laura Gómez",
                    Email = "caja@techservice.com",
                    Telefono = "809-555-0101",
                    RolId = rolVendedor.RolId,
                    TecnicoId = null,
                    Activo = true
                },
                new()
                {
                    NombreUsuario = "tecnico1",
                    Contrasena = "taller123",
                    NombreCompleto = "Carlos Mendoza",
                    Email = "carlos@techservice.com",
                    Telefono = "809-555-0102",
                    RolId = rolTecnico.RolId,
                    TecnicoId = primerTecnico?.TecnicoId,
                    Activo = true
                }
            );
            await db.SaveChangesAsync();
        }

        // Si ya hay clientes registrados, no resembrar datos operativos
        if (await db.Clientes.AnyAsync()) return;

        // Cargar referencias de catálogos para asociar IDs correctos
        var estadoRecibido = await db.Estados.FirstAsync(e => e.Nombre == "Recibido");
        var estadoRevision = await db.Estados.FirstAsync(e => e.Nombre == "RevisionPlaca");
        var estadoReparado = await db.Estados.FirstAsync(e => e.Nombre == "Reparado");

        var prioridadNormal = await db.Prioridades.FirstAsync(p => p.Nombre == "Normal");
        var prioridadExpress = await db.Prioridades.FirstAsync(p => p.Nombre == "Express24h");

        var tipoCelular = await db.TiposEquipos.FirstAsync(t => t.Nombre == "Celular");
        var tipoLaptop = await db.TiposEquipos.FirstAsync(t => t.Nombre == "Laptop");
        var tipoUniversal = await db.TiposEquipos.FirstAsync(t => t.Nombre == "Universal");

        var tipoAccesorio = await db.TiposItems.FirstAsync(t => t.Nombre == "AccesorioPOS");
        var tipoRepuesto = await db.TiposItems.FirstAsync(t => t.Nombre == "RepuestoInterno");
        var tipoServicio = await db.TiposItems.FirstAsync(t => t.Nombre == "TarifaServicio");

        var estadoAprobado = await db.EstadosAprobacions.FirstAsync(e => e.Nombre == "Aprobado");
        var metodoEfectivo = await db.MetodosPagos.FirstAsync(m => m.Nombre == "Efectivo");

        var listaTecnicos = await db.Tecnicos.ToListAsync();

        // ── CLIENTES ──────────────────────────────────────────────────────
        var clientes = new List<Cliente>
        {
            new() { Nombre = "Maria Lopez",   DocumentoIdentidad = "001-1234567-8", Telefono = "809-555-0101", Email = "maria.lopez@email.com" },
            new() { Nombre = "Pedro Garcia",  DocumentoIdentidad = "002-9876543-1", Telefono = "809-555-0202", Email = "pedro.garcia@email.com" },
            new() { Nombre = "Ana Fernandez", DocumentoIdentidad = "003-1111222-3", Telefono = "849-555-0303", Email = "ana.fernandez@email.com" },
        };
        db.Clientes.AddRange(clientes);
        await db.SaveChangesAsync();

        // ── CATÁLOGO DE ITEMS (Precios en RD$) ────────────────────────────
        var items = new List<CatalogoItem>
        {
            new() { CodigoSku = "ACC-CARG-65W", Nombre = "Cargador Rápido USB-C 65W GaN",        TipoItemId = tipoAccesorio.TipoItemId, TipoEquipoId = tipoUniversal.TipoEquipoId, Precio = 1850.00m, Stock = 15, StockMinimoAlerta = 3 },
            new() { CodigoSku = "ACC-MICA-IP15", Nombre = "Mica de Vidrio Privacidad iPhone 15", TipoItemId = tipoAccesorio.TipoItemId, TipoEquipoId = tipoCelular.TipoEquipoId,   Precio = 450.00m,  Stock = 2,  StockMinimoAlerta = 5 },
            new() { CodigoSku = "REP-BAT-IP13",  Nombre = "Batería Original iPhone 13",          TipoItemId = tipoRepuesto.TipoItemId,  TipoEquipoId = tipoCelular.TipoEquipoId,   Precio = 3200.00m, Stock = 8,  StockMinimoAlerta = 2 },
            new() { CodigoSku = "REP-HDMI-PS5",  Nombre = "Puerto HDMI OEM PlayStation 5",       TipoItemId = tipoRepuesto.TipoItemId,  TipoEquipoId = tipoUniversal.TipoEquipoId, Precio = 2500.00m, Stock = 10, StockMinimoAlerta = 2 },
            new() { CodigoSku = "SRV-MAN-LAPTOP", Nombre = "Mantenimiento Térmico y Pasta",       TipoItemId = tipoServicio.TipoItemId,  TipoEquipoId = tipoLaptop.TipoEquipoId,    Precio = 1500.00m, Stock = 99, StockMinimoAlerta = 1 },
            new() { CodigoSku = "SRV-MICROSOLD",  Nombre = "Diagnóstico y Reballing de Placa",   TipoItemId = tipoServicio.TipoItemId,  TipoEquipoId = tipoUniversal.TipoEquipoId, Precio = 4500.00m, Stock = 99, StockMinimoAlerta = 1 },
        };
        db.CatalogoItems.AddRange(items);
        await db.SaveChangesAsync();

        // ── ÓRDENES DE REPARACIÓN ─────────────────────────────────────────
        var ordenes = new List<OrdenesReparacion>
        {
            new()
            {
                CodigoTracking        = "TS-2026-0001",
                ClienteId             = clientes[0].ClienteId,
                TecnicoId             = listaTecnicos[0].TecnicoId,
                TipoEquipoId          = tipoCelular.TipoEquipoId,
                EstadoId              = estadoRevision.EstadoId,
                PrioridadId           = prioridadExpress.PrioridadId,
                MarcaModelo           = "iPhone 13 Pro",
                NumeroSerieImei       = "354678901234567",
                PinDesbloqueo         = "1234",
                IngresoEnciende       = true,
                IngresoPantallaRota   = false,
                IngresoMojado         = false,
                IngresoDejaCargador   = true,
                FalloReportado        = "No carga la batería, dura menos de 1 hora.",
                FechaIngreso          = DateTime.UtcNow.AddDays(-3),
                FechaEntregaEstimada  = DateTime.UtcNow.AddDays(2),
                CheckRevisionPlaca    = true,
                CheckCambioPieza      = false,
                CheckPruebasEncendido = false,
                ObservacionTecnico    = "Batería degradada al 61%. Se recomienda cambio.",
                CostoManoObra         = 1200.00m,
                PresupuestoAprobadoCliente = true,
            },
            new()
            {
                CodigoTracking        = "TS-2026-0002",
                ClienteId             = clientes[1].ClienteId,
                TecnicoId             = listaTecnicos[1].TecnicoId,
                TipoEquipoId          = tipoLaptop.TipoEquipoId,
                EstadoId              = estadoRecibido.EstadoId,
                PrioridadId           = prioridadNormal.PrioridadId,
                MarcaModelo           = "Dell Inspiron 15",
                NumeroSerieImei       = "DLLXYZ9988776",
                IngresoEnciende       = false,
                IngresoPantallaRota   = false,
                IngresoMojado         = false,
                IngresoDejaCargador   = false,
                FalloReportado        = "No enciende, posible fallo de memoria o placa.",
                FechaIngreso          = DateTime.UtcNow.AddDays(-1),
                FechaEntregaEstimada  = DateTime.UtcNow.AddDays(5),
                CostoManoObra         = 1500.00m,
                PresupuestoAprobadoCliente = false,
            },
            new()
            {
                CodigoTracking        = "TS-2026-0003",
                ClienteId             = clientes[2].ClienteId,
                TipoEquipoId          = tipoCelular.TipoEquipoId,
                EstadoId              = estadoReparado.EstadoId,
                PrioridadId           = prioridadNormal.PrioridadId,
                MarcaModelo           = "Samsung Galaxy S21",
                NumeroSerieImei       = "352099001234568",
                IngresoEnciende       = true,
                IngresoPantallaRota   = true,
                IngresoMojado         = false,
                IngresoDejaCargador   = false,
                FalloReportado        = "Pantalla rota, táctil responde pero no da imagen.",
                FechaIngreso          = DateTime.UtcNow.AddDays(-7),
                FechaEntregaEstimada  = DateTime.UtcNow.AddDays(-1),
                CheckRevisionPlaca    = true,
                CheckCambioPieza      = true,
                CheckPruebasEncendido = true,
                ObservacionTecnico    = "Pantalla reemplazada exitosamente. Pruebas superadas.",
                CostoManoObra         = 1000.00m,
                PresupuestoAprobadoCliente = true,
            },
        };
        db.OrdenesReparacions.AddRange(ordenes);
        await db.SaveChangesAsync();

        // ── HISTORIAL DE EVENTOS (SIGNALR / TRAZABILIDAD) ─────────────────
        var eventos = new List<HistorialOrdenEvento>
        {
            new() { OrdenId = ordenes[0].OrdenId, Origen = "Sistema",        Autor = "Sistema",        Mensaje = "Orden creada con estado Recibido.",           FechaHora = DateTime.UtcNow.AddDays(-3) },
            new() { OrdenId = ordenes[0].OrdenId, Origen = "TecnicoAndroid", Autor = "Carlos Mendoza", Mensaje = "Inicio de diagnóstico. Batería degradada.", FechaHora = DateTime.UtcNow.AddDays(-2) },
            new() { OrdenId = ordenes[0].OrdenId, Origen = "TecnicoAndroid", Autor = "Carlos Mendoza", Mensaje = "Cambio a estado En Revisión de Placa.",    FechaHora = DateTime.UtcNow.AddDays(-1) },
            new() { OrdenId = ordenes[1].OrdenId, Origen = "CajaWinForms",   Autor = "Laura Gómez",    Mensaje = "Orden ingresada en ventanilla.",              FechaHora = DateTime.UtcNow.AddDays(-1) },
            new() { OrdenId = ordenes[2].OrdenId, Origen = "Sistema",        Autor = "Sistema",        Mensaje = "Orden creada con estado Recibido.",           FechaHora = DateTime.UtcNow.AddDays(-7) },
            new() { OrdenId = ordenes[2].OrdenId, Origen = "TecnicoAndroid", Autor = "Laura Ramirez",  Mensaje = "Pantalla reemplazada. Pruebas OK.",         FechaHora = DateTime.UtcNow.AddDays(-2) },
            new() { OrdenId = ordenes[2].OrdenId, Origen = "Sistema",        Autor = "Sistema",        Mensaje = "Estado actualizado a Reparado.",             FechaHora = DateTime.UtcNow.AddDays(-1) },
        };
        db.HistorialOrdenEventos.AddRange(eventos);
        await db.SaveChangesAsync();

        // ── REPUESTOS CONSUMIDOS POR ORDEN ─────────────────────────────────
        var repuestos = new List<OrdenRepuesto>
        {
            new() { OrdenId = ordenes[0].OrdenId, ItemId = items[2].ItemId, Cantidad = 1, PrecioUnitario = items[2].Precio, EstadoAprobacionId = estadoAprobado.EstadoAprobacionId },
        };
        db.OrdenRepuestos.AddRange(repuestos);
        await db.SaveChangesAsync();

        // ── VENTAS DE MOSTRADOR POS ───────────────────────────────────────
        var venta = new Venta
        {
            ClienteId    = clientes[0].ClienteId,
            MetodoPagoId = metodoEfectivo.MetodoPagoId,
            FechaVenta   = DateTime.UtcNow,
            Subtotal     = 1850.00m,
            Itbis        = 333.00m,
            TotalVenta   = 2183.00m,
        };
        db.Ventas.Add(venta);
        await db.SaveChangesAsync();

        var detalles = new List<DetalleVenta>
        {
            new() { VentaId = venta.VentaId, ItemId = items[0].ItemId, Cantidad = 1, PrecioUnitario = items[0].Precio },
        };
        db.DetalleVentas.AddRange(detalles);
        await db.SaveChangesAsync();
    }
}
