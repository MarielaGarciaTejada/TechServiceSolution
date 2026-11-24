using System;

namespace TechService.Application.Dtos;

public class HistorialEventoDto
{
    public int EventoId { get; set; }
    public int OrdenId { get; set; }
    public string Origen { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public string Mensaje { get; set; } = string.Empty;
    public DateTime? FechaHora { get; set; }
}
