using System;
using System.Collections.Generic;

namespace CapaEntidad;

public partial class DetallePresupuesto
{
    public int IdDetallePresupuesto { get; set; }

    public int? IdPresupuesto { get; set; }

    public int? IdCategoria { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal Monto { get; set; }

    public string TipoGasto { get; set; } = null!;

    public virtual Categoria? IdCategoriaNavigation { get; set; }

    public virtual Presupuesto? IdPresupuestoNavigation { get; set; }
}
