using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace tarea_1._5_facturacion.Dominio
{
    public class DetalleFac
    {
        public int Id { get; set; }


        public int Id_fac { get; set; }


        public Articulo Articulo { get; set; }


        public int Cantidad { get; set; }

        public override string ToString()
        {
            return @$" - {Articulo.Nombre}    X{Cantidad}  c/u: ${Articulo.Precio}  - ${Articulo.Precio*Cantidad}";
        }
    }
}
