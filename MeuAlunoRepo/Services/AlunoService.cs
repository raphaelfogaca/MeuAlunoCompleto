using MeuAlunoDominio;
using MeuAlunoDominio.Interfaces.Repositories;
using MeuAlunoDominio.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuAlunoRepo.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMateriaService _materiaService;
        private readonly IEnderecoService _enderecoService;
        private readonly IMateriaAlunoService _materiaAlunoService;
        

        public AlunoService(IAlunoRepository alunoRepository, 
            IMateriaService materiaService, 
            IEnderecoService enderecoService,
            IMateriaAlunoService materiaAlunoService)
        {
            _alunoRepository = alunoRepository;
            _materiaService = materiaService;
            _enderecoService = enderecoService;
            _materiaAlunoService = materiaAlunoService;
        }

        public async Task<bool> Alterar(Aluno aluno)
        {
            try
            {
                var materiasAtuais = await _materiaAlunoService.BuscarPorAlunoId(aluno.Id);
                var novasMaterias = aluno.MateriaAlunos;
                var materiasParaRemover = materiasAtuais.Where(x => !novasMaterias.Contains(x));
                var materiasParaIncluir = novasMaterias.Where(x => !materiasAtuais.Contains(x));
                aluno.MateriaAlunos = materiasParaIncluir.ToList();
                foreach (var m in materiasParaRemover)
                {
                    await _materiaService.RemoverMateria(m.MateriaId);
                }
                _alunoRepository.Update(aluno);
                await _alunoRepository.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
            
        }

        public async Task<Aluno> BuscarAlunoPorId(int id)
        {
            var aluno = await _alunoRepository.BuscarAlunoPorId(id);
            aluno.Endereco = await _enderecoService.BuscarPorId(aluno.EnderecoId);
            aluno.MateriaAlunos = await _materiaAlunoService.BuscarPorAlunoId(aluno.Id);
            return aluno;
        }

        public async Task<List<Aluno>> BuscarAlunoPorNome(string nome)
        {
            return await _alunoRepository.BuscarAlunoPorNome(nome);
        }

        public async Task<List<Aluno>> BuscarAlunosPorEmpresaid(int empresaId)
        {
            return await _alunoRepository.BuscarAlunosPorEmpresaid(empresaId);
        }

        public async Task<List<Aluno>> BuscarTodosAlunos()
        {
            return await _alunoRepository.BuscarTodosAlunos();
        }

        public async Task<Aluno> Cadastrar(Aluno aluno)
        {
            try
            {
                _alunoRepository.Add(aluno);
                await _alunoRepository.SaveChangesAsync();
                return aluno;
            }
            catch (System.Exception)
            {
                return null;
            }
            
        }
    }
}
