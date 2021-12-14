using dotnet.Models;
using dotnet.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly TrijuantaBDContext _context;

        public UsuariosController(TrijuantaBDContext context)
        {
            _context = context;
        }

        // GET: Cuentum/Details/5
        [HttpPost]
        public ActionResult GetUsuarios(string User, string Pass)
        {

            var cuentum = _context.Cuenta.Where(s => s.Usuario == User && s.Contrasena == Pass);
            
            if (cuentum.Any())
            {
                if (cuentum.Where(s => s.Usuario == User.Trim() && s.Contrasena == Pass.Trim()).Any())
                {
                    return Json(new { status = true, message = "Bienvenido" });
                }
                else
                {
                    return Json(new { status = false, message = "Contraseña incorrecta" });
                }
            }
            else
            {
                return Json(new { status = false, message = "Usuario incorrecto" });
            }
        }
    }
}
