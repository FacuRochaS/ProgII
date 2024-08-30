using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarea_1._5_facturacion.Dominio;

namespace tarea_1._5_facturacion.Datos.RepoDetalles
{
    public interface IDetallesRepositorio
    {
        bool Guardar(DetalleFac detalle);

        bool Borrar(int id);

        DetalleFac Obtener(int id);

        List<DetalleFac> ObtenerList(int id);

    }
}
