
using MeuAlunoDominio.Entities;
using MeuAlunoDominio.Interfaces.Repositories;
using MeuAlunoDominio.Interfaces.Services;
using System.Threading.Tasks;

namespace MeuAlunoRepo.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public async Task<Endereco> BuscarPorId(int enderecoId)
        {
            return await _enderecoRepository.BuscarPorId(enderecoId);
        }
               
    }
}
