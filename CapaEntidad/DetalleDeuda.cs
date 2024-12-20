using System;
using System.Collections.Generic;

namespace CapaEntidad;

public partial class DetalleDeuda
{
    public int IdDetalleDeuda { get; set; }

    public int? IdDeuda { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal Monto { get; set; }

    public virtual Deuda? IdDeudaNavigation { get; set; }
}
