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
        List<Aluno> BuscarAlunoPorNome(string nome);
        Aluno BuscarAlunoPorId(int? id);
        Task<Aluno[]> BuscarTodosAlunos();
        Usuario Login(Usuario usuario);
        List<Servico> BuscarServicoPorEmpresa(int id);
        List<Aula> BuscarAulaPorEmpresa(int id);
        List<Materia> BuscarMateriaPorEmpresa(int id);
        List<MateriaAluno> BuscarMateriaPorId(int id);
        List<MateriaAluno> BuscarMateriaPorAluno(int id);
    }
}

