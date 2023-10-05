using System.Text.Json;
namespace cadeteria;
public abstract class AccesoADatos
{
    public bool ExisteArchivo(string path)
    {
        return File.Exists(path);
    }
    public abstract Cadeteria cargarCadeteria(string path);
    public abstract List<Cadete> cargarCadetes(string path);
}

public class ArchivoCSV : AccesoADatos
{
    public override Cadeteria cargarCadeteria(string path)
    {
        var archivo = new StreamReader(path);
        string texto = archivo.ReadLine();
        string[] textoSeparado;
        Cadeteria cadeteria = null;
        while (texto != null)
        {
            textoSeparado = texto.Split(";");
            cadeteria = new Cadeteria(textoSeparado[0], textoSeparado[1]);
            texto = archivo.ReadLine();
        }
        archivo.Close();
        return cadeteria;
    }
    public override List<Cadete> cargarCadetes(string path)
    {
        List<Cadete> listaCad = new List<Cadete>();
        var archivo = new StreamReader(path);
        string texto = archivo.ReadLine();
        string[] textoSeparado;
        while (texto != null)
        {
            textoSeparado = texto.Split(";");
            Cadete cadete = new Cadete(Convert.ToInt32(textoSeparado[0]), textoSeparado[1], textoSeparado[2], textoSeparado[3]);
            listaCad.Add(cadete);
            texto = archivo.ReadLine();
        }
        archivo.Close();
        return listaCad;
    }
}

public class ArchivoJSON : AccesoADatos
{
    public override Cadeteria cargarCadeteria(string path)
    {
        var archivo = new StreamReader(path);
        string texto = archivo.ReadToEnd();
        Cadeteria cadeteria = null;
        if (texto != null)
        {
            cadeteria = JsonSerializer.Deserialize<Cadeteria>(texto);
        }
        archivo.Close();
        return cadeteria;
    }
    public override List<Cadete> cargarCadetes(string path)
    {
        List<Cadete> lisCad = new List<Cadete>();
        var archivo = new StreamReader(path);
        string texto = archivo.ReadToEnd();
        lisCad = JsonSerializer.Deserialize<List<Cadete>>(texto);
        archivo.Close();
        return lisCad;
    }
}