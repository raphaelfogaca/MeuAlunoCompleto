using MeuAlunoDominio.Entities;
using System.Threading.Tasks;

namespace MeuAlunoDominio.Interfaces.Services
{
    public interface IContratoAlunoService
    {
        public Task<Contrato> GerarContratoPDF(int empresaId, int alunoId);
    }
}
