using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;

namespace FakeDB
{
    public static class TablaSignosVitales
    {
        private static readonly List<AtributosSignosVitales> signosVitales = new List<AtributosSignosVitales>();
        class AtributosSignosVitales
        {
            public int idSignosVitales {get; set;}
            public int oximetria {get;set;}
            public int frecCardiaca {get; set;}
            public int frecRespiratoria {get; set;}
            public int temperatura {get; set;}
            public int presionArterial {get; set;}
            public int glicemias {get; set;}

            public AtributosSignosVitales(int id)
            {
                idSignosVitales = 10000 + id;
                oximetria = "Oximetria" + id;
                frecCardiaca = "FrecCardiaca" + id;
                frecRespiratoria = "FrecRespiratoria" + id;
                temperatura = "Temperatura" + id;
                presionArterial = "PresionArterial" + id;
                glicemias = "Glicemias" + id;
            }

            public String ToJSON()
            {
                return System.Text.Json.JsonSerializer.Serialize(this);
            }
        }

        public static void InstanciarSignosVitales(int sigVitales)
        {
            for (int i = 0; i < sigVitales; i++)
            {
                signosVitales.Add(new AtributosSignosVitales(i));
            }
        }

        public static String ToJson()
        {
            if(signosVitales.Count == 0)
            {
                InstanciarSignosVitales(10);
            }
            var options = new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true
            };

            return System.Text.Json.JsonSerializer.Serialize(signosVitales, options);
        }
    }
}