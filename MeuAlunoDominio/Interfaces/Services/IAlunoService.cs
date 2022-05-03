using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuAlunoDominio.Interfaces.Services
{
    public interface IAlunoService
    {
        Task<List<Aluno>> BuscarAlunoPorNome(string nome);
        Task<Aluno> BuscarAlunoPorId(int id);
        Task<List<Aluno>> BuscarTodosAlunos();
        Task<List<Aluno>> BuscarAlunosPorEmpresaid(int empresaId);
        Task<bool> Alterar(Aluno aluno);
        Task<Aluno> Cadastrar(Aluno aluno);
    }
}
