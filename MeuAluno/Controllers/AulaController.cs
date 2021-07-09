using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuAlunoDominio;
using MeuAlunoRepo;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeuAluno.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AulaController : ControllerBase
    {
        private readonly IMeuAlunoRepository _repo;
        public AulaController(IMeuAlunoRepository repo)
        {
            _repo = repo;
        }
        // GET: api/<AulaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AulaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id) //buscar pelo Id da Empresa
        {
            try
            {
                var servicos = _repo.BuscarAulaPorEmpresa(id);
                return Ok(servicos);
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
                _repo.Add(model);
                if (await _repo.SaveChangesAsync())
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
