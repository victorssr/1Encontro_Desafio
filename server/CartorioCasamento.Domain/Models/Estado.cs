namespace CartorioCasamento.Domain.Models
{
    public class Estado : EntityBase
    {
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public decimal ValorCasamento { get; set; }
    }
}
