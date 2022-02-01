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
        public List<Servico> BuscarServicoPorEmpresaId(int id)
        {
            IQueryable<Servico> query = _context.Servicos.Where(s => s.EmpresaId == id);
            return query.ToList();
        }
        public Task<Servico[]> BuscarTodosServicos()
        {
            IQueryable<Servico> query = _context.Servicos;
            return query.ToArrayAsync();
        }
        public Servico BuscarServicoPorId(int id)
        {
            Servico query = _context.Servicos.FirstOrDefault(s => s.Id == id);
            if (query != null)
            {
                query.ServicosAulas = BuscarServicoAula(id);
            }

            return query;
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
        public Materia BuscarMateriaPorId(int id)
        {
            return _context.Materias.FirstOrDefault(s => s.Id == id);
        }
        public Empresa BuscarEmpresaPorId(int id)
        {
            Empresa query = _context.Empresas.FirstOrDefault(e => e.Id == id);
            query.Endereco = _context.Enderecos.FirstOrDefault(e => e.Id == query.EnderecoId);
            query.Pessoas = BuscarPessoasPorEmpresaId(id);
            return query;
        }
        public Task<Empresa[]> BuscarTodasEmpresas()
        {
            IQueryable<Empresa> query = _context.Empresas;
            return query.ToArrayAsync();
        }
        public Aluno BuscarAlunoPorId(int? id)
        {
            Aluno query = _context.Alunos.FirstOrDefault(a => a.Id == id);
            query.Endereco = _context.Enderecos.FirstOrDefault(e => e.Id == query.EnderecoId);
            query.MateriaAlunos = BuscarMateriaPorAluno(query.Id);
            query.Servico = BuscarServicoPorAluno(query.ServicoId);
            return query;
        }
        public List<ServicoAula> BuscarServicoAula(int id)
        {
            IQueryable<ServicoAula> query = _context.ServicoAula.Where(s => s.ServicoId == id);
            return query.ToList();
        }
        public Aula BuscarAulaPorId(int id)
        {
            return _context.Aulas.FirstOrDefault(a => a.Id == id);
        }
        public Task<FinanceiroModelo[]> BuscarFinanceiroPorEmpresaId(int empresaId)
        {
            IQueryable<FinanceiroModelo> query = (IQueryable<FinanceiroModelo>)_context.Financeiros.Where(x => x.EmpresaId == empresaId)
                .Select(s => new FinanceiroModelo()
                {
                    Id = s.Id,
                    AlunoId = s.AlunoId,
                    DataVencimento = s.DataVencimento,
                    Situacao = s.Situacao,
                    EmpresaId = s.EmpresaId,
                    FormaPagamento = s.FormaPagamento,
                    Valor = s.Valor,
                    Tipo = s.Tipo,
                    PessoaNome = s.PessoaNome,
                    NomeAluno = _context.Alunos.Where(x => x.Id == s.AlunoId).Select(n => n.Nome).FirstOrDefault(),
                });

            return query.ToArrayAsync();
        }
        public FinanceiroModelo BuscarFinanceiroPorId(int id)
        {
            IQueryable<FinanceiroModelo> query = _context.Financeiros.Where(x => x.Id == id)
               .Select(s => new FinanceiroModelo()
               {
                   Id = s.Id,
                   AlunoId = s.AlunoId,
                   DataVencimento = s.DataVencimento,
                   Situacao = s.Situacao,
                   EmpresaId = s.EmpresaId,
                   FormaPagamento = s.FormaPagamento,
                   Valor = s.Valor,
                   NomeAluno = _context.Alunos.Where(x => x.Id == s.AlunoId).Select(n => n.Nome).FirstOrDefault(),
                   Tipo = s.Tipo,
               });
            return query.FirstOrDefault();
        }
        public Task<Aluno[]> BuscarAlunosPorEmpresaid(int empresaId)
        {
            IQueryable<Aluno> query = _context.Alunos.Where(x => x.EmpresaId == empresaId);
            return query.ToArrayAsync();
        }
        public Task<Pessoa[]> BuscarPessoaPorEmpresaId(int empresaId)
        {
            IQueryable<Pessoa> query = _context.Pessoas.Where(x => x.EmpresaId == empresaId);
            return query.ToArrayAsync();
        }
        public Task<UsuarioModelo[]> BuscarUsuarioPorEmpresaId(int empresaId)
        {
            IQueryable<UsuarioModelo> query = _context.Usuarios.Where(x => x.EmpresaId == empresaId)
               .Select(s => new UsuarioModelo()
               {
                   Id = s.Id,
                   Login = s.Login,
                   Ativo = s.Ativo,
                   PessoaId = s.PessoaId,
                   PessoaNome = _context.Pessoas.Where(x => x.Id == s.PessoaId).Select(n => n.Nome).FirstOrDefault(),
                   EmpresaId = s.EmpresaId,
                   EmpresaNome = _context.Empresas.Where(x => x.Id == s.EmpresaId).Select(n => n.RazaoSocial).FirstOrDefault(),
                   TipoUsuario = s.TipoUsuario
               });
            return query.ToArrayAsync();
        }
        public Task<UsuarioModelo> BuscarUsuarioPorId(int id)
        {
            IQueryable<UsuarioModelo> query = _context.Usuarios.Where(x => x.Id == id)
                .Select(s => new UsuarioModelo()
                {
                    Id = s.Id,
                    Login = s.Login,
                    Ativo = s.Ativo,
                    PessoaId = s.PessoaId,
                    PessoaNome = _context.Pessoas.Where(x => x.Id == s.PessoaId).Select(n => n.Nome).FirstOrDefault(),
                    EmpresaId = s.EmpresaId,
                    EmpresaNome = _context.Empresas.Where(x => x.Id == s.EmpresaId).Select(n => n.RazaoSocial).FirstOrDefault(),
                    TipoUsuario = s.TipoUsuario
                });
            return query.FirstOrDefaultAsync();
        }
        public Task<UsuarioTokenModelo> Login(string login, string senha)
        {
            var usuario = _context.Usuarios.FirstOrDefault(x => x.Login == login && x.Senha == senha && x.Ativo == true);
            if (usuario != null && usuario.TipoUsuario == 2)
            {
                IQueryable<UsuarioTokenModelo> query = _context.Usuarios.Where(x => x.Login == login && x.Senha == senha && x.Ativo == true)
               .Select(s => new UsuarioTokenModelo()
               {
                   Id = s.Id.ToString(),                   
                   Login = s.Login,
                   PessoaId = s.PessoaId,
                   PessoaNome = _context.Pessoas.Where(x => x.Id == s.PessoaId).Select(n => n.Nome).FirstOrDefault(),
                   Email = _context.Pessoas.Where(x => x.Id == s.PessoaId).Select(n => n.Email).FirstOrDefault(),
                   EmpresaId = s.EmpresaId,
                   EmpresaNome = _context.Empresas.Where(x => x.Id == s.EmpresaId).Select(n => n.RazaoSocial).FirstOrDefault(),
                   TipoUsuario = s.TipoUsuario,
                   ExpirationTime = 1,
               });
                return query.FirstOrDefaultAsync();
            }
            else if (usuario != null & usuario.TipoUsuario == 1)
            {
                IQueryable<UsuarioTokenModelo> query = _context.Usuarios.Where(x => x.Login == login && x.Senha == senha && x.Ativo == true)
                .Select(s => new UsuarioTokenModelo()
                {
                    Id = s.Id.ToString(),
                    Login = s.Login,
                    PessoaId = s.PessoaId,
                    PessoaNome = _context.Pessoas.Where(x => x.Id == s.PessoaId).Select(n => n.Nome).FirstOrDefault(),
                    Email = _context.Pessoas.Where(x => x.Id == s.PessoaId).Select(n => n.Email).FirstOrDefault(),
                    EmpresaId = s.EmpresaId,
                    EmpresaNome = _context.Empresas.Where(x => x.Id == s.EmpresaId).Select(n => n.RazaoSocial).FirstOrDefault(),
                    TipoUsuario = s.TipoUsuario,
                    ExpirationTime = 1,
                    Empresa = _context.Empresas.ToList(),
                });
                return query.FirstOrDefaultAsync();
            }
            return null;
        }
        public Task<FinanceiroModelo[]> BuscarFinanceiroPorFiltro(FinanceiroFiltros filtros)
        {
            IQueryable<FinanceiroModelo> query = (IQueryable<FinanceiroModelo>)_context.Financeiros.Where(x => x.EmpresaId == filtros.EmpresaId)
                .Select(s => new FinanceiroModelo()
                {
                    Id = s.Id,
                    AlunoId = s.AlunoId,
                    DataVencimento = s.DataVencimento,
                    Situacao = s.Situacao,
                    EmpresaId = s.EmpresaId,
                    FormaPagamento = s.FormaPagamento,
                    Valor = s.Valor,
                    Tipo = s.Tipo,
                    PessoaNome = s.PessoaNome,
                    NomeAluno = _context.Alunos.Where(x => x.Id == s.AlunoId).Select(n => n.Nome).FirstOrDefault(),
                });
            if(filtros.VencimentoInicio != null)
            {
                query = query.Where(x => x.DataVencimento >= filtros.VencimentoInicio);
            }
            if (filtros.VencimentoFim != null)
            {
                query = query.Where(x => x.DataVencimento <= filtros.VencimentoFim);
            }
            if (filtros.Pessoa != "")
            {
                query = query.Where(x => x.PessoaNome.Contains(filtros.Pessoa));
            }
            if (filtros.Tipo > 0)
            {
                query = query.Where(x => x.Tipo == filtros.Tipo);
            }
            if (filtros.Situacao > 0)
            {
                query = query.Where(x => x.Situacao == filtros.Situacao);
            }
            return query.ToArrayAsync();
        }
    }
}


