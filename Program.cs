using cadeteria;

AccesoADatos HelperDatos;
Cadeteria cadeteria;
List<Cadete> listaCadetes;
string acceder = "";
string rutaArchivoDatosCadeteria = "", rutaArchivoDatosCadetes = "";

do
{
    Console.WriteLine("TIPO DE ACCESO A LOS DATOS\n");
    Console.WriteLine("> Opción a: Por archivo csv");
    Console.WriteLine("> Opción b: Por archivo json\n");
    Console.Write("Opcion: ");
    acceder = Console.ReadLine();
} while (acceder != "a" && acceder != "b");

if (acceder == "a")
{
    rutaArchivoDatosCadeteria = "cadeteria.csv";
    rutaArchivoDatosCadetes = "cadetes.csv";
    HelperDatos = new ArchivoCSV();
}
else
{
    rutaArchivoDatosCadeteria = "cadeteria.json";
    rutaArchivoDatosCadetes = "cadetes.json";
    HelperDatos = new ArchivoJSON();
}


if (HelperDatos.ExisteArchivo(rutaArchivoDatosCadeteria) && HelperDatos.ExisteArchivo(rutaArchivoDatosCadetes))
{
    cadeteria = HelperDatos.cargarCadeteria(rutaArchivoDatosCadeteria);
    listaCadetes = HelperDatos.cargarCadetes(rutaArchivoDatosCadetes);
    cadeteria.AgregarListaCadetes(listaCadetes);
}

void nuevoPedido()
{
    int idC;
    string? obsP, nomC, dirC, telC, refC;

    Console.WriteLine("\n===== NUEVO PEDIDO =====");
    Console.WriteLine("Observaciones del pedido: ");
    obsP = Console.ReadLine();
    Console.WriteLine("Nombre del cliente: ");
    nomC = Console.ReadLine();
    Console.WriteLine("Direccion del cliente: ");
    dirC = Console.ReadLine();
    Console.WriteLine("Telefono del cliente: ");
    telC = Console.ReadLine();
    Console.WriteLine("Referencias del cliente: ");
    refC = Console.ReadLine();
    Console.WriteLine("Id del cadete: ");
    int.TryParse(Console.ReadLine(), out idC);

    cadeteria.crearPedido(idC, cadeteria.ListadoPedidos.Count + 1, obsP, nomC, dirC, telC, refC);
}

void cambiarEstadoPedido()
{
    int nroP;
    Pedido pedidoBuscado = null;
    Console.WriteLine("\n===== CAMBIAR ESTADO PEDIDO =====");
    Console.WriteLine("Numero de pedido: ");
    int.TryParse(Console.ReadLine(), out nroP);
    foreach (Pedido p in cadeteria.ListadoPedidos)
    {
        if (p.Nro == nroP)
        {
            pedidoBuscado = p;
        }
    }
    if (pedidoBuscado == null)
    {
        Console.WriteLine("No existe el pedido buscado");
    }
    else if (pedidoBuscado.Estado == Estados.Cancelado)
    {
        Console.WriteLine("El pedido fue cancelado. No se puede cambiar el estado");
    }
    else if (pedidoBuscado.Estado == Estados.Entregado)
    {
        Console.WriteLine("El pedido fue entregado. No se puede cambiar el estado");
    }
    else
    {
        int op;
        Console.WriteLine("Cambiar el estado a: 1-Entregado 2-Cancelado");
        int.TryParse(Console.ReadLine(), out op);
        if (op == 1)
        {
            pedidoBuscado.Estado = Estados.Entregado;
        }
        else if (op == 2)
        {
            pedidoBuscado.Estado = Estados.Cancelado;
        }
    }
}

void reasignarPedido()
{
    int nroP, nuevoCadeteId;
    Pedido pedidoBuscado = null;
    Console.WriteLine("\n===== REASIGNAR PEDIDO =====");
    Console.WriteLine("Numero de pedido: ");
    int.TryParse(Console.ReadLine(), out nroP);
    Console.WriteLine("Id del nuevo cadete: ");
    int.TryParse(Console.ReadLine(), out nuevoCadeteId);

    foreach (Pedido p in cadeteria.ListadoPedidos)
    {
        if (p.Nro == nroP)
        {
            p.IdCadete = nuevoCadeteId;
            break;
        }
    }
}

// MENU
/* int aux;
do
{
    Console.WriteLine("\n===== MENU CADETERIA =====");
    Console.WriteLine("Ingrese una opcion:\n0-Salir\n1-Crear pedido\n2-Cambiar el estado de un pedido\n3-Reasignar un pedido a otro cadete");
    int.TryParse(Console.ReadLine(), out aux);

    switch (aux)
    {
        case 1:
            nuevoPedido();
            break;
        case 2:
            cambiarEstadoPedido();
            break;
        case 3:
            reasignarPedido();
            break;
    }
} while (aux >= 1 && aux <= 3); */