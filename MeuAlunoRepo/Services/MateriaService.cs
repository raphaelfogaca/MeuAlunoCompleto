
using MeuAlunoDominio.Entities;
using MeuAlunoDominio.Interfaces.Repositories;
using MeuAlunoDominio.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuAlunoRepo.Services
{
    public class MateriaService : IMateriaService
    {
        private readonly IMateriaRepository _materiaRepository;
        public MateriaService(IMateriaRepository materiaRepository)
        {
            _materiaRepository = materiaRepository;
        }
        public async Task<List<Materia>> BuscarMateriaPorEmpresa(int id)
        {
            return await _materiaRepository.BuscarMateriaPorEmpresa(id);
        }

        public async Task<Materia> BuscarMateriaPorId(int id)
        {
            return await _materiaRepository.BuscarMateriaPorId(id);
        }

        public async Task<Materia> Cadastrar(Materia materia)
        {
            return await _materiaRepository.Cadastrar(materia);
        }

        public async Task<bool> RemoverMateria(int id)
        {
            var materia = await _materiaRepository.BuscarMateriaPorId(id);
            try
            {
                _materiaRepository.Remove(materia);
                await _materiaRepository.SaveChangesAsync();
                return true;

            }
            catch (System.Exception)
            {
                return false;
            }
            
        }
    }
}
