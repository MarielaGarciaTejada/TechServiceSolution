namespace TechService.Application.Dtos
{
    public class TecnicoDto
    {
        public int TecnicoId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;
        public decimal? PorcentajeComision { get; set; }
        public bool? Activo { get; set; }
    }
}
