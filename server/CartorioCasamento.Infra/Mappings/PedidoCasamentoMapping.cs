using CartorioCasamento.Domain.Models;
using CartorioCasamento.Infra.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CartorioCasamento.Infra.Mappings
{
    public class PedidoCasamentoMapping : IEntityTypeConfiguration<PedidoCasamento>
    {
        public void Configure(EntityTypeBuilder<PedidoCasamento> builder)
        {
            // TABELA
            builder.SetEntityBaseConfiguration("PEDIDO_CASAMENTO");
            builder.HasOne(p => p.UsuarioSolicitante).WithMany(p => p.PedidosCasamentos).HasForeignKey(p => p.UsuarioSolicitanteId);
            builder.HasOne(p => p.UsuarioSolicitado).WithMany(p => p.PedidosCasamentos).HasForeignKey(p => p.UsuarioSolicitadoId);
            builder.HasOne(p => p.RegimeBens).WithMany(p => p.PedidosCasamentos).HasForeignKey(p => p.RegimeBensId);

            // CAMPOS
            builder.Property(p => p.UsuarioSolicitanteId)
                    .HasColumnName("ID_USUARIO_SOLICITANTE")
                    .IsRequired();

            builder.Property(p => p.UsuarioSolicitadoId)
                    .HasColumnName("ID_USUARIO_SOLICITADO")
                    .IsRequired();

            builder.Property(p => p.RegimeBensId)
                    .HasColumnName("ID_REGIME_BENS")
                    .IsRequired();

            builder.Property(p => p.DataPedidoNegado)
                    .HasColumnName("DAT_PEDIDO_NEGADO");

            builder.Property(p => p.DataPedidoAceito)
                    .HasColumnName("DAT_PEDIDO_NEGADO");
        }
    }
}
