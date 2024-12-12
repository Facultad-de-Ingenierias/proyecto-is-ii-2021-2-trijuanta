using L01_Domain.Administrativos;
using System;
using System.Collections.Generic;
using System.Text;

namespace L02_Persistence
{
    public class RepositorioAdministrativos : IRepositorioAdministrativos
    {
        List<Administrativos> IRepositorioAdministrativos.GetAdministrativos()
        {
            throw new NotImplementedException();
        }
    }
}