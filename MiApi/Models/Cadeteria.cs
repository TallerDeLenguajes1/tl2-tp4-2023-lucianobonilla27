namespace EspacioClase
{
    public class Cadeteria
    {
        private string nombre;
        private int telefono;
        private List<Cadete> listaCadetes = new List<Cadete>();
        private int nroPedidosCreados;
        private List<Pedidos> listaPedidos = new List<Pedidos>();

        public List<Cadete> ListaCadetes { get => listaCadetes; set => listaCadetes = value; }
        public int NroPedidosCreados { get => nroPedidosCreados; set => nroPedidosCreados = value; }
    
        public List<Pedidos> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Telefono { get => telefono; set => telefono = value; }

    public Cadeteria(string nombre,int telefono, int nroPedidosCreados)
            {
                this.Nombre = nombre;
                this.Telefono = telefono;
                this.nroPedidosCreados = nroPedidosCreados;
            }

        
        

        public Pedidos AsignarCadeteAPedido()
        {
            if (ListaCadetes.Count > 0)
            {
                Random random = new Random();
                int indiceAleatorio = random.Next(0, ListaCadetes.Count);
                Cadete cadeteAleatorio = ListaCadetes[indiceAleatorio]; // Elijo un cadete de manera aleatoria

                Pedidos nuevoPedido = new Pedidos(NroPedidosCreados + 1); // Crea una instancia de Pedido ; NOTA: necesito AGREGAR OBS
                NroPedidosCreados += 1; // Incremento la cantidad de pedidos creados

                nuevoPedido.CadeteAsignado = cadeteAleatorio; // al nuevo pedido le asigno un cadete
                listaPedidos.Add(nuevoPedido);
                return nuevoPedido;

                //Console.WriteLine("Pedido nro "+nuevoPedido.Nro+" asignado al cadete: " + cadeteAleatorio.Nombre);
            }
            else
            {
                return null;
                //Console.WriteLine("No hay cadetes disponibles para asignar el pedido.");
            }
        }



        public Pedidos CambiarEstadoPedido(int idPedido, string nuevoEstado)
        {
            foreach (Pedidos pedido in ListaPedidos)
            {
                if (idPedido == pedido.Nro)
                {
                    pedido.Estado = nuevoEstado;
                    //Console.WriteLine("El pedido nro " + idPedido + " cambio de estado a : " + nuevoEstado);
                    return pedido;
                }
            }
            //Console.WriteLine("No se encontró el pedido con ID " + idPedido);
            return null;
        }

        public bool AltaPedido(int idPedido){ // Esta funcion da de alta un pedio por una id recibida
            foreach (Pedidos pedido in listaPedidos)
            {
                var pedidoAlta = ListaPedidos.FirstOrDefault(pedido => pedido.Nro == idPedido);
                if (pedidoAlta != null)
                {
                    ListaPedidos.Remove(pedidoAlta);
                    //Console.WriteLine("El pedido " + idPedido + " ha sido dado de alta correctamente");
                    return true;
                }
            }
            //Console.WriteLine("No se encontro el pedido " + idPedido + ".");
            return false;
        }



         public int JornalACobrar(int id) {
            int cantPedidosEntregados = 0;
            const int precioPorEnvio = 500;
            foreach (Pedidos pedido in ListaPedidos)
            {
                if (pedido.Estado == "Entregado" && pedido.CadeteAsignado.Id == id)
                {
                    cantPedidosEntregados++;
                }
            }
            return cantPedidosEntregados*precioPorEnvio;
         }
         public int PedidosEntregados(Cadete c){
            int cantPedidosRealizados = 0;
            foreach (Pedidos pedido in ListaPedidos)
            {
                if (pedido.CadeteAsignado.Id == c.Id){    
                    if (pedido.Estado == "Entregado")
                    {
                        cantPedidosRealizados += 1;
                    }
                }    
            }
            return cantPedidosRealizados;
        }

    }
}