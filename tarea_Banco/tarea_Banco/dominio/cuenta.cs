using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace tarea_Banco.dominio
{
    public class Cuenta
    {
        public Cuenta() { }

        public int Id { get; set; }

        public int Cbu { get; set; }

        public double Saldo { get; set; }

        public Tipo_cuenta tipo { get; set; }

        public DateTime Movimiento { get; set; }

        public Cliente cliente { get; set; }
        public override string ToString()
        {
            return @$" Id: {Id} | Titular: {cliente.Nombre} {cliente.Apellido}  | Tipo de cuenta: {tipo.Nombre}  | Cbu: {Cbu}  | Saldo: ${Saldo}  | Ultimo Movimiento: {Movimiento}";
        }

    }
}
