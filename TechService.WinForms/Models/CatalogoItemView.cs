namespace TechService.WinForms.Models;

public class CatalogoItemView
{
    public int ItemId { get; set; }
    public string CodigoSku { get; set; } = "";
    public string Nombre { get; set; } = "";
    public int TipoItemId { get; set; }
    public int TipoEquipoId { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public int StockMinimoAlerta { get; set; }

    public override string ToString() =>
        $"{Nombre} ({CodigoSku}) - RD$ {Precio:N2} (Stock: {Stock})";
}
