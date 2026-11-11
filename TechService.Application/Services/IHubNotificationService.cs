namespace TechService.Application.Services;

public interface IHubNotificationService
{
    Task EnviarAlertaCajaAsync(string tipoAlerta, string mensaje);
    Task NotificarCambioEstadoAsync(string codigoTracking, string nuevoEstado, string modificadoPor = "Sistema");
    Task NotificarNuevaOrdenAsync(int ordenId, string codigoTracking, int tipoEquipoId, string marcaModelo);
    Task EnviarMensajeOrdenAsync(string codigoTracking, string autor, string mensaje, string origen);
}
