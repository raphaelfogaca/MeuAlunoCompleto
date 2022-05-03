using MeuAlunoDominio.Entities;
using MeuAlunoDominio.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuAlunoRepo.Repositories
{
    public class MateriaRepository : MeuAlunoBaseRepository<Materia>, IMateriaRepository
    {
        private readonly MeuAlunoContext _context;
        public MateriaRepository(MeuAlunoContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Materia>> BuscarMateriaPorEmpresa(int id)
        {
            var materias = await _context.Materias.Where(a => a.EmpresaId == id).ToListAsync();
            return materias;
        }        
        public async Task<Materia> BuscarMateriaPorId(int id)
        {
            return await _context.Materias.FirstAsync(s => s.Id == id);
        }

        public async Task<Materia> Cadastrar(Materia materia)
        {
            if(materia.Id > 0)
            {
                _context.Update(materia);
            }
            else
            {
                _context.Add(materia);
            }
            await _context.SaveChangesAsync();
            return materia;
        }
    }
}
