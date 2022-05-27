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
            return await _context.Contratos.Where(x => x.EmpresaId == empresaId).FirstAsync();          
        }

        public async Task<Contrato> BuscarContratoModelo()
        {            
            return await _context.Contratos.Where(x => x.EmpresaId == 1).FirstAsync();  
           
        }

        public async Task<Contrato> BuscarPorId(int id)
        {
            return await _context.Contratos.Where(x => x.Id == id).FirstAsync();
        }
    }
}
