namespace cadeteria;

public enum Estados
{
    Pendiente,
    Entregado,
    Cancelado
}

public class Cadete
{
    private int id;
    private string? nombre;
    private string? direccion;
    private string? telefono;


    public int Id { get => id; set => id = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Direccion { get => direccion; set => direccion = value; }
    public string? Telefono { get => telefono; set => telefono = value; }


    public Cadete(int id, string nom, string dir, string tel)
    {
        this.id = id;
        this.nombre = nom;
        this.direccion = dir;
        this.telefono = tel;
    }

}