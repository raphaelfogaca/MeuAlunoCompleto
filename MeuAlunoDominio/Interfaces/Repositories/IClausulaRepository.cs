using MeuAlunoDominio.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuAlunoDominio.Interfaces.Repositories
{
    public interface IClausulaRepository : IMeuAlunoBaseRepository<Clausula>
    {
        Task<List<Clausula>> BuscarClausulasModelo(int contratoId);
    }
}
