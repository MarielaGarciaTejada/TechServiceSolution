using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace TechService.Infrastructure.Models;

public partial class HistorialOrdenEvento
{
    public int EventoId { get; set; }

    public int OrdenId { get; set; }

    public string Origen { get; set; } = null!;

    public string Autor { get; set; } = null!;

    public string Mensaje { get; set; } = null!;

    public DateTime? FechaHora { get; set; }

    [JsonIgnore]

    public virtual OrdenesReparacion? Orden { get; set; }
}
