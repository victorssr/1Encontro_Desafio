using CartorioCasamento.Domain.Interfaces.Repositories;
using CartorioCasamento.Domain.Interfaces.Services;
using CartorioCasamento.Domain.Models;

namespace CartorioCasamento.Domain.Services
{
    public class PedidoCasamentoService : ServiceBase<PedidoCasamento>, IPedidoCasamentoService
    {
        private readonly IPedidoCasamentoRepository _pedidoCasamentoRepository;

        public PedidoCasamentoService(IPedidoCasamentoRepository pedidoCasamentoRepository)
            : base(pedidoCasamentoRepository)
        {
            _pedidoCasamentoRepository = pedidoCasamentoRepository;
        }
    }
}
