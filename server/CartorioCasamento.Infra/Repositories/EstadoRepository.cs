using CartorioCasamento.Domain.Interfaces.Repositories;
using CartorioCasamento.Domain.Models;
using CartorioCasamento.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CartorioCasamento.Infra.Repositories
{
    public class EstadoRepository : RepositoryBase<Estado>, IEstadoRepository
    {
        public EstadoRepository(ContextBase contextBase) : base(contextBase) { }

        public async Task<Estado> BuscaEstadoPorSigla(string sigla)
        {
            return await _contextBase.Estado.AsNoTracking()
                            .FirstOrDefaultAsync(e => e.Sigla == sigla);
        }

        public async Task<decimal> BuscaValorCasamento(int id)
        {
            var estado = await _contextBase.Estado.AsNoTracking()
                            .FirstOrDefaultAsync(e => e.Id == id);

            return estado.ValorCasamento;
        }
    }
}
