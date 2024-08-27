using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarea_pila.Interfaces
{
    public class ColeccionAbstracta : Icolection
    {
        bool Icolection.anadir(object objeto)
        {
            throw new NotImplementedException();
        }

        bool Icolection.estaVacia()
        {
            throw new NotImplementedException();
        }

        object Icolection.extraer()
        {
            throw new NotImplementedException();
        }

        object Icolection.primero()
        {
            throw new NotImplementedException();
        }
    }
}
