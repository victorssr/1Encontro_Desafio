using CartorioCasamento.Domain.Interfaces.Repositories;
using CartorioCasamento.Domain.Interfaces.Services;
using CartorioCasamento.Domain.Models;
using System.Threading.Tasks;

namespace CartorioCasamento.Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
            : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> BuscaDesimpedimento(int id)
        {
            return await _usuarioRepository.BuscaDesimpedimento(id);
        }

        public async Task<Usuario> ObterPorCpf(string cpf)
        {
            return await _usuarioRepository.ObterPorCpf(cpf);
        }
    }
}
