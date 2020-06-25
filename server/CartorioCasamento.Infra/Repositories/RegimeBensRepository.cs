using CartorioCasamento.Domain.Interfaces.Repositories;
using CartorioCasamento.Domain.Models;
using CartorioCasamento.Infra.Context;

namespace CartorioCasamento.Infra.Repositories
{
    public class RegimeBensRepository : RepositoryBase<RegimeBens>, IRegimeBensRepository
    {
        public RegimeBensRepository(ContextBase contextBase) : base(contextBase) { }
    }
}
