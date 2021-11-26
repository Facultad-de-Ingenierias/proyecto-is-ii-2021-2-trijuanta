using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;

namespace FakeDB
{
    public static class TablaFamiliar
    {
        private static readonly List<AtributosFamiliar> familiares = new List<AtributosFamiliar>();
        class AtributosFamiliar
        {   
            public string tipoDocumento { get; set; }
            public int documento { get; set; }
            public string nombre { get; set; }
            public string apellidos { get; set; }
            public int telefono { get; set; }
            public string direccion { get; set; }
            public string correo { get; set; }
    
            

            public AtributosFamiliar(int id)
            {
                tipoDocumento = "TipoDocumento" + id;
                documento = 10000 + id;
                nombre = "NombreFamiliarJSON" + id;
                apellidos = "ApellidosFamiliar" + id;
                telefono = "TelefonoFamiliar" + id;
                direccion = "DirecionFamiliar" + id;
                correo = "CorreoFamiliar" + id;
               
            }

            public String ToJSON()
            {
                return System.Text.Json.JsonSerializer.Serialize(this);
            }
                           
        }

      
        public static void InstanciarFamiliar(int numeroFamiliar)
        {
            for (int i = 0; i < numeroFamiliar; i++)
            {
                familiares.Add(new AtributosFamiliar(i));
            }
        }

        public static String ToJSON()
        {
            if (familiares.Count == 0)
            {
                InstanciarFamiliar(10);
            }
            var options = new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true
            };

            return System.Text.Json.JsonSerializer.Serialize(familiares, options);
        }

    
     }
}
