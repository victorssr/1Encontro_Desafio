using CartorioCasamento.Domain.Models;
using System.Threading.Tasks;

namespace CartorioCasamento.Domain.Interfaces.Services
{
    public interface ICasamentoService : IServiceBase<Casamento>
    {
        public Task<Casamento> BuscarCasamentoUsuario(int idUsuario);
    }
}
