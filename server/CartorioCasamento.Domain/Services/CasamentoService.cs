using CartorioCasamento.Domain.Interfaces.Repositories;
using CartorioCasamento.Domain.Interfaces.Services;
using CartorioCasamento.Domain.Models;
using System.Threading.Tasks;

namespace CartorioCasamento.Domain.Services
{
    public class CasamentoService : ServiceBase<Casamento>, ICasamentoService
    {
        private readonly ICasamentoRepository _casamentoRepository;

        public CasamentoService(ICasamentoRepository casamentoRepository) : base(casamentoRepository)
        {
            _casamentoRepository = casamentoRepository;
        }

        public async Task<Casamento> BuscarCasamentoUsuario(int idUsuario)
        {
            return await _casamentoRepository.BuscarCasamentoUsuario(idUsuario);
        }
    }
}
