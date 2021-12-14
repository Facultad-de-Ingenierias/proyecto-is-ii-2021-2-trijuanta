using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace dotnet.Models.DB
{
    public partial class Familiar
    {
        public Familiar()
        {
            FamiliarXpacientes = new HashSet<FamiliarXpaciente>();
            IdCuenta = 1;
        }

        public int Id { get; set; }

        [DisplayName("T.D")]
        [Required]
        [MaxLength(4)]
        public string TipoDocumento { get; set; }

        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        public string Documento { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nombres { get; set; }

        [Required]
        [MaxLength(30)]
        public string Apellidos { get; set; }

        [MaxLength(1)]
        [MinLength(1)]
        [Required]
        public string Sexo { get; set; }

        [MaxLength(13)]
        public string Celular { get; set; }

        [MaxLength(100)]
        [MinLength(5)]
        [Required]
        [EmailAddress]
        public string Correo { get; set; }
        public int IdCuenta { get; set; }

        public virtual Cuentum IdCuentaNavigation { get; set; }
        public virtual ICollection<FamiliarXpaciente> FamiliarXpacientes { get; set; }
    }
}
