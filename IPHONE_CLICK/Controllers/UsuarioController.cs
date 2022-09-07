using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IPHONE_CLICK.Controllers
{
    public class UsuarioController : Controller
    {
        N_Usuario nUsuario;

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarUsuarios()
        {
            if (nUsuario == null) { nUsuario = new N_Usuario(); }

            List<Usuario> lista = nUsuario.GetUsuarios();

            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarUsuario(Usuario obj)
        {
            object resultado;
            string mensaje = string.Empty;
            if (nUsuario == null) { nUsuario = new N_Usuario(); }

            if (obj.Id == 0)
            { // Nuevo
                resultado = nUsuario.Registrar(obj, out mensaje);
            }
            else
            { // Editar
                resultado = nUsuario.Editar(obj, out mensaje);
            }

            return Json(new
            {
                resultado = resultado,
                mensaje = mensaje
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarUsuario(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;
            if (nUsuario == null) { nUsuario = new N_Usuario(); }

            respuesta = nUsuario.Eliminar(id, out mensaje);

            return Json(new
            {
                resultado = respuesta,
                mensaje = mensaje
            }, JsonRequestBehavior.AllowGet);
        }

    }
}