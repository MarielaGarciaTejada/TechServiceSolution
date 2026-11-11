using System;

namespace TechService.Application.Dtos;

// DTO para alertas directas a caja (POS)
public record AlertaCajaDto(
    string TipoAlerta, // "StockMinimo", "OrdenListaCobro", "AprobacionRepuesto", "NuevoRepuestoAgregado"
    string Mensaje,
    DateTime FechaHora
);
