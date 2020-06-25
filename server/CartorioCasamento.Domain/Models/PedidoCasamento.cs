using System;

namespace CartorioCasamento.Domain.Models
{
    public class PedidoCasamento : EntityBase
    {
        public int UsuarioSolicitanteId { get; set; }
        public int UsuarioSolicitadoId { get; set; }
        public int RegimeBensId { get; set; }
        public DateTime? DataPedidoNegado { get; set; }
        public DateTime? DataPedidoAceito { get; set; }

        // RELACIONAMENTO
        public Usuario UsuarioSolicitante { get; set; }
        public Usuario UsuarioSolicitado { get; set; }
        public RegimeBens RegimeBens { get; set; }
        public Casamento Casamento { get; set; }
    }
}
