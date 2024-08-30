using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarea_1._5_facturacion.Dominio;

namespace tarea_1._5_facturacion.Datos.RepoFormaPago
{
    public interface IFormaPagoRepositorio
    {

        public Tipo_pago Obtener(int id);

        public List<Tipo_pago> ObtenerList();
    }
}
