using CartorioCasamento.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CartorioCasamento.API.ViewModels
{
    public class CasamentoViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid Referencia { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int PedidoCasamentoId { get; set; }

        public int? UsuarioPrimeiraTestemunhaId { get; set; }
        public int? UsuarioSegundaTestemunhaId { get; set; }
        public DateTime? DataEntrada { get; set; }
        public decimal? ValorCasamento { get; set; }
        public DateTime? DataAprovacaoEntrada { get; set; }
        public DateTime? DataCasamento { get; set; }
        public DateTime? DataRealizacaoCasamento { get; set; }
        public string LinkCerimoniaGravada { get; set; }
        public DateTime? DataAprovacaoDiarioOficial { get; set; }
        public string ArquivoFoto { get; set; }
        public DateTime? DataDivorcio { get; set; }

        // RELACIONAMENTOS
        //public PedidoCasamentoViewModel PedidoCasamento { get; set; }
        //public UsuarioViewModel UsuarioPrimeiraTestemunha { get; set; }
        //public UsuarioViewModel UsuarioSegundaTestemunha { get; set; }

        // AUXILIAR
        public string Status
        {
            get
            {
                if (DataAprovacaoEntrada == null) return "Aguardando aprovação do casamento pelo cartório";
                if (DataCasamento == null) return "Aguardando a escolha da data da cerimônica";
                if (DataRealizacaoCasamento == null) return "Estamos aguardando ansiosamente pelo grande dia!";
                if (DataAprovacaoDiarioOficial == null) return "Agora estamos aguardando somente a publicação no diário oficial.";

                if (DataDivorcio != null) return "O processo de divórcio já foi finalizado com sucesso.";

                return "Parabéns! O seu casamento foi incrível. Já está tudo certo por aqui.";
            }
        }
    }
}
