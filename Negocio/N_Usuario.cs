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
            mensaje = string.Empty;
            if (DatoUsuario == null) { DatoUsuario = new D_Usuario(); }

            string clave = N_Recursos.GenerarClave();
            string asunto = "Creacion de Cuenta en Iphone Click";
            string mensaje_correo = "<h3>Su cuenta fue creada correctamente</h3></br><p>Su contraseña para acceder es: !clave!</p>";
            mensaje_correo = mensaje_correo.Replace("!clave!", clave);

            bool respuesta = N_Recursos.EnviarCorreo(obj.Correo, asunto, mensaje_correo);
            if (respuesta)
            {
                obj.Constraseña = N_Recursos.ConvertirSha256(clave);
                return DatoUsuario.Registrar(obj, out mensaje);
            }

            mensaje = "No se puede enviar el correo";
            return 0;
        }

        public bool Editar(Usuario obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (DatoUsuario == null) { DatoUsuario = new D_Usuario(); }
            return DatoUsuario.Editar(obj, out mensaje);
        }

        public bool Eliminar(int id, out string mensaje)
        {
            if (DatoUsuario == null) { DatoUsuario = new D_Usuario(); }
            bool respuesta = DatoUsuario.Eliminar(id, out mensaje);
            //if (respuesta) { mensaje = "El usuario fue eliminado correctamente."; }
            return respuesta;

        }
    }



}
