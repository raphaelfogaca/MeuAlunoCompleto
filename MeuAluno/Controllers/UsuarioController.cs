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


        [Route("/api/usuariosPorEmpresa/{empresaid:int}")]
        public async Task<IActionResult> GetByEmpresaId(int empresaId)
        {
            try
            {
                var usuarios = await _repo.BuscarUsuarioPorEmpresaId(empresaId);
                return Ok(usuarios);
            }
            catch
            {
                return Ok("Erro ao buscar financeiro.");
            }
        }

        [Route("/api/usuarioPorId/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var usuarios = await _repo.BuscarUsuarioPorId(id);
                return Ok(usuarios);
            }
            catch
            {
                return Ok("Erro ao buscar financeiro.");
            }
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public async Task<IActionResult> Post(Usuario model)
        {
            List<string> erros = null;
            try
            {
                if(model.Id > 0)
                {
                  _repo.Update(model);

                  if (await _repo.SaveChangesAsync())
                  {
                    return Ok("Usuário atualizado com sucesso");
                  }                    
                }
                else
                {
                    model.Ativo = true;
                    _repo.Add(model);

                    if (await _repo.SaveChangesAsync())
                    {
                        return Ok("Usuário cadastrado com sucesso");
                    }
                }
                return Ok("Erro ao cadastrar ou atualizar usuário");
            }
            catch (Exception ex)
            {
                return Ok("Erro ao cadastrar: " + ex.Message);
            }
        }

        [Route("/api/usuario/login")]
        public async Task<IActionResult> Login(Usuario model)
        {
            try
            {
                var token = await _repo.Login(model.Login, model.Senha);
                if (token != null)
                {
                   return Ok(token);
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
