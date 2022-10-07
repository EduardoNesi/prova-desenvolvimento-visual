using System;
using System.ComponentModel.DataAnnotations;
using API_Folhas.Validations;

namespace API_Folhas.Models
{
    public class Funcionario
    {
        public Funcionario() => CriadoEm = DateTime.Now;
        public int FuncionarioId { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório!")]
        [StringLength(
            11,
            MinimumLength = 11,
            ErrorMessage = "O cpf deve conter 11 caracteres!"
        )]
        [CpfEmUso]
        public string Cpf { get; set; }

        [EmailAddress(ErrorMessage = "e-mail inválido!")]
        public string Email { get; set; }

        [Range(
            0,
            1000,
            ErrorMessage = "O salário deve ser no máximo R$ 1.000,00"
        )]
        public int Salario { get; set; }
        public DateTime Nascimento { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}