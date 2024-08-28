using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace tarea_Banco.dominio
{
    public class Cliente
    {
        public Cliente() { }

        public int Id { get; set; }

        public string  Nombre { get; set; }

        public string Apellido { get; set; }

        public int Dni { get; set; }

        public override string ToString()
        {
            return @$" Id: {Id} | Nombre: {Nombre}  | Apellido: {Apellido}  | Dni: {Dni} ";
        }

    }
}
