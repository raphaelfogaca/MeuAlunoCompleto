using MeuAlunoDominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuAlunoRepo
{
    public class MeuAlunoRepository : IMeuAlunoRepository
    {
        private readonly MeuAlunoContext _context;

        public MeuAlunoRepository(MeuAlunoContext context)
        {
            _context = context;
        }

        public void Add<T>(T Entity) where T : class
        {
            _context.Add(Entity);
        }

        public void Delete<T>(T Entity) where T : class
        {
            _context.Remove(Entity);
        }

        public void Update<T>(T Entity) where T : class
        {
            _context.Update(Entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }       

        public List<Pessoa> BuscarPessoasPorEmpresaId(int id)
        {
            IQueryable<Pessoa> query = _context.Pessoas.Where(e => e.EmpresaId == id);
            return query.ToList();
        }

        public List<Aluno> BuscarAlunoPorNome(string nome)
        {
            IQueryable<Aluno> query = _context.Alunos.Where(a => a.Nome.Contains(nome));           
            return query.ToList();
        }
        
        public Task<Aluno[]> BuscarTodosAlunos()
        {
            IQueryable<Aluno> query = _context.Alunos;
            return query.ToArrayAsync();
        }

        public Usuario Login(Usuario usuario)
        {
            Usuario query = _context.Usuarios.FirstOrDefault(a => a.Login == usuario.Login && a.Senha == usuario.Senha);
            query.Empresa = _context.Empresas.FirstOrDefault(e => e.Id == query.EmpresaId);
            query.Pessoa = _context.Pessoas.FirstOrDefault(p => p.Id == query.PessoaId);
            query.Empresa = null;
            return query;            
        }

        public List<Servico> BuscarServicoPorEmpresa(int id)
        {
            IQueryable<Servico> query = _context.Servicos.Where(s => s.EmpresaId == id);
            return query.ToList();
        }

        public Servico BuscarServicoPorAluno(int id)
        {
            Servico query = _context.Servicos.FirstOrDefault(s => s.Id == id);
            return query;
        }

        public List<Aula> BuscarAulaPorEmpresa(int id)
        {
            IQueryable<Aula> query = _context.Aulas.Where(a => a.EmpresaId == id);
            return query.ToList();
        }

        public List<Materia> BuscarMateriaPorEmpresa(int id)
        {
            IQueryable<Materia> query = _context.Materias.Where(a => a.EmpresaId == id);
            return query.ToList();
        }

        public List<MateriaAluno> BuscarMateriaPorAluno(int id)
        {
            IQueryable<MateriaAluno> query = _context.MateriaAluno.Where(m => m.AlunoId == id);
            return query.ToList();
        }

        public List<MateriaAluno> BuscarMateriaPorId(int id)
        {
            IQueryable<MateriaAluno> query = _context.MateriaAluno.Where(m => m.MateriaId == id);
            return query.ToList();
        }


        public Empresa BuscarEmpresaPorId(int id)
        {
            Empresa query = _context.Empresas.FirstOrDefault(e => e.Id == id);
            query.Endereco = _context.Enderecos.FirstOrDefault(e => e.Id == query.EnderecoId);
            query.Pessoas = BuscarPessoasPorEmpresaId(id);
            return query;
        }

        public Aluno BuscarAlunoPorId(int? id)
        {
            Aluno query = _context.Alunos.FirstOrDefault(a => a.Id == id);
            query.Endereco = _context.Enderecos.FirstOrDefault(e => e.Id == query.EnderecoId);
            query.MateriaAlunos = BuscarMateriaPorAluno(query.Id);
            query.Servico = BuscarServicoPorAluno(query.ServicoId);
            return query;
        }

       
    }
}
