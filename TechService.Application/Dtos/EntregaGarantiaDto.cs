using System;
namespace TechService.Application.Dtos;

public class EntregaGarantiaDto
{
    public int EntregaId { get; set; }
    public int OrdenId { get; set; }
    public int MetodoPagoId { get; set; }
    public string MetodoPagoNombre { get; set; } = string.Empty;
    public DateTime? FechaEntrega { get; set; }
    public int DiaGarantia { get; set; } = 30;
    public DateTime? FechaVencimientoGarantia { get; set; }
    public decimal TotalManoObra { get; set; }
    public decimal TotalRepuesto { get; set; }
    public decimal TotalCobrado { get; set; }
    public string ObservacionFinal { get; set; } = string.Empty;
}