using System;
using System.Collections.Generic;

namespace TechService.Application.Dtos;

public class VentaDto
{
	public int VentaId { get; set; }
	public string NumeroFactura { get; set; } = string.Empty;
	public int? ClienteId { get; set; }
	public string? ClienteNombre { get; set; }
	public int UsuarioId { get; set; }
	public string UsuarioNombre { get; set; } = string.Empty;
	public DateTime Fecha { get; set; }
	public int MetodoPagoId { get; set; }
	public string MetodoPagoNombre { get; set; } = string.Empty;
	public decimal Subtotal { get; set; }
	public decimal Itbis { get; set; }
	public decimal Total { get; set; }
	public List<DetalleVentaDto> Detalles { get; set; } = new();
}
