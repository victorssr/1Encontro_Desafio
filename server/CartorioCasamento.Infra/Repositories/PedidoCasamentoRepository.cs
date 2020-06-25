using CartorioCasamento.Domain.Interfaces.Repositories;
using CartorioCasamento.Domain.Models;
using CartorioCasamento.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartorioCasamento.Infra.Repositories
{
    public class PedidoCasamentoRepository : RepositoryBase<PedidoCasamento>, IPedidoCasamentoRepository
    {
        public PedidoCasamentoRepository(ContextBase contextBase) : base(contextBase) { }

        public async Task<List<PedidoCasamento>> BuscaPedidosPendentesUsuario(int idUsuario)
        {
            return await _contextBase.PedidoCasamento.AsNoTracking()
                            .Where(p => p.UsuarioSolicitadoId == idUsuario && p.DataPedidoAceito == null && p.DataPedidoNegado == null)
                            .ToListAsync();
        }
    }
}
