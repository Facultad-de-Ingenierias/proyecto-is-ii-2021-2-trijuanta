using System;
using System.Collections.Generic;

#nullable disable

namespace dotnet.Models.DB
{
    public partial class Enfermero
    {
        public Enfermero()
        {
            EnfermeroXpacientes = new HashSet<EnfermeroXpaciente>();
            SignosVitales = new HashSet<SignosVitale>();
        }

        public int Id { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public string PathImagen { get; set; }
        public int IdCuenta { get; set; }

        public virtual Cuentum IdCuentaNavigation { get; set; }
        public virtual ICollection<EnfermeroXpaciente> EnfermeroXpacientes { get; set; }
        public virtual ICollection<SignosVitale> SignosVitales { get; set; }
    }
}
