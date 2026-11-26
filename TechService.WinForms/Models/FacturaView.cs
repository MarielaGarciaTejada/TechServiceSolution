namespace TechService.WinForms.Models;

public class FacturaView
{
    public int VentaId { get; set; }
    public int? ClienteId { get; set; }
    public int MetodoPagoId { get; set; } = 1; // 1 = Efectivo por defecto
    public DateTime FechaVenta { get; set; } = DateTime.UtcNow;
    public decimal Subtotal { get; set; }
    public decimal Itbis { get; set; }
    public decimal TotalVenta { get; set; }
    public List<VentaItemRow> Items { get; set; } = new();
}
