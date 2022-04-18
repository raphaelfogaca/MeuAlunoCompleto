using MeuAlunoDominio.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuAlunoDominio.Interfaces.Repositories
{
    public interface IMateriaRepository : IMeuAlunoBaseRepository<Materia>
    {
        Task<List<Materia>>BuscarMateriaPorEmpresa(int id);
        Task<Materia> BuscarMateriaPorId(int id);
        Task<List<MateriaAluno>> BuscarMateriaPorAluno(int id);
        Task<Materia> Cadastrar(Materia materia);
    }
}
