using System;
using System.Collections.Generic;
using System.Text;

namespace MeuAlunoDominio
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public List<MateriaAluno> MateriaAlunos { get; set; }

    }
}
