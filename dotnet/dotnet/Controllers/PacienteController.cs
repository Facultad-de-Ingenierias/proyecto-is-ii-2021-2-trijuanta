using dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet.Controllers
{
    public class PacienteController : Controller
    {
       
        public IActionResult RegistrarPaciente()
        {
            List<Paciente> lista = new List<Paciente>();

            using (var db = new Models.DB.TrijuantaBDContext())
            {
                lista = (from d in db.Pacientes
                        select new Paciente
                        {
                           primerNombre = d.PrimerNombre,
                           segundoNombre = d.SegundoNombre,
                           primerApellido = d.PrimerApellido,
                           segundoApellido = d.SegundoApellido
                           

                        }).ToList();    


            }
            return View(lista);
        }
    }
}
