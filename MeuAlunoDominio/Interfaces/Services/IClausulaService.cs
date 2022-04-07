using MeuAlunoDominio.Entities;
using MeuAlunoDominio.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuAlunoDominio.Interfaces.Services
{
    public interface IClausulaService
    {
        Task<List<Clausula>> BuscarClausulasModelo(int contratoId);

        Task<List<Clausula>> CadastrarClausulas(List<Clausula> clausulaList);
    }
}
