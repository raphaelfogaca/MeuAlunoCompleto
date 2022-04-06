using MeuAlunoDominio;
using MeuAlunoDominio.Interfaces;
using MeuAlunoRepo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuAlunoRepo.Services
{
    public class ClausulaService : IClausulaService
    {
        private readonly ClausulaRepository _repo;

        public ClausulaService(ClausulaRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<Clausula>> BuscarClausulasModelo(int contratoId)
        {
            return await _repo.BuscarClausulasModelo(contratoId);
        }
    }
}
