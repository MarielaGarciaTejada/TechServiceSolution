using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace TechService.Infrastructure.Models;

public partial class OrdenRepuesto
{
    public int OrdenRepuestoId { get; set; }

    public int OrdenId { get; set; }

    public int ItemId { get; set; }

    public int EstadoAprobacionId { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public virtual EstadosAprobacion? EstadoAprobacion { get; set; }

    public virtual CatalogoItem? Item { get; set; }

    [JsonIgnore]

    public virtual OrdenesReparacion? Orden { get; set; }
}
