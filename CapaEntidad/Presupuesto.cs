using System;
using System.Collections.Generic;

namespace CapaEntidad;

public partial class Presupuesto
{
    public int IdPresupuesto { get; set; }

    public int? IdUsuario { get; set; }

    public DateTime Fecha { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Total { get; set; }

    public virtual ICollection<DetallePresupuesto> DetallePresupuestos { get; set; } = new List<DetallePresupuesto>();

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
