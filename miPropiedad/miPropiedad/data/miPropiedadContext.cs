using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using miPropiedad.Model;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace miPropiedad.data
{
    public partial class miPropiedadContext : DbContext
    {
        public miPropiedadContext()
        {
        }

        public miPropiedadContext(DbContextOptions<miPropiedadContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Propiedad> Propiedad { get; set; }
        public virtual DbSet<Propietario> Propietario { get; set; }
        public virtual DbSet<Publicacion> Publicacion { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=DESKTOP-0CA3EBA;Database=miPropiedad;Trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Propiedad>(entity =>
            {
                entity.HasKey(e => e.IdPropiedad);

                entity.Property(e => e.IdPropiedad).HasColumnName("idPropiedad");

                entity.Property(e => e.Baños).HasColumnName("baños");

                entity.Property(e => e.Caracteristica)
                    .HasColumnName("caracteristica")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.Categoria)
                    .HasColumnName("categoria")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ciudad)
                    .HasColumnName("ciudad")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Fotos)
                    .HasColumnName("fotos")
                    .HasColumnType("image");

                entity.Property(e => e.Habitaciones).HasColumnName("habitaciones");

                entity.Property(e => e.IdPropietario).HasColumnName("idPropietario");

                entity.Property(e => e.Operacion)
                    .HasColumnName("operacion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pais)
                    .HasColumnName("pais")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Precio)
                    .HasColumnName("precio")
                    .HasColumnType("decimal(16, 2)");

                entity.Property(e => e.Sector)
                    .HasColumnName("sector")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPropietarioNavigation)
                    .WithMany(p => p.Propiedad)
                    .HasForeignKey(d => d.IdPropietario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Propiedad_Propietario");
            });

            modelBuilder.Entity<Propietario>(entity =>
            {
                entity.HasKey(e => e.IdPropietario);

                entity.Property(e => e.IdPropietario).HasColumnName("idPropietario");

                entity.Property(e => e.Contacto)
                    .HasColumnName("contacto")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.EmailNavigation)
                    .WithMany(p => p.Propietario)
                    .HasForeignKey(d => d.Email)
                    .HasConstraintName("FK_Propietario_Usuario");
            });

            modelBuilder.Entity<Publicacion>(entity =>
            {
                entity.HasKey(e => e.IdPublicacion);

                entity.Property(e => e.IdPublicacion)
                    .HasColumnName("idPublicacion")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.IdPropiedad).HasColumnName("idPropiedad");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("titulo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPublicacionNavigation)
                    .WithOne(p => p.Publicacion)
                    .HasForeignKey<Publicacion>(d => d.IdPublicacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Publicacion_Propiedad");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasColumnName("contraseña")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
