using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarea_1._5_facturacion.Dominio;

namespace tarea_1._5_facturacion.Datos.RepoFacturas
{
    public interface IFacturaRepositorio
    {
        bool Guardar(Factura factura);

        bool Borrar(int id);

        Factura Obtener(int id);

        List<Factura> ObtenerList();
    }
}
