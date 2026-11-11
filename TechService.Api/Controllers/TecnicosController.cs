using Microsoft.AspNetCore.Mvc;
using TechService.Infrastructure.Models;
using TechService.Application.Services;
using TechService.Application.Dtos;

namespace TechService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TecnicosController(TecnicosService tecnicosService, ILogger<TecnicosController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TecnicoDto>>> GetAll()
    {
        logger.LogInformation("Consultando lista de técnicos");
        var tecnicos = await tecnicosService.GetList();
        return Ok(tecnicos);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TecnicoDto>> GetById(int id)
    {
        var result = await tecnicosService.Buscar(id);
        if (result.Value == null)
            return NotFound(new { mensaje = $"Técnico con ID {id} no encontrado." });

        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TecnicoDto tecnico)
    {
        var creado = await tecnicosService.Guardar(tecnico);
        if (!creado.IsSuccess)
            return BadRequest(new { mensaje = "No se pudo registrar el técnico." });

        return CreatedAtAction(nameof(GetById), new { id = tecnico.TecnicoId }, tecnico);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] TecnicoDto tecnico)
    {
        if (id != tecnico.TecnicoId)
            return BadRequest(new { mensaje = "El ID de la ruta no coincide con el cuerpo." });

        if (!await tecnicosService.Existe(id))
            return NotFound(new { mensaje = "Técnico no encontrado." });

        var actualizado = await tecnicosService.Modificar(tecnico);
        if (!actualizado)
            return BadRequest(new { mensaje = "No se pudo actualizar el técnico." });

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminado = await tecnicosService.Eliminar(id);
        if (!eliminado.IsSuccess)
            return NotFound(new { mensaje = "Técnico no encontrado." });

        return NoContent();
    }
}
