using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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

        [Required]
        [MaxLength(255)]
        [MinLength(5)]
        public string Direccion { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        public string Latitud { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        public string Longitud { get; set; }

        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
