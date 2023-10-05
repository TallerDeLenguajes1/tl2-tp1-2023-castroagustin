namespace cadeteria;

public class Cadeteria
{
    private string? nombre;
    private string? telefono;
    private List<Cadete>? listadoCadetes;
    private List<Pedido>? listadoPedidos;

    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Telefono { get => telefono; set => telefono = value; }
    public List<Cadete>? ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
    public List<Pedido>? ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

    public Cadeteria(string nom, string tel)
    {
        Nombre = nom;
        Telefono = tel;
        listadoPedidos = new List<Pedido>();
    }

    public void crearPedido(int cadId, string obs, string cliNom, string cliDir, string cliTel, string cliRef)
    {
        Cliente clientePedido = new Cliente(cliNom, cliDir, cliTel, cliRef);
        Pedido nuevoPedido = new Pedido(listadoPedidos.Count + 1, obs, clientePedido);
        listadoPedidos.Add(nuevoPedido);
    }


    public int JornalACobrar(int id)
    {
        int total = 0;
        foreach (Pedido p in listadoPedidos)
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
        foreach (Pedido p in listadoPedidos)
        {
            if (p.Nro == idPed)
            {
                p.IdCadete = idCad;
            }
        }
    }
}