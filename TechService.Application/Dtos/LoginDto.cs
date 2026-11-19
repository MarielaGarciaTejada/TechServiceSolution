namespace TechService.Application.Dtos;

public class LoginRequestDto
{
    public string NombreUsuario { get; set; } = string.Empty;
    public string Contrasena { get; set; } = string.Empty;
}

public class LoginResponseDto
{
    public bool Exito { get; set; }
    public string Mensaje { get; set; } = string.Empty;
    public UsuarioDto? Usuario { get; set; }
}
