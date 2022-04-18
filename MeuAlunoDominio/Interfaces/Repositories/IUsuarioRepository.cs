using MeuAlunoDominio.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuAlunoDominio.Interfaces.Repositories
{
    public interface IUsuarioRepository : IMeuAlunoBaseRepository<Usuario>
    {
        Task<UsuarioTokenModelo> Login(string login, string senha);
        Task<List<UsuarioModelo>> BuscarUsuarioPorEmpresaId(int empresaId);
        Task<UsuarioModelo> BuscarUsuarioPorId(int id);
        Task<Usuario> Cadastrar(Usuario usuario);

    }
}
