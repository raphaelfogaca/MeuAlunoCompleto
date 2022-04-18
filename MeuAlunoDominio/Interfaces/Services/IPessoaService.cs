using MeuAlunoDominio.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuAlunoDominio.Interfaces.Services
{
    public interface IPessoaService
    {
        Task<List<Pessoa>> BuscarPessoaPorEmpresaId(int empresaId);
    }
}
