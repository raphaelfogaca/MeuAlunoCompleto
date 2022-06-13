
using MeuAlunoDominio.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuAlunoDominio.Interfaces.Services
{
    public interface IServicoAulaService
    {
        Task<List<ServicoAula>> BuscarServicoAulaPorServicoId(int servicoId);
        Task<bool> RemoverServicoAula(int servicoId);
    }
}
