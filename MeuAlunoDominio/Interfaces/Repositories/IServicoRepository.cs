
using MeuAlunoDominio.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuAlunoDominio.Interfaces.Repositories
{
    public interface IServicoRepository : IMeuAlunoBaseRepository<Servico>
    {
        public Task<List<Servico>> BuscarServicoPorEmpresaId(int empresaId);
        public Task<Servico> BuscarServicoPorId(int servicoId);
        public Task<Servico> CadastrarServico(Servico servico);
    }
}
