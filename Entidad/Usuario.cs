using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Usuario
    {
        int idUsuario;
        string nombre;
        string apellido;
        string correo;
        string constraseña;
        bool restablecer;
        bool activo;

        public Usuario(int idUsuario, string nombre, string apellido, string correo, string constraseña, bool restablecer, bool activo)
        {
            this.idUsuario = idUsuario;
            this.nombre = nombre;
            this.apellido = apellido;
            this.correo = correo;
            this.constraseña = constraseña;
            this.restablecer = restablecer;
            this.activo = activo;
        }

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Constraseña { get => constraseña; set => constraseña = value; }
        public bool Restablecer { get => restablecer; set => restablecer = value; }
        public bool Activo { get => activo; set => activo = value; }
    }
}
