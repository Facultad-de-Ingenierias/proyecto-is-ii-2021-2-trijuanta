using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;

namespace FakeDB
{
    public static class TablaAdministrativo
    {
        private static readonly List<AtributosAdministrativo> administrativos = new List<AtributosAdministrativo>();
        class AtributosAdministrativo
        {
            public int documento { get; set; }
            public string nombre { get; set; }
            public string apellidos { get; set; }
            public string contraseña { get; set; }


            public AtributosAdministrativo(int id)
            {
                documento = 10000 + id;
                nombre = "NombreAdministrativoJSON" + id;
                apellidos = "ApellidosAdministrativoEPS" + id;
                contraseña = "contraseñaAdministrativoEPS" + id;
            }

            public String ToJSON()
            {
                return System.Text.Json.JsonSerializer.Serialize(this);
            }
                           
        }

      
        public static void InstanciarAdministrativo(int numeroAdministrativo)
        {
            for (int i = 0; i < numeroAdministrativo; i++)
            {
                administrativos.Add(new AtributosAdministrativo(i));
            }
        }

        public static String ToJSON()
        {
            if (administrativos.Count == 0)
            {
                InstanciarAdministrativo(10);
            }
            var options = new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true
            };

            return System.Text.Json.JsonSerializer.Serialize(administrativo, options);
        }

    
     }
}