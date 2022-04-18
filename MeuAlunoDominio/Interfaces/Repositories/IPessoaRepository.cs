
using MeuAlunoDominio.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuAlunoDominio.Interfaces.Repositories
{
    public interface IPessoaRepository : IMeuAlunoBaseRepository<Pessoa>
    {
        Task<List<Pessoa>> BuscarPessoaPorEmpresaId(int empresaId);                  
        
    }
}
