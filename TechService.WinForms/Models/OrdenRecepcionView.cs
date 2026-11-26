namespace TechService.WinForms.Models;

public class OrdenRecepcionView
{
    public int OrdenId { get; set; }
    public string CodigoTracking { get; set; } = "";
    public int ClienteId { get; set; }
    public int? TecnicoId { get; set; }
    public int TipoEquipoId { get; set; }
    public int EstadoId { get; set; } = 1; // 1 = Recibido
    public int PrioridadId { get; set; } = 1; // 1 = Normal
    public string MarcaModelo { get; set; } = "";
    public string NumeroSerieImei { get; set; } = "";
    public string? PinDesbloqueo { get; set; }

    // Checklist físico de recepción en mostrador
    public bool IngresoEnciende { get; set; }
    public bool IngresoPantallaRota { get; set; }
    public bool IngresoMojado { get; set; }
    public bool IngresoDejaCargador { get; set; }

    public string FalloReportado { get; set; } = "";
    public DateTime? FechaIngreso { get; set; } = DateTime.UtcNow;
    public DateTime FechaEntregaEstimada { get; set; } = DateTime.UtcNow.AddDays(3);
    public string? ObservacionTecnico { get; set; }
    public decimal CostoManoObra { get; set; }
    public bool PresupuestoAprobadoCliente { get; set; } = true;
}
