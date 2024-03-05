using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace MvcCoreCSRF.Controllers
{
    public class TiendaController : Controller
    {
        public IActionResult Productos()
        {
            //comprobamos si existe user
            if (HttpContext.Session.GetString("USUARIO") == null)
            {
                return RedirectToAction("AccesoDenegado", "Managed");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Productos(
            string direccion, string[] producto)
        {
            //comprobamos si existe user antes de hacer la compra
            if(HttpContext.Session.GetString("USUARIO") == null)
            {
                return RedirectToAction("AccesoDenegado", "Managed");
            }
            else
            {
                TempData["DIRECCION"] = direccion;
                TempData["PRODUCTOS"] = producto;
                return RedirectToAction("PedidoFinal");
            }
            
        }

        public IActionResult PedidoFinal()
        {
            string[] productos = TempData["PRODUCTOS"] as string[];
            ViewData["DIRECCION"] = TempData["DIRECCION"].ToString();
            return View(productos);
        }
    }
}
