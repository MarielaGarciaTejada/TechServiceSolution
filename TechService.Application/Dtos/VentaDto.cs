using System;
using System.Collections.Generic;

namespace TechService.Application.Dtos;

public class VentaDto
{
    public int VentaId { get; set; }
    public int? ClienteId { get; set; }
    public string? ClienteNombre { get; set; }
    public int MetodoPagoId { get; set; }
    public string MetodoPagoNombre { get; set; } = string.Empty;
    public DateTime? FechaVenta { get; set; }
    public decimal Subtotal { get; set; }
    public decimal Itbis { get; set; }
    public decimal TotalVenta { get; set; }
    public List<DetalleVentaDto> Detalles { get; set; } = new();
}
