
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuAlunoDominio.Interfaces.Repositories
{
    public interface IAlunoRepository : IMeuAlunoBaseRepository<Aluno>
    {
        Task<List<Aluno>> BuscarAlunoPorNome(string nome);
        Task<Aluno> BuscarAlunoPorId(int id);
        Task<List<Aluno>> BuscarTodosAlunos();
        Task<List<Aluno>> BuscarAlunosPorEmpresaid(int empresaId);

    }
}
