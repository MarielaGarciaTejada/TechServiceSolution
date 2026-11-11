using Microsoft.AspNetCore.Mvc;
using TechService.Infrastructure.Models;
using TechService.Application.Services;
using TechService.Application.Dtos;

namespace TechService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CatalogoController(CatalogoService catalogoService, ILogger<CatalogoController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CatalogoItemDto>>> GetAll()
    {
        var items = await catalogoService.GetList();
        return Ok(items);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CatalogoItemDto>> GetById(int id)
    {
        var result = await catalogoService.Buscar(id);
        if (result.Value == null)
            return NotFound(new { mensaje = $"Artículo con ID {id} no encontrado." });

        return Ok(result.Value);
    }

    [HttpGet("stock-bajo")]
    public async Task<ActionResult<IEnumerable<CatalogoItemDto>>> GetStockBajo()
    {
        logger.LogWarning("Consultando artículos con alerta de stock bajo");
        var bajoStock = await catalogoService.ListarStockBajo();
        return Ok(bajoStock);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CatalogoItemDto item)
    {
        var guardado = await catalogoService.Guardar(item);
        if (!guardado.IsSuccess)
            return BadRequest(new { mensaje = "No se pudo registrar el artículo en el catálogo." });

        return CreatedAtAction(nameof(GetById), new { id = item.ItemId }, item);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] CatalogoItemDto item)
    {
        if (id != item.ItemId)
            return BadRequest(new { mensaje = "Discrepancia en el identificador." });

        if (!await catalogoService.Existe(id))
            return NotFound(new { mensaje = "El artículo no existe." });

        var modificado = await catalogoService.Modificar(item);
        if (!modificado)
            return BadRequest(new { mensaje = "No se pudo modificar el artículo." });

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminado = await catalogoService.Eliminar(id);
        if (!eliminado.IsSuccess)
            return BadRequest(new { mensaje = "No se pudo eliminar el artículo." });

        return NoContent();
    }
}
