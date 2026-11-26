namespace TechService.WinForms.Models;

public class VentaItemRow
{
    public int ItemId { get; set; }
    public string CodigoSku { get; set; } = "";
    public string Articulo { get; set; } = "";
    public decimal PrecioUnitario { get; set; }
    public int Cantidad { get; set; }
    public decimal Subtotal => PrecioUnitario * Cantidad;
}