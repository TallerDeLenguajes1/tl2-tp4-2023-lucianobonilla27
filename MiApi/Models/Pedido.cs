
namespace EspacioClase
{
    public class Pedidos
    {
        private int nro;
        private string obs;
        private Cliente infoCliente;
        private string estado; 
        private Cadete cadeteAsignado;

        public string Obs { get => obs; set => obs = value; }
        public Cliente InfoCliente { get => infoCliente;}
        public string Estado { get => estado; set => estado = value; }
        public int Nro { get => nro; }
        public Cadete CadeteAsignado { get => cadeteAsignado; set => cadeteAsignado = value; }

    public Pedidos(int nro)
        {
            this.nro = nro;
            this.obs = null;
            this.infoCliente = CrearClienteAleatorio(); // Crear cliente aleatorio
            Estado = "EnCamino";
            
        }

        public Pedidos(int nro,string obs,Cliente info,string estado,Cadete cadeteAsignado){
            this.nro = nro;
            this.obs = obs;
            this.infoCliente = info;
            this.estado = estado;
            this.cadeteAsignado = cadeteAsignado;
        }

        private Cliente CrearClienteAleatorio()
        {
            Random random = new Random();
            string nombre = "Cliente" + random.Next(1, 100);
            string direccion = "Dirección" + random.Next(1, 100);
            int telefono = random.Next(100000000, 999999999);
            string datosReferenciaDireccion = "Referencia" + random.Next(1, 100);

            return new Cliente(nombre, direccion, telefono, datosReferenciaDireccion);
        }
        public void VerDireccionCliente()
        {
            Console.WriteLine("La direccion del cliente "+ infoCliente.Nombre + "es: "+ infoCliente.Direccion);
        }

        public void VerDatosCliente()
        {
            Console.WriteLine("----Info del Cliente---");
            Console.WriteLine("Nombre: "+ infoCliente.Nombre);
            Console.WriteLine("Telefono: "+ infoCliente.Telefono);
            Console.WriteLine("Direccion: "+ infoCliente.Direccion);
        }

    }
}