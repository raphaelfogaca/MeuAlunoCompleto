
using MeuAlunoDominio;
using MeuAlunoDominio.Entities;
using MeuAlunoDominio.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuAlunoRepo.Repositories
{
    public class UsuarioRepository : MeuAlunoBaseRepository<Usuario>, IUsuarioRepository
    {
        MeuAlunoContext _context;
        public UsuarioRepository(MeuAlunoContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<UsuarioModelo>> BuscarUsuarioPorEmpresaId(int empresaId)
        {
            var listaAlunos = await _context.Usuarios.Where(x => x.EmpresaId == empresaId)
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
               }).ToListAsync();

            return listaAlunos;
        }
        public async Task<UsuarioModelo> BuscarUsuarioPorId(int id)
        {
           var usuario = await _context.Usuarios.Where(x => x.Id == id)
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
                }).FirstAsync();    
            return usuario;
        }
        public async Task<UsuarioTokenModelo> Login(string login, string senha)
        {
            var usuario = _context.Usuarios.FirstOrDefault(x => x.Login == login && x.Senha == senha && x.Ativo == true);

            if (usuario == null)
            {
                return null;
            }
            if (usuario != null && usuario.TipoUsuario == 1)
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
                return await query.FirstOrDefaultAsync();
            }

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
                    Empresa = _context.Empresas.Where(x => x.Id == s.EmpresaId).ToList(),
                });
                return await query.FirstOrDefaultAsync();
            }
            return null;
        }
        public async Task<Usuario> Cadastrar(Usuario usuario)
        {
            if(usuario.Id > 0)
            {
                 _context.Update(usuario);
            }
            else
            {
                _context.Add(usuario);
            }
            await SaveChangesAsync();
            return usuario;
        }
    }
}
