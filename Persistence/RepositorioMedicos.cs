using L01_Domain.medicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace L02_Persistence
{
    public class RepositorioMedicos : IRepositorioMedicos
    {
        List<Medicos> IRepositorioMedicos.GetMedicos()
        {
            throw new NotImplementedException();
        }
    }
}
