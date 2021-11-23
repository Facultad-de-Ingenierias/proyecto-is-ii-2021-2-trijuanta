using L01_Domain.Enfermeros;
using System;
using System.Collections.Generic;
using System.Text;

namespace L02_Persistence
{
    public class RepositorioEnfermeros : IRepositorioEnfermeros
    {
        List<Enfermeros> IRepositorioEnfermeros.GetEnfermeros()
        {
            throw new NotImplementedException();
        }
    }
}
