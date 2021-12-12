using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace dotnet.Models.DB
{
    public partial class TrijuantaBDContext : DbContext
    {
        public TrijuantaBDContext()
        {
        }

        public TrijuantaBDContext(DbContextOptions<TrijuantaBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Paciente> Pacientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server = trijuantaserver.database.windows.net; Database = TrijuantaBD; User ID = trijuanta; pwd = Software2;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.Documento)
                    .HasName("PK__paciente__A25B3E600BFBE68E");

                entity.ToTable("paciente");

                entity.Property(e => e.Documento)
                    .ValueGeneratedNever()
                    .HasColumnName("documento");

                entity.Property(e => e.CorreoElectronico)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("correoElectronico");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fechaNacimiento");

                entity.Property(e => e.IdDireccionGeo)
                    .HasMaxLength(50)
                    .HasColumnName("idDireccionGeo");

                entity.Property(e => e.IdFamiliar).HasColumnName("idFamiliar");

                entity.Property(e => e.IdHistorial)
                    .HasMaxLength(50)
                    .HasColumnName("idHistorial");

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("primerApellido");

                entity.Property(e => e.PrimerNombre)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("primerNombre");

                entity.Property(e => e.Rh)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("rh");

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(15)
                    .HasColumnName("segundoApellido");

                entity.Property(e => e.SegundoNombre)
                    .HasMaxLength(15)
                    .HasColumnName("segundoNombre");

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("sexo")
                    .IsFixedLength(true);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(13)
                    .HasColumnName("telefono");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
