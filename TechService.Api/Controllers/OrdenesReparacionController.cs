using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechService.Infrastructure.Data;
using TechService.Infrastructure.Models;
using TechService.Application.Services;
using TechService.Application.Dtos;

namespace TechService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdenesReparacionController(
    OrdenesReparacionService ordenesService, 
    TechServiceDbContext dbContext,
    IHubNotificationService hubNotification, 
    ILogger<OrdenesReparacionController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrdenDto>>> GetAll()
    {
        logger.LogInformation("Consultando lista de órdenes de reparación");
        var lista = await ordenesService.GetList();
        return Ok(lista);
    }

    [HttpGet("tracking/{codigoTracking}")]
    public async Task<ActionResult<OrdenDto>> GetByTracking(string codigoTracking)
    {
        var lista = await ordenesService.Listar(o => o.CodigoTracking.ToLower() == codigoTracking.ToLower());
        var orden = lista.FirstOrDefault();
        if (orden == null)
            return NotFound(new { mensaje = $"Orden con código '{codigoTracking}' no encontrada." });

        return Ok(orden);
    }

    [HttpGet("tipos-equipo")]
    public async Task<ActionResult<IEnumerable<TiposEquipo>>> GetTiposEquipo()
    {
        var tipos = await dbContext.TiposEquipos.AsNoTracking().ToListAsync();
        return Ok(tipos);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<OrdenDto>> GetById(int id)
    {
        var result = await ordenesService.Buscar(id);
        var orden = result.Value;
        if (orden == null)
            return NotFound(new { mensaje = $"Orden {id} no encontrada." });

        return Ok(orden);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] OrdenDto orden)
    {
        var guardado = await ordenesService.Guardar(orden);
        if (!guardado.IsSuccess)
            return BadRequest(new { mensaje = "No fue posible registrar la orden de reparación." });

        // Notificar en vivo a los técnicos y a la caja por SignalR
        await hubNotification.NotificarNuevaOrdenAsync(orden.OrdenId, orden.CodigoTracking, orden.TipoEquipoId, orden.MarcaModelo);

        return CreatedAtAction(nameof(GetById), new { id = orden.OrdenId }, orden);
    }

    [HttpPut("{id:int}/estado")]
    public async Task<IActionResult> ActualizarEstado(int id, [FromBody] string nuevoEstado)
    {
        var result = await ordenesService.Buscar(id);
        var orden = result.Value;
        if (orden == null)
            return NotFound(new { mensaje = "Orden no encontrada." });

        // Resolver EstadoId si viene como texto o como número
        Estado? estadoEntidad = null;
        if (int.TryParse(nuevoEstado, out int estadoIdNumerico))
        {
            estadoEntidad = await dbContext.Estados.FindAsync(estadoIdNumerico);
        }
        else
        {
            estadoEntidad = await dbContext.Estados
                .FirstOrDefaultAsync(e => e.Nombre.ToLower() == nuevoEstado.ToLower());
        }

        if (estadoEntidad == null)
            return BadRequest(new { mensaje = $"El estado '{nuevoEstado}' no es válido." });

        orden.EstadoId = estadoEntidad.EstadoId;
        var actualizado = await ordenesService.Modificar(orden);
        if (!actualizado)
            return BadRequest(new { mensaje = "No se pudo actualizar el estado de la orden." });

        // Notificar al cliente y al taller
        await hubNotification.NotificarCambioEstadoAsync(orden.CodigoTracking, estadoEntidad.Nombre);

        return NoContent();
    }
}
