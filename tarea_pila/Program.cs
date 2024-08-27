using tarea_pila.Clases;

Cola cola = new Cola();
int op;
bool c = true;
Console.WriteLine("─────────────────────████████████████───────────\r\n───────────█████████████░░░░░███████████████────\r\n──███████████████░░░░░░░░░██░░░████████████████─\r\n─██░░░░░░░░░░░░░░░░░░░░░░██░░░░░░░░░░░░░░░░░░░██\r\n─██░███░░░░░░░░░░░░░░░░░██░░███░░░░░░░░░░░░░░░██\r\n─██░█░█░█░█░░░███░░░░░░██░░░█░░░████░█░░░███░░██\r\n─██░███░░░█░░░█░█░░░░░██░░░░█░░░█░░█░█░░░█░█░░██\r\n─██░█░░░█░█░░█████░░░██░░░░░█░░░█░░█░█░░█████░██\r\n─██░█░░░█░██░█░░░█░░██░░░░░░███░████░██░█░░░█░██\r\n─██░░░░░░░░░░░░░░░░██░░░░░░░░░░░░░░░░░░░░░░░░░██\r\n──█████████░░░░░░░██░░░░░░░░███████████████████─\r\n──────█████████░░░░░░░░░██████████████████──────\r\n───────────██████████████████───────────────────\r\n────────────────────────────────────────────────\r\n───██──██──███─████───███─████─████─────────────\r\n───██████─████────██─████─█──█─█──█─────────────\r\n──────███───██───██────██─█──█──██──────────────\r\n──────███───██─██──────██─█──█─█──█─────────────\r\n──────███───██─█████───██─████─████─────────────\r\n────────────────────────────────────────────────\r\n");
Console.WriteLine("Que tipo de memoria quiere probar? (Ingrese un numero)");
Console.WriteLine("|1| PILA");
Console.WriteLine("|2| COLA");

int m = Convert.ToInt32(Console.ReadLine());
if (m==1)
{
    Console.WriteLine("Ingrese el tamaño de su pila: ");

    int i = Convert.ToInt32(Console.ReadLine());

    Pila pila = new Pila(i);

    // Cilco para las pilas
    while (c)
    {
        Texto();
        op = Convert.ToInt32(Console.ReadLine());



        if (op == 0) { c = false; }
        else if (op == 1)
        {
            if (pila.estaVacia())
            {
                Console.WriteLine("La MEMORIA esta vacia.");
            }
            else
            {
                Console.WriteLine("La MEMORIA NO esta vacia");
            }
        }
        else if (op == 2)
        {
            Console.WriteLine("Ingrese el nuevo elemento:");
            if (pila.anadir(Convert.ToString(Console.ReadLine()))) { Console.WriteLine("El elemnto fue guardado!!"); }
            else
            {
                Console.WriteLine("La PILA se llenó, extraiga elementos antes de continuar");
            }
        }
        else if (op == 3) { Console.WriteLine("El ultimo elemnto es: " + pila.primero()); }

        else if (op == 4) { Console.WriteLine("El elemento eliminado fue: " + pila.extraer().ToString()); }



    }
}
else
{
    while (c)
    {
        Texto();
        op = Convert.ToInt32(Console.ReadLine());


        // ciclo para las cocas COLAS
        if (op == 0) { c = false; }
        else if (op == 1)
        {
            if (cola.estaVacia())
            {
                Console.WriteLine("La PILA esta vacia.");
            }
            else
            {
                Console.WriteLine("La PILA NO esta vacia");
            }
        }
        else if (op == 2)
        {
            Console.WriteLine("Ingrese el nuevo elemento:");
            if (cola.anadir(Convert.ToString(Console.ReadLine()))) { Console.WriteLine("El elemnto fue guardado!!"); }
            else
            {
                Console.WriteLine("La PILA se llenó, extraiga elementos antes de continuar");
            }
        }
        else if (op == 3) { Console.WriteLine("El ultimo elemnto es: " + cola.primero()); }

        else if (op == 4) { Console.WriteLine("El elemento eliminado fue: " + cola.extraer().ToString()); }



    }
}




void Texto()
{
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("Que desea hacer? (seleccione una opcion)");
    Console.WriteLine("1| Verificar estado de la Memoria");
    Console.WriteLine("2| Añadir a la Memoria");
    Console.WriteLine("3| Retornar el proximo en salir");
    Console.WriteLine("4| Eliminar");
    Console.WriteLine();
    Console.WriteLine("0| Salir");
    Console.WriteLine();
}





Console.WriteLine("HAsta luego!!");
