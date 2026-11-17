namespace TechService.Infrastructure.Models
{
    public class VentaConDetallesRequest
    {
        public Venta Venta { get; set; } = null!;
        public List<DetalleVenta> Detalles { get; set; } = [];
    }
}
