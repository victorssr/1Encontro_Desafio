using CartorioCasamento.Domain.Interfaces.Repositories;
using CartorioCasamento.Domain.Interfaces.Services;
using CartorioCasamento.Domain.Models;

namespace CartorioCasamento.Domain.Services
{
    public class RegimeBensService : ServiceBase<RegimeBens>, IRegimeBensService
    {
        private readonly IRegimeBensRepository _regimeBensRepository;

        public RegimeBensService(IRegimeBensRepository regimeBensRepository)
            : base(regimeBensRepository)
        {
            _regimeBensRepository = regimeBensRepository;
        }
    }
}
