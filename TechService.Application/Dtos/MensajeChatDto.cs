using System;

namespace TechService.Application.Dtos;

// DTO para el chat e historial en tiempo real
public record MensajeChatDto(
    string CodigoTracking,
    string Autor,
    string Mensaje,
    string Origen,
    DateTime FechaHora
);
