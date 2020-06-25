using CartorioCasamento.Domain.Interfaces.Repositories;
using CartorioCasamento.Domain.Interfaces.Services;
using CartorioCasamento.Domain.Models;

namespace CartorioCasamento.Domain.Services
{
    public class EstadoService : ServiceBase<Estado>, IEstadoService
    {
        private readonly IEstadoRepository _estadoRepository;

        public EstadoService(IEstadoRepository estadoRepository) : base(estadoRepository)
        {
            _estadoRepository = estadoRepository;
        }
    }
}
