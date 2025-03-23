namespace DDDCommerceBCC.Domain
{
    public class Pedido
    {
        public int Id { get; private set; }
        public string Cliente { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public decimal ValorTotal { get; private set; }

        public Pedido(int id, string cliente, DateTime dataCriacao, decimal valorTotal)
        {
            Id = id;
            Cliente = cliente;
            DataCriacao = dataCriacao;
            ValorTotal = valorTotal;
        }

        // Exemplo de método de domínio
        public void AtualizarValorTotal(decimal novoValor)
        {
            ValorTotal = novoValor;
        }
    }
}
