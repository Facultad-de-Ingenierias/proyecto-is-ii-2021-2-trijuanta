using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace dotnet.Models.DB
{
    public partial class Paciente
    {

        public Paciente()
        {
            Diagnosticos = new HashSet<Diagnostico>();
            EnfermeroXpacientes = new HashSet<EnfermeroXpaciente>();
            FamiliarXpacientes = new HashSet<FamiliarXpaciente>();
            MedicoXpacientes = new HashSet<MedicoXpaciente>();

        }

        public int Id { get; set; }

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

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy", ApplyFormatInEditMode = true)]
        [DisplayName("F. Nacimiento")]
        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [MaxLength(1)]
        public string Sexo { get; set; }

        [Required]
        [MaxLength(13)]
        [MinLength(13)]
        public string Celular { get; set; }

        [MaxLength(100)]
        [MinLength(5)]
        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        [MaxLength(2)]
        public string Rh { get; set; }

        [DisplayName("Direccion")]
        [Required]
        public int IdDireccionGeo { get; set; }

        [DisplayName("Direccion")]
        public virtual DireccionGeo IdDireccionGeoNavigation { get; set; }
        public virtual ICollection<Diagnostico> Diagnosticos { get; set; }
        public virtual ICollection<EnfermeroXpaciente> EnfermeroXpacientes { get; set; }
        public virtual ICollection<FamiliarXpaciente> FamiliarXpacientes { get; set; }
        public virtual ICollection<MedicoXpaciente> MedicoXpacientes { get; set; }
    }
}
