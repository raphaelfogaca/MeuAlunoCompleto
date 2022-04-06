using MeuAlunoDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MeuAlunoDominio.Interfaces;

namespace MeuAlunoRepo.Services
{
    public class EmpresaService : IEmpresaService
    {
        MeuAlunoContext _context;
        IMeuAlunoRepository _repository;

        public EmpresaService(MeuAlunoContext context, IMeuAlunoRepository repository)
        {
            _context = context;
            _repository = repository;
        }
        public Empresa BuscarEmpresaPorId(int id)
        {
            Empresa query = _context.Empresas.FirstOrDefault(e => e.Id == id);
            query.Endereco = _context.Enderecos.FirstOrDefault(e => e.Id == query.EnderecoId);
            //query.Pessoas = BuscarPessoasPorEmpresaId(id);
            return query;
        }
        public Task<Empresa[]> BuscarTodasEmpresas()
        {
            IQueryable<Empresa> query = _context.Empresas;
            return query.ToArrayAsync();            
        }
    }
}
