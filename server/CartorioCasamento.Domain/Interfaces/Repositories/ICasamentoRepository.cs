using CartorioCasamento.Domain.Models;
using System.Threading.Tasks;

namespace CartorioCasamento.Domain.Interfaces.Repositories
{
    public interface ICasamentoRepository : IRepositoryBase<Casamento>
    {
        public Task<Casamento> BuscarCasamentoUsuario(int idUsuario);
    }
}
