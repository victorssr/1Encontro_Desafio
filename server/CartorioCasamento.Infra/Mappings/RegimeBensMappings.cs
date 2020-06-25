using CartorioCasamento.Domain.Models;
using CartorioCasamento.Infra.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CartorioCasamento.Infra.Mappings
{
    public class RegimeBensMappings : IEntityTypeConfiguration<RegimeBens>
    {
        public void Configure(EntityTypeBuilder<RegimeBens> builder)
        {
            // TABELA
            builder.SetEntityBaseConfiguration("REGIME_BENS");

            // CAMPOS
            builder.Property(p => p.Descricao)
                .HasColumnName("DSC_REGIME_BENS")
                .HasMaxLength(300)
                .IsRequired();
        }
    }
}
