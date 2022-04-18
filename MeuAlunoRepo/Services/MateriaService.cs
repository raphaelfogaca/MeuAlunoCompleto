
using MeuAlunoDominio.Entities;
using MeuAlunoDominio.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuAlunoRepo.Services
{
    public class MateriaService : IMateriaService
    {
        private readonly IMateriaService _materiaService;
        public MateriaService(IMateriaService materiaService)
        {
            _materiaService = materiaService;
        }
        public async Task<List<MateriaAluno>> BuscarMateriaPorAluno(int id)
        {
           return await _materiaService.BuscarMateriaPorAluno(id);
        }

        public async Task<List<Materia>> BuscarMateriaPorEmpresa(int id)
        {
            return await _materiaService.BuscarMateriaPorEmpresa(id);
        }

        public async Task<Materia> BuscarMateriaPorId(int id)
        {
            return await _materiaService.BuscarMateriaPorId(id);
        }

        public async Task<Materia> Cadastrar(Materia materia)
        {
            return await _materiaService.Cadastrar(materia);
        }
    }
}
