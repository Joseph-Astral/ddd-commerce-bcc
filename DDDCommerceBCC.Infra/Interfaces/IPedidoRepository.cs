using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDCommerceBCC.Domain
{
    public interface IPedidoRepository
    {
        Task<Pedido> ObterPorIdAsync(int id);
        Task<IEnumerable<Pedido>> ObterTodosAsync();
        Task AdicionarAsync(Pedido pedido);
        Task AtualizarAsync(Pedido pedido);
        Task RemoverAsync(int id);
    }
}
