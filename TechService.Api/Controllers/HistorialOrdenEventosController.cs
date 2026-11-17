using Microsoft.AspNetCore.Mvc;
using TechService.Application.Services;
using TechService.Application.Dtos;

namespace TechService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HistorialOrdenEventosController(
    HistorialOrdenEventosService historialService, 
    IHubNotificationService hubNotification, 
    ILogger<HistorialOrdenEventosController> logger) : ControllerBase
{
    [HttpGet("orden/{ordenId:int}")]
    public async Task<ActionResult<IEnumerable<HistorialEventoDto>>> GetByOrden(int ordenId)
    {
        logger.LogInformation("Consultando historial de eventos de la orden {OrdenId}", ordenId);
        var eventos = await historialService.Listar(e => e.OrdenId == ordenId);
        return Ok(eventos);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] HistorialEventoDto nuevoEvento)
    {
        var guardado = await historialService.Guardar(nuevoEvento);
        if (!guardado.IsSuccess)
            return BadRequest(new { mensaje = "No se pudo registrar el evento en el historial." });

        // Emitir mensaje instantáneo a la sala de chat de la orden (para Blazor y Android)
        await hubNotification.EnviarMensajeOrdenAsync(nuevoEvento.OrdenId.ToString(), nuevoEvento.Autor, nuevoEvento.Mensaje, nuevoEvento.Origen);

        return Ok(nuevoEvento);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminado = await historialService.Eliminar(id);
        if (!eliminado.IsSuccess)
            return NotFound(new { mensaje = "Evento no encontrado." });

        return NoContent();
    }
}
