using CartorioCasamento.Domain.Models;
using CartorioCasamento.Infra.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CartorioCasamento.Infra.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            // TABELA
            builder.SetEntityBaseConfiguration("USUARIO");
            builder.HasOne(p => p.Estado).WithMany(p => p.Usuarios).HasForeignKey(p => p.EstadoId);

            // CAMPOS
            builder.Property(p => p.Email)
                .HasColumnName("END_EMAIL")
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(p => p.Celular)
                .HasColumnName("NUM_CELULAR")
                .HasMaxLength(14)
                .IsRequired();

            builder.Property(p => p.Senha)
                .HasColumnName("DSC_SENHA")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(p => p.NomeCompleto)
                .HasColumnName("NOM_USUARIO")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(p => p.DataNascimento)
                .HasColumnName("DAT_NASCIMENTO")
                .IsRequired();

            builder.Property(p => p.Cpf)
                .HasColumnName("NUM_CPF")
                .HasMaxLength(14)
                .IsRequired();

            builder.Property(p => p.Rg)
                .HasColumnName("NUM_RG")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Desimpedido)
                .HasColumnName("IND_DESIMPEDIDO")
                .IsRequired();

            builder.Property(p => p.Logradouro)
                .HasColumnName("DSC_LOGRADOURO")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.Numero)
                .HasColumnName("NUM_ENDERECO")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(p => p.Complemento)
                .HasColumnName("DSC_COMPLEMENTO");

            builder.Property(p => p.Bairro)
                .HasColumnName("NOM_BAIRRO")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.Cidade)
                .HasColumnName("NOM_CIDADE")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.EstadoId)
                .HasColumnName("ID_ESTADO")
                .IsRequired();

            builder.Property(p => p.Cidade)
                .HasColumnName("COD_CEP")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(p => p.ArquivoFoto)
                .HasColumnName("NOM_ARQUIVO_FOTO")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.ArquivoCertidaoNascimento)
                .HasColumnName("NOM_ARQUIVO_CERTIDAO_NASCIMENTO")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.ArquivoRg)
                .HasColumnName("NOM_ARQUIVO_RG")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.ArquivoCpf)
                .HasColumnName("NOM_ARQUIVO_CPF")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.ArquivoCertidaoDivorcio)
                .HasColumnName("NOM_ARQUIVO_CERTIDAO_DIVORCIO")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.ArquivoSentencaDivorcio)
                .HasColumnName("NOM_ARQUIVO_SENTENCA_DIVORCIO")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
