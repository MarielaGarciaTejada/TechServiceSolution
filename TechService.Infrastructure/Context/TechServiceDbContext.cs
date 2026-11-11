using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TechService.Infrastructure.Models;

namespace TechService.Infrastructure.Data;

public partial class TechServiceDbContext : DbContext
{
    public TechServiceDbContext()
    {}

    public TechServiceDbContext(DbContextOptions<TechServiceDbContext> options): base(options)
    {}

    public virtual DbSet<CatalogoItem> CatalogoItems { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetalleVenta> DetalleVentas { get; set; }

    public virtual DbSet<EntregasGarantium> EntregasGarantia { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<EstadosAprobacion> EstadosAprobacions { get; set; }

    public virtual DbSet<HistorialOrdenEvento> HistorialOrdenEventos { get; set; }

    public virtual DbSet<MetodosPago> MetodosPagos { get; set; }

    public virtual DbSet<OrdenRepuesto> OrdenRepuestos { get; set; }

    public virtual DbSet<OrdenesReparacion> OrdenesReparacions { get; set; }

    public virtual DbSet<Prioridade> Prioridades { get; set; }

    public virtual DbSet<Rol> Roles { get; set; }

    public virtual DbSet<Tecnico> Tecnicos { get; set; }

    public virtual DbSet<TiposEquipo> TiposEquipos { get; set; }

    public virtual DbSet<TiposItem> TiposItems { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CatalogoItem>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__Catalogo__727E838B24B5AC97");

            entity.HasIndex(e => e.CodigoSku, "UQ__Catalogo__F02E07B1C72EEB01").IsUnique();

            entity.Property(e => e.CodigoSku).HasMaxLength(30);
            entity.Property(e => e.Nombre).HasMaxLength(120);
            entity.Property(e => e.Precio).HasColumnType("money");
            entity.Property(e => e.StockMinimoAlerta).HasDefaultValue(3);

            entity.HasOne(d => d.TipoEquipo).WithMany(p => p.CatalogoItems)
                .HasForeignKey(d => d.TipoEquipoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CatalogoI__TipoE__43D61337");

            entity.HasOne(d => d.TipoItem).WithMany(p => p.CatalogoItems)
                .HasForeignKey(d => d.TipoItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CatalogoI__TipoI__42E1EEFE");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Clientes__71ABD0876F42DEAB");

            entity.HasIndex(e => e.DocumentoIdentidad, "UQ__Clientes__049E81A9BF9879A7").IsUnique();

            entity.Property(e => e.DocumentoIdentidad).HasMaxLength(20);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(25);
        });

        modelBuilder.Entity<DetalleVenta>(entity =>
        {
            entity.HasKey(e => e.DetalleVentaId).HasName("PK__DetalleV__340EEDA4BB44DD70");

            entity.Property(e => e.PrecioUnitario).HasColumnType("money");

            entity.HasOne(d => d.Item).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleVe__ItemI__6BE40491");

            entity.HasOne(d => d.Venta).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.VentaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleVe__Venta__6AEFE058");
        });

        modelBuilder.Entity<EntregasGarantium>(entity =>
        {
            entity.HasKey(e => e.EntregaId).HasName("PK__Entregas__D9AD23034D63FBD9");

            entity.Property(e => e.DiaGarantia).HasDefaultValue(30);
            entity.Property(e => e.FechaEntrega).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.FechaVencimientoGarantia).HasComputedColumnSql("(dateadd(day,[DiaGarantia],[FechaEntrega]))", false);
            entity.Property(e => e.ObservacionFinal).HasMaxLength(300);
            entity.Property(e => e.TotalCobrado).HasColumnType("money");
            entity.Property(e => e.TotalManoObra).HasColumnType("money");
            entity.Property(e => e.TotalRepuesto).HasColumnType("money");

            entity.HasOne(d => d.MetodoPago).WithMany(p => p.EntregasGarantia)
                .HasForeignKey(d => d.MetodoPagoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EntregasG__Metod__6166761E");

            entity.HasOne(d => d.Orden).WithMany(p => p.EntregasGarantia)
                .HasForeignKey(d => d.OrdenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EntregasG__Orden__607251E5");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.EstadoId).HasName("PK__Estados__FEF86B00D81EED2C");

            entity.HasIndex(e => e.Nombre, "UQ__Estados__75E3EFCF6E583C3F").IsUnique();

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<EstadosAprobacion>(entity =>
        {
            entity.HasKey(e => e.EstadoAprobacionId).HasName("PK__EstadosA__3FDDF5F1ACA6C03D");

            entity.ToTable("EstadosAprobacion");

            entity.HasIndex(e => e.Nombre, "UQ__EstadosA__75E3EFCF753036D7").IsUnique();

            entity.Property(e => e.Nombre).HasMaxLength(30);
        });

        modelBuilder.Entity<HistorialOrdenEvento>(entity =>
        {
            entity.HasKey(e => e.EventoId).HasName("PK__Historia__1EEB592146C7FEFE");

            entity.Property(e => e.Autor).HasMaxLength(80);
            entity.Property(e => e.FechaHora).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Mensaje).HasMaxLength(300);
            entity.Property(e => e.Origen).HasMaxLength(30);

            entity.HasOne(d => d.Orden).WithMany(p => p.HistorialOrdenEventos)
                .HasForeignKey(d => d.OrdenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Historial__Orden__5CA1C101");
        });

        modelBuilder.Entity<MetodosPago>(entity =>
        {
            entity.HasKey(e => e.MetodoPagoId).HasName("PK__MetodosP__A8FEAF5471B99F48");

            entity.ToTable("MetodosPago");

            entity.HasIndex(e => e.Nombre, "UQ__MetodosP__75E3EFCF2AA22666").IsUnique();

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<OrdenRepuesto>(entity =>
        {
            entity.HasKey(e => e.OrdenRepuestoId).HasName("PK__OrdenRep__1BB16F44DFE3F52F");

            entity.Property(e => e.Cantidad).HasDefaultValue(1);
            entity.Property(e => e.PrecioUnitario).HasColumnType("money");

            entity.HasOne(d => d.EstadoAprobacion).WithMany(p => p.OrdenRepuestos)
                .HasForeignKey(d => d.EstadoAprobacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrdenRepu__Estad__58D1301D");

            entity.HasOne(d => d.Item).WithMany(p => p.OrdenRepuestos)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrdenRepu__ItemI__57DD0BE4");

            entity.HasOne(d => d.Orden).WithMany(p => p.OrdenRepuestos)
                .HasForeignKey(d => d.OrdenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrdenRepu__Orden__56E8E7AB");
        });

        modelBuilder.Entity<OrdenesReparacion>(entity =>
        {
            entity.HasKey(e => e.OrdenId).HasName("PK__OrdenesR__C088A5042EBA1114");

            entity.ToTable("OrdenesReparacion");

            entity.HasIndex(e => e.CodigoTracking, "UQ__OrdenesR__0C6472BE9C29C537").IsUnique();

            entity.Property(e => e.CodigoTracking).HasMaxLength(20);
            entity.Property(e => e.CostoManoObra).HasColumnType("money");
            entity.Property(e => e.FalloReportado).HasMaxLength(300);
            entity.Property(e => e.FechaIngreso).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.MarcaModelo).HasMaxLength(100);
            entity.Property(e => e.NumeroSerieImei).HasMaxLength(60);
            entity.Property(e => e.ObservacionTecnico).HasMaxLength(500);
            entity.Property(e => e.PinDesbloqueo).HasMaxLength(30);
            entity.Property(e => e.PresupuestoAprobadoCliente).HasDefaultValue(true);
            entity.Property(e => e.CheckRevisionPlaca).HasDefaultValue(false);
            entity.Property(e => e.CheckCambioPieza).HasDefaultValue(false);
            entity.Property(e => e.CheckPruebasEncendido).HasDefaultValue(false);

            entity.HasOne(d => d.Cliente).WithMany(p => p.OrdenesReparacions)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrdenesRe__Clien__498EEC8D");

            entity.HasOne(d => d.Estado).WithMany(p => p.OrdenesReparacions)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrdenesRe__Estad__4C6B5938");

            entity.HasOne(d => d.Prioridad).WithMany(p => p.OrdenesReparacions)
                .HasForeignKey(d => d.PrioridadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrdenesRe__Prior__4D5F7D71");

            entity.HasOne(d => d.Tecnico).WithMany(p => p.OrdenesReparacions)
                .HasForeignKey(d => d.TecnicoId)
                .HasConstraintName("FK__OrdenesRe__Tecni__4A8310C6");

            entity.HasOne(d => d.TipoEquipo).WithMany(p => p.OrdenesReparacions)
                .HasForeignKey(d => d.TipoEquipoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrdenesRe__TipoE__4B7734FF");
        });

        modelBuilder.Entity<Prioridade>(entity =>
        {
            entity.HasKey(e => e.PrioridadId).HasName("PK__Priorida__3939172E2BD1948A");

            entity.HasIndex(e => e.Nombre, "UQ__Priorida__75E3EFCF2637559C").IsUnique();

            entity.Property(e => e.Nombre).HasMaxLength(30);
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.RolId);

            entity.HasIndex(e => e.Nombre).IsUnique();

            entity.Property(e => e.Nombre).HasMaxLength(30);
            entity.Property(e => e.Descripcion).HasMaxLength(150);
        });

        modelBuilder.Entity<Tecnico>(entity =>
        {
            entity.HasKey(e => e.TecnicoId).HasName("PK__Tecnicos__C866A05DB9DF19EB");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Especialidad).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.PorcentajeComision)
                .HasDefaultValue(20.00m)
                .HasColumnType("decimal(5, 2)");
        });

        modelBuilder.Entity<TiposEquipo>(entity =>
        {
            entity.HasKey(e => e.TipoEquipoId).HasName("PK__TiposEqu__A75AB0B6043AF97D");

            entity.ToTable("TiposEquipo");

            entity.HasIndex(e => e.Nombre, "UQ__TiposEqu__75E3EFCF76BCA1B8").IsUnique();

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<TiposItem>(entity =>
        {
            entity.HasKey(e => e.TipoItemId).HasName("PK__TiposIte__FC89053B991D7055");

            entity.ToTable("TiposItem");

            entity.HasIndex(e => e.Nombre, "UQ__TiposIte__75E3EFCFBB399E10").IsUnique();

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId);

            entity.HasIndex(e => e.NombreUsuario).IsUnique();

            entity.Property(e => e.NombreUsuario).HasMaxLength(50);
            entity.Property(e => e.Contrasena).HasMaxLength(100);
            entity.Property(e => e.NombreCompleto).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(25);
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(getutcdate())");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Tecnico).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.TecnicoId);
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.VentaId).HasName("PK__Ventas__5B4150AC0AA3734B");

            entity.Property(e => e.FechaVenta).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Subtotal).HasColumnType("money").HasDefaultValue(0m);
            entity.Property(e => e.Itbis).HasColumnType("money").HasDefaultValue(0m);
            entity.Property(e => e.TotalVenta).HasColumnType("money");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Venta)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__Ventas__ClienteI__662B2B3B");

            entity.HasOne(d => d.MetodoPago).WithMany(p => p.Venta)
                .HasForeignKey(d => d.MetodoPagoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ventas__MetodoPa__671F4F74");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
