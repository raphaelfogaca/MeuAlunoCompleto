using System;
using System.Collections.Generic;
using System.Text;

namespace MeuAlunoDominio
{
    public class MateriaAluno
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int MateriaId { get; set; }
        public Materia Materia { get; set; }

    }
}
