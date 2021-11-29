using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;

namespace FakeDB
{
    public static class TablaDiagnosticoXPaciente
    {
        private static readonly List<AtributosDiagnosticoXPaciente> DiagnosticoXPaciente = new List<AtributosDiagnosticoXPaciente>();
        class AtributosDiagnosticoXPaciente
        {
            public int idDiagnostico { get;}
            public int idPaciente { get;}
            public int idMedico { get;}
            public string sugerencia { get; set;}
            public string antecedentes {get; set;}
            public string saludSexual {get; set;}
            public DateTime fecha {get; set;}
            public int idSignosVitales{get;}

            public AtributosDiagnosticoXPaciente(int id)
            {
                idDiagnostico = 10000 + id;
                idPaciente = 20000 + id;
                idPaciente = 30000 + id;
                sugerencia = "sugerencia";
                antecedentes = "antecedentes";
                saludSexual = "saludSexual";
                fecha = "2019-01-06T17:16:40";
                idSignosVitales = 30000 + id;
            }

            public String ToJSON()
            {
                return System.Text.Json.JsonSerializer.Serialize(this);
            }        
        }

        
        public static void InstanciarDiagnosticoXPaciente(int numeroDiagnosticoXPaciente)
        {
            for (int i = 0; i < numeroDiagnosticoXPaciente; i++)
            {
                DiagnosticoXPaciente.Add(new AtributosDiagnosticoXPaciente(i));
            }
        }

        public static String ToJSON()
        {
            if (DiagnosticoXPaciente.Count == 0)
            {
                InstanciarDiagnosticoXPaciente(10);
            }
            var options = new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true
            };

            return System.Text.Json.JsonSerializer.Serialize(DiagnosticoXPaciente, options);
        }


    }
}