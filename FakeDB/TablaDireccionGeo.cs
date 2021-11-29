using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;

namespace FakeDB
{
    public static class TablaDireccionGeo
    {
        private static readonly List<AtributosDireccionGeo> direccionGeo = new List<AtributosDireccionGeo>();
        class AtributosDireccionGeo
        {
            public int id { get; set; }
            public string pais { get; set; }
            public string departamento { get; set; }
            public string municipio { get; set; }
            public decimal latitud  { get; set; }
            public decimal longitud  { get; set; }

            public AtributosDireccionGeo(int id)
            {
                id = 10000 + id;
                pais = "PaisDireccionGeo" + id;
                departamento = "DepartamentoDireccionGeo" + id;
                municipio = "MunicipioDireccionGeo" + id;
                latitud = "LatitudDireccionGeo" + id;
                longitud = "LongitudDireccionGeo" + id;
            }

            public String ToJSON()
            {
                return System.Text.Json.JsonSerializer.Serialize(this);
            }
                           
        }

      
        public static void InstanciarDireccionGeo(int numeroDireccionGeo)
        {
            for (int i = 0; i < numeroDireccionGeo; i++)
            {
                direccionGeo.Add(new AtributosDireccionGeo(i));
            }
        }

        public static String ToJSON()
        {
            if (direccionGeo.Count == 0)
            {
                InstanciarDireccionGeo(10);
            }
            var options = new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true
            };

            return System.Text.Json.JsonSerializer.Serialize(direccionGeo, options);
        }

    
     }
}