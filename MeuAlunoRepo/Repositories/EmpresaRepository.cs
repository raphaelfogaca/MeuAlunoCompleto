using MeuAlunoDominio.Entities;
using MeuAlunoDominio.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuAlunoRepo.Repositories
{
    public class EmpresaRepository : MeuAlunoBaseRepository<Empresa>, IEmpresaRepository
    {
        MeuAlunoContext _context;
        public EmpresaRepository(MeuAlunoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Empresa> Alterar(Empresa empresa)
        {
            _context.Update(empresa);
            await _context.SaveChangesAsync();
            return empresa;
        }

        public async Task<Empresa> BuscarEmpresaPorId(int empresaId)
        {
            var empresa = await _context.Empresas.Where(x => x.Id == empresaId).FirstAsync();
            return empresa;
        }

        public async Task<List<Empresa>> BuscarTodasEmpresas()
        {
            var empresas = await _context.Empresas.ToListAsync();
            return empresas;
        }

        public async Task<Empresa> Inserir(Empresa empresa)
        {
            _context.Add(empresa);
            await _context.SaveChangesAsync();
            return empresa;
        }
    }
}
