using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;

namespace FakeDB
{
    public static class TablaPaciente
    {
        private static readonly List<AtributosPaciente> pacientes = new List<AtributosPaciente>();
        class AtributosPaciente
        {
            public int documento { get; set; }
            public string primerNombre { get; set; }
            public string segundoNombre { get; set; }
            public string NombreCompleto { get { return primerNombre + " " + segundoNombre; } }
            public string primerApellido { get; set; }
            public string segundoApellido { get; set; }
            public string NombreApellidoCompleto { get { return NombreCompleto + " " + primerApellido + " " + segundoApellido; } }
            public string idDireccionGeo { get; set; }
            public int idFamiliar { get; set; }
            public string idHistorial { get; set; }
            public short rh { get; set; }
            public string fechaNacimiento { get; set; }
            public short sexo { get; set; }
            public string telefono { get; set; }
            public string correoElectronico { get; set; }

            public AtributosPaciente(int id)
            {
                Random random = new Random();
                documento = 10000 + id;
                primerNombre = "primerNombrePacienteJSON" + id;
                segundoNombre = "segundoNombrePacienteJSON" + id;
                primerApellido = "primerApellidoPacienteEPS" + id;
                segundoApellido = "segundoApellidoPacienteEPS" + id;
                idDireccionGeo = 10000 + id;
                idFamiliar = 10000 + id;
                idHistorial = 10000 + id;
                rh = (short)random.Next(1, 8);
                fechaNacimiento = "2019-01-06T17:16:40";
                sexo = (short)random.Next(1, 2);
                telefono = "telefonoPacienteEPS" + id;
                correoElectronico = "paciente" + id + "@is.edu";
            }

            public String ToJSON()
            {
                return System.Text.Json.JsonSerializer.Serialize(this);
            }
                           
        }

      
        public static void InstanciarPacientes(int numeroPacientes)
        {
            for (int i = 0; i < numeroPacientes; i++)
            {
                pacientes.Add(new AtributosPaciente(i));
             
            }
        }

        public static String ToJSON()
        {
            if (pacientes.Count == 0)
            {
                InstanciarPacientes(10);
            }
            var options = new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true
            };

            return System.Text.Json.JsonSerializer.Serialize(pacientes, options);
        }

    
     }
}
