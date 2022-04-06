﻿
using MeuAlunoDominio;
using MeuAlunoDominio.Contrato;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuAlunoRepo.Repositories
{
    public class ClausulaRepository : MeuAlunoBaseRepository<Clausula>
    {
        MeuAlunoContext _context;
        public ClausulaRepository(MeuAlunoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Clausula>> BuscarClausulasModelo(int contratoId)
        {
            var clausulas = await _context.Clausulas.Where(x => x.ContratoId == contratoId).ToListAsync();

            return clausulas;
        }
    }
}