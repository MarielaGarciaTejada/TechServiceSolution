using System;
using System.Text.Json.Serialization;

namespace TechService.Infrastructure.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public string NombreCompleto { get; set; } = null!;

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public int RolId { get; set; }

    public int? TecnicoId { get; set; }

    public bool Activo { get; set; } = true;

    public DateTime? FechaRegistro { get; set; }

    public virtual Rol? Rol { get; set; }

    public virtual Tecnico? Tecnico { get; set; }
}
