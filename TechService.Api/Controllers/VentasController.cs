using Microsoft.AspNetCore.Mvc;
using TechService.Application.Services;
using TechService.Application.Dtos;

namespace TechService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VentasController(VentasService ventasService, ILogger<VentasController> logger) : ControllerBase
{
	[HttpGet]
	public async Task<ActionResult<IEnumerable<VentaDto>>> GetAll()
	{
		logger.LogInformation("Consultando lista de ventas");
		var lista = await ventasService.GetList();
		return Ok(lista);
	}

	[HttpGet("{id:int}")]
	public async Task<ActionResult<VentaDto>> GetById(int id)
	{
		var result = await ventasService.Buscar(id);
		var venta = result.Value;

		if (venta == null)
			return NotFound(new { mensaje = $"Venta con ID {id} no encontrada." });

		return Ok(venta);
	}

	[HttpPost]
	public async Task<IActionResult> Create([FromBody] VentaDto venta)
	{
		if (venta.Detalles == null || venta.Detalles.Count == 0)
			return BadRequest(new { mensaje = "La venta debe tener al menos un detalle." });

		var guardado = await ventasService.Guardar(venta);

		if (!guardado.IsSuccess)
			return BadRequest(new { mensaje = "No fue posible registrar la venta." });

		return Ok(new { mensaje = "Venta registrada correctamente." });
	}
}