using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarea_1._5_facturacion.Datos.utilidades;
using tarea_1._5_facturacion.Dominio;
using tarea_Banco.datos.utilidades;

namespace tarea_1._5_facturacion.Datos.RepoFormaPago
{
    public class FormaPagoRepositorioADO : IFormaPagoRepositorio
    {

        private SqlConnection _conn;

        public FormaPagoRepositorioADO()
        {
            _conn = new SqlConnection(Properties.Resources.Cadena);
        }


        public Tipo_pago Obtener(int id)
        {
            var parametros = new List<ParameterSQL>();
            parametros.Add(new ParameterSQL("@id_forma_pago", id));
            DataTable tabla = DataHelper.GetInstance().ExecuteSPQuery("SP_Buscar_Forma_pago", parametros);

            if (tabla != null && tabla.Rows.Count == 1)
            {
                DataRow fila = tabla.Rows[0];
                int ide = Convert.ToInt32(fila["id_forma_pago"]);
                string forma = Convert.ToString(fila["forma_pago"]);
               

                Tipo_pago tipo = new Tipo_pago()
                {
                    Id = ide,
                    Forma = forma,
                    
                };


                return tipo;




            }
            return null;
        }

        public List<Tipo_pago> ObtenerList()
        {
            List<Tipo_pago> tipos = new List<Tipo_pago>();
            var helper = DataHelper.GetInstance();
            var tabla = helper.ExecuteSPQuery("SP_Recuperar_Formas_pago", null);
            foreach (DataRow fila in tabla.Rows)
            {
                int ide = Convert.ToInt32(fila["id_forma_pago"]);
                string forma = Convert.ToString(fila["forma_pago"]);


                Tipo_pago tipo = new Tipo_pago()
                {
                    Id = ide,
                    Forma = forma,

                };
                tipos.Add(tipo);

            }
            return tipos;
        }
    }
}
