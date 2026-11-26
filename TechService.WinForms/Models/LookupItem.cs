namespace TechService.WinForms.Models;

public class LookupItem
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";

    public LookupItem() { }

    public LookupItem(int id, string nombre)
    {
        Id = id;
        Nombre = nombre;
    }

    public override string ToString() => Nombre;
}
