using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace tarea_1._5_facturacion.Dominio
{
    public class Factura
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public string Cliente { get; set; }

        public Tipo_pago Tipo { get; set; }

        public List<DetalleFac> Detalles { get; set; }


        public override string ToString()
        {
            string strfac = @$"Nro factura: {Id}    Cliente: {Cliente}
Forma de pago: {Tipo.Forma}
Fecha: {Fecha}

Productos: ";
            double total = 0;

            foreach (DetalleFac detalle in Detalles)
            {
                total = total + (detalle.Cantidad * detalle.Articulo.Precio);
                strfac = strfac + @$"
- "+ detalle.ToString();
            }

            strfac = strfac + @$"

Total: {total}";





            return strfac;
        }

    }
}
