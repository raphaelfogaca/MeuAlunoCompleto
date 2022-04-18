
using MeuAlunoDominio.Entities;
using MeuAlunoDominio.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuAlunoDominio.Interfaces.Services
{
    public interface IMateriaService
    {
        Task<List<Materia>> BuscarMateriaPorEmpresa(int id);
        Task<Materia> BuscarMateriaPorId(int id);
        Task<List<MateriaAluno>> BuscarMateriaPorAluno(int id);
        Task<Materia> Cadastrar(Materia materia);

    }
}
