using System;
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
    public class MateriaController : ControllerBase
    {
        private readonly IMateriaService _materiaService;
        public MateriaController(IMateriaService materiaService)
        {
            _materiaService = materiaService;
        }

        // GET api/<MateriaController>/5
        [Route("/api/materiaPorEmpresa/{id:int}")]
        public async Task<IActionResult> GetByEmpresaId(int id) //buscar pelo Id da Empresa
        {
            try
            {
                var materias = await _materiaService.BuscarMateriaPorEmpresa(id);
                return Ok(materias);
            }
            catch (Exception ex)
            {

                return Ok("Erro:" + ex);
            }
        }
        // GET api/<MateriaController>/5
        [Route("/api/materia/{id:int}")]
        public async Task<IActionResult> GetById(int id) //buscar pelo Id da materia
        {
            try
            {
                var materias = await _materiaService.BuscarMateriaPorId(id);
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

                var retorno = await _materiaService.Cadastrar(model);
                if (retorno != null)
                {
                    return Ok("Matéria cadastrada");
                }
                else
                {
                    return Ok("Matéria não cadastrada");
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
