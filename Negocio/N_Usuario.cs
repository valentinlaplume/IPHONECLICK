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
            mensaje = "";

            if(string.IsNullOrEmpty(mensaje))
            {
                mensaje = "insertamos";
            }

            return DatoUsuario.Registrar(obj, out mensaje);
        }

        public bool Editar(Usuario obj, out string mensaje)
        {
            if (DatoUsuario == null) { DatoUsuario = new D_Usuario(); }

            return DatoUsuario.Editar(obj, out mensaje);
        }
    }



}
