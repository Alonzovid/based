using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Reserva_1.Models;

public partial class Habitacion
{
    public int HabitacionId { get; set; }

    public string NumeroHabitacion { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public bool Disponible { get; set; }

    public string? Foto { get; set; }

    public int TipoHabitacionId { get; set; }
    [JsonIgnore]
    public virtual ICollection<Reservacion> Reservacions { get; set; } = new List<Reservacion>();

    public virtual TipoHabitacion TipoHabitacion { get; set; } = null!;
}
