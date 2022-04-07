
using MeuAlunoDominio.DTO;
using MeuAlunoDominio.Entities;
using System.Threading.Tasks;

namespace MeuAlunoDominio.Interfaces.Repositories
{
    public interface IContratoRepository : IMeuAlunoBaseRepository<Contrato>
    {
        Task<Contrato> BuscarContratoPorEmpresaId(int empresaId);
        Task<Contrato> BuscarContratoModelo();
        Task<Contrato> CadastrarContratoModelo(Contrato contrato);
    }
}
