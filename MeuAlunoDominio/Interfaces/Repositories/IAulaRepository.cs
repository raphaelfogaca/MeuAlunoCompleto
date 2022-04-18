
using MeuAlunoDominio.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuAlunoDominio.Interfaces.Repositories
{
    public interface IAulaRepository : IMeuAlunoBaseRepository<Aula>
    {
        Task<List<Aula>> BuscarAulaPorEmpresa(int id);
        Task<Aula> BuscarAulaPorId(int id);
    }
}
