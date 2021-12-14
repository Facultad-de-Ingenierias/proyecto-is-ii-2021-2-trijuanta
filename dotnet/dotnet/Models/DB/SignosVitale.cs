using System;
using System.Collections.Generic;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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

        [MaxLength(10)]
        public string Oximetria { get; set; }

        [MaxLength(10)]
        public string FrecCardiaca { get; set; }

        [MaxLength(10)]
        public string FrecRespiratoria { get; set; }

        [MaxLength(10)]
        public string Temperatura { get; set; }

        [MaxLength(10)]
        public string PresionArterial { get; set; }
        
        [MaxLength(10)]
        public string Glicemias { get; set; }

        [DisplayName("Enfermero Responsable")]
        [Required]
        public int IdEnfermero { get; set; }

        public virtual Enfermero IdEnfermeroNavigation { get; set; }
        public virtual ICollection<Diagnostico> Diagnosticos { get; set; }
    }
}
