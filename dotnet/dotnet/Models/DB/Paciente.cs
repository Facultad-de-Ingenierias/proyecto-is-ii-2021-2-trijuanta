using System;
using System.Collections.Generic;

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
        public string Documento { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public string Rh { get; set; }
        public int IdDireccionGeo { get; set; }

        public virtual DireccionGeo IdDireccionGeoNavigation { get; set; }
        public virtual ICollection<Diagnostico> Diagnosticos { get; set; }
        public virtual ICollection<EnfermeroXpaciente> EnfermeroXpacientes { get; set; }
        public virtual ICollection<FamiliarXpaciente> FamiliarXpacientes { get; set; }
        public virtual ICollection<MedicoXpaciente> MedicoXpacientes { get; set; }
    }
}
