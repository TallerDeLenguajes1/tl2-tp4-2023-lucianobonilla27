using System.Text.Json;
using System.Text.Json.Serialization;
namespace EspacioClase
{
    public abstract class AccesoADatos
{
    public abstract Cadeteria CargarDatos(string archivoInfoCadeteria, string archivoCadetes);
    
}

// Clase derivada AccesoCSV
public class AccesoCSV : AccesoADatos
{
    public override Cadeteria CargarDatos(string archivoInfoCadeteria, string archivoCadetes)
    {
    Cadeteria cadeteria = null; // Declarar cadeteria fuera de los bloques try

    try // Cargar datos de la cadeteria
    {
        using (StreamReader reader = new StreamReader(archivoInfoCadeteria))
        {
            string[] datos = reader.ReadLine().Split(',');
            string nombre = datos[0];
            int telefono = int.Parse(datos[1]);
            int nroPedidosCreados = int.Parse(datos[2]);
            cadeteria = new Cadeteria(nombre, telefono, nroPedidosCreados);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error al cargar la información de la cadetería: " + ex.Message);
    }

    try // Cargar datos de los cadetes
    {
        if (cadeteria != null) // Asegurarse de que cadeteria no sea nula
        {
            using (StreamReader reader = new StreamReader(archivoCadetes))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] datosCadete = line.Split(',');
                    int id = int.Parse(datosCadete[0]);
                    string nombre = datosCadete[1];
                    string direccion = datosCadete[2];
                    int telefono = int.Parse(datosCadete[3]);

                    Cadete cadete = new Cadete(id, nombre, direccion, telefono);
                    cadeteria.ListaCadetes.Add(cadete);
                }
            }
        }
        else
        {
            Console.WriteLine("Error: La cadetería no se ha cargado correctamente.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error al cargar la lista de cadetes: " + ex.Message);
    }
    return cadeteria;
    }

    
}


public class AccesoJson : AccesoADatos
{
    

    public override Cadeteria CargarDatos(string archivoInfoCadeteria, string archivoCadetes)
    {
        Cadeteria cadeteria = null;

        try
        {
            string jsonInfoCadeteria = File.ReadAllText(archivoInfoCadeteria);
            cadeteria = JsonSerializer.Deserialize<Cadeteria>(jsonInfoCadeteria);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al cargar la información de la cadetería desde JSON: " + ex.Message);
        }

        try
        {
            if (cadeteria != null)
            {
                string jsonCadetes = File.ReadAllText(archivoCadetes);
                var cadetes = JsonSerializer.Deserialize<Cadete[]>(jsonCadetes);
                cadeteria.ListaCadetes.AddRange(cadetes);
            }
            else
            {
                Console.WriteLine("Error: La cadetería no se ha cargado correctamente desde JSON.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al cargar la lista de cadetes desde JSON: " + ex.Message);
        }

        return cadeteria;
    }
}
}