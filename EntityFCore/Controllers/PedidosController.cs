using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFCore.Domais;
using EntityFCore.Interfaces;
using EntityFCore.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace EntityFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidosController()
        {
            _pedidoRepository = new PedidoRepository();
        }

        // GET: api/<PedidosController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var pedidos = _pedidoRepository.Listar();

                if(pedidos.Count == 0)
                    return NoContent();

                return Ok(pedidos);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/<PedidosController>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var pedido = _pedidoRepository.BuscarPorId(id);

                if (pedido == null)
                    return NotFound();

                return Ok(pedido);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<PedidosController>
        [HttpPost]
        public IActionResult Post(List<PedidoItem> pedidosItens)
        {
            try
            {
                //Adiciona um pedido
                Pedido pedido = _pedidoRepository.Adicionar(pedidosItens);

                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
