using CartorioCasamento.Domain.Interfaces.Repositories;
using CartorioCasamento.Domain.Interfaces.Services;
using CartorioCasamento.Domain.Models;
using System.Threading.Tasks;

namespace CartorioCasamento.Domain.Services
{
    public class EstadoService : ServiceBase<Estado>, IEstadoService
    {
        private readonly IEstadoRepository _estadoRepository;

        public EstadoService(IEstadoRepository estadoRepository) : base(estadoRepository)
        {
            _estadoRepository = estadoRepository;
        }

        public async Task<Estado> BuscaEstadoPorSigla(string sigla)
        {
            return await _estadoRepository.BuscaEstadoPorSigla(sigla);
        }

        public async Task<decimal> BuscaValorCasamento(int id)
        {
            return await _estadoRepository.BuscaValorCasamento(id);
        }
    }
}
