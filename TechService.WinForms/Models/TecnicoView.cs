namespace TechService.WinForms.Models;

public class TecnicoView
{
    public int TecnicoId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Especialidad { get; set; } = string.Empty;
    public decimal PorcentajeComision { get; set; } = 20.00m;
    public bool Activo { get; set; } = true;

    public string ComisionTexto => $"{PorcentajeComision:N2} %";
    public string ActivoTexto => Activo ? "Activo" : "Inactivo";
    public string EspecialidadConTecnico => $"{Especialidad} ({Nombre})";

    public override string ToString() => EspecialidadConTecnico;
}
