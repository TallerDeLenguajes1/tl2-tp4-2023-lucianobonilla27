using EspacioClase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace MiApi.Controllers
{
    [ApiController]
    [Route("Cadeteria")]
    public class CadeteriaController : ControllerBase
    {
        private static List<Pedidos> pedidos = new List<Pedidos>();
        private static List<Cadete> cadetes = new List<Cadete>();

        public CadeteriaController(ILogger<CadeteriaController> logger)
        {
            _logger = logger;

            // Inicializa la lista de pedidos en el constructor
            Cliente cliente1 = new Cliente("Cliente 1", "Dirección 1", 123456789, "Datos de referencia 1");
            Cliente cliente2 = new Cliente("Cliente 2", "Dirección 2", 987654321, "Datos de referencia 2");
            Cliente cliente3 = new Cliente("Cliente 3", "Dirección 3", 732445555, "Datos de referencia 3");
            Cadete cadete1 = new Cadete(1, "Cadete 1", "Dirección 1", 123456789);
            Cadete cadete2 = new Cadete(2, "Cadete 2", "Dirección 2", 987654321);
            Cadete cadete3 = new Cadete(3, "Cadete 3", "Dirección 3", 732445555);

            pedidos.Add(new Pedidos(1, "este es el pedido 1", cliente1, "Pendiente", cadete1));
            pedidos.Add(new Pedidos(2, "este es el pedido 2", cliente2, "Realizado", cadete2));
            pedidos.Add(new Pedidos(3, "este es el pedido 3", cliente3, "EnCamino", cadete3));

            cadetes.Add(cadete1);
            cadetes.Add(cadete2);
            cadetes.Add(cadete3);
        }

        private readonly ILogger<CadeteriaController> _logger;

        [HttpGet(Name = "GetPedidos")]
        [Route("ListarPedidos")]
        public ActionResult<IEnumerable<Pedidos>> GetPedidos()
        {
            return Ok(pedidos);
        }

        [HttpGet(Name = "GetCadetes")]
        [Route("ListarCadetes")]
        public ActionResult<IEnumerable<Cadete>> GetCadetes()
        {
            return Ok(cadetes);
        }
    }
}

