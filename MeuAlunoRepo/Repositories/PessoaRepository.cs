
using MeuAlunoDominio.Entities;
using MeuAlunoDominio.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuAlunoRepo.Repositories
{
    public class PessoaRepository : MeuAlunoBaseRepository<Pessoa> , IPessoaRepository
    {
        private readonly MeuAlunoContext _context;
        public PessoaRepository(MeuAlunoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Pessoa>> BuscarPessoaPorEmpresaId(int empresaId)
        {
            var pessoa = await _context.Pessoas.Where(x => x.EmpresaId == empresaId).ToListAsync();
            return pessoa;
        }      
    }
}
