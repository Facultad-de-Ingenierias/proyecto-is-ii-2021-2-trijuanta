using System;
using System.Collections.Generic;

#nullable disable

namespace dotnet.Models.DB
{
    public partial class Paciente
    {
        public int Documento { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string IdDireccionGeo { get; set; }
        public int? IdFamiliar { get; set; }
        public string IdHistorial { get; set; }
        public string Rh { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
    }
}
