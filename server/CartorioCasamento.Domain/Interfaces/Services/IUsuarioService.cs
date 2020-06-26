using CartorioCasamento.Domain.Models;
using System.Threading.Tasks;

namespace CartorioCasamento.Domain.Interfaces.Services
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        public Task<bool> BuscaDesimpedimento(int id);
        public Task<Usuario> ObterPorCpf(string cpf);
    }
}
