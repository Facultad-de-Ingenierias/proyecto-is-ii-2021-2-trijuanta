using L01_Domain.SignosVitales;
using System;
using System.Collections.Generic;
using System.Text;

namespace L02_Persistence
{
    public class RepositorioSignosVitales : IRepositorioSignosVitales
    {
        List<SignosVitales> IRepositorioSignosVitales.GetSignosVitales()
        {
            throw new NotImplementedException();
        }
    }
}