using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Categoria
    {
        int id;
        string descripcion;
        DateTime fechaRegistro;
        bool activo;

        public Categoria()
        {
        }

        public Categoria(int id, string descripcion, DateTime fechaRegistro, bool activo)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.FechaRegistro = fechaRegistro;
            this.Activo = activo;
        }

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        public bool Activo { get => activo; set => activo = value; }
    }
}
