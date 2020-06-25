using CartorioCasamento.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CartorioCasamento.Domain.Interfaces.Services
{
    public interface IPedidoCasamentoService : IServiceBase<PedidoCasamento>
    {
        public Task<List<PedidoCasamento>> BuscaPedidosPendentesUsuario(int idUsuario);
    }
}
