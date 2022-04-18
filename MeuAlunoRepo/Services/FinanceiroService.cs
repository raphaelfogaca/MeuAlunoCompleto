
using MeuAlunoDominio;
using MeuAlunoDominio.Entities;
using MeuAlunoDominio.Interfaces.Repositories;
using MeuAlunoDominio.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuAlunoRepo.Services
{
    public class FinanceiroService : IFinanceiroService
    {
        private readonly IFinanceiroRepository _financeiroRepository;

        public FinanceiroService(IFinanceiroRepository financeiroRepository)
        {
            _financeiroRepository = financeiroRepository;
        }
        public async Task<List<FinanceiroModelo>> BuscarFinanceiroPorEmpresaId(int empresaId)
        {
            return await _financeiroRepository.BuscarFinanceiroPorEmpresaId(empresaId); 
        }

        public async Task<List<FinanceiroModelo>> BuscarFinanceiroPorFiltro(FinanceiroFiltroModelo filtros)
        {
            return await _financeiroRepository.BuscarFinanceiroPorFiltro(filtros);
        }

        public async Task<FinanceiroModelo> BuscarFinanceiroPorId(int documentoId)
        {
            return await _financeiroRepository.BuscarFinanceiroPorId(documentoId);
        }
        public async Task<bool> LiquidarDocumento(int documentoId)
        {
           var financeiro = await _financeiroRepository.GetById(documentoId);
            financeiro.Situacao = 2;
            _financeiroRepository.Update(financeiro);
            try
            {
                await _financeiroRepository.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
           
           
        }

        public async Task<FinanceiroModelo> Cadastrar(FinanceiroModelo financeiroModelo)
        {
            if(financeiroModelo.Id > 0)
            {
                try
                {
                    var financeiro = await _financeiroRepository.GetById(financeiroModelo.Id);
                    _financeiroRepository.Update(financeiro);
                    await _financeiroRepository.SaveChangesAsync();
                    return financeiroModelo;
                }
                catch (Exception)
                {
                    throw new Exception("Erro ao atualizar o documento");
                }
                
            }
            else
            {
                try
                {
                    if (financeiroModelo.todosAlunos)
                    {
                        //implementar
                    }

                    _financeiroRepository.Add(financeiroModelo);
                    return financeiroModelo;
                }
                catch (Exception)
                {
                    throw new Exception("Erro ao cadastrar o documento");
                }
            }
        } 
    }
}
