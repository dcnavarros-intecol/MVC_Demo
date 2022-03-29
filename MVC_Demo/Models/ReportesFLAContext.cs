using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MVC_Demo.Models
{
    public partial class ReportesFLAContext : DbContext
    {
        public ReportesFLAContext()
        {
        }

        public ReportesFLAContext(DbContextOptions<ReportesFLAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CodigoParo> CodigoParos { get; set; }
        public virtual DbSet<InspeccionManual> InspeccionManuals { get; set; }
        public virtual DbSet<Linea> Lineas { get; set; }
        public virtual DbSet<Maquina> Maquinas { get; set; }
        public virtual DbSet<MensajeError> MensajeErrors { get; set; }
        public virtual DbSet<ParosMaquina> ParosMaquinas { get; set; }
        public virtual DbSet<PlanProduccion> PlanProduccions { get; set; }
        public virtual DbSet<Producido> Producidos { get; set; }
        public virtual DbSet<Referencia> Referencia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server = LAPTOP-JUK1A45R; Database = ReportesFLA; Trusted_Connection= True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<CodigoParo>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("CodigoParos", "Maestro");

                entity.Property(e => e.Codigo).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.FechaHora)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<InspeccionManual>(entity =>
            {
                entity.ToTable("InspeccionManual", "Produccion");

                entity.Property(e => e.FechaHora)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Referencia)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.TipoError)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Linea>(entity =>
            {
                entity.ToTable("Linea", "Maestro");

                entity.Property(e => e.FechaHora)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Maquina>(entity =>
            {
                entity.ToTable("Maquina", "Maestro");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaHora)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdLineaNavigation)
                    .WithMany(p => p.Maquinas)
                    .HasForeignKey(d => d.IdLinea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Maquina_Linea");
            });

            modelBuilder.Entity<MensajeError>(entity =>
            {
                entity.ToTable("MensajeError", "Maestro");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FechaHora)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Mensaje)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ParosMaquina>(entity =>
            {
                entity.ToTable("ParosMaquina", "Produccion");

                entity.Property(e => e.FechaHora)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaHoraFin).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraInicio).HasColumnType("datetime");

                entity.Property(e => e.Linea)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Maquina)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Referencia)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoParoNavigation)
                    .WithMany(p => p.ParosMaquinas)
                    .HasForeignKey(d => d.CodigoParo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ParosMaquina_CodigoParos");
            });

            modelBuilder.Entity<PlanProduccion>(entity =>
            {
                entity.ToTable("PlanProduccion", "Produccion");

                entity.Property(e => e.FechaHora)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Producto)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.TrazabilidadEtiqueta1)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.TrazabilidadEtiqueta2)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.TrazabilidadTapa1)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.TrazabilidadTapa2)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Producido>(entity =>
            {
                entity.ToTable("Producido", "Produccion");

                entity.Property(e => e.FechaHora)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Linea)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Maquina)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Mensaje)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Referencia)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.TimeStampSalidas).HasColumnType("datetime");
            });

            modelBuilder.Entity<Referencia>(entity =>
            {
                entity.ToTable("Referencias", "Maestro");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.FechaHora)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdLineaNavigation)
                    .WithMany(p => p.Referencia)
                    .HasForeignKey(d => d.IdLinea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Referencias_Linea");

                entity.HasOne(d => d.IdMaquinaNavigation)
                    .WithMany(p => p.Referencia)
                    .HasForeignKey(d => d.IdMaquina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Referencias_Maquina");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
