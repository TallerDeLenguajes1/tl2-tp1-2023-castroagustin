namespace cadeteria;

public class Pedido {
    private int? nro;
    private string? obs;
    private Cliente? cliente;
    private Estados estado;

    public int? Nro { get => nro; set => nro = value; }
    public string? Obs { get => obs; set => obs = value; }
    public Estados Estado { get => estado; set => estado = value; }
    public Cliente? Cliente { get => cliente; set => cliente = value; }

    public Pedido (int nro, string obs, Cliente cli) {
        this.nro = nro;
        this.obs = obs;
        this.cliente = cli;
        this.estado = Estados.Pendiente;
    }

    public void CambiarEstado (Estados est) {
        if (this.estado == Estados.Pendiente) {
            this.estado = est;
        }
    }
}