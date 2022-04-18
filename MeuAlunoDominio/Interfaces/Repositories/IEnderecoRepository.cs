
using MeuAlunoDominio.Entities;
using System.Threading.Tasks;

namespace MeuAlunoDominio.Interfaces.Repositories
{
    public interface IEnderecoRepository : IMeuAlunoBaseRepository<Endereco>
    {
        Task<Endereco> BuscarPorId(int enderecoId);
    }
}
