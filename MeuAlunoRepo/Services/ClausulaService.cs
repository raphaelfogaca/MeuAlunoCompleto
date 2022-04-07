using MeuAlunoDominio;
using MeuAlunoDominio.Entities;
using MeuAlunoDominio.Interfaces.Repositories;
using MeuAlunoDominio.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuAlunoRepo.Services
{
    public class ClausulaService : IClausulaService
    {
        private readonly IClausulaRepository _repo;

        public ClausulaService(IClausulaRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<Clausula>> BuscarClausulasModelo(int contratoId)
        {
            return await _repo.BuscarClausulasModelo(contratoId);
        }

        public async Task<List<Clausula>> CadastrarClausulas(List<Clausula> clausulaList)
        {
            List<Clausula> newClausulas = new List<Clausula>();
            foreach(var clausula in clausulaList)
            {
                _repo.Add(clausula);
                newClausulas.Add(clausula);
            }
            await _repo.SaveChangesAsync();
            return newClausulas;
        }
    }
}
