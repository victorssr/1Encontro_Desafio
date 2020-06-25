using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CartorioCasamento.API.ViewModels
{
    public class RegimeBensViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(300, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
        public string Descricao { get; set; }

        // RELACIONAMENTO
        public List<PedidoCasamentoViewModel> PedidosCasamentos { get; set; }
    }
}
