using tarea_1._5_facturacion.Dominio;
using tarea_1._5_facturacion.Servicios;

int op;
bool c = true;
AdminArticulos adminArticulos = new AdminArticulos();
AdminDetalles adminDetalles = new AdminDetalles();
AdminFacturas adminFacturas = new AdminFacturas();
Console.WriteLine("|---------------------------------------------------------|\r\n|  Bienvenido al supermercado de FACU                     |\r\n|                                                         |\r\n|  Tenemos todo lo que busca                              |\r\n|  Si no le gustan los precios vaya al super de Fede Funes|\r\n|  ahí es mas barato, pero tenga cuidado que a la noche   |\r\n|  apagan las heladeras.                                  |\r\n|                                                         |\r\n|---------------------------------------------------------|");
Console.WriteLine("Ingrese su nombre: ");
string nomb = Console.ReadLine();
List<Factura> facturas = adminFacturas.ObtenerList();
int id =  facturas[facturas.Count - 1].Id + 1;
facturas = null;
Factura factura = new Factura() { Cliente=nomb, Id=id};
List<DetalleFac> detalleFacs = new List<DetalleFac>();

while (c)
{
    Texto();
    op = Convert.ToInt32(Console.ReadLine());
    


    
    if (op == 1)
    {
        bool existe = false;
        List<Articulo> articulos = adminArticulos.ObtenerList();
        Console.WriteLine("Ingrese el Nro de Producto para agregarlo al carrito: ");
        Console.WriteLine();
        foreach (var articulo in articulos)
        {
            Console.WriteLine(articulo.ToString());
            Console.WriteLine();

        }
        int art = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Cuantos Desea agregar?");
        int cant = Convert.ToInt32(Console.ReadLine());


        foreach (DetalleFac detalle in detalleFacs)
        {
            
            if (detalle.Articulo.Id == art)
            {
                detalle.Cantidad = detalle.Cantidad + cant;
                existe = true;
            }


            
        }

        if (!existe)
        {
            Articulo articuloSelec = adminArticulos.Obtener(art);

            DetalleFac detalleFac = new DetalleFac() { Cantidad = cant, Id_fac = id, Articulo = articuloSelec };

            detalleFacs.Add(detalleFac);
        }


    }
    else if (op == 2)
    {
        double total = 0;
        Console.WriteLine("En su carrito tiene: ");
        foreach(DetalleFac detalle in detalleFacs)
        {
            Console.WriteLine(detalle.ToString());
            total = total + detalle.Cantidad*detalle.Articulo.Precio;
        }
        Console.WriteLine();
        Console.WriteLine(@$"Total: ${total}");


    }
    else if (op == 3)
    {
        List<Articulo> articulos = adminArticulos.ObtenerList();
        Console.WriteLine("Ingrese el Nro de Producto para quitar del carrito: ");
        Console.WriteLine();
        foreach (var articulo in articulos)
        {
            Console.WriteLine(articulo.ToString());
            Console.WriteLine();

        }
        int art = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Cuantos desea eliminar?  (ingrese -1 para quitar todos)");
        int quitar = Convert.ToInt32(Console.ReadLine());
        foreach (DetalleFac detalle in detalleFacs)
        {
            if (quitar == -1)
            {
                if (detalle.Articulo.Id == art)
                {
                    detalleFacs.Remove(detalle);
                    Console.WriteLine($@"Se quitaron todos los {detalle.Articulo.Nombre}");
                }


            }
            else
            {
                if (detalle.Articulo.Id == art && detalle.Cantidad > quitar)
                {
                    detalle.Cantidad = detalle.Cantidad - quitar;
                    Console.WriteLine(@$"Ahora tiene: {detalle.Articulo.Nombre}  X{detalle.Cantidad}  en el carrito.");
                }
                else
                {
                    Console.WriteLine("Ingresó un valor invalido");
                }
            }
        }

    }

    else if (op == 4)
    {
        Console.WriteLine("Como desea pagar? (seleccione una opcion)");
        List<Tipo_pago> tipos = adminFacturas.ObtenerFormasList();
        
        Console.WriteLine();
        foreach (var tipo in tipos)
        {
            Console.WriteLine(tipo.ToString());
            Console.WriteLine();

        }
        int forma = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Gracias por su compra, aqui tiene su factura:");
        factura.Fecha = DateTime.Now;
        factura.Detalles = detalleFacs;
        Tipo_pago tip = adminFacturas.ObtenerForma(forma);
        factura.Tipo = tip;
        
        Console.WriteLine(factura.ToString());
        adminFacturas.Guardar(factura);
        c = false;

    }
    
    else
    {
        Console.WriteLine("Opcion Incorrecta");
    }
}






void Texto()
{
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("Que desea hacer? (seleccione una opcion)");
    Console.WriteLine();
    Console.WriteLine("  -------------------------");
    Console.WriteLine("  | 1) Comprar productos. |");
    Console.WriteLine();
    Console.WriteLine("  | 2) Ver el carrito.    |");
    Console.WriteLine();
    Console.WriteLine("  | 3) Devolver productos.|");
    Console.WriteLine();
    Console.WriteLine("  | 4) Pagar y Salir.     |");
    Console.WriteLine("  -------------------------");

}





Console.WriteLine("HAsta luego!!");

