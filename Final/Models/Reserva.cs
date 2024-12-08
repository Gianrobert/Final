using System;
using System.Collections.Generic;

namespace Final.Models;

public partial class Reserva
{
    public int ReservaId { get; set; }

    public int? UsuarioId { get; set; }

    public int? EquipoId { get; set; }

    public DateTime? FechaReserva { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public string? Estado { get; set; }

    public virtual Equipo? Equipo { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual Usuario? Usuario { get; set; }
}
