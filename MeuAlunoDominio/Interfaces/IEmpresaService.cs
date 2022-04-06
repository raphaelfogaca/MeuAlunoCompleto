using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuAlunoDominio.Interfaces
{
    public interface IEmpresaService
    {
        Empresa BuscarEmpresaPorId(int id);
        Task<Empresa[]> BuscarTodasEmpresas();
    }
}
