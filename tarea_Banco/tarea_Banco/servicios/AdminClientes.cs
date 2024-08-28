using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using tarea_Banco.datos;
using tarea_Banco.dominio;

namespace tarea_Banco.servicios
{
    public class AdminClientes
    {
        private ClienteRepositorioADO _repo = new ClienteRepositorioADO();

        public bool Guardar(Cliente cliente)
        {
            return _repo.Guardar(cliente);
        }

        public bool Borrar(int id)
        {
            return (_repo.Borrar(id));
        }

        public Cliente Obtener(int id)
        {
            return _repo.Obtener(id);
        }

        public List<Cliente> ObtenerList()
        {
            return _repo.ObtenerList();
        }


    }
}
