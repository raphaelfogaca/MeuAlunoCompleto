using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using MeuAlunoDominio;
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

        private readonly IMeuAlunoRepository _repo;
        public FinanceiroController(IMeuAlunoRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<FinanceiroController>
        
        [Route("/api/financeiroPorEmpresa/{empresaid:int}")]
        public async Task<IActionResult> GetByEmpresaId(int empresaId)
        {
            try
            {
                var financeiros = await _repo.BuscarFinanceiroPorEmpresaId(empresaId);
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
                var financeiros = await _repo.BuscarFinanceiroPorFiltro(filtros);
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
                    var doc = _repo.BuscarFinanceiroPorId(item);
                    doc.Situacao = 2;
                    _repo.Update(doc);
                    var resultado = await _repo.SaveChangesAsync();
                    if (!resultado)
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
                var financeiros = _repo.BuscarFinanceiroPorId(id);
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
                List<string> erros = null;
                bool edicao = false;

                if (!(financeiro.AlunoId > 0) && financeiro.PessoaNome == "" && financeiro.todosAlunos == false)
                {                    
                    return Ok("Erro ao gerar CRE.");
                }

                if (financeiro.Id > 0)
                {
                    edicao = true;
                }
                financeiro.Valor /= 100;               
                if (financeiro != null && financeiro.todosAlunos)
                {
                    var listaAlunos = await _repo.BuscarAlunosPorEmpresaid(financeiro.EmpresaId);
                    
                    foreach (var aluno in listaAlunos)
                    {
                        financeiro.Id = 0;
                        financeiro.AlunoId = aluno.Id;
                        Aluno novoAluno = _repo.BuscarAlunoPorId(aluno.Id);
                        Servico servicoAluno = _repo.BuscarServicoPorId(novoAluno.ServicoId);
                        financeiro.Valor = servicoAluno.Valor;
                        financeiro.PessoaNome = novoAluno.Nome;

                        erros = await CadastrarFinanceiro(financeiro);
                    }
                }
                else if (financeiro != null && !financeiro.todosAlunos)
                {
                   
                    if(financeiro.AlunoId > 0)
                    {
                        Aluno aluno = _repo.BuscarAlunoPorId(financeiro.AlunoId);
                        financeiro.PessoaNome = aluno.Nome;
                    }
                   
                    if (financeiro.qtdProvisionar > 0)
                    {                        
                        for(int i = 0; i <= financeiro.qtdProvisionar; i++)
                        {
                            erros = await CadastrarFinanceiro(financeiro);
                            financeiro.DataVencimento = financeiro.DataVencimento.AddMonths(1);
                            financeiro.Id = 0;
                        }
                    }
                    else
                    {
                        erros = await CadastrarFinanceiro(financeiro);
                    }
                }
                if (erros != null)
                {
                   
                    return Ok("Erro ao gerar CRE.");
                }
                else
                {
                    if (edicao)
                    {
                        return Ok("Financeiro atualizado com sucesso.");
                    }
                    else
                    {
                        return Ok("Financeiro gerado com sucesso.");
                    }                    
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

            async Task<List<string>> CadastrarFinanceiro(Financeiro financeiro)
            {
                List<string> listaErros = null;
                try
                {
                    if (financeiro.Id > 0)
                    {
                        _repo.Update(financeiro);
                        var retorno = await _repo.SaveChangesAsync();
                        if (!retorno)
                        {
                            listaErros.Add(retorno.ToString());
                        }

                    }
                    else
                    {
                        _repo.Add(financeiro);
                        var retorno = await _repo.SaveChangesAsync();
                        if (!retorno)
                        {
                            listaErros.Add(retorno.ToString());
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
                return listaErros;
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
