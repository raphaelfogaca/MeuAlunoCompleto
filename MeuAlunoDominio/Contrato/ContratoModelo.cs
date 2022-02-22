using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuAlunoDominio.Contrato
{
    public class ContratoModelo
    {
        public IEnumerable<Clausula> Clausulas { get; set; }
        public Contrato Contrato { get; set; }

    }
}
