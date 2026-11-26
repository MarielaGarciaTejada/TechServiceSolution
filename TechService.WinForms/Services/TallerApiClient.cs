using System.Net.Http.Json;
using Microsoft.AspNetCore.SignalR.Client;
using TechService.Application.Dtos;

namespace TechService.WinForms.Services;

public class TallerApiClient
{
    // Ajusta el puerto al que utilice tu API en local o Azure
    private const string BaseUrl = "https://techserviceapi-g0a4h6daeghqg9fv.westus3-01.azurewebsites.net/";
    private const string HubUrl = "https://techservicehub-fgg2bjheghfmarhw.westus3-01.azurewebsites.net/hubs/reparacion";

    public HttpClient Http { get; }
    public HubConnection Hub { get; private set; }

    public event Action<AlertaCajaDto>? AlertaCajaRecibida;
    public event Action<CambioEstadoOrdenDto>? EstadoOrdenActualizado;

    public TallerApiClient()
    {
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
        };

        Http = new HttpClient(handler) { BaseAddress = new Uri(BaseUrl) };

        Hub = new HubConnectionBuilder()
            .WithUrl(HubUrl)
            .WithAutomaticReconnect()
            .Build();

        ConfigurarEventosHub();
    }

    private void ConfigurarEventosHub()
    {
        Hub.On<AlertaCajaDto>("RecibirAlertaCaja", alerta =>
        {
            AlertaCajaRecibida?.Invoke(alerta);
        });

        Hub.On<CambioEstadoOrdenDto>("OrdenEstadoActualizado", cambio =>
        {
            EstadoOrdenActualizado?.Invoke(cambio);
        });
    }

    public async Task IniciarConexionRealTimeAsync()
    {
        try
        {
            if (Hub.State == HubConnectionState.Disconnected)
            {
                await Hub.StartAsync();
                await Hub.InvokeAsync("UnirseASala", "SalaCaja");
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"[SignalR Error] {ex.Message}");
        }
    }

    public async Task<List<T>?> ObtenerListaAsync<T>(string endpoint) =>
        await Http.GetFromJsonAsync<List<T>>(endpoint);

    public async Task<HttpResponseMessage> PostAsync<T>(string endpoint, T data) =>
        await Http.PostAsJsonAsync(endpoint, data);

    public async Task<List<UsuarioDto>?> ObtenerUsuariosAsync() =>
        await Http.GetFromJsonAsync<List<UsuarioDto>>("api/usuarios");

    public async Task<List<RolDto>?> ObtenerRolesAsync() =>
        await Http.GetFromJsonAsync<List<RolDto>>("api/usuarios/roles");

    public async Task<HttpResponseMessage> GuardarUsuarioAsync(UsuarioDto dto) =>
        dto.UsuarioId == 0 
            ? await Http.PostAsJsonAsync("api/usuarios", dto)
            : await Http.PutAsJsonAsync($"api/usuarios/{dto.UsuarioId}", dto);

    public async Task<HttpResponseMessage> EliminarUsuarioAsync(int id) =>
        await Http.DeleteAsync($"api/usuarios/{id}");

    public async Task<LoginResponseDto?> IniciarSesionAsync(LoginRequestDto request)
    {
        var response = await Http.PostAsJsonAsync("api/usuarios/login", request);
        return await response.Content.ReadFromJsonAsync<LoginResponseDto>();
    }
}
