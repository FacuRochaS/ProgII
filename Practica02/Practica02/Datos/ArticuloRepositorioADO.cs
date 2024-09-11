using Microsoft.Extensions.Configuration.UserSecrets;
using Practica02.Models;
using System.Data;
using System.Data.SqlClient;
using Practica02.Utilidades;


namespace Practica02.Datos
{
    public class ArticuloRepositorioADO : IArticuloRepositorio
    {
        private SqlConnection _conn;

        public ArticuloRepositorioADO()
        {
            _conn = new SqlConnection(Properties.Resources.Cadena);
        }

        public bool Borrar(int id)
        {
            var parametros = new List<ParameterSQL>();
            parametros.Add(new ParameterSQL("@id_articulo", id));
            int filas = DataHelper.GetInstance().ExecuteSPDML("SP_Eliminar_Articulo", parametros);
            return filas == 1;
        }




        public bool Guardar(Articulo articulo)
        {
            bool resultado = true;
            string querry = "SP_Guardar_Articulo";
            
            try
            {
                if (articulo != null)
                {
                    _conn.Open();
                    var cmd = new SqlCommand(querry, _conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", articulo.Nombre);
                    cmd.Parameters.AddWithValue("@precio", articulo.Precio);



                    resultado = cmd.ExecuteNonQuery() == 1;


                }

            }
            catch (SqlException ex)
            {
                resultado = false;
            }
            finally
            {
                if (_conn != null && _conn.State == ConnectionState.Open)
                {
                    _conn.Close();
                }

            }


            return resultado;



        }






        public Articulo Obtener(int id)
        {
            var parametros = new List<ParameterSQL>();
            parametros.Add(new ParameterSQL("@id_articulo", id));
            DataTable tabla = DataHelper.GetInstance().ExecuteSPQuery("SP_Buscar_Articulo", parametros);

            if (tabla != null && tabla.Rows.Count == 1)
            {
                DataRow fila = tabla.Rows[0];
                int ide = Convert.ToInt32(fila["id_articulo"]);
                string nombre = Convert.ToString(fila["nombre"]);
                double precio = Convert.ToDouble(fila["precio"]);

                Articulo articulo = new Articulo()
                {
                    Id = ide,
                    Nombre = nombre,
                    Precio = precio,
                };


                return articulo;




            }
            return null;
        }

        public List<Articulo> ObtenerList()
        {
            List<Articulo> articulos = new List<Articulo>();
            var helper = DataHelper.GetInstance();
            var tabla = helper.ExecuteSPQuery("SP_Recuperar_Articulos", null);
            foreach (DataRow fila in tabla.Rows)
            {

                int ide = Convert.ToInt32(fila["id_articulo"]);
                string nombre = Convert.ToString(fila["nombre"]);
                double precio = Convert.ToDouble(fila["precio"]);

                Articulo articulo = new Articulo()
                {
                    Id = ide,
                    Nombre = nombre,
                    Precio = precio,
                };
                articulos.Add(articulo);

            }
            return articulos;
        }






        




        





        
    }
}
