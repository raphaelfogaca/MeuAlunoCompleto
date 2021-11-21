using System;
using System.Collections.Generic;
using System.Text;

namespace MeuAlunoDominio
{
    public class Servico
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int QtdAulas { get; set; }       
        public bool Fidelidade  { get; set; }
        public int TipoMulta { get; set; }
        public double ValorMulta { get; set; }
        public List<ServicoAula> ServicosAulas { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }

    }
}
