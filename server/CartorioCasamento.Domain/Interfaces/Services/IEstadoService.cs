using CartorioCasamento.Domain.Models;
using System.Threading.Tasks;

namespace CartorioCasamento.Domain.Interfaces.Services
{
    public interface IEstadoService : IServiceBase<Estado>
    {
        public Task<decimal> BuscaValorCasamento(int id);
        public Task<Estado> BuscaEstadoPorSigla(string sigla);
    }
}
