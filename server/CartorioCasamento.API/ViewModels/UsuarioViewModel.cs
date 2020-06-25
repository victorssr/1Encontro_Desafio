using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CartorioCasamento.API.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(300, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter {1} caracteres")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(500, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
        public string Senha { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(500, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "O campo {0} precisa ter de {1} até {2} caracteres")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(50, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Desimpedido { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(200, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(10, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
        public string Numero { get; set; }

        [MaxLength(10, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(200, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(200, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int EstadoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(100, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
        public string ArquivoFoto { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(100, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
        public string ArquivoCertidaoNascimento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(100, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
        public string ArquivoRg { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(100, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
        public string ArquivoCpf { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(100, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
        public string ArquivoCertidaoDivorcio { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(100, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
        public string ArquivoSentencaDivorcio { get; set; }
    }
}
