using System;
using System.Collections.Generic;

namespace CapaEntidad;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Apellidos { get; set; }

    public string Correo { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool? Activo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Ahorro> Ahorros { get; set; } = new List<Ahorro>();

    public virtual ICollection<Deuda> Deuda { get; set; } = new List<Deuda>();

    public virtual ICollection<Presupuesto> Presupuestos { get; set; } = new List<Presupuesto>();

    public virtual ICollection<Transaccion> Transaccions { get; set; } = new List<Transaccion>();
}
