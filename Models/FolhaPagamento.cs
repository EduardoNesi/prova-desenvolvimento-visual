using System;
using System.ComponentModel.DataAnnotations;
using API_Folhas.Validations;

namespace API_Folhas.Models
{
    public class FolhaPagamento
    {

        public int FolhaPagamentoId { get; set; }

        public int Mes { get; set; }
        public int Ano { get; set; }
        public int ValordaHora { get; set; }
        public int QuantidadedeHoras { get; set; }
        public double ImpostodeRenda { get; set; }
        public double ImpostodoInss { get; set; }
        public double ImpostodoFgts { get; set; }
        public double SalarioLiquido { get; set; }
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}