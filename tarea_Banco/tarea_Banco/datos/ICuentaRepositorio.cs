using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarea_Banco.dominio;

namespace tarea_Banco.datos
{
    public interface ICuentaRepositorio
    {
        bool Guardar(Cuenta cuenta);

        bool Borrar(int id);

        Cuenta Obtener(int id);

        List<Cuenta> ObtenerList();
    }
}
