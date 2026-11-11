using System;

namespace TechService.Application.Dtos;

public class UsuarioDto
{
    public int UsuarioId { get; set; }
    public string NombreUsuario { get; set; } = string.Empty;
    public string? Contrasena { get; set; }
    public string NombreCompleto { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Telefono { get; set; }
    public int RolId { get; set; }
    public string RolNombre { get; set; } = string.Empty;
    public int? TecnicoId { get; set; }
    public string? TecnicoNombre { get; set; }
    public bool Activo { get; set; } = true;
    public DateTime? FechaRegistro { get; set; }
}
