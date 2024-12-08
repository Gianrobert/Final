using System;
using System.Collections.Generic;

namespace Final.Models;

public partial class Equipo
{
    public int EquipoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public DateTime? FechaAdquisicion { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
