
using MeuAlunoDominio.Entities;
using MeuAlunoDominio.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MeuAlunoRepo.Repositories
{
    public class EnderecoRepository : MeuAlunoBaseRepository<Endereco>, IEnderecoRepository
    {
        MeuAlunoContext _context;
        public EnderecoRepository(MeuAlunoContext context) : base(context)
        {
            context = _context;
        }

        public async Task<Endereco> BuscarPorId(int enderecoId)
        {
            var endereco = await _context.Enderecos.Where(x => x.Id == enderecoId).FirstAsync();
            return endereco;
        }
    }
}
