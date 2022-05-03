using MeuAlunoDominio.Entities;
using MeuAlunoDominio.Interfaces.Repositories;
using MeuAlunoDominio.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuAlunoRepo.Services
{
    public class AulaService : IAulaService
    {
        private readonly IAulaRepository _serviceRepository;
        public AulaService(IAulaRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public async Task<List<Aula>> BuscarAulaPorEmpresa(int id)
        {
            return await _serviceRepository.BuscarAulaPorEmpresa(id);
        }

        public async Task<Aula> BuscarAulaPorId(int id)
        {
            return await _serviceRepository.BuscarAulaPorId(id);
        }

        public async Task<Aula> Cadastrar(Aula aula)
        {
            try
            {
                if (aula.Id == 0)
                {
                    _serviceRepository.Add(aula);

                }
                else
                {
                    _serviceRepository.Update(aula);
                }
                await _serviceRepository.SaveChangesAsync();
                return aula;
            }
            catch (System.Exception)
            {
                return null;
            }
            
        }
    }
}
