using MeuAlunoDominio.DTO;
using MeuAlunoDominio.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeuAluno.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {        
        private readonly IContratoService _contratoService;
        private readonly IContratoAlunoService _contratoAlunoService;
        public ContratoController(IContratoService contratoService,
            IContratoAlunoService contratoAlunoService)
        {
            _contratoService = contratoService;
            _contratoAlunoService = contratoAlunoService;
        }
        // GET: api/<ContratoController>
        [HttpGet]
        [Route("/api/contratoPorEmpresaId/{empresaid:int}")]

        public async Task<IActionResult> GetByEmpresAId(int empresaId)
        {
            var contrato = await _contratoService.BuscarContratoPorEmpresaId(empresaId);
            return Ok(contrato);
        }

        [HttpGet]
        [Route("/api/gerarContratoPDF/{empresaid:int},{alunoid:int}")]

        public async Task<IActionResult> GerarContratoPDF(int empresaId, int alunoId)
        {
            await _contratoAlunoService.GerarContratoPDF(empresaId, alunoId);
            return Ok("");
        }

        // GET api/<ContratoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // POST api/<ContratoController>
        [HttpPost]
        public async Task<IActionResult> Post(ContratoModelo contrato)
        {
            try
            {
                await _contratoService.AlterarContrato(contrato);
                return Ok("Contrato atualizado");
            }
            catch (Exception)
            {
                return BadRequest("Erro ao atualizar contrato");
            }          
            
        }

        // PUT api/<ContratoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ContratoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
       
    }
}
