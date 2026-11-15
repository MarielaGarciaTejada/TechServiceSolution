using System;
namespace TechService.Application.Dtos;

public class EntregaGarantiaDto
{
    public int EntregaId { get; set; }
    public int OrdenId { get; set; }
    public DateTime? FechaEntrega { get; set; }
    public string RecibidoPor { get; set; } = string.Empty;
    public string CedulaReceptor { get; set; } = string.Empty;
    public string? FirmaDigital { get; set; }
    public int MesesGarantia { get; set; }
    public string? CondicionesGarantia { get; set; }
    public int? TecnicoEntregaId { get; set; }
    public string? TecnicoEntregaNombre { get; set; }
}