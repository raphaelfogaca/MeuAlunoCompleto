
using MeuAlunoDominio;
using MeuAlunoDominio.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuAlunoRepo.Repositories
{
    public class AlunoRepository : MeuAlunoBaseRepository<Aluno>, IAlunoRepository
    {
        private readonly MeuAlunoContext _context;
        public AlunoRepository(MeuAlunoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Aluno> BuscarAlunoPorId(int id)
        {
            var aluno = await _context.Alunos.Where(a => a.Id == id).FirstAsync();
            return aluno;
        }

        public async Task<List<Aluno>> BuscarAlunoPorNome(string nome)
        {
            var alunos = await _context.Alunos.Where(a => a.Nome.Contains(nome)).ToListAsync();
            return alunos;
        }

        public async Task<List<Aluno>> BuscarAlunosPorEmpresaid(int empresaId)
        {
            var aluno = await _context.Alunos.Where(a => a.EmpresaId == empresaId).ToListAsync();
            return aluno;
        }

        public async Task<List<Aluno>> BuscarTodosAlunos()
        {
            var alunos = await _context.Alunos.ToListAsync();
            return alunos;
        }
    }
}
