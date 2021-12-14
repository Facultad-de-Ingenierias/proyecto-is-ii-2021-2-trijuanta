using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace dotnet.Models.DB
{
    public partial class Cuentum
    {
        public Cuentum()
        {
            Administrativos = new HashSet<Administrativo>();
            Enfermeros = new HashSet<Enfermero>();
            Familiars = new HashSet<Familiar>();
            Medicos = new HashSet<Medico>();
        }

        public int Id { get; set; }
        public int Rol { get; set; }
        public string Usuario { get; set; }
        
        [DataType(DataType.Password)]
        public string Contrasena { get; set; }

        public virtual ICollection<Administrativo> Administrativos { get; set; }
        public virtual ICollection<Enfermero> Enfermeros { get; set; }
        public virtual ICollection<Familiar> Familiars { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
