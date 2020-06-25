using CartorioCasamento.Domain.Interfaces.Repositories;
using CartorioCasamento.Domain.Models;
using CartorioCasamento.Infra.Context;

namespace CartorioCasamento.Infra.Repositories
{
    public class CasamentoRepository : RepositoryBase<Casamento>, ICasamentoRepository
    {
        public CasamentoRepository(ContextBase contextBase) : base(contextBase) { }
    }
}
