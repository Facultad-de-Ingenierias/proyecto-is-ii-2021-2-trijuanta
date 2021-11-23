using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;

namespace FakeDB
{
    public static class TablaMedico
    {
        private static readonly List<AtributosMedico> medicos = new List<AtributosMedico>();
        class AtributosMedico
        {
            public int documento { get; set; }
            public string nombre { get; set; }
            public string apellidos { get; set; }
            public string direccion { get; set; }
            public string imagen { get; set; }
            public string especialidad { get; set; }
            public string tarjetaProfesional { get; set; }
            

            public AtributosMedico(int id)
            {
                documento = 10000 + id;
                nombre = "NombreMedicoJSON" + id;
                apellidos = "ApellidosMedicoEPS" + id;
                direccion = "direcion MedicoEPS" + id;
                imagen = "link.image";
                especialidad = "especialidadMedico" + id;
                tarjetaProfesional = "tarjetaProfesional Medico"+ id;
            }

            public String ToJSON()
            {
                return System.Text.Json.JsonSerializer.Serialize(this);
            }
                           
        }

      
        public static void InstanciarMedico(int numeroMedico)
        {
            for (int i = 0; i < numeroMedico; i++)
            {
                medicos.Add(new AtributosMedico(i));
            }
        }

        public static String ToJSON()
        {
            if (medicos.Count == 0)
            {
                InstanciarMedico(10);
            }
            var options = new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true
            };

            return System.Text.Json.JsonSerializer.Serialize(medicos, options);
        }

    
     }
}
