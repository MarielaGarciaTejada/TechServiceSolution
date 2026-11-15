using Microsoft.AspNetCore.Mvc;
using TechService.Application.Services;
using TechService.Application.Dtos;

namespace TechService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EntregasGarantiaController(
    EntregasGarantiaService entregasService,
    OrdenesReparacionService ordenesService,
    ILogger<EntregasGarantiaController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EntregaGarantiaDto>>> GetAll()
    {
        logger.LogInformation("Consultando lista de entregas");
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

        return CreatedAtAction(nameof(GetById), new { id = entrega.EntregaId }, entrega);
    }
}