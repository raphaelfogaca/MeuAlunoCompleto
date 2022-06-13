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
    public class ServicoRepository : MeuAlunoBaseRepository<Servico>, IServicoRepository
    {
        private readonly MeuAlunoContext _context;

        public ServicoRepository(MeuAlunoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Servico>> BuscarServicoPorEmpresaId(int empresaId)
        {
           var servicos = await _context.Servicos.Where(x => x.EmpresaId == empresaId).ToListAsync();
           return servicos;
        }

        public async Task<Servico> BuscarServicoPorId(int servicoId)
        {
            var servico = await _context.Servicos.Where(x => x.Id == servicoId).FirstAsync();
            return servico;
        }

        public async Task<Servico> CadastrarServico(Servico servico)
        {
            _context.Servicos.Add(servico);
            await _context.SaveChangesAsync();
            return servico;
        }
    }
}
