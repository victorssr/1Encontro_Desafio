using CartorioCasamento.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CartorioCasamento.Infra.Configurations
{
    public static class EntityBaseConfiguration
    {
        public static void SetEntityBaseConfiguration<TEntity>(this EntityTypeBuilder<TEntity> builder, string tableName)
            where TEntity : EntityBase
        {
            // DEFINIÇÕES DA TABLE
            builder.ToTable(tableName);
            builder.HasKey(b => b.Id);

            // CAMPOS PADRÕES
            builder.Property(b => b.Id)
                .HasColumnName("ID_" + tableName)
                .IsRequired();
        }
    }
}
