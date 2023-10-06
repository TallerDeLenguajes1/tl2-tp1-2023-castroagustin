namespace cadeteria;

public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> listadoCadetes;
    private List<Pedido> listadoPedidos;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
    public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

    public Cadeteria(string nombre, string telefono)
    {
        Nombre = nombre;
        Telefono = telefono;
        listadoPedidos = new List<Pedido>();
    }


    public void AgregarListaCadetes(List<Cadete> listaCadetes)
    {
        this.listadoCadetes = listaCadetes;
    }

    public void crearPedido(int cadId, int nroP, string obs, string cliNom, string cliDir, string cliTel, string cliRef)
    {
        Cliente clientePedido = new Cliente(cliNom, cliDir, cliTel, cliRef);
        Pedido nuevoPedido = new Pedido(cadId, nroP, obs, clientePedido);
        ListadoPedidos.Add(nuevoPedido);
    }


    public int JornalACobrar(int id)
    {
        int total = 0;
        foreach (Pedido p in ListadoPedidos)
        {
            if (p.IdCadete == id && p.Estado == Estados.Entregado)
            {
                total += 500;
            }
        }
        return total;
    }

    public void asignarCadeteAPedido(int idCad, int idPed)
    {
        foreach (Pedido p in ListadoPedidos)
        {
            if (p.Nro == idPed)
            {
                p.IdCadete = idCad;
            }
        }
    }
}