using System;
using System.Collections.Generic;

namespace dotnet.Models
{
    public class Paciente
    {
        public int documento { get; set; }
        public string primerNombre { get; set; }
        public string segundoNombre { get; set; }
        public string NombreCompleto { get { return primerNombre + " " + segundoNombre; } }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string NombreApellidoCompleto { get { return NombreCompleto + " " + primerApellido + " " + segundoApellido; } }
        public short rh { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public short sexo { get; set; }
        public string telefono { get; set; }
        public string correoElectronico { get; set; }

    }
}


