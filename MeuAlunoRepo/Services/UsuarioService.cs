
using MeuAlunoDominio;
using MeuAlunoDominio.Entities;
using MeuAlunoDominio.Interfaces.Repositories;
using MeuAlunoDominio.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuAlunoRepo.Services
{
    public class UsuarioService : IUsuarioService
    {
        IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<List<UsuarioModelo>> BuscarUsuarioPorEmpresaId(int empresaId)
        {
            return await _usuarioRepository.BuscarUsuarioPorEmpresaId(empresaId);
        }

        public async Task<UsuarioModelo> BuscarUsuarioPorId(int id)
        {
            return await _usuarioRepository.BuscarUsuarioPorId(id);
        }

        public async Task<Usuario> Cadastrar(Usuario usuario)
        {
            return await _usuarioRepository.Cadastrar(usuario);
        }

        public async Task<UsuarioTokenModelo> Login(string login, string senha)
        {
            return await _usuarioRepository.Login(login, senha);
        }        
    }
}
