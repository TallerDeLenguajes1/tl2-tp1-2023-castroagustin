using cadeteria;

AccesoADatos HelperDatos;
Cadeteria? cadeteria = null;
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
    AgregarListaCadetes(ref cadeteria, listaCadetes);
}

// MENU
int aux;
do
{
    Console.WriteLine("========== MENU CADETERIA ==========");
    Console.WriteLine("Ingrese que quiere realizar:");
    Console.WriteLine("1- Dar de alta pedido");
    Console.WriteLine("2- Asignar cadete a pedido");
    Console.WriteLine("3- Cambiar estado de pedido");
    Console.WriteLine("4- Reasignar pedido a otro cadete");
    Console.WriteLine("5- Mostrar informe");
    Console.WriteLine("0- SALIR");
    int.TryParse(Console.ReadLine(), out aux);

    switch (aux)
    {
        case 1:
            nuevoPedido(ref cadeteria);
            break;
        case 2:
            int nroP, idC;
            Console.WriteLine("Numero de pedido: ");
            int.TryParse(Console.ReadLine(), out nroP);
            Console.WriteLine("Id del cadete nuevo: ");
            int.TryParse(Console.ReadLine(), out idC);
            cadeteria.asignarCadeteAPedido(idC, nroP);
            break;
        case 3:
            cambiarEstadoPedido();
            break;
        case 4:
            reasignarPedido();
            break;
        case 5:
            Informe();
            break;
    }
} while (aux >= 1 && aux <= 5);


void nuevoPedido(ref Cadeteria cadeteria)
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

    cadeteria.CrearPedido(idC, cadeteria.ListadoPedidos.Count + 1, obsP, nomC, dirC, telC, refC);
}

void cambiarEstadoPedido()
{
    int nroP, estadoN;
    Console.WriteLine("\n===== CAMBIAR ESTADO PEDIDO =====");
    Console.WriteLine("Numero de pedido: ");
    int.TryParse(Console.ReadLine(), out nroP);
    do
    {
        Console.WriteLine("Ingrese el nuevo estado:\n1. Entregado\n2. Cancelado");
        int.TryParse(Console.ReadLine(), out estadoN);
    } while (estadoN != 1 && estadoN != 2);

    cadeteria.CambiarEstadoPedido(nroP, estadoN);
}

void reasignarPedido()
{
    int nroP, nuevoCadeteId;
    Console.WriteLine("\n===== REASIGNAR PEDIDO =====");
    Console.WriteLine("Numero de pedido: ");
    int.TryParse(Console.ReadLine(), out nroP);
    Console.WriteLine("Id del nuevo cadete: ");
    int.TryParse(Console.ReadLine(), out nuevoCadeteId);

    cadeteria.ReasignarPedido(nroP, nuevoCadeteId);
}

void AgregarListaCadetes(ref Cadeteria cadeteria, List<Cadete> cadetes)
{
    cadeteria.ListadoCadetes = cadetes;
}

void Informe()
{
    float montoTotal = 0;
    int cantPedidosEnvTotal = 0;
    foreach (Cadete cad in cadeteria.ListadoCadetes)
    {
        float monto = 0;
        int cantPedidos = 0;
        int cantPedidosEnviados = 0;
        Console.WriteLine("=============");
        Console.WriteLine("ID: {0}", cad.Id);
        Console.WriteLine("Nombre: {0}", cad.Nombre);
        foreach (var ped in cadeteria.ListadoPedidos)
        {
            if (ped.IdCadete == cad.Id)
            {
                cantPedidos++;
                if (ped.Estado == Estados.Entregado)
                {
                    cantPedidosEnviados++;
                    cantPedidosEnvTotal++;
                    monto += 500;
                }
            }
        }
        Console.WriteLine("Cantidad pedidos: {0}", cantPedidos);
        Console.WriteLine("Cantidad pedidos enviados: {0}", cantPedidosEnviados);
        Console.WriteLine("Jornal: ${0}", monto);
        Console.WriteLine("=============");
        montoTotal += monto;
    }
    Console.WriteLine("Monto total recaudado: ${0}", montoTotal);
    float promedio = 0;
    if (cadeteria.ListadoCadetes.Count != 0)
    {
        promedio = (float)cantPedidosEnvTotal / cadeteria.ListadoCadetes.Count;
    }
    Console.WriteLine("Promedio de envios por cadete: {0}", promedio);
}