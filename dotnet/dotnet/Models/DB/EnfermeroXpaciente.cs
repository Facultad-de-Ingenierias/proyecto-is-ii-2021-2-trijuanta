using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace dotnet.Models.DB
{
    public partial class EnfermeroXpaciente
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        [DisplayName("Documento Enfermero")]
        [Required]
        public int IdEnfermero { get; set; }

        [DisplayName("Documento Paciente")]
        [Required]
        public int IdPaciente { get; set; }

        public virtual Enfermero IdEnfermeroNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
    }
}
