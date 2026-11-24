using Microsoft.AspNetCore.Mvc;
using TechService.Infrastructure.Models;
using TechService.Application.Services;
using TechService.Application.Dtos;

namespace TechService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientesController(ClientesService clientesService, ILogger<ClientesController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClienteDto>>> GetAll()
    {
        logger.LogInformation("Consultando lista completa de clientes");
        var lista = await clientesService.GetList();
        return Ok(lista);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ClienteDto>> GetById(int id)
    {
        var result = await clientesService.Buscar(id);
        if (result.Value == null)
            return NotFound(new { mensaje = $"Cliente con ID {id} no encontrado." });

        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ClienteDto cliente)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var guardado = await clientesService.Guardar(cliente);
        if (!guardado.IsSuccess)
            return BadRequest(new { mensaje = "No fue posible registrar el cliente." });

        return CreatedAtAction(nameof(GetById), new { id = cliente.ClienteId }, cliente);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] ClienteDto cliente)
    {
        if (id != cliente.ClienteId)
            return BadRequest(new { mensaje = "El ID de la ruta no coincide con el cuerpo." });

        if (!await clientesService.Existe(id))
            return NotFound(new { mensaje = $"El cliente {id} no existe." });

        var actualizado = await clientesService.Modificar(cliente);
        if (!actualizado)
            return BadRequest(new { mensaje = "Error al actualizar los datos." });

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminado = await clientesService.Eliminar(id);
        if (!eliminado.IsSuccess)
            return NotFound(new { mensaje = $"El cliente {id} no fue encontrado o no se pudo eliminar." });

        return NoContent();
    }
}
