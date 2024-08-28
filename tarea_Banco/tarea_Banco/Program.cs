
using tarea_Banco.dominio;
using tarea_Banco.servicios;

int op;
bool c = true;

AdminClientes ac = new AdminClientes();
AdminCuentas ad = new AdminCuentas();
while (c)
{
    Texto();
    op = Convert.ToInt32(Console.ReadLine());



    if (op == 0) { c = false; }
    else if (op == 1)
    {
        Console.WriteLine("Ingrese el nombre del Cliente: ");
        string nombre = Convert.ToString(Console.ReadLine());

        Console.WriteLine("Ingrese el apellido del Cliente: ");
        string apellido = Convert.ToString(Console.ReadLine());

        Console.WriteLine("Ingrese el Dni del Cliente: ");
        int dni = Convert.ToInt32(Console.ReadLine());

        Cliente cliente = new Cliente()
        {
            Nombre = nombre,
            Apellido = apellido,
            Dni = dni
        };


        if (ac.Guardar(cliente)) { Console.WriteLine("El cliente fue guardado con exito!!"); }


    }
    else if (op == 2)
    {
        Console.WriteLine("Ingrese el id del cliente: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Cliente cliente = ac.Obtener(id);
        Console.WriteLine(cliente.ToString());


    }
    else if (op == 3) 
    {
        List<Cliente> clientes = ac.ObtenerList();
        foreach (Cliente cliente in clientes)
        {
            Console.WriteLine(cliente.ToString());
        }
    }

    else if (op == 4) 
    {
        Console.WriteLine("Ingrese el id del cliente a borrar: ");
        int id = Convert.ToInt32(Console.ReadLine());

        if (ac.Borrar(id)) { Console.WriteLine("El cliente fue ELIMINADO con exito!!"); }
        



    }

    else if (op == 5)
    {
        Console.WriteLine("Ingrese id del deuño de la cuenta: ");
        int idCliente = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ingrese el Tipo de cuenta a crear:");
        int tipo = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ingrese el cbu: ");
        int cbu = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ingrese el Saldo Inicial: ");
        double saldo = Convert.ToDouble(Console.ReadLine());

        DateTime fecha = DateTime.Now;

        Tipo_cuenta tipoCuenta = ad.BuscarTipo(tipo);
        Cliente cliente = ac.Obtener(idCliente);

        Cuenta cuenta = new Cuenta()
        {
            Cbu = cbu,
            Saldo = saldo,
            Movimiento = fecha,
            tipo = tipoCuenta,
            cliente = cliente

        };


        if (ad.Guardar(cuenta)) { Console.WriteLine("La cuenta fue guardado con exito!!"); }


    }
    else if (op == 6)
    {
        Console.WriteLine("Ingrese el id de la cuenta: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Cuenta cuenta = ad.Obtener(id);
        Console.WriteLine(cuenta.ToString());


    }
    else if (op == 7)
    {
        List<Cuenta> cuentas = ad.ObtenerList();
        foreach (Cuenta cuenta in cuentas)
        {
            Console.WriteLine(cuenta.ToString());
        }
    }

    else if (op == 8)
    {
        Console.WriteLine("Ingrese el id de la cuenta a borrar: ");
        int id = Convert.ToInt32(Console.ReadLine());

        if (ad.Borrar(id)) { Console.WriteLine("La cuenta fue ELIMINADA con exito!!"); }




    }


}





void Texto()
{
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("Que desea hacer? (seleccione una opcion)");
    Console.WriteLine();
    Console.WriteLine("------------------------");
    Console.WriteLine("|1| Cargar un Cliente");
    Console.WriteLine("|2| Buscar un Cliente");
    Console.WriteLine("|3| Mostrar todos Clientes");
    Console.WriteLine("|4| Eliminar un Cliente");
    Console.WriteLine("------------------------");
    Console.WriteLine("|5| Cargar una Cuenta");
    Console.WriteLine("|6| Buscar una Cuenta");
    Console.WriteLine("|7| Mostrar todas Cuenta");
    Console.WriteLine("|8| Eliminar una Cuenta");
    Console.WriteLine("------------------------");
    Console.WriteLine();
    Console.WriteLine("|0| Salir");
    Console.WriteLine("------------------------");
    Console.WriteLine();
}





Console.WriteLine("HAsta luego!!");
