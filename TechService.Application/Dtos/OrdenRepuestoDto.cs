namespace TechService.Application.Dtos;

public class OrdenRepuestoDto
{
    public int OrdenRepuestoId { get; set; }
    public int OrdenId { get; set; }
    public int ItemId { get; set; }
    public int EstadoAprobacionId { get; set; }
    public string EstadoAprobacionNombre { get; set; } = "Aprobado";
    public int Cantidad { get; set; } = 1;
    public decimal PrecioUnitario { get; set; }
    public string? NombreItem { get; set; }
}
