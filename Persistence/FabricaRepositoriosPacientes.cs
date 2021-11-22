

using L01_Domain.Paciente;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace L02_Persistence
{
    public class FabricaRepositoriosPacientes
    {
        public static IRepositorioPacientes CrearRepositorioPacientes()
        {
            var repo = ConfigurationManager.AppSettings["repository"];

            return repo switch


            {
                "fake" => new RepositorioPacientesFake(),
                "json" => new RepositorioPacientesJSON(),
                _ => null,
            };
        }
    }
}
