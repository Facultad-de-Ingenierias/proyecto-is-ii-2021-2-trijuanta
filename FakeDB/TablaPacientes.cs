using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;

namespace FakeDB
{
    public static class TablaPacientes
    {
        private static readonly List<AtributosPaciente> pacientes = new List<AtributosPaciente>();
        class AtributosPaciente
        {
            public int DocumentoId { get; set; }
            public short TipoDocumento { get; set; }
            public string Nombre { get; set; }
            public string Apellidos { get; set; }
            public string NombreCompleto { get { return Nombre + " " + Apellidos; } }
            public string Telefono1 { get; set; }
            public string Telefono2 { get; set; }
            public short TipoSexo { get; set; }
            public string FechaNacimiento { get; set; }
            public string CorreoElectronico { get; set; }
            public string Direccion { get; set; }
            public string Departamento { get; set; }
            public string Municipio { get; set; }
            public short EstadoCivil { get; set; }
            public string Ocupacion { get; set; }
            public string Religion { get; set; }
            public short GradoEscolaridad { get; set; }
            public short TipoSanguineo { get; set; }
            public string EPS { get; set; }

            public AtributosPaciente(int id)
            {
                Random random = new Random();
                DocumentoId = 10000 + id;
                TipoDocumento = (short)random.Next(1, 4);
                Nombre = "NombrePacienteJSON" + id;
                Apellidos = "ApellidosPacienteEPS" + id;
                Telefono1 = "Telefono1PacienteEPS" + id;
                Telefono2 = "Telefono2PacienteEPS" + id;
                TipoSexo = (short)random.Next(1, 2);
                FechaNacimiento = "2019-01-06T17:16:40";
                CorreoElectronico = "paciente" + id + "@is.edu";
                Direccion = "direcion pacienteEPS" + id;
                Departamento = "COD_Dpto" + id;
                Municipio = "COD_Muni" + id;
                EstadoCivil = (short)random.Next(1, 6);
                Ocupacion = "Ocupación" + id;
                Religion = "Religion" + id;
                GradoEscolaridad = (short)random.Next(1, 4);
                TipoSanguineo = (short)random.Next(1, 8);
                EPS = "EPS" + (short)random.Next(1, 8);
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
