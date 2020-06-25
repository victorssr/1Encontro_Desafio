using System.Collections.Generic;

namespace CartorioCasamento.Domain.Models
{
    public class RegimeBens : EntityBase
    {
        public string Descricao { get; set; }

        // RELACIONAMENTO
        public List<PedidoCasamento> PedidosCasamentos { get; set; }
    }
}
