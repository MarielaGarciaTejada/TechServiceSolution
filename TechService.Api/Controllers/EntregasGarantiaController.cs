using Microsoft.AspNetCore.Mvc;
using TechService.Application.Services;
using TechService.Application.Dtos;

namespace TechService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EntregasGarantiaController(
    EntregasGarantiaService entregasService,
    OrdenesReparacionService ordenesService,
    IHubNotificationService hubNotification,
    ILogger<EntregasGarantiaController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EntregaGarantiaDto>>> GetAll()
    {
        logger.LogInformation("Consultando lista de entregas y garantías");
        var lista = await entregasService.GetList();
        return Ok(lista);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<EntregaGarantiaDto>> GetById(int id)
    {
        var result = await entregasService.Buscar(id);
        var entrega = result.Value;

        if (entrega == null)
            return NotFound(new { mensaje = $"Entrega con ID {id} no encontrada." });

        return Ok(entrega);
    }

    [HttpGet("orden/{ordenId:int}")]
    public async Task<ActionResult<EntregaGarantiaDto>> GetByOrden(int ordenId)
    {
        var lista = await entregasService.Listar(e => e.OrdenId == ordenId);
        var entrega = lista.FirstOrDefault();
        if (entrega == null)
            return NotFound(new { mensaje = $"No existe registro de entrega para la orden {ordenId}." });

        return Ok(entrega);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] EntregaGarantiaDto entrega)
    {
        var resultOrden = await ordenesService.Buscar(entrega.OrdenId);
        var orden = resultOrden.Value;
        if (orden == null)
            return NotFound(new { mensaje = $"La orden {entrega.OrdenId} no existe." });

        var estadoEntregadoId = await entregasService.ObtenerEstadoId("Entregado");
        if (estadoEntregadoId == null)
            return BadRequest(new { mensaje = "No existe el estado 'Entregado' en la base de datos." });

        var guardado = await entregasService.Guardar(entrega);
        if (!guardado.IsSuccess)
            return BadRequest(new { mensaje = "No fue posible registrar la entrega." });

        orden.EstadoId = estadoEntregadoId.Value;
        var actualizada = await ordenesService.Modificar(orden);
        if (!actualizada)
            return BadRequest(new { mensaje = "La entrega se registró, pero no se pudo actualizar el estado de la orden." });

        await hubNotification.NotificarCambioEstadoAsync(orden.CodigoTracking, "Entregado");

        return CreatedAtAction(nameof(GetById), new { id = entrega.EntregaId }, entrega);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] EntregaGarantiaDto entrega)
    {
        if (id != entrega.EntregaId)
            return BadRequest(new { mensaje = "El ID de la ruta no coincide con el cuerpo." });

        if (!await entregasService.Existe(id))
            return NotFound(new { mensaje = $"La entrega {id} no existe." });

        var actualizado = await entregasService.Modificar(entrega);
        if (!actualizado)
            return BadRequest(new { mensaje = "No se pudo actualizar la entrega." });

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminado = await entregasService.Eliminar(id);
        if (!eliminado.IsSuccess)
            return NotFound(new { mensaje = $"La entrega {id} no fue encontrada o no se pudo eliminar." });

        return NoContent();
    }
}


