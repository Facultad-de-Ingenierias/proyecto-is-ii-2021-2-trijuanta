using System;
using System.Collections.Generic;

#nullable disable

namespace dotnet.Models.DB
{
    public partial class FamiliarXpaciente
    {
        public int Id { get; set; }
        public int IdFamiliar { get; set; }
        public int IdPaciente { get; set; }

        public virtual Familiar IdFamiliarNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
    }
}
