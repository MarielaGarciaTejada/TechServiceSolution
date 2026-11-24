using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace TechService.Infrastructure.Models;

public partial class TiposItem
{
    public int TipoItemId { get; set; }

    public string Nombre { get; set; } = null!;

    [JsonIgnore]

    public virtual ICollection<CatalogoItem> CatalogoItems { get; set; } = new List<CatalogoItem>();
}
