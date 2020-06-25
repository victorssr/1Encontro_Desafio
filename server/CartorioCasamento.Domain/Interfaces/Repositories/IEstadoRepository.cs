using CartorioCasamento.Domain.Models;
using System.Threading.Tasks;

namespace CartorioCasamento.Domain.Interfaces.Repositories
{
    public interface IEstadoRepository : IRepositoryBase<Estado>
    {
        public Task<decimal> BuscaValorCasamento(int id);
        public Task<Estado> BuscaEstadoPorSigla(string sigla);
    }
}
