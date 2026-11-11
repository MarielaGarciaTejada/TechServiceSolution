using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace TechService.Infrastructure.Models;

public partial class EntregasGarantium
{
    public int EntregaId { get; set; }

    public int OrdenId { get; set; }

    public int MetodoPagoId { get; set; }

    public DateTime? FechaEntrega { get; set; }

    public int DiaGarantia { get; set; }

    public DateTime? FechaVencimientoGarantia { get; set; }

    public decimal TotalManoObra { get; set; }

    public decimal TotalRepuesto { get; set; }

    public decimal TotalCobrado { get; set; }

    public string ObservacionFinal { get; set; } = null!;

    public virtual MetodosPago? MetodoPago { get; set; }

    [JsonIgnore]

    public virtual OrdenesReparacion? Orden { get; set; }
}
