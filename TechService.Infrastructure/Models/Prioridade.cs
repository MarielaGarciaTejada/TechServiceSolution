using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace TechService.Infrastructure.Models;

public partial class Prioridade
{
    public int PrioridadId { get; set; }

    public string Nombre { get; set; } = null!;

    [JsonIgnore]

    public virtual ICollection<OrdenesReparacion> OrdenesReparacions { get; set; } = new List<OrdenesReparacion>();
}
