using MeuAlunoDominio.Entities;
using MeuAlunoDominio.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuAlunoRepo.Services
{
    public class AulaService : IAulaService
    {
        private readonly IAulaService _service;
        public AulaService(IAulaService service)
        {
            _service = service;
        }
        public async Task<List<Aula>> BuscarAulaPorEmpresa(int id)
        {
            return await _service.BuscarAulaPorEmpresa(id);
        }

        public async Task<Aula> BuscarAulaPorId(int id)
        {
            return await _service.BuscarAulaPorId(id);
        }

        public Task<Aula> Cadastrar(Aula aula)
        {
            throw new System.NotImplementedException();
        }
    }
}
