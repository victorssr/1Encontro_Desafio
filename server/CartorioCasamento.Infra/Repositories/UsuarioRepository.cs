using CartorioCasamento.Domain.Interfaces.Repositories;
using CartorioCasamento.Domain.Models;
using CartorioCasamento.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CartorioCasamento.Infra.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ContextBase contextBase) : base(contextBase) { }

        public async Task<bool> BuscaDesimpedimento(int id)
        {
            var usuario = await _contextBase.Usuario.AsNoTracking()
                            .FirstOrDefaultAsync(u => u.Id == id);

            return usuario.Desimpedido;
        }

        public async Task<Usuario> ObterPorCpf(string cpf)
        {
            return await _contextBase.Usuario.AsNoTracking()
                        .FirstOrDefaultAsync(u => u.Cpf == cpf.Replace(".", "").Replace("-", ""));
        }
    }
}
