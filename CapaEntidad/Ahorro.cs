using System;
using System.Collections.Generic;

namespace CapaEntidad;

public partial class Ahorro
{
    public int IdAhorro { get; set; }

    public int? IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime? FechaRegistro { get; set; }

    public decimal Total { get; set; }

    public virtual ICollection<DetalleAhorro> DetalleAhorros { get; set; } = new List<DetalleAhorro>();

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
