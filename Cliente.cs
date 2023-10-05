namespace cadeteria;

public class Cliente {
    private string? nombre;
    private string? direccion;
    private string? telefono;
    private string? datosReferenciaDireccion;

    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Direccion { get => direccion; set => direccion = value; }
    public string? Telefono { get => telefono; set => telefono = value; }
    public string? DatosReferenciaDireccion { get => datosReferenciaDireccion; set => datosReferenciaDireccion = value; }

    public Cliente (string nom, string dir, string tel, string referencia) {
        this.nombre = nom;
        this.direccion = dir;
        this.telefono = tel;
        this.datosReferenciaDireccion = referencia;
    }
}