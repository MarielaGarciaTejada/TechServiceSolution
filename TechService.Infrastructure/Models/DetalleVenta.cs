using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace TechService.Infrastructure.Models;

public partial class DetalleVenta
{
    public int DetalleVentaId { get; set; }

    public int VentaId { get; set; }

    public int ItemId { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public virtual CatalogoItem? Item { get; set; }

    [JsonIgnore]

    public virtual Venta? Venta { get; set; }
}
