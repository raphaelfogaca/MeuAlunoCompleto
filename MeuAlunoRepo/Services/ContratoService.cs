using MeuAlunoDominio.Contrato;
using MeuAlunoDominio.Interfaces;
using MeuAlunoRepo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuAlunoRepo.Services
{
    public class ContratoService : IContratoService
    {
        private readonly ContratoRepository _repo;
        private readonly IClausulaService _clausulaService;
        public ContratoService(ContratoRepository repo, IClausulaService clausulaService)
        {
            _repo = repo;
            _clausulaService = clausulaService;
        }
        public async Task<ContratoModelo> BuscarContratoModelo()
        {
            var contrato = _repo.BuscarContratoModelo();
            ContratoModelo contratoModelo = new ContratoModelo();
            contratoModelo.ContratoId = contrato.Id;
            contratoModelo.Clausulas = await _clausulaService.BuscarClausulasModelo(contrato.Id);
            return contratoModelo;            
        }

        public async Task<ContratoModelo> BuscarContratoPorEmpresaId(int empresaId)
        {
            var contrato = await _repo.BuscarContratoPorEmpresaId(empresaId);
            ContratoModelo contratoModelo = new ContratoModelo();
            contratoModelo.ContratoId = contrato.Id;
            contratoModelo.Clausulas = await _clausulaService.BuscarClausulasModelo(contrato.Id);
            return contratoModelo;            
        }

        public Task<ContratoModelo> CadastrarContratoModelo(int empresaId)
        {
            throw new NotImplementedException();
        }
    }
}
