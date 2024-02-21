using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Reserva_1.Models;

public partial class TipoHabitacion
{
    public int TipoHabitacionId { get; set; }

    public string Descripcion { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Habitacion> Habitacions { get; set; } = new List<Habitacion>();
}
