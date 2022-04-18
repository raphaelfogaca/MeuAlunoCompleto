using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuAlunoDominio.Interfaces.Services
{
    public interface IFinanceiroService 
    {
        Task<List<FinanceiroModelo>> BuscarFinanceiroPorEmpresaId(int empresaId);
        Task<List<FinanceiroModelo>> BuscarFinanceiroPorFiltro(FinanceiroFiltroModelo filtros);
        Task<FinanceiroModelo> BuscarFinanceiroPorId(int documentoId);
        Task<bool> LiquidarDocumento(int documentoId);
        Task<FinanceiroModelo> Cadastrar(FinanceiroModelo financeiroModelo);
    }
}
