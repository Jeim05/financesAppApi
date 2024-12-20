using System;
using System.Collections.Generic;

namespace CapaEntidad;

public partial class Deuda
{
    public int IdDeuda { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdCategoria { get; set; }

    public DateTime Fecha { get; set; }

    public string Detalle { get; set; } = null!;

    public decimal MontoInicial { get; set; }

    public decimal MontoPendiente { get; set; }

    public virtual ICollection<DetalleDeuda> DetalleDeuda { get; set; } = new List<DetalleDeuda>();

    public virtual Categoria? IdCategoriaNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
