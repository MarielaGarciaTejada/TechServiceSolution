using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace TechService.Infrastructure.Models;

public class Cliente
{
    public int ClienteId { get; set; }

    public string Nombre { get; set; } = null!;

    public string DocumentoIdentidad { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime? FechaRegistro { get; set; }

    [JsonIgnore]

    public virtual ICollection<OrdenesReparacion> OrdenesReparacions { get; set; } = new List<OrdenesReparacion>();

    [JsonIgnore]

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
