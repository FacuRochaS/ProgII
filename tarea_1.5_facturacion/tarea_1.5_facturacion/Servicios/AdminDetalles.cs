using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarea_1._5_facturacion.Datos.RepoArticulos;
using tarea_1._5_facturacion.Dominio;

namespace tarea_1._5_facturacion.Servicios
{
    public class AdminDetalles
    {
        private Datos.RepoDetalles.DetallesRepositorioADO _repo = new Datos.RepoDetalles.DetallesRepositorioADO();
        public bool Guardar(DetalleFac detalle)
        {
            return _repo.Guardar(detalle);
        }

        public bool Borrar(int id)
        {
            return (_repo.Borrar(id));
        }

        public DetalleFac Obtener(int id)
        {
            return _repo.Obtener(id);
        }

        public List<DetalleFac> ObtenerList(int id)
        {
            return _repo.ObtenerList(id);
        }
    }
}
