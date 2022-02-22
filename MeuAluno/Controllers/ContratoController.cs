using MeuAlunoDominio.Contrato;
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

        public MeuAlunoContext _context { get; }

        private readonly IMeuAlunoRepository _repo;
        public ContratoController(IMeuAlunoRepository repo)
        {
            _repo = repo;
        }
        // GET: api/<ContratoController>
        [HttpGet]
        [Route("/api/contratoPorEmpresaId/{empresaid:int}")]

        public async Task<IActionResult> GetByEmpresAId(int empresaId)
        {
            var contrato = await _repo.BuscarContratoPorEmpresaId(empresaId);
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
            var contratoDaEmpresa = await _repo.BuscarContratoPorEmpresaId(contrato.Contrato.EmpresaId.GetValueOrDefault());
            var contratoExistente = (contratoDaEmpresa.Contrato.EmpresaId == contrato.Contrato.EmpresaId);

            if (contrato.Contrato.Id == 0)
            {
                _repo.Add(contrato.Contrato);
                await _repo.SaveChangesAsync();                
            }

            foreach (var clausula in contrato.Clausulas)
            {
                if (contratoExistente)
                {
                    _repo.Update(clausula);
                }
                else
                {
                    clausula.ContratoId = contrato.Contrato.Id;
                    clausula.Id = 0;
                    _repo.Add(clausula);
                }
            }

            await _repo.SaveChangesAsync();
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
