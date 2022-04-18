using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using MeuAlunoDominio;
using MeuAlunoDominio.Entities;
using MeuAlunoDominio.Interfaces.Repositories;
using MeuAlunoDominio.Interfaces.Services;
using MeuAlunoRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeuAluno.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceiroController : ControllerBase
    {

        private readonly IFinanceiroService _financeiroService;
        public FinanceiroController(IFinanceiroService financeiroService)
        {
            _financeiroService = financeiroService;
        }

        // GET: api/<FinanceiroController>
        
        [Route("/api/financeiroPorEmpresa/{empresaid:int}")]
        public async Task<IActionResult> GetByEmpresaId(int empresaId)
        {
            try
            {
                var financeiros = await _financeiroService.BuscarFinanceiroPorEmpresaId(empresaId);
                return Ok(financeiros);
            }
            catch
            {
                return Ok("Erro ao buscar financeiro.");
            }
        }


        [Route("/api/financeiro/buscar")]
        public async Task<IActionResult> Buscar(FinanceiroFiltroModelo filtros)
        {
            try
            {
                var financeiros = await _financeiroService.BuscarFinanceiroPorFiltro(filtros);
                if (financeiros.FirstOrDefault() != null)
                {
                    return Ok(financeiros);
                }
                else return Ok("");
            }
            catch (Exception ex)    
            {
                return Ok("Erro ao buscar financeiro.");
            }
        }

        [Route("/api/financeiro/liquidar")]
        public async Task<IActionResult> Liquidar(int[] documentos)
        {
            try
            {
                List<string> erros = new List<string>();
                foreach (var item in documentos)
                {
                   var retorno = await _financeiroService.LiquidarDocumento(item);
                    if (!retorno)
                        erros.Add(item.ToString());
                }
               return Ok(erros);
                
            }
            catch (Exception ex)
            {
                return Ok("Erro ao liquidar documentos.");
            }            
        }

        // GET api/<FinanceiroController>/5
        [Route("/api/cadastroFinanceiro/{id:int}")]
        public  IActionResult GetFinanceiroPorId(int id)
        {
            try
            {
                var financeiros = _financeiroService.BuscarFinanceiroPorId(id);
                return Ok(financeiros);
            }
            catch (Exception ex)
            {
                return Ok("Erro ao buscar financeiro.");
            }
        }

             
        [Route("/api/financeiro/cadastrar")]
        public async Task<IActionResult> Cadastrar(FinanceiroModelo financeiro)
        {
            try
            {
                var financeiros = _financeiroService.Cadastrar(financeiro);
                return Ok("Financeiro cadastrado");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<FinanceiroController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        // DELETE api/<FinanceiroController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
