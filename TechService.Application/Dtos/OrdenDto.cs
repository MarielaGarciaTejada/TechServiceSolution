using System;

namespace TechService.Application.Dtos;

public class OrdenDto
{
    public int OrdenId { get; set; }
    public string CodigoTracking { get; set; } = string.Empty;
    public int ClienteId { get; set; }
    public string? ClienteNombre { get; set; }
    public string? ClienteTelefono { get; set; }
    public int? TecnicoId { get; set; }
    public string? TecnicoNombre { get; set; }
    public int TipoEquipoId { get; set; }
    public string TipoEquipoNombre { get; set; } = string.Empty;
    public int EstadoId { get; set; }
    public string EstadoNombre { get; set; } = string.Empty;
    public int PrioridadId { get; set; }
    public string PrioridadNombre { get; set; } = string.Empty;
    public string MarcaModelo { get; set; } = string.Empty;
    public string NumeroSerieImei { get; set; } = string.Empty;
    public string? PinDesbloqueo { get; set; }
    public bool IngresoEnciende { get; set; }
    public bool IngresoPantallaRota { get; set; }
    public bool IngresoMojado { get; set; }
    public bool IngresoDejaCargador { get; set; }
    public string FalloReportado { get; set; } = string.Empty;
    public DateTime? FechaIngreso { get; set; }
    public DateTime FechaEntregaEstimada { get; set; }
    
    // Checks técnicos de mesa (Android)
    public bool CheckRevisionPlaca { get; set; }
    public bool CheckCambioPieza { get; set; }
    public bool CheckPruebasEncendido { get; set; }

    public string? ObservacionTecnico { get; set; }
    public decimal CostoManoObra { get; set; }
    public bool PresupuestoAprobadoCliente { get; set; }
}
