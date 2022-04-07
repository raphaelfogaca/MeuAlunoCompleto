using MeuAlunoDominio.DTO;
using MeuAlunoDominio.Entities;
using MeuAlunoDominio.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MeuAlunoRepo.Repositories
{
    public class ContratoRepository : MeuAlunoBaseRepository<Contrato>, IContratoRepository
    {
        private readonly MeuAlunoContext _context;
        public ContratoRepository(MeuAlunoContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Contrato> CadastrarContratoModelo(Contrato contrato)
        {
            _context.Add(contrato);
            await _context.SaveChangesAsync();           
            return contrato;
        }

        public async Task<Contrato> BuscarContratoPorEmpresaId(int empresaId)
        {
            var contrato = await _context.Contratos.Where(x => x.EmpresaId == empresaId).ToListAsync();

            return contrato.FirstOrDefault();
        }

        public async Task<Contrato> BuscarContratoModelo()
        {            
            var contrato = await _context.Contratos.Where(x => x.EmpresaId == 1).ToListAsync();           
            
            return contrato.FirstOrDefault();
        }
    }
}
