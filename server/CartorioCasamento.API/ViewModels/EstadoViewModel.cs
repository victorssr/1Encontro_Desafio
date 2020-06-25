using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CartorioCasamento.API.ViewModels
{
    public class EstadoViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(2, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
        public string Sigla { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(100, ErrorMessage = "O campo {0} precisa ter até {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal ValorCasamento { get; set; }

        // RELACIONAMENTO
        //public List<UsuarioViewModel> Usuarios { get; set; }
    }
}
