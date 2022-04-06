using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuAlunoDominio
{
    public class Clausula
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int? ContratoId { get; set; }
        public bool? Ativa { get; set; }

    }
}
