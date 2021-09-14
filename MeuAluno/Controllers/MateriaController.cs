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
    public class MateriaController : ControllerBase
    {
        private readonly IMeuAlunoRepository _repo;

        public MateriaController(IMeuAlunoRepository repo)
        {
            _repo = repo;
        }

        // GET api/<MateriaController>/5
        [Route("/api/materiaPorEmpresa/{id:int}")]
        public IActionResult GetByEmpresaId(int id) //buscar pelo Id da Empresa
        {
            try
            {
                var materias = _repo.BuscarMateriaPorEmpresa(id);
                return Ok(materias);
            }
            catch (Exception ex)
            {

                return Ok("Erro:" + ex);
            }
        }
        // GET api/<MateriaController>/5
        [Route("/api/materia/{id:int}")]
        public IActionResult GetById(int id) //buscar pelo Id da materia
        {
            try
            {
                var materias = _repo.BuscarMateriaPorId(id);
                return Ok(materias);
            }
            catch (Exception ex)
            {

                return Ok("Erro:" + ex);
            }
        }

        // POST api/<MateriaController>
        [HttpPost]
        public async Task<IActionResult> Post(Materia model)
        {
            try
            {
                if(model.Id > 0)
                {
                    _repo.Update(model);
                    if (await _repo.SaveChangesAsync())
                    {
                        return Ok("Matéria atualizada");
                    }
                    else
                    {
                        return Ok("Matéria não atualizada");
                    }
                } else
                {
                    _repo.Add(model);
                    if (await _repo.SaveChangesAsync())
                    {
                        return Ok("Matéria cadastrada");
                    }
                    else
                    {
                        return Ok("Matéria não cadastrada");
                    }
                }
               
            }
            catch (Exception ex)
            {

                return Ok("Erro ao cadastrar matéria:" + ex);
            }
        }

        // PUT api/<MateriaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MateriaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
