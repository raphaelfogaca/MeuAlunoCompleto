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
    public class UsuarioController : ControllerBase
    {
        public MeuAlunoContext _context { get; }

        private readonly IMeuAlunoRepository _repo;

        public UsuarioController(IMeuAlunoRepository repo)
        {
            _repo = repo;
        }
        // GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Usuario model)
        {
            try
            {
                var usuario = _repo.Login(model);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public async Task<IActionResult> Post(Usuario model)
        {
            try
            {
                var usuario =  _repo.Login(model);
                if (usuario != null)
                {
                    usuario.Senha = "";
                    return Ok(usuario);
                }
                else return Ok("usuario não encontrado");
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
