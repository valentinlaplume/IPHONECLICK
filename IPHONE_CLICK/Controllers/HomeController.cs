using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IPHONE_CLICK.Controllers
{
    public class HomeController : Controller
    {
        N_Usuario nUsuario;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Usuarios()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarUsuarios()
        {
            if(nUsuario == null) { nUsuario = new N_Usuario(); }

            List<Usuario> lista = nUsuario.GetUsuarios();

            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
    }
}