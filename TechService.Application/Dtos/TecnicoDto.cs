using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using TechService.Infrastructure.Models;

namespace TechService.Application.Dtos
{
    public class TecnicoDto
    {
        public int TecnicoId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;
    }
}
