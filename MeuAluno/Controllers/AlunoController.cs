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
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeuAluno.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _alunoService;
        private readonly IMateriaService _materiaService;
        public AlunoController(IAlunoService alunoService, IMateriaService materiaService)
        {
            _alunoService = alunoService;
            _materiaService = materiaService;
        }
        // GET: api/<AlunoController>

        [Route("/api/alunoPorEmpresa/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetByEmpresaId(int id)
        {
            try
            {
                var alunos = await _alunoService.BuscarAlunosPorEmpresaid(id);
                return Ok(alunos);
            }
            catch (Exception ex)
            {

                return Ok("Erro:" + ex);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var alunos = await _alunoService.BuscarTodosAlunos();
                return Ok(alunos);
            }
            catch (Exception ex)
            {

                return Ok("Erro:" + ex);
            }

        }

        [Route("/api/aluno/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {

            try
            {
                var aluno = await _alunoService.BuscarAlunoPorId(id);
                return Ok(aluno);
            }
            catch (Exception ex)
            {

                return Ok("Erro:" + ex);
            }

        }

        // POST api/<AlunoController>
        [HttpPost]
        public async Task<IActionResult> Post(Aluno model)
        {
            try
            {
                if (model.Id > 0)
                {                   
                    if(await _alunoService.Alterar(model))
                    {
                        return Ok("Aluno atualizado");
                    }
                    else
                    {
                        return Ok("Erro ao atualizar aluno");
                    }
                }
                else
                {                    
                        var retornoCadastro = await _alunoService.Cadastrar(model);
                        if (retornoCadastro != null)
                        {
                            return Ok("Aluno cadastrado");
                        }
                        else
                        {
                            return Ok("Aluno não cadastrado");
                        }                   
                }               
            }
            catch (Exception ex)
            {

                return Ok("Erro ao cadastrar: " + ex);
            }
        }

        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Aluno model)
        {
            try
            {
                
                if (await _alunoService.Alterar(model))
                {
                    return Ok("Aluno alterado");
                }
                else
                {
                    return Ok("Aluno não alterada");
                }
            }
            catch (Exception ex)
            {
                return Ok("erro ao editar:" + ex);
            }
        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
