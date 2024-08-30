using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarea_1._5_facturacion.Dominio
{
    public class Articulo
    {

        public int Id { get; set; }

        public string Nombre { get; set; }

        public double Precio { get; set; }

        public override string ToString()
        {
            return @$" Nro |{Id}|  - {Nombre}    ${Precio}";
        }
    }
}
