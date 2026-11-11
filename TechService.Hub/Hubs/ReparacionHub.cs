using Microsoft.AspNetCore.SignalR;
using TechService.Application.Dtos;

namespace TechService.Hub.Hubs;

public class ReparacionHub : Microsoft.AspNetCore.SignalR.Hub
{
    // ==========================================
    // 1. GESTIÓN DE SALAS Y GRUPOS
    // ==========================================

    // Unirse a la sala de una orden específica (Blazor Cliente / Android Técnico)
    public async Task UnirseAOrden(string codigoTracking)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, $"Orden-{codigoTracking}");
    }

    // Salir de la sala de la orden
    public async Task SalirDeOrden(string codigoTracking)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"Orden-{codigoTracking}");
    }

    // Unirse a las salas generales de taller o caja
    public async Task UnirseASala(string nombreSala)
    {
        // Ejemplos: "SalaTecnicos", "SalaCaja"
        await Groups.AddToGroupAsync(Context.ConnectionId, nombreSala);
    }

    public async Task SalirDeSala(string nombreSala)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, nombreSala);
    }

    // ==========================================
    // 2. EMISIÓN DE EVENTOS Y MENSAJERÍA
    // ==========================================

    // Mensaje de chat entre cliente y técnico
    public async Task EnviarMensajeOrden(string codigoTracking, string autor, string mensaje, string origen)
    {
        var chatDto = new MensajeChatDto(codigoTracking, autor, mensaje, origen, DateTime.UtcNow);

        // Emite únicamente a quienes estén en la sala de esta orden
        await Clients.Group($"Orden-{codigoTracking}").SendAsync("RecibirMensajeOrden", chatDto);
    }

    // Notificación de avance de etapa técnica (ej. de 'RevisionPlaca' a 'CambioPieza')
    public async Task NotificarCambioEstado(string codigoTracking, string nuevoEstado, string modificadoPor)
    {
        var cambioDto = new CambioEstadoOrdenDto(codigoTracking, nuevoEstado, modificadoPor, DateTime.UtcNow);

        // Notifica al cliente en su sala y a la pantalla de recepción en caja
        await Clients.Group($"Orden-{codigoTracking}").SendAsync("OrdenEstadoActualizado", cambioDto);
        await Clients.Group("SalaCaja").SendAsync("OrdenEstadoActualizado", cambioDto);
    }

    // Notificación directa a la caja de Windows Forms (alertas de cobro o stock bajo)
    public async Task EnviarAlertaCaja(string tipoAlerta, string mensaje)
    {
        var alertaDto = new AlertaCajaDto(tipoAlerta, mensaje, DateTime.UtcNow);
        await Clients.Group("SalaCaja").SendAsync("RecibirAlertaCaja", alertaDto);
    }
}
