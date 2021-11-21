using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuAlunoDominio;
using MeuAlunoRepo;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeuAluno.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        public MeuAlunoContext _context { get; }

        //public EmpresaController(MeuAlunoContext context)
        //{
        //    _context = context;
        //}
        private readonly IMeuAlunoRepository _repo;
        public EmpresaController(IMeuAlunoRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<EmpresaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           try
            {
                var empresas = await _repo.BuscarTodasEmpresas();
                return Ok(empresas);
            }
            catch (Exception ex)
            {
                return Ok("Erro:" + ex);
            }
        }

        // GET api/<EmpresaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var empresa = _repo.BuscarEmpresaPorId(id);
                return Ok(empresa);
            }
            catch (Exception)
            {
                return Ok("Não encontrada");
            }
        }

        // POST api/<EmpresaController>
        [HttpPost]
        public async Task<IActionResult> Post(Empresa model)
        {
            try
            {
                if(model.Id > 0)
                {
                  model.Pessoas = null;
                  _repo.Update(model);
                } else
                {
                  _repo.Add(model);
                }
                
                if (await _repo.SaveChangesAsync())
                { return Ok("Empresa cadastrada com sucesso"); }
                else
                {
                    return Ok("Erro ao cadastrar");
                }
            }
            catch (Exception ex)
            {

                return Ok("Empresa não cadastrada:" + ex);
            }            
        }

        // PUT api/<EmpresaController>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Empresa> empresa)
        {
            try
            {
                var model = _repo.BuscarEmpresaPorId(id);
                empresa.ApplyTo(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Ok("Empresa alterada");
                }
                else
                {
                    return Ok("Empresa não alterada");
                }
            }
            catch (Exception ex)
            {

                return Ok("erro ao editar:" + ex);
            }
        }


        // DELETE api/<EmpresaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
