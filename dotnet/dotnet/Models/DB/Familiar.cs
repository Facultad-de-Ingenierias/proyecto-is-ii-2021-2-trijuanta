using System;
using System.Collections.Generic;

#nullable disable

namespace dotnet.Models.DB
{
    public partial class Familiar
    {
        public Familiar()
        {
            FamiliarXpacientes = new HashSet<FamiliarXpaciente>();
        }

        public int Id { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Sexo { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public int IdCuenta { get; set; }

        public virtual Cuentum IdCuentaNavigation { get; set; }
        public virtual ICollection<FamiliarXpaciente> FamiliarXpacientes { get; set; }
    }
}
