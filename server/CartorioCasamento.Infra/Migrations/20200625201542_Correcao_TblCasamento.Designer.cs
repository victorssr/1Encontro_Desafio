﻿// <auto-generated />
using System;
using CartorioCasamento.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CartorioCasamento.Infra.Migrations
{
    [DbContext(typeof(ContextBase))]
    [Migration("20200625201542_Correcao_TblCasamento")]
    partial class Correcao_TblCasamento
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CartorioCasamento.Domain.Models.Casamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_CASAMENTO")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArquivoFoto")
                        .HasColumnName("NOM_ARQUIVO_FOTO")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("DataAprovacaoDiarioOficial")
                        .HasColumnName("DAT_DIARIO_OFICIAL")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataAprovacaoEntrada")
                        .HasColumnName("DAT_APROVACAO_ENTRADA")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataCasamento")
                        .HasColumnName("DAT_CASAMENTO")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataDivorcio")
                        .HasColumnName("DAT_DIVORCIO")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataEntrada")
                        .HasColumnName("DAT_ENTRADA")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataRealizacaoCasamento")
                        .HasColumnName("DAT_REALIZACAO_CASAMENTO")
                        .HasColumnType("datetime2");

                    b.Property<string>("LinkCerimoniaGravada")
                        .HasColumnName("DSC_LINK_CERIMONIA")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("PedidoCasamentoId")
                        .HasColumnName("ID_PEDIDO_CASAMENTO")
                        .HasColumnType("int");

                    b.Property<Guid>("Referencia")
                        .HasColumnName("COD_REFERENCIA")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("UsuarioPrimeiraTestemunhaId")
                        .HasColumnName("ID_USUARIO_PRIMEIRA_TESTEMUNHA")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioSegundaTestemunhaId")
                        .HasColumnName("ID_USUARIO_SEGUNDA_TESTEMUNHA")
                        .HasColumnType("int");

                    b.Property<decimal?>("ValorCasamento")
                        .HasColumnName("VLR_CASAMENTO")
                        .HasColumnType("DECIMAL(9, 2)");

                    b.HasKey("Id");

                    b.HasIndex("PedidoCasamentoId")
                        .IsUnique();

                    b.HasIndex("UsuarioPrimeiraTestemunhaId");

                    b.HasIndex("UsuarioSegundaTestemunhaId");

                    b.ToTable("CASAMENTO");
                });

            modelBuilder.Entity("CartorioCasamento.Domain.Models.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_ESTADO")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("NOM_ESTADO")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnName("SGL_ESTADO")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<decimal>("ValorCasamento")
                        .HasColumnName("VLR_CASAMENTO")
                        .HasColumnType("DECIMAL(9, 2)");

                    b.HasKey("Id");

                    b.ToTable("ESTADO");
                });

            modelBuilder.Entity("CartorioCasamento.Domain.Models.PedidoCasamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_PEDIDO_CASAMENTO")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataPedidoAceito")
                        .HasColumnName("DAT_PEDIDO_ACEITO")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataPedidoNegado")
                        .HasColumnName("DAT_PEDIDO_NEGADO")
                        .HasColumnType("datetime2");

                    b.Property<int>("RegimeBensId")
                        .HasColumnName("ID_REGIME_BENS")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioSolicitadoId")
                        .HasColumnName("ID_USUARIO_SOLICITADO")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioSolicitanteId")
                        .HasColumnName("ID_USUARIO_SOLICITANTE")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegimeBensId");

                    b.HasIndex("UsuarioSolicitadoId");

                    b.HasIndex("UsuarioSolicitanteId");

                    b.ToTable("PEDIDO_CASAMENTO");
                });

            modelBuilder.Entity("CartorioCasamento.Domain.Models.RegimeBens", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_REGIME_BENS")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("DSC_REGIME_BENS")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.ToTable("REGIME_BENS");
                });

            modelBuilder.Entity("CartorioCasamento.Domain.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_USUARIO")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArquivoCertidaoDivorcio")
                        .IsRequired()
                        .HasColumnName("NOM_ARQUIVO_CERTIDAO_DIVORCIO")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("ArquivoCertidaoNascimento")
                        .IsRequired()
                        .HasColumnName("NOM_ARQUIVO_CERTIDAO_NASCIMENTO")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("ArquivoCpf")
                        .IsRequired()
                        .HasColumnName("NOM_ARQUIVO_CPF")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("ArquivoFoto")
                        .IsRequired()
                        .HasColumnName("NOM_ARQUIVO_FOTO")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("ArquivoRg")
                        .IsRequired()
                        .HasColumnName("NOM_ARQUIVO_RG")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("ArquivoSentencaDivorcio")
                        .IsRequired()
                        .HasColumnName("NOM_ARQUIVO_SENTENCA_DIVORCIO")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnName("NOM_BAIRRO")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnName("NUM_CELULAR")
                        .HasColumnType("nvarchar(14)")
                        .HasMaxLength(14);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnName("COD_CEP")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnName("NOM_CIDADE")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Complemento")
                        .HasColumnName("DSC_COMPLEMENTO")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnName("NUM_CPF")
                        .HasColumnType("nvarchar(14)")
                        .HasMaxLength(14);

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnName("DAT_NASCIMENTO")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Desimpedido")
                        .HasColumnName("IND_DESIMPEDIDO")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("END_EMAIL")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<int>("EstadoId")
                        .HasColumnName("ID_ESTADO")
                        .HasColumnType("int");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnName("DSC_LOGRADOURO")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasColumnName("NOM_USUARIO")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnName("NUM_ENDERECO")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasColumnName("NUM_RG")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnName("DSC_SENHA")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("USUARIO");
                });

            modelBuilder.Entity("CartorioCasamento.Domain.Models.Casamento", b =>
                {
                    b.HasOne("CartorioCasamento.Domain.Models.PedidoCasamento", "PedidoCasamento")
                        .WithOne("Casamento")
                        .HasForeignKey("CartorioCasamento.Domain.Models.Casamento", "PedidoCasamentoId")
                        .IsRequired();

                    b.HasOne("CartorioCasamento.Domain.Models.Usuario", "UsuarioPrimeiraTestemunha")
                        .WithMany("CasamentosPrimeirasTestemunhas")
                        .HasForeignKey("UsuarioPrimeiraTestemunhaId");

                    b.HasOne("CartorioCasamento.Domain.Models.Usuario", "UsuarioSegundaTestemunha")
                        .WithMany("CasamentosSegundasTestemunhas")
                        .HasForeignKey("UsuarioSegundaTestemunhaId");
                });

            modelBuilder.Entity("CartorioCasamento.Domain.Models.PedidoCasamento", b =>
                {
                    b.HasOne("CartorioCasamento.Domain.Models.RegimeBens", "RegimeBens")
                        .WithMany("PedidosCasamentos")
                        .HasForeignKey("RegimeBensId")
                        .IsRequired();

                    b.HasOne("CartorioCasamento.Domain.Models.Usuario", "UsuarioSolicitado")
                        .WithMany("PedidosCasamentosSolicitado")
                        .HasForeignKey("UsuarioSolicitadoId")
                        .IsRequired();

                    b.HasOne("CartorioCasamento.Domain.Models.Usuario", "UsuarioSolicitante")
                        .WithMany("PedidosCasamentosSolicitante")
                        .HasForeignKey("UsuarioSolicitanteId")
                        .IsRequired();
                });

            modelBuilder.Entity("CartorioCasamento.Domain.Models.Usuario", b =>
                {
                    b.HasOne("CartorioCasamento.Domain.Models.Estado", "Estado")
                        .WithMany("Usuarios")
                        .HasForeignKey("EstadoId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}