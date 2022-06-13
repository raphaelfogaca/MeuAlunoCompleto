using MeuAlunoDominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuAlunoDominio.Interfaces.Services
{
    public interface IServicoService
    {
        public Task<List<Servico>> BuscarServicoPorEmpresaId(int empresaId);
        public Task<Servico> BuscarServicoPorId(int servicoId);

        public Task<Servico> CadastrarServico(Servico servico);

    }
}
