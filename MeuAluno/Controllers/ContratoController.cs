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
            ContratoModelo contratoDaEmpresa = null;

            foreach (var clausula in contrato.Clausulas)
            {
                _repo.Update(clausula);
                _repo.SaveChangesAsync().Wait();
            }

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

        public async void CadastrarContratoPadrao(int empresaId)
        {
            var contratoModelo = _repo.BuscarContratoModelo();
            _repo.Add(contratoModelo.Contrato);
            await _repo.SaveChangesAsync();
            var contratoEmpresa = _repo.BuscarContratoPorEmpresaId(empresaId);
            foreach (var item in contratoModelo.Clausulas)
            {
                item.ContratoId = contratoEmpresa.Id;
                _repo.Add(item);
                await _repo.SaveChangesAsync();
            }
        }
    }
}
