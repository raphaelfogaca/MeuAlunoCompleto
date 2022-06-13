
using MeuAlunoDominio.Entities;
using MeuAlunoDominio.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuAlunoRepo.Repositories
{
    public class ServicoAulaRepository : MeuAlunoBaseRepository<ServicoAula>, IServicoAulaRepository
    {
        private MeuAlunoContext _context;

        public ServicoAulaRepository(MeuAlunoContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<ServicoAula>> BuscarServicoAulaPorServicoId(int id)
        {
            var servicoAula = await _context.ServicoAula.Where(x => x.ServicoId == id).ToListAsync();
            return servicoAula;
        }

        public async Task<bool> RemoverServicoAula(int id)
        {
            try
            {
                var servicoAula = await _context.ServicoAula.FirstOrDefaultAsync(x => x.Id == id);
                _context.ServicoAula.Remove(servicoAula);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
            
        }
    }
}
