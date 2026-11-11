using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace TechService.Infrastructure.Models;

public partial class CatalogoItem
{
    public int ItemId { get; set; }

    public string CodigoSku { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public int TipoItemId { get; set; }

    public int TipoEquipoId { get; set; }

    public decimal Precio { get; set; }

    public int Stock { get; set; }

    public int StockMinimoAlerta { get; set; }

    [JsonIgnore]
    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    [JsonIgnore]
    public virtual ICollection<OrdenRepuesto> OrdenRepuestos { get; set; } = new List<OrdenRepuesto>();

    public virtual TiposEquipo TipoEquipo { get; set; } = null!;

    public virtual TiposItem TipoItem { get; set; } = null!;
}
