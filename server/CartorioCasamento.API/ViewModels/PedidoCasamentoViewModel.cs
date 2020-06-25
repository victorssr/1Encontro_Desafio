using System;
using System.ComponentModel.DataAnnotations;

namespace CartorioCasamento.API.ViewModels
{
    public class PedidoCasamentoViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int UsuarioSolicitanteId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int UsuarioSolicitadoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int RegimeBensId { get; set; }

        public DateTime? DataPedidoNegado { get; set; }
        public DateTime? DataPedidoAceito { get; set; }

        // RELACIONAMENTO
        public UsuarioViewModel UsuarioSolicitante { get; set; }
        public UsuarioViewModel UsuarioSolicitado { get; set; }
        public RegimeBensViewModel RegimeBens { get; set; }
        public CasamentoViewModel Casamento { get; set; }
    }
}
