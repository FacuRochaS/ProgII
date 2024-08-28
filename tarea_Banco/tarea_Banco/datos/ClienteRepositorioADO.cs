using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarea_Banco.datos.utilidades;
using tarea_Banco.dominio;

namespace tarea_Banco.datos
{
    public class ClienteRepositorioADO : IClienteRepositorio
    {
        private SqlConnection _conn;

        public ClienteRepositorioADO()
        {
            _conn = new SqlConnection(Properties.Resources.Cadena);
        }

        public bool Borrar(int id)
        {
            var parametros = new List<ParameterSQL>();
            parametros.Add(new ParameterSQL("@id_cliente", id));
            int filas = DataHelper.GetInstance().ExecuteSPDML("SP_Eliminar_Cliente",parametros);
            return filas == 1;
        }

        public bool Guardar(Cliente cliente)
        {
            bool resultado = true;
            string querry = "SP_Guardar_Cliente";
            try
            {
                if(cliente != null)
                {
                    _conn.Open();
                    var cmd = new SqlCommand(querry, _conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", cliente.Nombre );
                    cmd.Parameters.AddWithValue("@apellido", cliente.Apellido);
                    cmd.Parameters.AddWithValue("@dni", cliente.Dni);
                    resultado = cmd.ExecuteNonQuery() == 1;
                }
                
            }
            catch (SqlException ex)
            {
                resultado = false;
            }
            finally
            {
                if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
                {
                    _conn.Close();
                }
            }
            return resultado;

        }

        public Cliente Obtener(int id)
        {
            var parametros = new List<ParameterSQL>();
            parametros.Add(new ParameterSQL("@id_cliente", id));
            DataTable tabla = DataHelper.GetInstance().ExecuteSPQuery("SP_Buscar_Cliente", parametros);
            
            if (tabla != null && tabla.Rows.Count == 1)
            {
                DataRow fila = tabla.Rows[0];
                int ide = Convert.ToInt32(fila["id_cliente"]);
                string nombre = fila["nombre"].ToString();
                string apellido = fila["apellido"].ToString();
                int dni = Convert.ToInt32(fila["dni"]);
                Cliente cliente = new Cliente()
                {

                    Id = ide,
                    Nombre = nombre,
                    Apellido = apellido,
                    Dni = dni


                };
                return cliente;




            }
            return null;
        }

        public List<Cliente> ObtenerList()
        {
            List<Cliente> cli = new List<Cliente>();
            var helper = DataHelper.GetInstance();
            var tabla = helper.ExecuteSPQuery("SP_Recuperar_Clientes", null);
            foreach(DataRow fila in tabla.Rows)
            {
                int id = Convert.ToInt32(fila["id_cliente"]);
                string nombre = fila["nombre"].ToString();
                string apellido = fila["apellido"].ToString();
                int dni = Convert.ToInt32(fila["dni"]);

                Cliente cliente = new Cliente()
                {

                    Id = id,
                    Nombre = nombre,
                    Apellido = apellido,
                    Dni = dni


                };
                cli.Add(cliente);

            }
            return cli;
        }
    }
}
