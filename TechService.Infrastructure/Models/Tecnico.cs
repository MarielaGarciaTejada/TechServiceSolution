using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace TechService.Infrastructure.Models;

public partial class Tecnico
{
    public int TecnicoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Especialidad { get; set; } = null!;

    public decimal PorcentajeComision { get; set; }

    public bool Activo { get; set; }

    [JsonIgnore]
    public virtual ICollection<OrdenesReparacion> OrdenesReparacions { get; set; } = new List<OrdenesReparacion>();

    [JsonIgnore]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
