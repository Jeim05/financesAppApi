using System;
using System.Collections.Generic;

namespace CapaEntidad;

public partial class DetalleAhorro
{
    public int IdDetalleAhorro { get; set; }

    public int? IdAhorro { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal Monto { get; set; }

    public virtual Ahorro? IdAhorroNavigation { get; set; }
}
