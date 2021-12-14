using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace dotnet.Models.DB
{
    public partial class Diagnostico
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string Sugerencia { get; set; }

        [MaxLength(255)]
        public string Antecedentes { get; set; }

        [MaxLength(255)]
        public string SaludSexual { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy", ApplyFormatInEditMode = true)]
        [DisplayName("F. Diagnostico")]
        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public int IdPaciente { get; set; }

        [Required]
        public int IdMedico { get; set; }

        [Required]
        public int IdSignosVitales { get; set; }

        [DisplayName("Medico")]
        public virtual Medico IdMedicoNavigation { get; set; }

        [DisplayName("Paciente")]
        public virtual Paciente IdPacienteNavigation { get; set; }

        public virtual SignosVitale IdSignosVitalesNavigation { get; set; }
    }
}
