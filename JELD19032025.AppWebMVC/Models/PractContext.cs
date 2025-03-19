using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JELD19032025.AppWebMVC.Models;

public partial class PractContext : DbContext
{
    public PractContext()
    {
    }

    public PractContext(DbContextOptions<PractContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DetallesVentum> DetallesVenta { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-GLJR0B3;Initial Catalog=Pract;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DetallesVentum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Detalles__3214EC07A1F212E4");

            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.VentaId).HasColumnName("VentaID");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetallesVenta)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__DetallesV__Produ__3E52440B");

            entity.HasOne(d => d.Venta).WithMany(p => p.DetallesVenta)
                .HasForeignKey(d => d.VentaId)
                .HasConstraintName("FK__DetallesV__Venta__3D5E1FD2");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3214EC0738D6CC1B");

            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC071EF4EB46");

            entity.Property(e => e.Email)
                .HasMaxLength(225)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(32)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UltimoInicioSesion).HasColumnType("datetime");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ventas__3214EC07B218C9D9");

            entity.HasIndex(e => e.Correlativo, "UQ__Ventas__25BD776AEC30DB1D").IsUnique();

            entity.Property(e => e.Correlativo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FechaVenta)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
