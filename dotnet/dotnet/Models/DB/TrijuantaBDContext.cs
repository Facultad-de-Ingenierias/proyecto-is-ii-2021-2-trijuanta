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

        public virtual DbSet<Administrativo> Administrativos { get; set; }
        public virtual DbSet<Cuentum> Cuenta { get; set; }
        public virtual DbSet<Diagnostico> Diagnosticos { get; set; }
        public virtual DbSet<DireccionGeo> DireccionGeos { get; set; }
        public virtual DbSet<Enfermero> Enfermeros { get; set; }
        public virtual DbSet<EnfermeroXpaciente> EnfermeroXpacientes { get; set; }
        public virtual DbSet<Especialidad> Especialidads { get; set; }
        public virtual DbSet<Familiar> Familiars { get; set; }
        public virtual DbSet<FamiliarXpaciente> FamiliarXpacientes { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<MedicoXpaciente> MedicoXpacientes { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<SignosVitale> SignosVitales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(" Server = trijuantaserver.database.windows.net, 1433;Initial Catalog= TrijuantaBD;Persist Security Info=False;User ID= trijuanta;Password= Software2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Administrativo>(entity =>
            {
                entity.ToTable("administrativo");

                entity.HasIndex(e => new { e.Celular, e.Correo }, "UQ__administ__9CECF507D28A240A")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasMaxLength(13)
                    .HasColumnName("celular");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("correo");

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("documento");

                entity.Property(e => e.IdCuenta).HasColumnName("idCuenta");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("nombres");

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("sexo")
                    .IsFixedLength(true);

                entity.Property(e => e.TipoDocumento)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("tipoDocumento");

                entity.HasOne(d => d.IdCuentaNavigation)
                    .WithMany(p => p.Administrativos)
                    .HasForeignKey(d => d.IdCuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__administr__idCue__619B8048");
            });

            modelBuilder.Entity<Cuentum>(entity =>
            {
                entity.ToTable("cuenta");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("contrasena");

                entity.Property(e => e.Rol).HasColumnName("rol");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("usuario");
            });

            modelBuilder.Entity<Diagnostico>(entity =>
            {
                entity.ToTable("diagnostico");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Antecedentes)
                    .HasMaxLength(255)
                    .HasColumnName("antecedentes");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdMedico).HasColumnName("idMedico");

                entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");

                entity.Property(e => e.IdSignosVitales).HasColumnName("idSignosVitales");

                entity.Property(e => e.SaludSexual)
                    .HasMaxLength(255)
                    .HasColumnName("saludSexual");

                entity.Property(e => e.Sugerencia)
                    .HasMaxLength(255)
                    .HasColumnName("sugerencia");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Diagnosticos)
                    .HasForeignKey(d => d.IdMedico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__diagnosti__idMed__7A672E12");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Diagnosticos)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__diagnosti__idPac__797309D9");

                entity.HasOne(d => d.IdSignosVitalesNavigation)
                    .WithMany(p => p.Diagnosticos)
                    .HasForeignKey(d => d.IdSignosVitales)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__diagnosti__idSig__7B5B524B");
            });

            modelBuilder.Entity<DireccionGeo>(entity =>
            {
                entity.ToTable("DireccionGeo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("direccion");

                entity.Property(e => e.Latitud)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("latitud");

                entity.Property(e => e.Longitud)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("longitud");
            });

            modelBuilder.Entity<Enfermero>(entity =>
            {
                entity.ToTable("enfermero");

                entity.HasIndex(e => new { e.Celular, e.Correo }, "UQ__enfermer__9CECF50745F96E8C")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasMaxLength(13)
                    .HasColumnName("celular");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("correo");

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("documento");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fechaNacimiento");

                entity.Property(e => e.IdCuenta).HasColumnName("idCuenta");

                entity.Property(e => e.PathImagen)
                    .HasMaxLength(255)
                    .HasColumnName("pathImagen");

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("primerApellido");

                entity.Property(e => e.PrimerNombre)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("primerNombre");

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

                entity.Property(e => e.TipoDocumento)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("tipoDocumento");

                entity.HasOne(d => d.IdCuentaNavigation)
                    .WithMany(p => p.Enfermeros)
                    .HasForeignKey(d => d.IdCuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__enfermero__idCue__6A30C649");
            });

            modelBuilder.Entity<EnfermeroXpaciente>(entity =>
            {
                entity.ToTable("enfermeroXpaciente");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("date")
                    .HasColumnName("fechaFin");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("fechaInicio");

                entity.Property(e => e.IdEnfermero).HasColumnName("idEnfermero");

                entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");

                entity.HasOne(d => d.IdEnfermeroNavigation)
                    .WithMany(p => p.EnfermeroXpacientes)
                    .HasForeignKey(d => d.IdEnfermero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__enfermero__idEnf__02084FDA");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.EnfermeroXpacientes)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__enfermero__idPac__02FC7413");
            });

            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.ToTable("especialidad");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Familiar>(entity =>
            {
                entity.ToTable("familiar");

                entity.HasIndex(e => new { e.Celular, e.Correo }, "UQ__familiar__9CECF507EA915312")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasMaxLength(13)
                    .HasColumnName("celular");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("correo");

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("documento");

                entity.Property(e => e.IdCuenta).HasColumnName("idCuenta");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("nombres");

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("sexo")
                    .IsFixedLength(true);

                entity.Property(e => e.TipoDocumento)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("tipoDocumento");

                entity.HasOne(d => d.IdCuentaNavigation)
                    .WithMany(p => p.Familiars)
                    .HasForeignKey(d => d.IdCuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__familiar__idCuen__6FE99F9F");
            });

            modelBuilder.Entity<FamiliarXpaciente>(entity =>
            {
                entity.ToTable("familiarXpaciente");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdFamiliar).HasColumnName("idFamiliar");

                entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");

                entity.HasOne(d => d.IdFamiliarNavigation)
                    .WithMany(p => p.FamiliarXpacientes)
                    .HasForeignKey(d => d.IdFamiliar)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__familiarX__idFam__7E37BEF6");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.FamiliarXpacientes)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__familiarX__idPac__7F2BE32F");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.ToTable("medico");

                entity.HasIndex(e => new { e.Celular, e.Correo }, "UQ__medico__9CECF507A929DD79")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasMaxLength(13)
                    .HasColumnName("celular");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("correo");

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("documento");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fechaNacimiento");

                entity.Property(e => e.IdCuenta).HasColumnName("idCuenta");

                entity.Property(e => e.IdEspecialidad).HasColumnName("idEspecialidad");

                entity.Property(e => e.PathImagen)
                    .HasMaxLength(255)
                    .HasColumnName("pathImagen");

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("primerApellido");

                entity.Property(e => e.PrimerNombre)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("primerNombre");

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

                entity.Property(e => e.TarjetaProf)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("tarjetaProf");

                entity.Property(e => e.TipoDocumento)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("tipoDocumento");

                entity.HasOne(d => d.IdCuentaNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdCuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__medico__idCuenta__66603565");

                entity.HasOne(d => d.IdEspecialidadNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdEspecialidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__medico__idEspeci__656C112C");
            });

            modelBuilder.Entity<MedicoXpaciente>(entity =>
            {
                entity.ToTable("medicoXpaciente");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("date")
                    .HasColumnName("fechaFin");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("fechaInicio");

                entity.Property(e => e.IdMedico).HasColumnName("idMedico");

                entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.MedicoXpacientes)
                    .HasForeignKey(d => d.IdMedico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__medicoXpa__idMed__05D8E0BE");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.MedicoXpacientes)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__medicoXpa__idPac__06CD04F7");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.ToTable("paciente");

                entity.HasIndex(e => new { e.Celular, e.Correo }, "UQ__paciente__9CECF50773BD4FAD")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasMaxLength(13)
                    .HasColumnName("celular");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("correo");

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("documento");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fechaNacimiento");

                entity.Property(e => e.IdDireccionGeo).HasColumnName("idDireccionGeo");

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

                entity.HasOne(d => d.IdDireccionGeoNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.IdDireccionGeo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__paciente__idDire__73BA3083");
            });

            modelBuilder.Entity<SignosVitale>(entity =>
            {
                entity.ToTable("signosVitales");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FrecCardiaca)
                    .HasMaxLength(10)
                    .HasColumnName("frecCardiaca");

                entity.Property(e => e.FrecRespiratoria)
                    .HasMaxLength(10)
                    .HasColumnName("frecRespiratoria");

                entity.Property(e => e.Glicemias)
                    .HasMaxLength(10)
                    .HasColumnName("glicemias");

                entity.Property(e => e.IdEnfermero).HasColumnName("idEnfermero");

                entity.Property(e => e.Oximetria)
                    .HasMaxLength(10)
                    .HasColumnName("oximetria");

                entity.Property(e => e.PresionArterial)
                    .HasMaxLength(10)
                    .HasColumnName("presionArterial");

                entity.Property(e => e.Temperatura)
                    .HasMaxLength(10)
                    .HasColumnName("temperatura");

                entity.HasOne(d => d.IdEnfermeroNavigation)
                    .WithMany(p => p.SignosVitales)
                    .HasForeignKey(d => d.IdEnfermero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__signosVit__idEnf__76969D2E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
