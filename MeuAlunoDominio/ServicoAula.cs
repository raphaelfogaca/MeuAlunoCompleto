using System;
using System.Collections.Generic;
using System.Text;

namespace MeuAlunoDominio
{
    public class ServicoAula
    {
        public int Id { get; set; }
        public int AulaId { get; set; }
        public Aula Aula { get; set; }
        public int ServicoId { get; set; }
        public Servico Servico { get; set; }
    }
}
