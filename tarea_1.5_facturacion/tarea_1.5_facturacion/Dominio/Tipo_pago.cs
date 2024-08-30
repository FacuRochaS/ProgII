using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace tarea_1._5_facturacion.Dominio
{
    public class Tipo_pago
    {
        public int Id { get; set; }

        public string Forma { get; set; }

        public override string ToString()
        {
            return @$" Nro |{Id}|  - {Forma}";
        }
    }
}
