using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace dotnet.Models.DB
{
    public partial class FamiliarXpaciente
    {
        public int Id { get; set; }

       
        [Required]
        public int IdFamiliar { get; set; }

        
        [Required]
        public int IdPaciente { get; set; }

        [DisplayName("Documento Familiar")]
        public virtual Familiar IdFamiliarNavigation { get; set; }

        [DisplayName("Documento Paciente")]
        public virtual Paciente IdPacienteNavigation { get; set; }
    }
}
