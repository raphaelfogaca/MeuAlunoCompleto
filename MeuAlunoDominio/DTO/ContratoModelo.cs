using MeuAlunoDominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuAlunoDominio.DTO
{
    public class ContratoModelo
    {
        public int EmpresaId { get; set; }
        public int ContratoId { get; set; }
        public List<Clausula> Clausulas { get; set; }        

    }
}
