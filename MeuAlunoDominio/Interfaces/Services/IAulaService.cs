
using MeuAlunoDominio.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuAlunoDominio.Interfaces.Services
{
    public interface IAulaService
    {
        Task<List<Aula>> BuscarAulaPorEmpresa(int id);
        Task<Aula> BuscarAulaPorId(int id);
        Task<Aula> Cadastrar(Aula aula);
    }
}
