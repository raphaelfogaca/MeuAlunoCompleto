using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuAlunoDominio;
using MeuAlunoDominio.Entities;
using MeuAlunoDominio.Interfaces.Repositories;
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
        private readonly IMeuAlunoRepository _repo;

        public MeuAlunoContext _context { get; }
        public AlunoController(IMeuAlunoRepository repo)
        {
            _repo = repo;
        }
        // GET: api/<AlunoController>

        [Route("/api/alunoPorEmpresa/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetByEmpresaId(int id)
        {
            try
            {
                var alunos = await _repo.BuscarAlunosPorEmpresaid(id);
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
                    var alunos = await _repo.BuscarTodosAlunos();
                    return Ok(alunos);
                }
                catch (Exception ex)
                {

                    return Ok("Erro:" + ex);
                }
           
        }
      
        [Route("/api/aluno/{id:int}")]
        public IActionResult GetById(int id)
        {
            
                try
                {
                    var aluno = _repo.BuscarAlunoPorId(id);
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
                List<string> erros = null;
                if (model.Id > 0)
                {                    
                    List<MateriaAluno> materias,novasMaterias = new List<MateriaAluno>();
                    materias = _repo.BuscarMateriaPorAluno(model.Id);
                    novasMaterias = model.MateriaAlunos;
                    MateriaAluno checkMateria = new MateriaAluno();
                    int index = 0;
                    //pegar dados completos do MateriaAluno e colocar no model para que nao seja inserido um novo
                    foreach (var x in model.MateriaAlunos.ToList())
                    {                           
                            if((materias.FirstOrDefault(x => x.MateriaId == model.MateriaAlunos[index].MateriaId)) != null)
                            {
                            model.MateriaAlunos[index] = materias.FirstOrDefault(e => e.MateriaId == model.MateriaAlunos[index].MateriaId);
                            }
                        index++;
                    }

                    //verificar se materia do banco existe na materia do request e deletando se não existir
                    foreach (var i in materias.ToList())
                    {                       
                            checkMateria = novasMaterias.FirstOrDefault(x => x.MateriaId == i.MateriaId);
                            if (checkMateria == null)
                        {
                            if (i.MateriaId > 0)
                            {
                                _repo.Delete(i);
                                await _repo.SaveChangesAsync();
                            }
                        } 
                    }
                    _repo.Update(model);
                } else
                {
                    try
                    {
                        _repo.Add(model);
                    }
                    catch (Exception ex)
                    {
                        return Ok("Erro ao cadastrar: "+ex);
                    }
                }
                                
                if (await _repo.SaveChangesAsync())
                {
                    return Ok("Aluno cadastrado");
                }
                else
                {
                    return Ok("Aluno não cadastrado");
                }
            }
            catch (Exception ex)
            {

                return Ok("Erro ao cadastrar: "+ex);
            }
        }

        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Aluno model)
        {
            try
            {
                _repo.Update(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Ok("Aluno alterado");
                } else
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
