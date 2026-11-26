namespace TechService.WinForms.Models;

public class UsuarioView
{
    public int UsuarioId { get; set; }
    public string NombreUsuario { get; set; } = string.Empty;
    public string Contrasena { get; set; } = string.Empty;
    public string NombreCompleto { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public int RolId { get; set; }
    public string RolNombre { get; set; } = string.Empty;
    public int? TecnicoId { get; set; }
    public string TecnicoNombre { get; set; } = "(null)";
    public bool Activo { get; set; } = true;
    public string ActivoTexto => Activo ? "Activo" : "Inactivo";
}
