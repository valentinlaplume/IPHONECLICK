using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IPHONE_CLICK.Controllers
{
    public class CategoriaController : Controller
    {
        N_Categoria nCategoria;

        // GET: Categoria
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarCategorias()
        {
            if (nCategoria == null) { nCategoria = new N_Categoria(); }

            List<Categoria> lista = nCategoria.GetCategorias();

            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarCategoria(Categoria obj)
        {
            object resultado;
            string mensaje = string.Empty;
            if (nCategoria == null) { nCategoria = new N_Categoria(); }

            if (obj.Id == 0) { // Nuevo 
                resultado = nCategoria.Registrar(obj, out mensaje);
            }
            else { // editar 
                resultado = nCategoria.Editar(obj, out mensaje);
            }

            return Json(new
            {
                resultado = resultado,
                mensaje = mensaje
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarCategoria(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;
            if (nCategoria == null) { nCategoria = new N_Categoria(); }

            respuesta = nCategoria.Eliminar(id, out mensaje);

            return Json(new
            {
                resultado = respuesta,
                mensaje = mensaje
            }, JsonRequestBehavior.AllowGet);
        }
    }
}