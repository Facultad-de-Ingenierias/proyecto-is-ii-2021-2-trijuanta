using System;
using System.Collections.Generic;

#nullable disable

namespace dotnet.Models.DB
{
    public partial class SignosVitale
    {
        public SignosVitale()
        {
            Diagnosticos = new HashSet<Diagnostico>();
        }

        public int Id { get; set; }
        public string Oximetria { get; set; }
        public string FrecCardiaca { get; set; }
        public string FrecRespiratoria { get; set; }
        public string Temperatura { get; set; }
        public string PresionArterial { get; set; }
        public string Glicemias { get; set; }
        public int IdEnfermero { get; set; }

        public virtual Enfermero IdEnfermeroNavigation { get; set; }
        public virtual ICollection<Diagnostico> Diagnosticos { get; set; }
    }
}
