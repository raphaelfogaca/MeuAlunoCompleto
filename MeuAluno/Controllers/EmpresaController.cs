using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuAlunoDominio;
using MeuAlunoRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MeuAluno.Controllers;
using MeuAlunoRepo.Services;
using MeuAlunoDominio.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeuAluno.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
       
        public MeuAlunoContext _context { get; }

        private readonly IMeuAlunoRepository _repo;

        private readonly IContratoService _contratoService;
        public EmpresaController(IMeuAlunoRepository repo, IContratoService contratoService)
        {
            _repo = repo;
            _contratoService = contratoService;
        }

        // GET: api/<EmpresaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {         
            //try
            //{
            //    var empresas = await _repo.BuscarTodasEmpresas();
            //    return Ok(empresas);
            //}
            //catch (Exception ex)
            //{
                return Ok("Erro:");
            //}
        }

        // GET api/<EmpresaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            //try
            //{
            //    var empresa = _repo.BuscarEmpresaPorId(id);
            //    return Ok(empresa);
            //}
            //catch (Exception)
            //{
                return Ok("Não encontrada");
            //}
        }

        // POST api/<EmpresaController>
        [HttpPost]
        public async Task<IActionResult> Post(EmpresaModelo model)
        {
            try
            {
                List<Pessoa> pessoas = new List<Pessoa>(); 
                pessoas.Add(model.Pessoa);

                Empresa empresa = new Empresa();
                empresa.Id = model.Id;
                empresa.CNPJ_CPF = model.CNPJ_CPF;
                empresa.RazaoSocial = model.RazaoSocial;
                empresa.Telefone = model.Telefone;
                empresa.Endereco = model.Endereco;
                empresa.Pessoas = pessoas;               

                if (empresa.Id > 0)
                {
                    empresa.Pessoas = null;
                    _repo.Update(empresa);
                    if (await _repo.SaveChangesAsync())
                    { return Ok("Empresa atualizada"); }
                    else
                    {
                        return Ok("Erro ao cadastrar");
                    }
                }
                else
                {
                    _repo.Add(empresa);
                    if (await _repo.SaveChangesAsync())
                    {
                        await _contratoService.CadastrarContratoModelo(empresa.Id);
                        return Ok("Empresa cadastrada com sucesso"); 
                    }
                    else
                    {
                        return Ok("Erro ao cadastrar");
                    }
                }


            }
            catch (Exception ex)
            {

                return Ok("Empresa não cadastrada:" + ex);
            }
        }

        // PUT api/<EmpresaController>/5        

        // DELETE api/<EmpresaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
