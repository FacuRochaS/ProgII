using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarea_1._5_facturacion.Dominio;

namespace tarea_1._5_facturacion.Datos.RepoArticulos
{
    public interface IArticulosRepositorio
    {
        Articulo Obtener(int id);

        List<Articulo> ObtenerList();
    }
}
