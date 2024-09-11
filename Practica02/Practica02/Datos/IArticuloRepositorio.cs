using Practica02.Models;

namespace Practica02.Datos
{
    public interface IArticuloRepositorio
    {

        Articulo Obtener(int id);

        List<Articulo> ObtenerList();

        bool Guardar(Articulo articulo);

        bool Borrar(int id);


    }
}
