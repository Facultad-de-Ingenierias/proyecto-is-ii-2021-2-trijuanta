using System;
using System.Collections.Generic;

#nullable disable

namespace dotnet.Models.DB
{
    public partial class DireccionGeo
    {
        public DireccionGeo()
        {
            Pacientes = new HashSet<Paciente>();
        }

        public int Id { get; set; }
        public string Direccion { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }

        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
