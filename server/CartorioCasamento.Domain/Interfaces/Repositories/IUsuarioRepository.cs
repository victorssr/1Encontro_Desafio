using CartorioCasamento.Domain.Models;
using System.Threading.Tasks;

namespace CartorioCasamento.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        public Task<bool> BuscaDesimpedimento(int id);
        public Task<Usuario> ObterPorCpf(string cpf);
    }
}
