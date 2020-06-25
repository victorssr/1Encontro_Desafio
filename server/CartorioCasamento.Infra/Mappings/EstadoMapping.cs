using CartorioCasamento.Domain.Models;
using CartorioCasamento.Infra.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CartorioCasamento.Infra.Mappings
{
    public class EstadoMapping : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            // TABELA
            builder.SetEntityBaseConfiguration("ESTADO");

            // CAMPOS
            builder.Property(p => p.Nome)
                .HasColumnName("NOM_ESTADO")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Sigla)
                .HasColumnName("SGL_ESTADO")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.ValorCasamento)
                .HasColumnName("VLR_CASAMENTO")
                .HasColumnType("DECIMAL(9, 2)")
                .IsRequired();
        }
    }
}
