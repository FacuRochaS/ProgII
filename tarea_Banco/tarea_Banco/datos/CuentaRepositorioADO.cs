using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarea_Banco.datos.utilidades;
using tarea_Banco.dominio;
using tarea_Banco.servicios;

namespace tarea_Banco.datos
{
    public class CuentaRepositorioADO : ICuentaRepositorio
    {
        private SqlConnection _conn;

        public CuentaRepositorioADO()
        {
            _conn = new SqlConnection(Properties.Resources.Cadena);
        }

        public bool Borrar(int id)
        {
            var parametros = new List<ParameterSQL>();
            parametros.Add(new ParameterSQL("@id_cuenta", id));
            int filas = DataHelper.GetInstance().ExecuteSPDML("SP_Eliminar_Cuenta", parametros);
            return filas == 1;
        }

        public bool Guardar(Cuenta cuenta)
        {
            bool resultado = true;
            string querry = "SP_Guardar_Cuenta";
            try
            {
                if (cuenta != null)
                {
                    _conn.Open();
                    var cmd = new SqlCommand(querry, _conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cbu", cuenta.Cbu );
                    cmd.Parameters.AddWithValue("@saldo", cuenta.Saldo);
                    cmd.Parameters.AddWithValue("@id_tipo", cuenta.tipo.Id);
                    cmd.Parameters.AddWithValue("@movimiento", cuenta.Movimiento);
                    cmd.Parameters.AddWithValue("@id_cliente", cuenta.cliente.Id);

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

        public Cuenta Obtener(int id)
        {
            var parametros = new List<ParameterSQL>();
            parametros.Add(new ParameterSQL("@id_cuenta", id));
            DataTable tabla = DataHelper.GetInstance().ExecuteSPQuery("SP_Buscar_Cuentas", parametros);
            AdminClientes ad = new AdminClientes();
            if (tabla != null && tabla.Rows.Count == 1)
            {
                DataRow fila = tabla.Rows[0];
                int ide = Convert.ToInt32(fila["id_cuenta"]);
                int cbu = Convert.ToInt32(fila["cbu"]);
                double saldo = Convert.ToDouble(fila["saldo"]);

                int tipo = Convert.ToInt32(fila["id_tipo_cuenta"]);
                Tipo_cuenta TipoCue = BuscarTipo(tipo);

                DateTime mov  = Convert.ToDateTime(fila["movimiento"]);

                int clie = Convert.ToInt32(fila["id_cliente"]);
                Cliente cliente = ad.Obtener(clie);

                

                Cuenta cuenta = new Cuenta()
                {
                    Id = ide,
                    Cbu = cbu,
                    Saldo = saldo,
                    tipo = TipoCue,
                    Movimiento = mov,
                    cliente = cliente,

                  


                };


                return cuenta;




            }
            return null;
        }

        public List<Cuenta> ObtenerList()
        {
            List<Cuenta> cuentas = new List<Cuenta>();
            var helper = DataHelper.GetInstance();
            AdminClientes ad = new AdminClientes();
            var tabla = helper.ExecuteSPQuery("SP_Recuperar_Cuentas", null);
            foreach (DataRow fila in tabla.Rows)
            {
                
                int ide = Convert.ToInt32(fila["id_cuenta"]);
                int cbu = Convert.ToInt32(fila["cbu"]);
                double saldo = Convert.ToDouble(fila["saldo"]);

                int tipo = Convert.ToInt32(fila["id_tipo_cuenta"]);
                Tipo_cuenta TipoCue = BuscarTipo(tipo);

                DateTime mov = Convert.ToDateTime(fila["movimiento"]);

                int clie = Convert.ToInt32(fila["id_cliente"]);
                Cliente cliente = ad.Obtener(clie);



                Cuenta cuenta = new Cuenta()
                {
                    Id = ide,
                    Cbu = cbu,
                    Saldo = saldo,
                    tipo = TipoCue,
                    Movimiento = mov,
                    cliente = cliente,




                };
                cuentas.Add(cuenta);

            }
            return cuentas;
        }




        public Tipo_cuenta BuscarTipo(int id)
        {
            var parametros = new List<ParameterSQL>();
            parametros.Add(new ParameterSQL("@id_tipo", id));
            DataTable tabla = DataHelper.GetInstance().ExecuteSPQuery("SP_Buscar_Tipo", parametros);

            if (tabla != null && tabla.Rows.Count == 1)
            {
                DataRow fila = tabla.Rows[0];
                int ide = Convert.ToInt32(fila["id_tipo"]);
                string nombre = fila["nombre"].ToString();

                Tipo_cuenta tipoC = new Tipo_cuenta()
                {

                    Id = ide,
                    Nombre = nombre,
                };
                return tipoC;




            }
            return null;
        }
    }
}
