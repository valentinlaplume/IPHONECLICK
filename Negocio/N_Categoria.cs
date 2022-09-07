using Dato;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class N_Categoria
    {
        D_Categoria DatoCategoria;

        public List<Categoria> GetCategorias()
        {
            if (DatoCategoria == null) { DatoCategoria = new D_Categoria(); }

            return DatoCategoria.GetCategorias();
        }
        public int Registrar(Categoria obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (DatoCategoria == null) { DatoCategoria = new D_Categoria(); }
            return DatoCategoria.Registrar(obj, out mensaje);
        }

        public bool Editar(Categoria obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (DatoCategoria == null) { DatoCategoria = new D_Categoria(); }
            return DatoCategoria.Editar(obj, out mensaje);
        }

        public bool Eliminar(int id, out string mensaje)
        {
            if (DatoCategoria == null) { DatoCategoria = new D_Categoria(); }
            bool respuesta = DatoCategoria.Eliminar(id, out mensaje);
            //if (respuesta) { mensaje = "El Categoria fue eliminado correctamente."; }
            return respuesta;

        }
    }

}
