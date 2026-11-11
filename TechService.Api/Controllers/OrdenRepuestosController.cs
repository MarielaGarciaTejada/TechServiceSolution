using Microsoft.AspNetCore.Mvc;
using TechService.Infrastructure.Models;
using TechService.Application.Services;

namespace TechService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdenRepuestosController(
    OrdenRepuestosService repuestosService,
    IHubNotificationService hubNotification,
    ILogger<OrdenRepuestosController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrdenRepuesto>>> GetAll()
    {
        logger.LogInformation("Consultando repuestos de órdenes");
        var repuestos = await repuestosService.GetList();
        return Ok(repuestos);
    }

    [HttpGet("orden/{ordenId:int}")]
    public async Task<ActionResult<IEnumerable<OrdenRepuesto>>> GetByOrden(int ordenId)
    {
        var repuestos = await repuestosService.Listar(r => r.OrdenId == ordenId);
        return Ok(repuestos);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<OrdenRepuesto>> GetById(int id)
    {
        var result = await repuestosService.Buscar(id);
        var repuesto = result.Value;
        if (repuesto == null)
            return NotFound(new { mensaje = $"Registro de repuesto {id} no encontrado." });

        return Ok(repuesto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] OrdenRepuesto repuesto)
    {
        var guardado = await repuestosService.Guardar(repuesto);
        if (!guardado.IsSuccess)
            return BadRequest(new { mensaje = "No se pudo asignar el repuesto a la orden." });

        // Notificar en tiempo real a mostrador / cliente sobre la nueva pieza
        await hubNotification.EnviarAlertaCajaAsync("NuevoRepuestoAgregado", $"Nuevo repuesto asignado a la orden #{repuesto.OrdenId}");

        return CreatedAtAction(nameof(GetById), new { id = repuesto.OrdenRepuestoId }, repuesto);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] OrdenRepuesto repuesto)
    {
        if (id != repuesto.OrdenRepuestoId)
            return BadRequest(new { mensaje = "El ID no coincide." });

        if (!await repuestosService.Existe(id))
            return NotFound(new { mensaje = "Repuesto no encontrado." });

        var modificado = await repuestosService.Modificar(repuesto);
        if (!modificado)
            return BadRequest(new { mensaje = "No se pudo actualizar el repuesto." });

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminado = await repuestosService.Eliminar(id);
        if (!eliminado.IsSuccess)
            return NotFound(new { mensaje = "Repuesto no encontrado." });

        return NoContent();
    }
}
