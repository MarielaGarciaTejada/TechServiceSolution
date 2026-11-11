namespace TechService.Application.Dtos;

public class CatalogoItemDto
{
    public int ItemId { get; set; }
    public string CodigoSku { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public int TipoItemId { get; set; }
    public string TipoItemNombre { get; set; } = string.Empty;
    public int TipoEquipoId { get; set; }
    public string TipoEquipoNombre { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public int StockMinimoAlerta { get; set; }
}
