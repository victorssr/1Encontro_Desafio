using CartorioCasamento.Domain.Interfaces.Repositories;
using CartorioCasamento.Domain.Models;
using CartorioCasamento.Infra.Context;

namespace CartorioCasamento.Infra.Repositories
{
    public class PedidoCasamentoRepository : RepositoryBase<PedidoCasamento>, IPedidoCasamentoRepository
    {
        public PedidoCasamentoRepository(ContextBase contextBase) : base(contextBase) { }
    }
}
