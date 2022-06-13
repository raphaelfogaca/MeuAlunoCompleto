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
              
    }
}


