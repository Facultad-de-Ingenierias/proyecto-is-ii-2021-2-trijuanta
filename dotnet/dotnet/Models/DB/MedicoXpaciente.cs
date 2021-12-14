using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace dotnet.Models.DB
{
    public partial class MedicoXpaciente
    {
        public int Id { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        [Required]
        public int IdMedico { get; set; }

        [Required]
        public int IdPaciente { get; set; }

        [DisplayName("Documento Paciente")]
        public virtual Medico IdMedicoNavigation { get; set; }

        [DisplayName("Documento Medico")]
        public virtual Paciente IdPacienteNavigation { get; set; }
    }
}
