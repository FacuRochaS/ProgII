using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarea_Banco.dominio;

namespace tarea_Banco.datos
{
    public interface IClienteRepositorio
    {
        bool Guardar(Cliente cliente);

        bool Borrar(int id);

        Cliente Obtener(int id);

        List<Cliente> ObtenerList();



    }
}
