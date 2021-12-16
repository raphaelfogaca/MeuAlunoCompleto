using MeuAlunoDominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeuAlunoRepo
{
    public interface IMeuAlunoRepository
    {
        void Add<T>(T Entity) where T : class;
        void Update<T>(T Entity) where T : class;
        void Delete<T>(T Entity) where T : class;
        Task<bool> SaveChangesAsync();
        Empresa BuscarEmpresaPorId(int id);
        Task<Empresa[]> BuscarTodasEmpresas();
        List<Aluno> BuscarAlunoPorNome(string nome);
        Aluno BuscarAlunoPorId(int? id);
        Task<Aluno[]> BuscarTodosAlunos();
        Task<UsuarioTokenModelo> Login(string login, string senha);
        List<Servico> BuscarServicoPorEmpresaId(int id);
        Task<Servico[]> BuscarTodosServicos();
        Servico BuscarServicoPorId(int id);
        List<Aula> BuscarAulaPorEmpresa(int id);
        List<ServicoAula> BuscarServicoAula(int id);
        List<Materia> BuscarMateriaPorEmpresa(int id);
        Task<FinanceiroModelo[]> BuscarFinanceiroPorEmpresaId(int empresaId);
        Task<FinanceiroModelo[]> BuscarFinanceiroPorFiltro(FinanceiroFiltros filtros);
        FinanceiroModelo BuscarFinanceiroPorId(int id);
        Task<Aluno[]> BuscarAlunosPorEmpresaid(int empresaId);
        Materia BuscarMateriaPorId(int id);
        List<MateriaAluno> BuscarMateriaPorAluno(int id);
        Aula BuscarAulaPorId(int id);
        Task<Pessoa[]> BuscarPessoaPorEmpresaId(int empresaId);
        Task<UsuarioModelo[]> BuscarUsuarioPorEmpresaId(int empresaId);
        Task<UsuarioModelo> BuscarUsuarioPorId(int id);
    }
}

