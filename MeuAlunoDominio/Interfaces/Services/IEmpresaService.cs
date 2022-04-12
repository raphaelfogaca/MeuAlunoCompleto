using MeuAlunoDominio.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuAlunoDominio.Interfaces.Services
{
    public interface IEmpresaService
    {
        Task<Empresa> BuscarEmpresaPorId(int id);
        Task<List<Empresa>> BuscarTodasEmpresas();
        Task<Empresa> Inserir(EmpresaModelo model);
        
    }
}
