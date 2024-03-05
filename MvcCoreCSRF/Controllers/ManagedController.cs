using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MvcCoreCSRF.Controllers
{
    public class ManagedController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string usuario, string password)
        {
            if (usuario.ToLower() == "admin" &&
                password.ToLower() == "admin") 
            {
                //almacenamos en session el usuario validado
                HttpContext.Session.SetString("USUARIO", usuario);
                return RedirectToAction("Productos", "Tienda");
            }
            else
            {
                ViewData["MENSAJE"] = "Datos incorrectos";
                return View();
            }
        }

        public IActionResult AccesoDenegado()
        {
            return View();
        }
    }
}
