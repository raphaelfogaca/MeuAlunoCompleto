using MeuAlunoDominio.Entities;
using MeuAlunoDominio.Interfaces.Repositories;
using MeuAlunoDominio.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuAlunoRepo.Services
{
    public class MateriaAlunoService : IMateriaAlunoService
    {
        private readonly IMateriaAlunoRepository _materiaAlunoRepository;

        public MateriaAlunoService(IMateriaAlunoRepository materiaAlunoRepository)
        {
            _materiaAlunoRepository = materiaAlunoRepository;
        }

        public async Task<List<MateriaAluno>> BuscarPorAlunoId(int alunoId)
        {
            return await _materiaAlunoRepository.BuscarPorAlunoId(alunoId);
        }
    }
}
