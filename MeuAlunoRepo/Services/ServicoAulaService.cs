
using MeuAlunoDominio.Entities;
using MeuAlunoDominio.Interfaces.Repositories;
using MeuAlunoDominio.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuAlunoRepo.Services
{
    public class ServicoAulaService : IServicoAulaService
    {
        private readonly IServicoAulaRepository _repo;

        public ServicoAulaService(IServicoAulaRepository servicoAulaRepository)
        {
            _repo = servicoAulaRepository;
        }
        public async Task<List<ServicoAula>> BuscarServicoAulaPorServicoId(int servicoId)
        {
            var servicoAulas = await _repo.BuscarServicoAulaPorServicoId(servicoId);
            return servicoAulas;
        }
    }
}
