using System;

namespace CartorioCasamento.Domain.Models
{
    public class Casamento : EntityBase
    {
        public Casamento()
        {
            Referencia = Guid.NewGuid();
        }
        public Guid Referencia { get; set; }
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
        public PedidoCasamento PedidoCasamento { get; set; }
        public Usuario UsuarioPrimeiraTestemunha { get; set; }
        public Usuario UsuarioSegundaTestemunha { get; set; }

        // AUXILIAR
        public string StatusDescricao
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

        public string Status
        {
            get
            {
                if (DataAprovacaoEntrada == null) return "APROVACAO_ENTRADA";
                if (DataCasamento == null) return "DATA_CASAMENTO";
                if (DataRealizacaoCasamento == null) return "REALIZACAO_CASAMENTO";
                if (DataAprovacaoDiarioOficial == null) return "DIARIO_OFICIAL";
                if (DataDivorcio != null) return "DIVORCIO";

                return "CONCLUIDO";
            }
        }
    }
}
