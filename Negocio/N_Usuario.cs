using Dato;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class N_Usuario
    {
        D_Usuario DatoUsuario;

        public List<Usuario> GetUsuarios()
        {
            if (DatoUsuario == null) { DatoUsuario = new D_Usuario(); }

            return DatoUsuario.GetUsuarios();
        }
        public int Registrar(Usuario obj, out string mensaje)
        {
            if (DatoUsuario == null) { DatoUsuario = new D_Usuario(); }
            mensaje = string.Empty;

            string clave = "clave123";
            obj.Constraseña = N_Recursos.ConvertirSha256(clave);

            return DatoUsuario.Registrar(obj, out mensaje);
        }

        public bool Editar(Usuario obj, out string mensaje)
        {
            if (DatoUsuario == null) { DatoUsuario = new D_Usuario(); }
            mensaje = string.Empty;

            return DatoUsuario.Editar(obj, out mensaje);
        }

        public bool Eliminar(int id, out string mensaje)
        {
            return DatoUsuario.Eliminar(id, out mensaje);

        }
    }



}
