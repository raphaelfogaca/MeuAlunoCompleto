
using MeuAlunoDominio.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuAlunoDominio.Interfaces.Repositories
{
    public interface IFinanceiroRepository : IMeuAlunoBaseRepository<Financeiro>
    {
        Task<List<FinanceiroModelo>> BuscarFinanceiroPorEmpresaId(int empresaId);
        Task<List<FinanceiroModelo>> BuscarFinanceiroPorFiltro(FinanceiroFiltroModelo filtros);
        Task<FinanceiroModelo> BuscarFinanceiroPorId(int documentoId);
        Task<Financeiro> GetById(int documentoId);
    }
}
