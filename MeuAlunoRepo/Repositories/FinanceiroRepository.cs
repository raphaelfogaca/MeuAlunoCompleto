
using MeuAlunoDominio;
using MeuAlunoDominio.Entities;
using MeuAlunoDominio.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuAlunoRepo.Repositories
{
    public class FinanceiroRepository : MeuAlunoBaseRepository<Financeiro>, IFinanceiroRepository
    {
        private readonly MeuAlunoContext _context;
        public FinanceiroRepository(MeuAlunoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<FinanceiroModelo>> BuscarFinanceiroPorEmpresaId(int empresaId)
        {
            var listaFinanceiro = await _context.Financeiros.Where(x => x.EmpresaId == empresaId)
                .Select(s => new FinanceiroModelo()
                {
                    Id = s.Id,
                    AlunoId = s.AlunoId,
                    DataVencimento = s.DataVencimento,
                    Situacao = s.Situacao,
                    EmpresaId = s.EmpresaId,
                    FormaPagamento = s.FormaPagamento,
                    Valor = s.Valor,
                    Tipo = s.Tipo,
                    PessoaNome = s.PessoaNome,
                    NomeAluno = _context.Alunos.Where(x => x.Id == s.AlunoId).Select(n => n.Nome).FirstOrDefault(),
                }).ToListAsync();
            return listaFinanceiro;
            
        }

        public async Task<List<FinanceiroModelo>> BuscarFinanceiroPorFiltro(FinanceiroFiltroModelo filtros)
        {
            var listaFinanceiro = await _context.Financeiros.Where(x => x.EmpresaId == filtros.EmpresaId)
                .Select(s => new FinanceiroModelo()
                {
                    Id = s.Id,
                    AlunoId = s.AlunoId,
                    DataVencimento = s.DataVencimento,
                    Situacao = s.Situacao,
                    EmpresaId = s.EmpresaId,
                    FormaPagamento = s.FormaPagamento,
                    Valor = s.Valor,
                    Tipo = s.Tipo,
                    PessoaNome = s.PessoaNome,
                    NomeAluno = _context.Alunos.Where(x => x.Id == s.AlunoId).Select(n => n.Nome).FirstOrDefault(),
                }).ToListAsync();

            if (filtros.VencimentoInicio != null)
            {
                listaFinanceiro = listaFinanceiro.Where(x => x.DataVencimento >= filtros.VencimentoInicio).ToList();
            }
            if (filtros.VencimentoFim != null)
            {
                listaFinanceiro = listaFinanceiro.Where(x => x.DataVencimento <= filtros.VencimentoFim).ToList();
            }
            if (filtros.Pessoa != "")
            {
                listaFinanceiro = listaFinanceiro.Where(x => x.PessoaNome.Contains(filtros.Pessoa)).ToList();
            }
            if (filtros.Tipo > 0)
            {
                listaFinanceiro = listaFinanceiro.Where(x => x.Tipo == filtros.Tipo).ToList();
            }
            if (filtros.Situacao > 0)
            {
                listaFinanceiro = listaFinanceiro.Where(x => x.Situacao == filtros.Situacao).ToList();
            }
            return listaFinanceiro;
        }

        public async Task<FinanceiroModelo> BuscarFinanceiroPorId(int documentoId)
        {
           var financeiro = await _context.Financeiros.Where(x => x.Id == documentoId)
              .Select(s => new FinanceiroModelo()
              {
                  Id = s.Id,
                  AlunoId = s.AlunoId,
                  DataVencimento = s.DataVencimento,
                  Situacao = s.Situacao,
                  EmpresaId = s.EmpresaId,
                  FormaPagamento = s.FormaPagamento,
                  Valor = s.Valor,
                  NomeAluno = _context.Alunos.Where(x => x.Id == s.AlunoId).Select(n => n.Nome).FirstOrDefault(),
                  Tipo = s.Tipo,
              }).FirstAsync();

            return financeiro;
        }
    
        public async Task<Financeiro> GetById(int documentoId)
        {
            return await _context.Financeiros.FirstAsync(x => x.Id == documentoId);
        }

    }
}
