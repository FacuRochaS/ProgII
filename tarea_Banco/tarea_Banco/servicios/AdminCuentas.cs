using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarea_Banco.datos;
using tarea_Banco.dominio;

namespace tarea_Banco.servicios
{
    public class AdminCuentas
    {
        private CuentaRepositorioADO _repo = new CuentaRepositorioADO();
        public bool Guardar(Cuenta cuenta)
        { return _repo.Guardar(cuenta); }

        public bool Borrar(int id) { return _repo.Borrar(id); }

        public Cuenta Obtener(int id) { return _repo.Obtener(id); }

        public List<Cuenta> ObtenerList() { return _repo.ObtenerList(); }

        public Tipo_cuenta BuscarTipo(int id)
        {
            return _repo.BuscarTipo(id);
        }

    }
}
