using CartorioCasamento.Domain.Interfaces.Repositories;
using CartorioCasamento.Domain.Models;
using CartorioCasamento.Infra.Context;

namespace CartorioCasamento.Infra.Repositories
{
    public class EstadoRepository : RepositoryBase<Estado>, IEstadoRepository
    {
        public EstadoRepository(ContextBase contextBase) : base(contextBase) { }
    }
}
