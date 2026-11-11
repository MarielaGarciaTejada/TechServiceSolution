using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace TechService.Infrastructure.Models;

public partial class MetodosPago
{
    public int MetodoPagoId { get; set; }

    public string Nombre { get; set; } = null!;

    [JsonIgnore]

    public virtual ICollection<EntregasGarantium> EntregasGarantia { get; set; } = new List<EntregasGarantium>();

    [JsonIgnore]

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
