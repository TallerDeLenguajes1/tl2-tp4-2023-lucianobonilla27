namespace WebApi
{
    using System.IO;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class AccesoADatosCadeteria
    {
        public Cadeteria cadeteria = null;
        public Cadeteria obtener(){
            string contenido = File.ReadAllText("Models/cadeteria.json");
            cadeteria = JsonSerializer.Deserialize<Cadeteria>(contenido);
            return cadeteria;
        }
    }

    public class AccesoADatosCadetes
    {
        private List<Cadete> Cadetes = new List<Cadete>(); 
        

        public List<Cadete> Obtener(){
        
                string jsonCadetes = File.ReadAllText("Models/cadetes.json");
                var cadetes = JsonSerializer.Deserialize<Cadete[]>(jsonCadetes);
                Cadetes.AddRange(cadetes);
                return Cadetes;

        }


    }   



    public class AccesoADatosPedidos
    {
        private List<Pedidos> Pedidos = new List<Pedidos>();

        public List<Pedidos> Obtener(){
            string jsonPedidos = File.ReadAllText("Models/pedidos.json");
            var pedidos = JsonSerializer.Deserialize<Pedidos[]>(jsonPedidos);
            Pedidos.AddRange(pedidos);
            return Pedidos;
        }

        public void Guardar(List<Pedidos> pedidos)
        {
            
                // Ruta del archivo JSON donde se guardarán los pedidos
                string rutaArchivoJson = "Models/pedidos.json";
                var opcionesDeSerializacion = new JsonSerializerOptions
                    {
                        WriteIndented = true // Esto activa la indentación
                    };
                // Serializar la lista de pedidos a formato JSON
                string jsonPedidos = JsonSerializer.Serialize(pedidos,opcionesDeSerializacion);

                // Escribir el JSON en el archivo
                File.WriteAllText(rutaArchivoJson, jsonPedidos);
            
           
        }
    }
}    
    // public abstract class AccesoADatos
    // {
    //     public Cadeteria cadeteria = null;
    //     public abstract Cadeteria CargarInfoCadeteria();
    // }

    // public class AccesoCsv : AccesoADatos
    // {
    //     public override Cadeteria CargarInfoCadeteria()
    //     {
    //         try
    //         {
    //             using (StreamReader reader = new StreamReader("Models/cadeteria.csv"))
    //             {
    //                 string[] datos = reader.ReadLine().Split(',');
    //                 // Asumiendo que Nombre, telefono y NroPedidosCreados están definidos en Cadeteria.
    //                 string Nombre = datos[0];
    //                 int Telefono = int.Parse(datos[1]);
    //                 int NroPedidosCreados = int.Parse(datos[2]);
    //                 cadeteria = new Cadeteria(Nombre, Telefono, NroPedidosCreados);
    //                 cadeteria.ListaCadetes = CargarCadetes();
    //             }
    //         }
    //         catch (Exception ex)
    //         {
    //             //Console.WriteLine("Error al cargar la información de la cadetería: " + ex.Message);
    //         }
    //         return cadeteria;
    //     }

    //     public List<Cadete> CargarCadetes()
    //     {
    //         List<Cadete> cadetes = new List<Cadete>(); // Nueva lista de cadetes

    //         try
    //         {
    //             using (StreamReader reader = new StreamReader("cadetes.csv"))
    //             {
    //                 string line;
    //                 while ((line = reader.ReadLine()) != null)
    //                 {
    //                     string[] datosCadete = line.Split(',');
    //                     int id = int.Parse(datosCadete[0]);
    //                     string nombre = datosCadete[1];
    //                     string direccion = datosCadete[2];
    //                     int telefono = int.Parse(datosCadete[3]);

    //                     Cadete cadete = new Cadete(id, nombre, direccion, telefono);
    //                     cadetes.Add(cadete); // Agrega el cadete a la nueva lista
    //                 }
    //             }
    //         }
    //         catch (Exception ex)
    //         {
    //             //Console.WriteLine("Error al cargar la lista de cadetes: " + ex.Message);
    //         }

    //         return cadetes; // Devuelve la lista de cadetes
    //     }

    // }
    // public class AccesoJson : AccesoADatos
    // {
    //     public override Cadeteria CargarInfoCadeteria()
    //     {

    //         string contenido = File.ReadAllText("Models/cadeteria.json");
    //         cadeteria = JsonSerializer.Deserialize<Cadeteria>(contenido);
            
    //         return cadeteria;

    //     }


    // }
