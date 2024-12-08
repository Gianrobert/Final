using System;
using System.Collections.Generic;

namespace Final.Models;

public partial class Pago
{
    public int PagoId { get; set; }

    public int? ReservaId { get; set; }

    public decimal Monto { get; set; }

    public DateTime? FechaPago { get; set; }

    public string? MetodoPago { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual Reserva? Reserva { get; set; }
}
