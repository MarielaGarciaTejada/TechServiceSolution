using System;
using System.Collections.Generic;

namespace TechService.Infrastructure.Models;

public partial class Venta
{
    public int VentaId { get; set; }

    public int? ClienteId { get; set; }

    public int MetodoPagoId { get; set; }

    public DateTime? FechaVenta { get; set; }

    public decimal Subtotal { get; set; }

    public decimal Itbis { get; set; }

    public decimal TotalVenta { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual MetodosPago? MetodoPago { get; set; }
}
