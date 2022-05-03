using MeuAlunoDominio;
using MeuAlunoDominio.Entities;
using MeuAlunoDominio.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuAlunoRepo
{
    public class MeuAlunoRepository : IMeuAlunoRepository
    {
        private readonly MeuAlunoContext _context;
        public MeuAlunoRepository(MeuAlunoContext context)
        {
            _context = context;
        }
        public void Add<T>(T Entity) where T : class
        {
            _context.Add(Entity);
        }
        public void Delete<T>(T Entity) where T : class
        {
            _context.Remove(Entity);
        }
        public void Update<T>(T Entity) where T : class
        {
            _context.Update(Entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
        public List<Servico> BuscarServicoPorEmpresaId(int id)
        {
            IQueryable<Servico> query = _context.Servicos.Where(s => s.EmpresaId == id);
            return query.ToList();
        }
        public Task<Servico[]> BuscarTodosServicos()
        {
            IQueryable<Servico> query = _context.Servicos;
            return query.ToArrayAsync();
        }
        public Servico BuscarServicoPorId(int id)
        {
            Servico query = _context.Servicos.FirstOrDefault(s => s.Id == id);
            if (query != null)
            {
                query.ServicosAulas = BuscarServicoAula(id);
            }

            return query;
        }
        public Servico BuscarServicoPorAluno(int id)
        {
            Servico query = _context.Servicos.FirstOrDefault(s => s.Id == id);
            return query;
        }
        public List<ServicoAula> BuscarServicoAula(int id)
        {
            IQueryable<ServicoAula> query = _context.ServicoAula.Where(s => s.ServicoId == id);
            return query.ToList();
        }
              
    }
}


