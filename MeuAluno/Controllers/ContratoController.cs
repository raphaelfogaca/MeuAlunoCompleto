using MeuAlunoDominio.Contrato;
using MeuAlunoDominio.Interfaces;
using MeuAlunoRepo;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeuAluno.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {        
        private readonly IContratoService _contratoService;
        public ContratoController(IContratoService contratoService)
        {
            _contratoService = contratoService;
        }
        // GET: api/<ContratoController>
        [HttpGet]
        [Route("/api/contratoPorEmpresaId/{empresaid:int}")]

        public async Task<IActionResult> GetByEmpresAId(int empresaId)
        {
            var contrato = _contratoService.BuscarContratoPorEmpresaId(empresaId);
            return Ok(contrato);
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
            
            return Ok("text");
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
