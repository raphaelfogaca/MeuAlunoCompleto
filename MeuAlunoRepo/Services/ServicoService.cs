
using MeuAlunoDominio.Entities;
using MeuAlunoDominio.Interfaces.Repositories;
using MeuAlunoDominio.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuAlunoRepo.Services
{
    public class ServicoService : IServicoService
    {
        private readonly IServicoRepository _repo;
        private readonly IServicoAulaService _servicoAulaService;
        public ServicoService(IServicoRepository repo,
            IServicoAulaService servicoAulaService)
        {
            _repo = repo;
            _servicoAulaService = servicoAulaService;
        }

        public async Task<List<Servico>> BuscarServicoPorEmpresaId(int empresaId)
        {
            var servicos = await _repo.BuscarServicoPorEmpresaId(empresaId);
            return servicos;
        }

        public async Task<Servico> BuscarServicoPorId(int servicoId)
        {
            var servico = await _repo.BuscarServicoPorId(servicoId);
            return servico;
        }

        public async Task<Servico> CadastrarServico(Servico servico)
        {
            try
            {
                if (servico.Id > 0)
                {
                    await _repo.CadastrarServico(servico);
                    return servico;
                }
                else
                {                    
                    var servicoAulaAtuais = await _servicoAulaService.BuscarServicoAulaPorServicoId(servico.Id);
                    var novosServicoAulas = servico.ServicosAulas;
                  
                    var servicoAulaParaRemover = servicoAulaAtuais.Where(x => !novosServicoAulas.Contains(x));
                    var servicoAulaParaIncluir = novosServicoAulas.Where(x => !servicoAulaAtuais.Contains(x));

                    servico.ServicosAulas = servicoAulaParaIncluir.ToList();
                    foreach (var m in servicoAulaParaRemover)
                    {
                        await _servicoAulaService.RemoverServicoAula(m.Id);
                    }
                    _repo.Update(servico);
                    await _repo.SaveChangesAsync();
                    return servico;
                }      
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar serviço");
            }
        }
    }
}
