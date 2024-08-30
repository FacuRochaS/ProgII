using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarea_1._5_facturacion.Datos.RepoArticulos;
using tarea_1._5_facturacion.Dominio;

namespace tarea_1._5_facturacion.Servicios
{
    public class AdminArticulos
    {
        private ArticulosRepositorioADO _repo = new Datos.RepoArticulos.ArticulosRepositorioADO();

        public Articulo Obtener(int id) { return _repo.Obtener(id); }

        public List<Articulo> ObtenerList() { return _repo.ObtenerList(); }


    }
}
