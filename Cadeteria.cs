namespace cadeteria;

public class Cadeteria
{
    private string? nombre;
    private string? telefono;
    private List<Cadete>? listadoCadetes;

    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Telefono { get => telefono; set => telefono = value; }
    public List<Cadete>? ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }

    public Cadeteria(string nom, string tel)
    {
        Nombre = nom;
        Telefono = tel;
        ListadoCadetes = new List<Cadete>();
    }

    public void crearPedido(int cadId, int nro, string obs, string cliNom, string cliDir, string cliTel, string cliRef)
    {
        Cliente clientePedido = new Cliente(cliNom, cliDir, cliTel, cliRef);
        Pedido nuevoPedido = new Pedido(nro, obs, clientePedido);
        foreach (Cadete Cad in listadoCadetes)
        {
            if (Cad.Id == cadId)
            {
                Cad.ListadoPedidos.Add(nuevoPedido);
                break;
            }
        }
    }
}