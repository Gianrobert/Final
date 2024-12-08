using System;
using System.Collections.Generic;

namespace Final.Models;

public partial class Factura
{
    public int FacturaId { get; set; }

    public int? PagoId { get; set; }

    public string? NumeroFactura { get; set; }

    public DateTime? FechaEmision { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public decimal Total { get; set; }

    public virtual Pago? Pago { get; set; }
}
