using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarea_1._5_facturacion.Datos.utilidades;
using tarea_1._5_facturacion.Dominio;
using tarea_Banco.datos.utilidades;

namespace tarea_1._5_facturacion.Datos.RepoArticulos
{
    public class ArticulosRepositorioADO : IArticulosRepositorio
    {

        private SqlConnection _conn;

        public ArticulosRepositorioADO()
        {
            _conn = new SqlConnection(Properties.Resources.Cadena);
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
