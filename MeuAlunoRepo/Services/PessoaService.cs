using MeuAlunoDominio.Entities;
using MeuAlunoDominio.Interfaces.Repositories;
using MeuAlunoDominio.Interfaces.Services;
using MeuAlunoRepo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuAlunoRepo.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _repository;
        public PessoaService(IPessoaRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Pessoa>> BuscarPessoaPorEmpresaId(int empresaId)
        {
            return await _repository.BuscarPessoaPorEmpresaId(empresaId);
        }

    }
}
