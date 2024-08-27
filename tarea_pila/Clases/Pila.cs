using System;
using System.ComponentModel.DataAnnotations;
using tarea_pila.Interfaces;

public class Pila : ColeccionAbstracta
{
	public Pila(int i)
	{
		memoria = new object[i];
	}

	object[] memoria;
	int posicion = -1;

	public bool estaVacia()
	{

		return posicion == -1;
	}

	public object extraer()
	{	
		object objeto = memoria[posicion];
		posicion = posicion - 1;
		return objeto;

	}

	public object primero()
	{
        object objeto = memoria[posicion];
        
        return objeto;
    }

	public bool anadir(object objeto)
	{
        
        if (posicion + 1 == memoria.Length) 
		{
			return false; 
		}

        posicion = posicion + 1;
        memoria[posicion] = objeto;
		
		return true;

	}

}
