using CartorioCasamento.Domain.Interfaces.Repositories;
using CartorioCasamento.Domain.Interfaces.Services;
using CartorioCasamento.Domain.Models;

namespace CartorioCasamento.Domain.Services
{
    public class CasamentoService : ServiceBase<Casamento>, ICasamentoService
    {
        private readonly ICasamentoRepository _casamentoRepository;

        public CasamentoService(ICasamentoRepository casamentoRepository) : base(casamentoRepository)
        {
            _casamentoRepository = casamentoRepository;
        }
    }
}
