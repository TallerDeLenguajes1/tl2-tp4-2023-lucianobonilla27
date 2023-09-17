namespace EspacioClase
{
    class Informe
    {
        private int montoTotalGanado;
        private int totalEnvios;
        private double promedioEnviosXCadete;
        private Cadeteria cadeteria ;
        public int MontoTotalGanado { get => montoTotalGanado; set => montoTotalGanado = value; }
        public int TotalEnvios { get => totalEnvios; set => totalEnvios = value; }
        public double PromedioEnviosXCadete { get => promedioEnviosXCadete; set => promedioEnviosXCadete = value; }
        public Cadeteria Cadeteria { get => cadeteria; set => cadeteria = value; }

        public Informe(Cadeteria cadeteria)
        {
            Cadeteria = cadeteria;
            foreach (Pedidos p in Cadeteria.ListaPedidos)
            {
                if (p.Estado == "Entregado")
                {
                    TotalEnvios++;
                }
            }
            MontoTotalGanado = TotalEnvios*500;
            if (Cadeteria.ListaCadetes.Count != 0)
            {
                PromedioEnviosXCadete = TotalEnvios/Cadeteria.ListaCadetes.Count;
            }
        }

        

        public void MostrarInforme(){
            Console.WriteLine("--------Informe de la Cadeteria "+ Cadeteria.Nombre + "--------");
            Console.WriteLine("Cantidad de Envios REALIZADOS: "+ TotalEnvios);
            Console.WriteLine("Promedio de Envios por cadete: "+PromedioEnviosXCadete);
            Console.WriteLine("Monto total generado: "+ MontoTotalGanado);
            Console.WriteLine("");
           
        }
    }
}