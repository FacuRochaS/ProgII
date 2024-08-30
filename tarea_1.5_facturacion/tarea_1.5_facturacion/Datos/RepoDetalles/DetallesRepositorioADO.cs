using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarea_1._5_facturacion.Datos.utilidades;
using tarea_1._5_facturacion.Dominio;
using tarea_1._5_facturacion.Servicios;
using tarea_Banco.datos.utilidades;

namespace tarea_1._5_facturacion.Datos.RepoDetalles
{
    public class DetallesRepositorioADO : IDetallesRepositorio
    {

        private SqlConnection _conn;

        public DetallesRepositorioADO()
        {
            _conn = new SqlConnection(Properties.Resources.Cadena);
        }
        public bool Borrar(int id)
        {
            var parametros = new List<ParameterSQL>();
            parametros.Add(new ParameterSQL("@id_detalle", id));
            int filas = DataHelper.GetInstance().ExecuteSPDML("SP_Eliminar_Detalle", parametros);
            return filas == 1;
        }



        public bool Guardar(DetalleFac detalle)
        {
            bool resultado = true;
            string querry = "SP_Guardar_Detalle";
            try
            {
                if (detalle != null)
                {
                    _conn.Open();
                    var cmd = new SqlCommand(querry, _conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_factura", detalle.Id_fac);
                    cmd.Parameters.AddWithValue("@id_articulo", detalle.Articulo.Id);
                    cmd.Parameters.AddWithValue("@cantidad", detalle.Cantidad);


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




        public DetalleFac Obtener(int id)
        {
            var parametros = new List<ParameterSQL>();
            parametros.Add(new ParameterSQL("@id_detalle", id));
            DataTable tabla = DataHelper.GetInstance().ExecuteSPQuery("SP_Buscar_Detalle", parametros);

            AdminArticulos aa = new AdminArticulos();
            if (tabla != null && tabla.Rows.Count == 1)
            {
                DataRow fila = tabla.Rows[0];

                int ide = Convert.ToInt32(fila["id_detalle_factura"]);
                int idf = Convert.ToInt32(fila["id_factura"]);

                int cantidad = Convert.ToInt32(fila["cantidad"]);

                int art = Convert.ToInt32(fila["id_articulo"]);
                Articulo articulo = aa.Obtener(art);



                DetalleFac detalle = new DetalleFac()
                {
                    Id = ide,
                    Id_fac = idf,
                    Cantidad = cantidad,
                    Articulo = articulo

                };


                return detalle;

            }
            return null;
        }



        public List<DetalleFac> ObtenerList(int idFac)
        {
            var parametros = new List<ParameterSQL>();
            parametros.Add(new ParameterSQL("@id_factura", idFac));

            DataTable tabla = DataHelper.GetInstance().ExecuteSPQuery("SP_Recuperar_Detalles", parametros);
            List<DetalleFac> detalles = new List<DetalleFac>();

            AdminArticulos aa = new AdminArticulos();

            foreach (DataRow fila in tabla.Rows)
            {

                int ide = Convert.ToInt32(fila["id_detalle_factura"]);
                int idf = Convert.ToInt32(fila["id_factura"]);

                int cantidad = Convert.ToInt32(fila["cantidad"]);

                int art = Convert.ToInt32(fila["id_articulo"]);
                Articulo articulo = aa.Obtener(art);



                DetalleFac detalle = new DetalleFac()
                {
                    Id = ide,
                    Id_fac = idf,
                    Cantidad = cantidad,
                    Articulo = articulo




                };
                detalles.Add(detalle);

            }
            return detalles;
        }
    }
}
