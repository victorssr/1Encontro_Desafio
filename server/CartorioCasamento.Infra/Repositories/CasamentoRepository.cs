using CartorioCasamento.Domain.Interfaces.Repositories;
using CartorioCasamento.Domain.Models;
using CartorioCasamento.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CartorioCasamento.Infra.Repositories
{
    public class CasamentoRepository : RepositoryBase<Casamento>, ICasamentoRepository
    {
        public CasamentoRepository(ContextBase contextBase) : base(contextBase) { }

        public async Task<Casamento> BuscarCasamentoUsuario(int idUsuario)
        {
            return await _contextBase.Casamento.AsNoTracking()
                         .Include(c => c.PedidoCasamento)
                         .FirstOrDefaultAsync(c => c.DataDivorcio == null &&
                         (c.PedidoCasamento.UsuarioSolicitadoId == idUsuario || c.PedidoCasamento.UsuarioSolicitanteId == idUsuario));
        }
    }
}
