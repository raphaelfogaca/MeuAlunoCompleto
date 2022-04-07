using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MeuAlunoDominio.Entities
{
    public class Financeiro
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataVencimento { get; set; }
        public decimal Valor { get; set; }
        public int AlunoId { get; set; }
        public string PessoaNome { get; set; }
        public string FormaPagamento { get; set; }
        public int Situacao { get; set; }
        public int EmpresaId { get; set; }
        public int Tipo { get; set; }
    }

}
