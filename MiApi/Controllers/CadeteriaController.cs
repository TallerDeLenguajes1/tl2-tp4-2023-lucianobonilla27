
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using WebApi;

namespace MiApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CadeteriaController : ControllerBase
    {
        // Supongamos que Cadeteria es una clase Singleton.
        private Cadeteria _cadeteria;
        private readonly ILogger<CadeteriaController> _logger;

        // Constructor para inicializar la Cadeteria.
        public CadeteriaController(ILogger<CadeteriaController> logger)
        {
            _logger = logger;
            _cadeteria = Cadeteria.Instance;
        }

        // GET api/Cadeteria/ListarPedidos
        [HttpGet]
        [Route("ListarPedidos")]
        public IActionResult GetPedidos()
        {
            var pedidos = _cadeteria.ListaPedidos;
            return Ok(pedidos);
        }

        // GET api/Cadeteria/ListarCadetes

        [HttpGet]
        [Route("ListarCadetes")]
        public IActionResult GetCadetes()
        {
            var cadetes = _cadeteria.ListaCadetes;
            return Ok(cadetes);
        }

        [HttpGet]
        [Route("Informe")]
         public ActionResult<Informe> GetInforme()
         {
            _cadeteria.CrearInforme();
            var informe = _cadeteria.CadInforme;
            return Ok(informe);
         }


        [HttpPost]
        [Route("AgregarPedido")]
        public ActionResult<Pedidos> AddPedido(Pedidos pedido)
        {
            _cadeteria.AgregarPedido();
            int cont = _cadeteria.NroPedidosCreados; // Obtener el último número de pedido generado
            
            // Asignar el número de pedido y agregarlo a la lista de pedidos
            pedido.Nro = cont;
            foreach (var p in _cadeteria.ListaPedidos)
            {
                if (p.Nro == cont)
                {
                    p.Obs = pedido.Obs;
                    p.InfoCliente = pedido.InfoCliente;
                    p.Estado = pedido.Estado;
                    p.IdCadeteEncargado = pedido.IdCadeteEncargado;

                }
            }

            // Puedes realizar otras operaciones aquí si es necesario

            // Devolver el pedido creado
            return Ok(pedido);

        }

        [HttpPut("AsignarPedido")]
        public ActionResult<Pedidos> AsignarPedido(int idPedido, int idCadete)
        {
            _cadeteria.AsignarPedido(idPedido,idCadete);
            return Ok($"Pedido {idPedido} asignado al cadete {idCadete}.");
        }

        [HttpPut("CambiarEstadoPedido")]
        public ActionResult<Pedidos> CambiarEstadoPedido(int idPedido,int NuevoEstado)
        {
            _cadeteria.CambiarEstadoPedido(idPedido, NuevoEstado);
            return Ok($"Estado del pedido {idPedido} cambiado a {NuevoEstado}.");
        }

        [HttpPut("CambiarCadetePedido")]
         public ActionResult CambiarCadetePedido(int idPedido, int idNuevoCadete)
        {
            _cadeteria.CambiarCadetePedido(idPedido,idNuevoCadete);
            return Ok($"Cadete del pedido {idPedido} cambiado a {idNuevoCadete}.");
        }    


 


        
    }
}

