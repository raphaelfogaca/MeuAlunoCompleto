
using MeuAlunoDominio.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuAlunoDominio.Interfaces.Repositories
{
    public interface IServicoAulaRepository : IMeuAlunoBaseRepository<ServicoAula>
    {
        public Task<List<ServicoAula>> BuscarServicoAulaPorServicoId(int id);
        public Task<bool> RemoverServicoAula(int id);
    }
}
