namespace TechService.WinForms.Models;

public class ClienteView
{
    public int ClienteId { get; set; }
    public string Nombre { get; set; } = "";
    public string DocumentoIdentidad { get; set; } = "";
    public string Telefono { get; set; } = "";
    public string Email { get; set; } = "";
    public DateTime? FechaRegistro { get; set; }

    public override string ToString() =>
        string.IsNullOrWhiteSpace(DocumentoIdentidad) ? Nombre : $"{Nombre} - {DocumentoIdentidad}";
}
