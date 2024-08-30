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

namespace tarea_1._5_facturacion.Datos.RepoFacturas
{
    public class FacturaRepositorioADO : IFacturaRepositorio
    {
        private SqlConnection _conn;

        public FacturaRepositorioADO()
        {
            _conn = new SqlConnection(Properties.Resources.Cadena);
        }




        public bool Borrar(int id)
        {
            var parametros = new List<ParameterSQL>();
            parametros.Add(new ParameterSQL("@id_factura", id));
            int filas = DataHelper.GetInstance().ExecuteSPDML("SP_Eliminar_Factura", parametros);
            return filas == 1;
        }





        public bool Guardar(Factura factura)
        {
            bool resultado = true;
            string querry = "SP_Guardar_Factura";
            AdminDetalles ad = new AdminDetalles();
            try
            {
                if (factura != null)
                {
                    _conn.Open();
                    var cmd = new SqlCommand(querry, _conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@fecha", factura.Fecha);
                    cmd.Parameters.AddWithValue("@cliente", factura.Cliente);
                    cmd.Parameters.AddWithValue("@id_forma_pago", factura.Tipo.Id);


                    resultado = cmd.ExecuteNonQuery() == 1;

                    foreach (DetalleFac detalle in factura.Detalles)
                    {
                        ad.Guardar(detalle);


                    }
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




        public Factura Obtener(int id)
        {
            var parametros = new List<ParameterSQL>();
            parametros.Add(new ParameterSQL("@id_factura", id));
            DataTable tabla = DataHelper.GetInstance().ExecuteSPQuery("SP_Buscar_Factura", parametros);
            AdminDetalles ad = new AdminDetalles();
            AdminFacturas af = new AdminFacturas();
            if (tabla != null && tabla.Rows.Count == 1)
            {
                DataRow fila = tabla.Rows[0];

                int ide = Convert.ToInt32(fila["id_factura"]);

                int tipo = Convert.ToInt32(fila["id_forma_pago"]);
                Tipo_pago TipoCue = af.ObtenerForma(tipo);

                DateTime mov = Convert.ToDateTime(fila["fecha_hora_venta"]);

                string cliente = Convert.ToString(fila["cliente"]);

                List<DetalleFac> detalles = ad.ObtenerList(ide);





                Factura factura = new Factura()
                {
                    Id = ide,
                    Tipo = TipoCue,
                    Fecha = mov,
                    Cliente = cliente,
                    Detalles = detalles

                };


                return factura;




            }
            return null;
        }





        public List<Factura> ObtenerList()
        {
            List<Factura> facturas = new List<Factura>();
            var helper = DataHelper.GetInstance();

            var tabla = helper.ExecuteSPQuery("SP_Recuperar_Facturas", null);
            AdminDetalles ad = new AdminDetalles();
            AdminFacturas af = new AdminFacturas();
            foreach (DataRow fila in tabla.Rows)
            {

                int ide = Convert.ToInt32(fila["id_factura"]);

                int tipo = Convert.ToInt32(fila["id_forma_pago"]);
                Tipo_pago TipoCue = af.ObtenerForma(tipo);

                DateTime mov = Convert.ToDateTime(fila["fecha_hora_venta"]);

                string cliente = Convert.ToString(fila["cliente"]);

                List<DetalleFac> detalles = ad.ObtenerList(ide);





                Factura factura = new Factura()
                {
                    Id = ide,
                    Tipo = TipoCue,
                    Fecha = mov,
                    Cliente = cliente,
                    Detalles = detalles

                };

                facturas.Add(factura);

            }
            return facturas;
        }

        // forma de pago










    }
}
