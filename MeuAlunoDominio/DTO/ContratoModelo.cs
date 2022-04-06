using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuAlunoDominio.Contrato
{
    public class ContratoModelo
    {
        public int EmpresaId { get; set; }
        public int ContratoId { get; set; }
        public IEnumerable<Clausula> Clausulas { get; set; }        

    }
}
