using System.Collections.Generic;

namespace CartorioCasamento.Domain.Models
{
    public class Estado : EntityBase
    {
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public decimal ValorCasamento { get; set; }

        // RELACIONAMENTO
        public List<Usuario> Usuarios { get; set; }
    }
}
