using System;
using System.Collections.Generic;

namespace Reserva_1.Models;

public partial class Reservacion
{
    public int ReservacionId { get; set; }

    public int HabitacionId { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public bool Activo { get; set; }

    public string DpiCliente { get; set; } = null!;

    public string NombresCliente { get; set; } = null!;

    public string ApellidosCliente { get; set; } = null!;

    public int CantidadPersonas { get; set; }

    public virtual Habitacion Habitacion { get; set; } = null!;
}
