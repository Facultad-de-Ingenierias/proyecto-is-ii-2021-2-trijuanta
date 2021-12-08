using L01_Domain.DiagnosticoXPaciente;
using System;
using System.Collections.Generic;
using System.Text;

namespace L02_Persistence
{
    public class RepositorioDiagnosticoXPaciente : IRepositorioDiagnosticoXPaciente
    {
        List<DiagnosticoXPaciente> IRepositorioDiagnosticoXPaciente.GetDiagnosticoXPaciente()
        {
            throw new NotImplementedException();
        }
    }
}