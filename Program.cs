using cadeteria;

List<Cadete> listaCadetes = new List<Cadete>();
Cadete cadete1 = new Cadete(1, "Agustin", "Dir1", "3811111111");
Cadete cadete2 = new Cadete(2, "Juan", "Dir2", "3812222222");
Cadete cadete3 = new Cadete(3, "Jose", "Dir3", "3813333333");

listaCadetes.Add(cadete1);
listaCadetes.Add(cadete2);
listaCadetes.Add(cadete3);

Cadeteria cadeteria = new Cadeteria("Cadeteria", "3815349154", listaCadetes);

void nuevoPedido()
{
    int nroP, idC;
    string? obsP, nomC, dirC, telC, refC;

    Console.WriteLine("\n===== NUEVO PEDIDO =====");
    Console.WriteLine("Numero de pedido: ");
    int.TryParse(Console.ReadLine(), out nroP);
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

    cadeteria.crearPedido(idC, nroP, obsP, nomC, dirC, telC, refC);
}

void cambiarEstadoPedido()
{
    int nroP;
    Pedido pedidoBuscado = null;
    Console.WriteLine("\n===== CAMBIAR ESTADO PEDIDO =====");
    Console.WriteLine("Numero de pedido: ");
    int.TryParse(Console.ReadLine(), out nroP);
    foreach (Cadete cad in cadeteria.ListadoCadetes)
    {
        foreach (Pedido p in cad.ListadoPedidos)
        {
            if (p.Nro == nroP)
            {
                pedidoBuscado = p;
                break;
            }
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
    int nroP, cadeteAntId = 0, nuevoCadeteId;
    Pedido pedidoBuscado = null;
    Console.WriteLine("\n===== REASIGNAR PEDIDO =====");
    Console.WriteLine("Numero de pedido: ");
    int.TryParse(Console.ReadLine(), out nroP);
    foreach (Cadete cad in cadeteria.ListadoCadetes)
    {
        foreach (Pedido p in cad.ListadoPedidos)
        {
            if (p.Nro == nroP)
            {
                pedidoBuscado = p;
                cad.ListadoPedidos.Remove(p);
                cadeteAntId = cad.Id;
                break;
            }
        }
    }
    if (pedidoBuscado == null)
    {
        Console.WriteLine("No existe el pedido buscado");
    }
    else
    {
        Console.WriteLine("Pedido encontrado. Id del cadete: " + cadeteAntId);
        Console.WriteLine("Ingrese el id del nuevo cadete: ");
        int.TryParse(Console.ReadLine(), out nuevoCadeteId);

        foreach (Cadete cad in cadeteria.ListadoCadetes)
        {
            if (cad.Id == nuevoCadeteId)
            {
                cad.ListadoPedidos.Add(pedidoBuscado);
                Console.WriteLine("Pedido reasignado correctamente");
                break;
            }
        }
    }
}

// MENU
int aux;
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
} while (aux >= 1 && aux <= 3);