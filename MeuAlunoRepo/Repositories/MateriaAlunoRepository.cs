using MeuAlunoDominio.Entities;
using MeuAlunoDominio.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuAlunoRepo.Repositories
{
    public class MateriaAlunoRepository : MeuAlunoBaseRepository<MateriaAluno>, IMateriaAlunoRepository
    {
        private readonly MeuAlunoContext _context;
        public MateriaAlunoRepository(MeuAlunoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<MateriaAluno>> BuscarPorAlunoId(int alunoId)
        {
            return await _context.MateriaAluno.Where(x => x.AlunoId == alunoId).ToListAsync();
        }
    }
}
