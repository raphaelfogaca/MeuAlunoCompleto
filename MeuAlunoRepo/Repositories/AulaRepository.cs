
using MeuAlunoDominio.Entities;
using MeuAlunoDominio.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuAlunoRepo.Repositories
{
    public class AulaRepository : MeuAlunoBaseRepository<Aula>, IAulaRepository
    {
        private readonly MeuAlunoContext _context;
        public AulaRepository(MeuAlunoContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Aula>> BuscarAulaPorEmpresa(int id)
        {
            var listaAula = await _context.Aulas.Where(a => a.EmpresaId == id).ToListAsync();
            return listaAula;
        }

        public async Task<Aula> BuscarAulaPorId(int id)
        {
            var aula = await _context.Aulas.FirstAsync(a => a.Id == id);
            return aula;
        }
    }
}
