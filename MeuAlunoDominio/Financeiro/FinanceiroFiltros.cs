using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MeuAlunoDominio
{
    public class FinanceiroFiltros
    {
        [Column(TypeName = "date")]
        public DateTime? VencimentoInicio { get; set; }

        [Column(TypeName = "date")]
        public DateTime? VencimentoFim { get; set; }
        public string? Pessoa { get; set; }
        public int? Tipo { get; set; }
        public int? Situacao { get; set; }
        public int EmpresaId { get; set; }
    }
}
