using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MeuAlunoDominio;
using MeuAlunoRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MeuAlunoDominio.Interfaces.Repositories;
using MeuAlunoDominio.Interfaces.Services;
using MeuAlunoDominio.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeuAluno.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {             
        private readonly IEmpresaService _empresaService;

        private readonly IContratoService _contratoService;
        public EmpresaController(IEmpresaService empresaService, IContratoService contratoService)
        {
            _empresaService = empresaService;
            _contratoService = contratoService;
        }

        // GET: api/<EmpresaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var empresas = await _empresaService.BuscarTodasEmpresas();
                return Ok(empresas);
            }
            catch (Exception ex)
            {
                return Ok("Erro:");
            }
        }

        // GET api/<EmpresaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var empresa = _empresaService.BuscarEmpresaPorId(id);
                return Ok(empresa);
            }
            catch (Exception)
            {
                return Ok("Não encontrada");
            }
        }

        // POST api/<EmpresaController>
        [HttpPost]
        public async Task<IActionResult> Post(EmpresaModelo model)
        {
           var cadastroEmpresa = await _empresaService.Inserir(model);
            if(cadastroEmpresa == null)
            {
                return Ok("Erro ao cadastrar empresa");
            }
            else
            {
                return Ok("Empresa cadastrada com sucesso");

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
