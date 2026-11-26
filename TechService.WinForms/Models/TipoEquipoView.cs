namespace TechService.WinForms.Models;

public class TipoEquipoView
{
    public int TipoEquipoId { get; set; }
    public string Nombre { get; set; } = "";

    public TipoEquipoView() { }

    public TipoEquipoView(int id, string nombre)
    {
        TipoEquipoId = id;
        Nombre = nombre;
    }

    public override string ToString() => Nombre;
}
