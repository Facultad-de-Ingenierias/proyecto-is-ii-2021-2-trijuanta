using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace dotnet.Models.DB
{
    public partial class Enfermero
    {
        public Enfermero()
        {
            EnfermeroXpacientes = new HashSet<EnfermeroXpaciente>();
            SignosVitales = new HashSet<SignosVitale>();
            IdCuenta = 1;
        }

        public int Id { get; set; }

        [DisplayName("T.D")]
        [Required]
        [MaxLength(4)]
        public string TipoDocumento { get; set; }

        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        public string Documento { get; set; }

        [DisplayName("Primer Nombre")]
        [Required]
        [MaxLength(15)]
        public string PrimerNombre { get; set; }

        [DisplayName("Segundo Nombre")]
        [MaxLength(15)]
        public string SegundoNombre { get; set; }

        [DisplayName("Primer Apellido")]
        [Required]
        [MaxLength(15)]
        public string PrimerApellido { get; set; }

        [DisplayName("Segundo Apellido")]
        [MaxLength(15)]
        public string SegundoApellido { get; set; }

        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        [DisplayName("F. Nacimiento")]
        [Required]
        public DateTime FechaNacimiento { get; set; }

        [MaxLength(1)]
        [MinLength(1)]
        [Required]
        public string Sexo { get; set; }

        [MaxLength(13)]
        [MinLength(13)]
        [Required]
        public string Celular { get; set; }

        [MaxLength(100)]
        [MinLength(5)]
        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [DisplayName("Imagen")]
        [MaxLength(255)]
        [MinLength(5)]
        public string PathImagen { get; set; }

        public int IdCuenta { get; set; }

        public virtual Cuentum IdCuentaNavigation { get; set; }
        public virtual ICollection<EnfermeroXpaciente> EnfermeroXpacientes { get; set; }
        public virtual ICollection<SignosVitale> SignosVitales { get; set; }
    }
}
