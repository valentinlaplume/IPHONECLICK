using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Dato
{
    public class D_Categoria
    {

        SqlConnection Conexion;
        SqlCommand Comando; // lleva la consulta
        SqlDataReader Lector;

        public D_Categoria()
        {
            Conexion = new SqlConnection();
            Conexion.ConnectionString = "Data Source=DESKTOP-SI4GNH1; Database=dbIphoneClick; Trusted_Connection=True;";
            //"Data Source=190.210.161.90;Integrated Security=false;User ID=alumno;Password=alumno;Initial Catalog=UTN";

            Comando = new SqlCommand();
            //Comando.CommandType = CommandType.Text; // que tipo de query vas a ejecutar
            //Comando.CommandType = CommandType.StoredProcedure;
            Comando.Connection = Conexion; // se agrega a donde se conecta, podes cambiar la Conexion
        }

        public List<Categoria> GetCategorias()
        {
            try
            {
                List<Categoria> listaLeida = new List<Categoria>(); // aca instancio la lista de lo que quiero leer
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = "SELECT Id,Descripcion,FechaRegistro,Estado FROM Categoria";

                if (Conexion.State != ConnectionState.Open) { Conexion.Open(); }

                Lector = Comando.ExecuteReader();
                while (Lector.Read())
                {
                    listaLeida.Add(new Categoria(Lector.GetInt32(0),
                                            Lector.GetString(1),
                                            Lector.GetDateTime(2),
                                            Lector.GetBoolean(3))
                                            );
                }

                return listaLeida;
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al leer datos. " + ex.Message);
            }
            finally
            {
                Conexion.Close();
            }
        }

        public int Registrar(Categoria obj, out string mensaje)
        {
            int idAutogenerado = 0;
            mensaje = "";
            try
            {
                Comando.Parameters.Clear();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "sp_RegistrarCategoria";

                if (Conexion.State != ConnectionState.Open) { Conexion.Open(); }

                Comando.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                Comando.Parameters.AddWithValue("@Estado", obj.Activo);
                //Comando.Parameters.AddWithValue("@FechaRegistro", obj.FechaRegistro);

                Comando.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("Mensaje", SqlDbType.NVarChar, 500).Direction = ParameterDirection.Output;

                Comando.ExecuteNonQuery();

                idAutogenerado = Convert.ToInt32(Comando.Parameters["Resultado"].Value);
                mensaje = Comando.Parameters["Mensaje"].Value.ToString();

                return idAutogenerado;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                throw new Exception(ex.Message);
            }
            finally
            {
                Conexion.Close();
            }
        }

        public bool Editar(Categoria obj, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;
            try
            {
                Comando.Parameters.Clear();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "sp_EditarCategoria";

                if (Conexion.State != ConnectionState.Open) { Conexion.Open(); }

                Comando.Parameters.AddWithValue("@Id", obj.Id);
                Comando.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                Comando.Parameters.AddWithValue("@Estado", obj.Activo);
                //Comando.Parameters.AddWithValue("@FechaRegistro", obj.FechaRegistro);

                Comando.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("Mensaje", SqlDbType.NVarChar, 500).Direction = ParameterDirection.Output;

                Comando.ExecuteNonQuery();

                resultado = Convert.ToBoolean(Comando.Parameters["Resultado"].Value);
                mensaje = Comando.Parameters["Mensaje"].Value.ToString();

                return resultado;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                throw new Exception(ex.Message);
            }
            finally
            {
                Conexion.Close();
            }
        }

        public bool Eliminar(int id, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;
            try
            {
                Comando.Parameters.Clear();
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = "DELETE TOP (1) FROM CATEGORIA WHERE Id = @id";

                if (Conexion.State != ConnectionState.Open) { Conexion.Open(); }

                Comando.Parameters.AddWithValue("@id", id);

                resultado = Comando.ExecuteNonQuery() > 0 ? true : false;

                return resultado;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                throw new Exception(ex.Message);
            }
            finally
            {
                Conexion.Close();
            }
        }




    }
}
