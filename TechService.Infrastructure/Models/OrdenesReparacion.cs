using System;
using System.Collections.Generic;

namespace TechService.Infrastructure.Models;

public partial class OrdenesReparacion
{
    public int OrdenId { get; set; }

    public string CodigoTracking { get; set; } = null!;

    public int ClienteId { get; set; }

    public int? TecnicoId { get; set; }

    public int TipoEquipoId { get; set; }

    public int EstadoId { get; set; }

    public int PrioridadId { get; set; }

    public string MarcaModelo { get; set; } = null!;

    public string NumeroSerieImei { get; set; } = null!;

    public string? PinDesbloqueo { get; set; }

    public bool IngresoEnciende { get; set; }

    public bool IngresoPantallaRota { get; set; }

    public bool IngresoMojado { get; set; }

    public bool IngresoDejaCargador { get; set; }

    public string FalloReportado { get; set; } = null!;

    public DateTime? FechaIngreso { get; set; }

    public DateTime FechaEntregaEstimada { get; set; }

    // Checks técnicos de mesa (Android)
    public bool CheckRevisionPlaca { get; set; }

    public bool CheckCambioPieza { get; set; }

    public bool CheckPruebasEncendido { get; set; }

    public string? ObservacionTecnico { get; set; }

    public decimal CostoManoObra { get; set; }

    public bool PresupuestoAprobadoCliente { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<EntregasGarantium> EntregasGarantia { get; set; } = new List<EntregasGarantium>();

    public virtual Estado? Estado { get; set; }

    public virtual ICollection<HistorialOrdenEvento> HistorialOrdenEventos { get; set; } = new List<HistorialOrdenEvento>();

    public virtual ICollection<OrdenRepuesto> OrdenRepuestos { get; set; } = new List<OrdenRepuesto>();

    public virtual Prioridade? Prioridad { get; set; }

    public virtual Tecnico? Tecnico { get; set; }

    public virtual TiposEquipo? TipoEquipo { get; set; }
}
