using System.Runtime.InteropServices;
using DDDCommerceBCC.Domain;
using Microsoft.EntityFrameworkCore;
using DDDCommerceBCC.Infra.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DDDCommerceBCC.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoRepository _pedidoService;

        public PedidoController(PedidoRepository pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarPedido([FromBody] Pedido p)
        {
            await _pedidoService.AdicionarAsync(p);
            return Ok(p);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarPedido(int id, [FromBody] Pedido p)
        {
            await _pedidoService.AtualizarAsync(p);
            return Ok(p);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverPedido(int id)
        {
            await _pedidoService.RemoverAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPedido(int id)
        {
            var pedido = await _pedidoService.ObterPorIdAsync(id);
            if (pedido == null)
                return NotFound();
            return Ok(pedido);
        }

        [HttpGet]
        public async Task<IActionResult> GetPedidos()
        {
            var pedidos = await _pedidoService.ObterTodosAsync();
            return Ok(pedidos);
        }
    }
}
