using System;

namespace TechService.Application.Dtos;

// DTO para notificación de nueva orden registrada
public record NuevaOrdenDto(
    int OrdenId,
    string CodigoTracking,
    int TipoEquipoId,
    string MarcaModelo,
    DateTime FechaHora
);
