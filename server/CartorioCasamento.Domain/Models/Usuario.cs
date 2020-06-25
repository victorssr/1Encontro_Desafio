using System;

namespace CartorioCasamento.Domain.Models
{
    public class Usuario : EntityBase
    {
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Senha { get; set; }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public bool Desimpedido { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public int EstadoId { get; set; }
        public string Cep { get; set; }

        public string ArquivoFoto { get; set; }
        public string ArquivoCertidaoNascimento { get; set; }
        public string ArquivoRg { get; set; }
        public string ArquivoCpf { get; set; }
        public string ArquivoCertidaoDivorcio { get; set; }
        public string ArquivoSentencaDivorcio { get; set; }

        // RELACIONAMENTOS
        public Estado Estado { get; set; }
    }
}
