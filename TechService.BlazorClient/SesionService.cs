using TechService.Application.Dtos;

namespace TechService.BlazorClient;

public class SesionService
{
    public UsuarioDto? UsuarioActual { get; private set; }
    public bool EstaAutenticado => UsuarioActual != null;

    public event Action? OnChange;

    public void IniciarSesion(UsuarioDto usuario)
    {
        UsuarioActual = usuario;
        OnChange?.Invoke();
    }

    public void CerrarSesion()
    {
        UsuarioActual = null;
        OnChange?.Invoke();
    }
}
