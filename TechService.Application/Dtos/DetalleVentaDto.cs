namespace TechService.Application.Dtos;

public class DetalleVentaDto
{
    public int DetalleVentaId { get; set; }
    public int VentaId { get; set; }
    public int ItemId { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal Subtotal => Cantidad * PrecioUnitario;
}
