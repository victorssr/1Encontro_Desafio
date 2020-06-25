using CartorioCasamento.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CartorioCasamento.Domain.Interfaces.Repositories
{
    public interface IPedidoCasamentoRepository : IRepositoryBase<PedidoCasamento>
    {
        public Task<List<PedidoCasamento>> BuscaPedidosPendentesUsuario(int idUsuario);
    }
}
