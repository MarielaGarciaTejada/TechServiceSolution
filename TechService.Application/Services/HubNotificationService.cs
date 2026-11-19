using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TechService.Application.Dtos;

namespace TechService.Application.Services;

public class HubNotificationService(HttpClient http, IConfiguration config, ILogger<HubNotificationService> logger) : IHubNotificationService
{
    private string HubBaseUrl => (config["HubBaseUrl"] ?? "https://techservicehub-fgg2bjheghfmarhw.westus3-01.azurewebsites.net/").TrimEnd('/') + "/";

    public async Task EnviarAlertaCajaAsync(string tipoAlerta, string mensaje)
    {
        try
        {
            var alerta = new AlertaCajaDto(tipoAlerta, mensaje, DateTime.UtcNow);
            await http.PostAsJsonAsync($"{HubBaseUrl}api/notificaciones/alerta-caja", alerta);
        }
        catch (Exception ex)
        {
            logger.LogWarning("No se pudo enviar alerta a TechService.Hub: {Message}", ex.Message);
        }
    }

    public async Task NotificarCambioEstadoAsync(string codigoTracking, string nuevoEstado, string modificadoPor = "Sistema")
    {
        try
        {
            var cambio = new CambioEstadoOrdenDto(codigoTracking, nuevoEstado, modificadoPor, DateTime.UtcNow);
            await http.PostAsJsonAsync($"{HubBaseUrl}api/notificaciones/cambio-estado", cambio);
        }
        catch (Exception ex)
        {
            logger.LogWarning("No se pudo notificar cambio de estado a TechService.Hub: {Message}", ex.Message);
        }
    }

    public async Task NotificarNuevaOrdenAsync(int ordenId, string codigoTracking, int tipoEquipoId, string marcaModelo)
    {
        try
        {
            var orden = new NuevaOrdenDto(ordenId, codigoTracking, tipoEquipoId, marcaModelo, DateTime.UtcNow);
            await http.PostAsJsonAsync($"{HubBaseUrl}api/notificaciones/nueva-orden", orden);
        }
        catch (Exception ex)
        {
            logger.LogWarning("No se pudo notificar nueva orden a TechService.Hub: {Message}", ex.Message);
        }
    }

    public async Task EnviarMensajeOrdenAsync(string codigoTracking, string autor, string mensaje, string origen)
    {
        try
        {
            var chat = new MensajeChatDto(codigoTracking, autor, mensaje, origen, DateTime.UtcNow);
            await http.PostAsJsonAsync($"{HubBaseUrl}api/notificaciones/mensaje-chat", chat);
        }
        catch (Exception ex)
        {
            logger.LogWarning("No se pudo enviar mensaje de orden a TechService.Hub: {Message}", ex.Message);
        }
    }
}
