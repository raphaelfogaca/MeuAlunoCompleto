﻿using MeuAlunoDominio.DTO;
using MeuAlunoDominio.Interfaces.Services;
using MeuAlunoRepo.Repositories;
using MeuAlunoDominio.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using MeuAlunoDominio.Interfaces.Repositories;
using System.Linq;

namespace MeuAlunoRepo.Services
{
    public class ContratoService : IContratoService
    {
        private readonly IContratoRepository _repo;
        private readonly IClausulaService _clausulaService;
        public ContratoService(IContratoRepository repo, IClausulaService clausulaService)
        {
            _repo = repo;
            _clausulaService = clausulaService;
        }

        public async Task<ContratoModelo> AlterarContrato(ContratoModelo contrato)
        {       
            var clausulasExistentes = await _clausulaService.BuscarClausulasModelo(contrato.ContratoId);

            foreach(var clausula in clausulasExistentes)
            {
                if(contrato.Clausulas.Where(x => x.Id == clausula.Id).Any())
                {
                    clausula.Ativa = true;
                    clausula.Descricao = contrato.Clausulas.First(x => x.Id == clausula.Id).Descricao;
                }
                else
                {
                    clausula.Ativa = false;
                }
            }            
            contrato.Clausulas = await _clausulaService.CadastrarClausulas(clausulasExistentes);
            return contrato;
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
        public async Task<ContratoModelo> CadastrarContratoModelo(int empresaId)
        {
            Contrato contrato = new Contrato();
            contrato.EmpresaId = empresaId;

            var retornoContrato = await _repo.CadastrarContratoModelo(contrato);
            var listaClausulas = await _clausulaService.BuscarClausulasModelo(retornoContrato.Id);
            foreach (var item in listaClausulas)
            {
                item.ContratoId = retornoContrato.Id;
            }

            await _clausulaService.CadastrarClausulas(listaClausulas);

            return await this.BuscarContratoPorEmpresaId(retornoContrato.EmpresaId.GetValueOrDefault());
            
        }
               
    }
}
