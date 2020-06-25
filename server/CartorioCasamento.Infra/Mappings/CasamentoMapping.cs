using CartorioCasamento.Domain.Models;
using CartorioCasamento.Infra.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CartorioCasamento.Infra.Mappings
{
    public class CasamentoMapping : IEntityTypeConfiguration<Casamento>
    {
        public void Configure(EntityTypeBuilder<Casamento> builder)
        {
            // TABELA
            builder.SetEntityBaseConfiguration("CASAMENTO");
            builder.HasOne(p => p.PedidoCasamento).WithOne(p => p.Casamento);
            builder.HasOne(p => p.UsuarioPrimeiraTestemunha).WithMany(p => p.CasamentosPrimeirasTestemunhas).HasForeignKey(p => p.UsuarioPrimeiraTestemunhaId);
            builder.HasOne(p => p.UsuarioSegundaTestemunha).WithMany(p => p.CasamentosSegundasTestemunhas).HasForeignKey(p => p.UsuarioSegundaTestemunhaId);

            // CAMPOS
            builder.Property(p => p.Referencia)
                .HasColumnName("COD_REFERENCIA")
                .IsRequired();

            builder.Property(p => p.PedidoCasamentoId)
                .HasColumnName("ID_PEDIDO_CASAMENTO")
                .IsRequired();

            builder.Property(p => p.UsuarioPrimeiraTestemunhaId)
                .HasColumnName("ID_USUARIO_PRIMEIRA_TESTEMUNHA")
                .IsRequired();

            builder.Property(p => p.UsuarioSegundaTestemunhaId)
                .HasColumnName("ID_USUARIO_SEGUNDA_TESTEMUNHA")
                .IsRequired();

            builder.Property(p => p.DataEntrada)
                .HasColumnName("DAT_ENTRADA")
                .IsRequired();

            builder.Property(p => p.ValorCasamento)
                .HasColumnName("VLR_CASAMENTO")
                .HasColumnType("DECIMAL(9, 2)")
                .IsRequired();

            builder.Property(p => p.DataAprovacaoEntrada)
                .HasColumnName("DAT_APROVACAO_ENTRADA");

            builder.Property(p => p.DataCasamento)
                .HasColumnName("DAT_CASAMENTO");

            builder.Property(p => p.DataRealizacaoCasamento)
                .HasColumnName("DAT_REALIZACAO_CASAMENTO");

            builder.Property(p => p.LinkCerimoniaGravada)
                .HasColumnName("DSC_LINK_CERIMONIA")
                .HasMaxLength(100);

            builder.Property(p => p.DataAprovacaoDiarioOficial)
                .HasColumnName("DAT_DIARIO_OFICIAL");

            builder.Property(p => p.ArquivoFoto)
                .HasColumnName("NOM_ARQUIVO_FOTO")
                .HasMaxLength(100);

            builder.Property(p => p.DataDivorcio)
                .HasColumnName("DAT_DIVORCIO");
        }
    }
}
