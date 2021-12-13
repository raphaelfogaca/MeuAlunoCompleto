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
    public class ServicoController : ControllerBase
    {
        private readonly IMeuAlunoRepository _repo;
        public ServicoController(IMeuAlunoRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var servicos = await _repo.BuscarTodosServicos();
                return Ok(servicos);
            }
            catch (Exception ex)
            {

                return Ok("Erro:" + ex);
            }

        }

        // GET api/<ServicoController>/5
        [Route("/api/servico/{id:int}")]
        public IActionResult GetById(int id) //buscar pelo Id
        {
            try
            {
                var servicos = _repo.BuscarServicoPorId(id);
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
                var servicos = _repo.BuscarServicoPorEmpresaId(id);
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
                model.Valor /= 100;
                if(model.ValorMulta != null && model.ValorMulta > 0)
                {
                    model.ValorMulta /= 100;
                }
                if (model.Id > 0)
                {
                    List<ServicoAula> servicoAulas,servicoAulasDoServico = new List<ServicoAula>();
                    servicoAulasDoServico = _repo.BuscarServicoAula(model.Id);
                    servicoAulas = model.ServicosAulas;
                    int index = 0;
                    ServicoAula servico = new ServicoAula();
                    foreach (var x in model.ServicosAulas.ToList())
                    {   //buscar serivocAula e atualizar Id no model
                        if ((servicoAulasDoServico.FirstOrDefault(x => x.AulaId == model.ServicosAulas[index].AulaId)) != null)
                        {
                            model.ServicosAulas[index] = servicoAulasDoServico.FirstOrDefault(x => x.AulaId == model.ServicosAulas[index].AulaId);
                            model.ServicosAulas[index].Id = servicoAulas[index].Id;
                        }
                        index++;
                    }

                    foreach (var servicoaula in servicoAulasDoServico)
                    {                        
                        if ((servicoAulas.FirstOrDefault(x => x.Id == servicoaula.Id)) == null)
                        {                           
                            _repo.Delete(servicoaula);
                            await _repo.SaveChangesAsync();
                        }
                    }

                    _repo.Update(model);
                    if(await _repo.SaveChangesAsync())
                    {
                        return Ok("Serviço atualizado");
                    }
                    else
                    {
                        return Ok("Serviço não atualizado");
                    }
                   
                }
                else
                {
                    _repo.Add(model);
                    if (await _repo.SaveChangesAsync())
                    {
                        return Ok("Serviço cadastrado");
                    }
                    else
                    {
                        return Ok("Serviço não cadastrado");
                    }
                }

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
