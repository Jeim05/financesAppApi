using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CapaEntidad;


public partial class DbPersonalfinancesContext : DbContext
{
    public DbPersonalfinancesContext()
    {
    }

    public DbPersonalfinancesContext(DbContextOptions<DbPersonalfinancesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ahorro> Ahorros { get; set; }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<DetalleAhorro> DetalleAhorros { get; set; }

    public virtual DbSet<DetalleDeuda> DetalleDeuda { get; set; }

    public virtual DbSet<DetallePresupuesto> DetallePresupuestos { get; set; }

    public virtual DbSet<Deuda> Deuda { get; set; }

    public virtual DbSet<Presupuesto> Presupuestos { get; set; }

    public virtual DbSet<Transaccion> Transaccions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ahorro>(entity =>
        {
            entity.HasKey(e => e.IdAhorro).HasName("PK__AHORRO__E16DC650DBF9F06F");

            entity.ToTable("AHORRO");

            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Ahorros)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__AHORRO__IdUsuari__46E78A0C");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__CATEGORI__A3C02A104537374D");

            entity.ToTable("CATEGORIA");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DetalleAhorro>(entity =>
        {
            entity.HasKey(e => e.IdDetalleAhorro).HasName("PK__DETALLE___5DDCD5DB4233A8B8");

            entity.ToTable("DETALLE_AHORRO");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdAhorroNavigation).WithMany(p => p.DetalleAhorros)
                .HasForeignKey(d => d.IdAhorro)
                .HasConstraintName("FK__DETALLE_A__IdAho__4AB81AF0");
        });

        modelBuilder.Entity<DetalleDeuda>(entity =>
        {
            entity.HasKey(e => e.IdDetalleDeuda).HasName("PK__DETALLE___BBE9846B0B0DEC03");

            entity.ToTable("DETALLE_DEUDA");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdDeudaNavigation).WithMany(p => p.DetalleDeuda)
                .HasForeignKey(d => d.IdDeuda)
                .HasConstraintName("FK__DETALLE_D__IdDeu__5165187F");
        });

        modelBuilder.Entity<DetallePresupuesto>(entity =>
        {
            entity.HasKey(e => e.IdDetallePresupuesto).HasName("PK__DETALLE___7791DC290031CDC4");

            entity.ToTable("DETALLE_PRESUPUESTO");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TipoGasto)
                .HasMaxLength(25)
                .IsUnicode(false);

            //entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.DetallePresupuestos)
            //    .HasForeignKey(d => d.IdCategoria)
            //    .HasConstraintName("FK__DETALLE_P__IdCat__5812160E");

            entity.HasOne(d => d.IdPresupuestoNavigation).WithMany(p => p.DetallePresupuestos)
                .HasForeignKey(d => d.IdPresupuesto)
                .HasConstraintName("FK__DETALLE_P__IdPre__571DF1D5");
        });

        modelBuilder.Entity<Deuda>(entity =>
        {
            entity.HasKey(e => e.IdDeuda).HasName("PK__DEUDA__7F8C86B1511BF90E");

            entity.ToTable("DEUDA");

            entity.Property(e => e.Detalle)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.MontoInicial).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.MontoPendiente).HasColumnType("decimal(10, 2)");

            //entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Deuda)
            //    .HasForeignKey(d => d.IdCategoria)
            //    .HasConstraintName("FK__DEUDA__IdCategor__4E88ABD4");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Deuda)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__DEUDA__IdUsuario__4D94879B");
        });

        modelBuilder.Entity<Presupuesto>(entity =>
        {
            entity.HasKey(e => e.IdPresupuesto).HasName("PK__PRESUPUE__D70FD1905680790B");

            entity.ToTable("PRESUPUESTO");

            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Presupuestos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__PRESUPUES__IdUsu__5441852A");
        });

        modelBuilder.Entity<Transaccion>(entity =>
        {
            entity.HasKey(e => e.IdTransaccion).HasName("PK__TRANSACC__334B1F7707437E68");

            entity.ToTable("TRANSACCION");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.MetodoPago)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TipoTransaccion)
                .HasMaxLength(50)
                .IsUnicode(false);

            //entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Transaccions)
            //    .HasForeignKey(d => d.IdCategoria)
            //    .HasConstraintName("FK__TRANSACCI__IdCat__3C69FB99");

            //entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Transaccions)
            //    .HasForeignKey(d => d.IdUsuario)
            //    .HasConstraintName("FK__TRANSACCI__IdUsu__3D5E1FD2");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__USUARIO__5B65BF97FA1991FB");

            entity.ToTable("USUARIO");

            entity.Property(e => e.Activo).HasDefaultValue(false);
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
