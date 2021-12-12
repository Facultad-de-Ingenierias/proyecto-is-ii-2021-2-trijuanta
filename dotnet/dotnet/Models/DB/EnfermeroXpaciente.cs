using System;
using System.Collections.Generic;

#nullable disable

namespace dotnet.Models.DB
{
    public partial class EnfermeroXpaciente
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int IdEnfermero { get; set; }
        public int IdPaciente { get; set; }

        public virtual Enfermero IdEnfermeroNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
    }
}
