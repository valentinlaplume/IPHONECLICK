using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IPHONE_CLICK.Controllers
{
    public class MarcaController : Controller
    {
        N_Marca nMarca;

        // GET: Marca
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarMarcas()
        {
            if (nMarca == null) { nMarca = new N_Marca(); }

            List<Marca> lista = nMarca.GetMarcas();

            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarMarca(Marca obj)
        {
            object resultado;
            string mensaje = string.Empty;
            if (nMarca == null) { nMarca = new N_Marca(); }

            if (obj.Id == 0)
            { // Nuevo 
                resultado = nMarca.Registrar(obj, out mensaje);
            }
            else
            { // editar 
                resultado = nMarca.Editar(obj, out mensaje);
            }

            return Json(new
            {
                resultado = resultado,
                mensaje = mensaje
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarMarca(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;
            if (nMarca == null) { nMarca = new N_Marca(); }

            respuesta = nMarca.Eliminar(id, out mensaje);

            return Json(new
            {
                resultado = respuesta,
                mensaje = mensaje
            }, JsonRequestBehavior.AllowGet);
        }
    }
}