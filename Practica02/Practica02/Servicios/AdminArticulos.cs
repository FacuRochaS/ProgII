using Practica02.Models;

namespace Practica02.Servicios
{
    public class AdminArticulos
    {
        private Datos.ArticuloRepositorioADO _repo = new Datos.ArticuloRepositorioADO();
        public Articulo Obtener(int id)
        {
            return _repo.Obtener(id);
        }

        public List<Articulo> ObtenerList()
        {
            return _repo.ObtenerList();
        }

        public bool Guardar(Articulo articulo)
        {
            return _repo.Guardar(articulo);
        }

        public bool Borrar(int id)
        {
            return _repo.Borrar(id);
        }

    }
}
