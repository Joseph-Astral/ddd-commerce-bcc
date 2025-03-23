using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDCommerceBCC.Domain;

namespace DDDCommerceBCC.Application
{
    public class PedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<PedidoDto> CriarPedidoAsync(string cliente, decimal valorTotal)
        {
            var pedido = new Pedido(0, cliente, DateTime.UtcNow, valorTotal);
            await _pedidoRepository.AdicionarAsync(pedido);

            return new PedidoDto
            {
                Id = pedido.Id,
                Cliente = pedido.Cliente,
                DataCriacao = pedido.DataCriacao,
                ValorTotal = pedido.ValorTotal
            };
        }

        public async Task<PedidoDto> AtualizarPedidoAsync(int id, decimal valorTotal)
        {
            var pedido = await _pedidoRepository.ObterPorIdAsync(id);
            if (pedido == null)
                throw new Exception("Pedido não encontrado");

            pedido.AtualizarValorTotal(valorTotal);
            await _pedidoRepository.AtualizarAsync(pedido);

            return new PedidoDto
            {
                Id = pedido.Id,
                Cliente = pedido.Cliente,
                DataCriacao = pedido.DataCriacao,
                ValorTotal = pedido.ValorTotal
            };
        }

        public async Task RemoverPedidoAsync(int id)
        {
            await _pedidoRepository.RemoverAsync(id);
        }

        public async Task<PedidoDto> ObterPedidoPorIdAsync(int id)
        {
            var pedido = await _pedidoRepository.ObterPorIdAsync(id);
            if (pedido == null)
                return null;

            return new PedidoDto
            {
                Id = pedido.Id,
                Cliente = pedido.Cliente,
                DataCriacao = pedido.DataCriacao,
                ValorTotal = pedido.ValorTotal
            };
        }

        public async Task<IEnumerable<PedidoDto>> ObterTodosPedidosAsync()
        {
            var pedidos = await _pedidoRepository.ObterTodosAsync();
            return pedidos.Select(p => new PedidoDto
            {
                Id = p.Id,
                Cliente = p.Cliente,
                DataCriacao = p.DataCriacao,
                ValorTotal = p.ValorTotal
            });
        }
    }
}
