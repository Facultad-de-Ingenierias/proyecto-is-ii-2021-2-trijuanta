using System;
using System.Collections.Generic;

#nullable disable

namespace dotnet.Models.DB
{
    public partial class Especialidad
    {
        public Especialidad()
        {
            Medicos = new HashSet<Medico>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
