
using MeuAlunoDominio.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuAlunoDominio.Interfaces.Repositories
{
    public interface IEmpresaRepository : IMeuAlunoBaseRepository<Empresa>
    {
        Task<Empresa> BuscarEmpresaPorId(int empresaId);
        Task<List<Empresa>> BuscarTodasEmpresas();
        Task<Empresa> Alterar(Empresa empresa);
        Task<Empresa> Inserir(Empresa empresa);

    }
}
