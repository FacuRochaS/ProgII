using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarea_pila.Interfaces;

namespace tarea_pila.Clases
{
    public class Cola : ColeccionAbstracta
    {
        public Cola() { }



        List<object> memoria = new List<object>();
        int posicion = 0;

        public bool estaVacia()
        {
            if (memoria.Count == 0)
            {
                return true;
            }
            return false;
        }

        public object extraer()
        {
            object objeto = memoria[posicion];
            memoria.RemoveAt(posicion);
            return objeto;
        }

        public object primero()
        {
            object objeto = memoria[posicion];

            return objeto;
        }

        public bool anadir(object objeto)
        {

            memoria.Add(objeto);

            return true;

        }

    }
}
