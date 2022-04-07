using System;
using System.Collections.Generic;
using System.Text;

namespace MeuAlunoDominio.Entities
{
    public class Aula
    {
        public int Id { get; set; }
        public string Dia { get; set; }
        public int Vagas { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
    }
}
