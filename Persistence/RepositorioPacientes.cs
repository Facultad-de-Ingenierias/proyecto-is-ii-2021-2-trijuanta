using L01_Domain.Pacientes;
using System;
using System.Collections.Generic;
using System.Text;

namespace L02_Persistence
{
    public class RepositorioPacientes : IRepositorioPacientes
    {
        List<Pacientes> IRepositorioPacientes.GetPacientes()
        {
            throw new NotImplementedException();
        }
    }
}