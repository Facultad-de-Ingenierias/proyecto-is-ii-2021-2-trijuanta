using System;
using System.Collections.Generic;

#nullable disable

namespace dotnet.Models.DB
{
    public partial class Diagnostico
    {
        public int Id { get; set; }
        public string Sugerencia { get; set; }
        public string Antecedentes { get; set; }
        public string SaludSexual { get; set; }
        public DateTime Fecha { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public int IdSignosVitales { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual SignosVitale IdSignosVitalesNavigation { get; set; }
    }
}
