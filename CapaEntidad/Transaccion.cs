using System;
using System.Collections.Generic;

namespace CapaEntidad;

public partial class Transaccion
{
    public int IdTransaccion { get; set; }

    public int? IdCategoria { get; set; }

    public int? IdUsuario { get; set; }

    public DateTime Fecha { get; set; }

    public string Descripcion { get; set; } = null!;

    public string MetodoPago { get; set; } = null!;

    public string TipoTransaccion { get; set; } = null!;

    public decimal Monto { get; set; }

    public virtual Categoria? IdCategoriaNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
