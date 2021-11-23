using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;

namespace FakeDB
{
    public static class TablaEnfermero
    {
        private static readonly List<AtributosEnfermero> enfermeros = new List<AtributosEnfermero>();
        class AtributosEnfermero
        {
            public int documento { get; set; }
            public string nombre { get; set; }
            public string apellidos { get; set; }
            public string direccion { get; set; }
            public string imagen { get; set; }
            public string especialidad { get; set; }
            public string idEmpresa { get; set; }
            

            public AtributosEnfermero(int id)
            {
                documento = 10000 + id;
                nombre = "NombreMedicoJSON" + id;
                apellidos = "ApellidosMedicoEPS" + id;
                direccion = "direcion MedicoEPS" + id;
                imagen = "link.image";
                especialidad = "especialidadMedico" + id;
                idEmpresa = "identificacion empresa Medico"+ id;
            }

            public String ToJSON()
            {
                return System.Text.Json.JsonSerializer.Serialize(this);
            }
                           
        }

      
        public static void InstanciarEnfermero(int numeroEnfermero)
        {
            for (int i = 0; i < numeroEnfermero; i++)
            {
                enfermeros.Add(new AtributosEnfermero(i));
            }
        }

        public static String ToJSON()
        {
            if (enfermeros.Count == 0)
            {
                InstanciarEnfermero(10);
            }
            var options = new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true
            };

            return System.Text.Json.JsonSerializer.Serialize(medicos, options);
        }

    
     }
}
