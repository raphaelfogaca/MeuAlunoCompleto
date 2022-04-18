
using MeuAlunoDominio.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuAlunoDominio.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<List<UsuarioModelo>> BuscarUsuarioPorEmpresaId(int empresaId);
        Task<UsuarioModelo> BuscarUsuarioPorId(int id);
        Task<UsuarioTokenModelo> Login(string login, string senha);
        Task<Usuario> Cadastrar(Usuario usuario);
    }
}
