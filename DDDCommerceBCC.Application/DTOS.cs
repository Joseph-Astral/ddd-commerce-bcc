namespace DDDCommerceBCC.Application
{
    public class PedidoDto
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public DateTime DataCriacao { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
