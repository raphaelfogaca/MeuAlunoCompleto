using MeuAlunoDominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuAlunoDominio.Interfaces.Repositories
{
    public interface IMateriaAlunoRepository : IMeuAlunoBaseRepository<MateriaAluno>
    {
        Task<List<MateriaAluno>> BuscarPorAlunoId(int alunoId);
    }
}
