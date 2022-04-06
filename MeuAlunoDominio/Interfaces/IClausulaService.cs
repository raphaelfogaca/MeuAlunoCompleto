using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuAlunoDominio.Interfaces
{
    public interface IClausulaService
    {
        Task<List<Clausula>> BuscarClausulasModelo(int contratoId);
    }
}
