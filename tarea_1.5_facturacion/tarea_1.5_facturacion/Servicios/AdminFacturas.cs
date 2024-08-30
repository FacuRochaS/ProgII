using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarea_1._5_facturacion.Dominio;

namespace tarea_1._5_facturacion.Servicios
{
    public class AdminFacturas
    {
        private Datos.RepoFacturas.FacturaRepositorioADO _repo = new Datos.RepoFacturas.FacturaRepositorioADO();
        private Datos.RepoFormaPago.FormaPagoRepositorioADO _tipo = new Datos.RepoFormaPago.FormaPagoRepositorioADO();
        public bool  Guardar(Factura factura)
        {
            return _repo.Guardar(factura);
        }
        
        public bool Borrar(int id)
        {
            return (_repo.Borrar(id));
        }

        public Factura Obtener(int id)
        {
            return _repo.Obtener(id);
        }

        public List<Factura> ObtenerList()
        {
            return _repo.ObtenerList();
        }

        public  Tipo_pago ObtenerForma(int id)
        {
            return _tipo.Obtener(id);
        }

        public List<Tipo_pago> ObtenerFormasList()
        {
            return _tipo.ObtenerList();
        }

    }
}
