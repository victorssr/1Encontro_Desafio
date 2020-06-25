using CartorioCasamento.Domain.Interfaces.Repositories;
using CartorioCasamento.Domain.Interfaces.Services;
using CartorioCasamento.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<List<PedidoCasamento>> BuscaPedidosPendentesUsuario(int idUsuario)
        {
            return await _pedidoCasamentoRepository.BuscaPedidosPendentesUsuario(idUsuario);
        }
    }
}
