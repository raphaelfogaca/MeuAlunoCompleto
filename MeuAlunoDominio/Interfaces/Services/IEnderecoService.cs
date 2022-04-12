
using MeuAlunoDominio.Entities;
using System.Threading.Tasks;

namespace MeuAlunoDominio.Interfaces.Services
{
    public interface IEnderecoService 
    {
        Task<Endereco> BuscarPorId(int enderecoId);
    }
}
