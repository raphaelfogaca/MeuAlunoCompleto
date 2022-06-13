using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuAlunoDominio;
using MeuAlunoDominio.Entities;
using MeuAlunoDominio.Interfaces.Repositories;
using MeuAlunoDominio.Interfaces.Services;
using MeuAlunoRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeuAluno.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly IServicoService _servicoService;
        public ServicoController(IServicoService servicoService)
        {
            _servicoService = servicoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            throw new NotImplementedException();

        }

        // GET api/<ServicoController>/5
        [Route("/api/servico/{id:int}")]
        public IActionResult GetById(int id) //buscar pelo Id
        {
            try
            {
                var servicos = _servicoService.BuscarServicoPorId(id);
                return Ok(servicos);
            }
            catch (Exception ex)
            {

                return Ok("Erro:" + ex);
            }
        }

        [Route("/api/servicoPorEmpresa/{id:int}")]
        public IActionResult GetByEmpresaId(int id) //buscar pelo Id
        {
            try
            {
                var servicos = _servicoService.BuscarServicoPorEmpresaId(id);
                return Ok(servicos);
            }
            catch (Exception ex)
            {

                return Ok("Erro:" + ex);
            }
        }

        // POST api/<ServicoController>
        [HttpPost]
        public async Task<IActionResult> Post(Servico model)
        {
            try
            {
                await _servicoService.CadastrarServico(model);
                return Ok("Serviço cadastrado");
            }


            catch (Exception ex)
            {
                return Ok("Erro ao cadastrar: " + ex);
            }

        }

        // PUT api/<ServicoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ServicoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
