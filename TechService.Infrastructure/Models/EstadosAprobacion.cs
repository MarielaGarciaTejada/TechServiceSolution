using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace TechService.Infrastructure.Models;

public partial class EstadosAprobacion
{
    public int EstadoAprobacionId { get; set; }

    public string Nombre { get; set; } = null!;

    [JsonIgnore]

    public virtual ICollection<OrdenRepuesto> OrdenRepuestos { get; set; } = new List<OrdenRepuesto>();
}
