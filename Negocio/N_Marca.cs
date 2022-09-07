using Dato;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Negocio
{
    public class N_Marca
    {
        D_Marca DatoMarca;

        public List<Marca> GetMarcas()
        {
            if (DatoMarca == null) { DatoMarca = new D_Marca(); }

            return DatoMarca.GetMarcas();
        }
        public int Registrar(Marca obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (DatoMarca == null) { DatoMarca = new D_Marca(); }
            return DatoMarca.Registrar(obj, out mensaje);
        }

        public bool Editar(Marca obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (DatoMarca == null) { DatoMarca = new D_Marca(); }
            return DatoMarca.Editar(obj, out mensaje);
        }

        public bool Eliminar(int id, out string mensaje)
        {
            if (DatoMarca == null) { DatoMarca = new D_Marca(); }
            bool respuesta = DatoMarca.Eliminar(id, out mensaje);
            //if (respuesta) { mensaje = "El Marca fue eliminado correctamente."; }
            return respuesta;

        }
    }
}
