using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MeuAlunoDominio.Entities;
using MeuAlunoDominio.Interfaces.Repositories;
using MeuAlunoDominio.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeuAluno.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AulaController : ControllerBase
    {
        private readonly IAulaService _aulaService;
        public AulaController(IAulaService aulaService)
        {
            _aulaService = aulaService;
        }
        // GET: api/<AulaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AulaController>/5
        [Route("/api/aulaPorEmpresa/{id:int}")]
        public async Task<IActionResult> GetByEmpresaId(int id) //buscar pelo Id da Empresa
        {
            try
            {
                var aulas = await _aulaService.BuscarAulaPorEmpresa(id);
                return Ok(aulas);
            }
            catch (Exception ex)
            {

                return Ok("Erro:" + ex);
            }
        }

        [Route("/api/aula/{id:int}")]
        public async Task<IActionResult> GetById(int id) //buscar pelo Id da Aula
        {
            try
            {
                var aula = await _aulaService.BuscarAulaPorId(id);
                return Ok(aula);
            }
            catch (Exception ex)
            {

                return Ok("Erro:" + ex);
            }
        }

        // POST api/<AulaController>
        [HttpPost]
        public async Task<IActionResult> Post(Aula model)
        {
            try
            {
                var retorno = await _aulaService.Cadastrar(model);
                if (retorno != null)
                {
                    return Ok("Aula cadastrada");
                }
                else
                {
                    return Ok("Aula não cadastrada");
                }

            }
            catch (Exception ex)
            {

                return Ok("Erro ao cadastrar: " + ex);
            }
        }

        // PUT api/<AulaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AulaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
