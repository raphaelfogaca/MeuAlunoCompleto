using MeuAlunoRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MeuAluno.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IMeuAlunoRepository _repo;
        public PessoaController(IMeuAlunoRepository repo)
        {
            _repo = repo;
        }
        // GET: Pessoa        
        [HttpGet]
        [Route("/api/pessoasPorEmpresa/{empresaid:int}")]
        public async Task<IActionResult> GetByEmpresaId(int empresaId)
        {
            try
            {
                var pessoas = await _repo.BuscarPessoaPorEmpresaId(empresaId);
                return Ok(pessoas);
            }
            catch (Exception ex)
            {
                return Ok("Erro:" + ex);
            }
        }

        // GET: Pessoa/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pessoa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pessoa/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
