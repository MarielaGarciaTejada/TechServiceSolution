using System;

namespace TechService.Application.Dtos;

// DTO para actualizaciones de estado técnico
public record CambioEstadoOrdenDto(
    string CodigoTracking,
    string NuevoEstado,
    string ModificadoPor,
    DateTime FechaHora
);
