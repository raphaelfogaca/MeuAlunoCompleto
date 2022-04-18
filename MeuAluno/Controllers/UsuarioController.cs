using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MeuAlunoDominio;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using MeuAlunoDominio.Interfaces.Repositories;
using MeuAlunoDominio.Entities;
using MeuAlunoDominio.Interfaces.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeuAluno.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioTokenModelo _usuarioTokenModelo;
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService,
                                 IOptions<UsuarioTokenModelo> usuarioTokenModelo)
        {
            _usuarioService = usuarioService;
            _usuarioTokenModelo = usuarioTokenModelo.Value;
        }
        // GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [Route("/api/usuariosPorEmpresa/{empresaid:int}")]
        public async Task<IActionResult> GetByEmpresaId(int empresaId)
        {
            try
            {
                var usuarios = await _usuarioService.BuscarUsuarioPorEmpresaId(empresaId);
                return Ok(usuarios);
            }
            catch
            {
                return Ok("Erro ao buscar financeiro.");
            }
        }
        [Authorize]
        [Route("/api/usuarioPorId/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var usuarios = await _usuarioService.BuscarUsuarioPorId(id);
                return Ok(usuarios);
            }
            catch
            {
                return Ok("Erro ao buscar financeiro.");
            }
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            List<string> erros = null;

            try
            {

                if (_usuarioService.Cadastrar(usuario) != null)
                {
                    return Ok("Usuário cadastrado com sucesso");
                }
                else
                {
                    return Ok("Erro ao cadastrar ou atualizar usuário");

                }

            }
            catch (Exception ex)
            {
                return Ok("Erro ao cadastrar: " + ex.Message);
            }
        }

        [Route("/api/usuario/login")]
        public async Task<IActionResult> Login(Usuario model)
        {
            try
            {
                var token = await _usuarioService.Login(model.Login, model.Senha);

                var expiration = DateTime.UtcNow.AddHours(1);

                if (token != null)
                {
                    var jsonResult = new { jwt = await GerarJwt(Convert.ToInt16(token.Id)), DadosUsuario = token };
                    return Ok(jsonResult);
                }
                else return Ok("Usuario não encontrado");
            }
            catch (Exception e) when (e.Message != "")
            {
                return Ok("Erro ao realizar login, contate o suporte.");
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private async Task<string> GerarJwt(int usuarioId)
        {
            var user = await _usuarioService.BuscarUsuarioPorId(usuarioId);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_usuarioTokenModelo.Secret);
            var dadosAdicionais = new Dictionary<string, string>();
            dadosAdicionais.Add("PessoaNome", "teste");

            var tokenDescriptor = new SecurityTokenDescriptor
            {

                Issuer = _usuarioTokenModelo.Emissor,
                Expires = DateTime.UtcNow.AddHours(_usuarioTokenModelo.ExpirationTime),
                //Expires = DateTime.UtcNow.AddMinutes(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _usuarioTokenModelo.ValidoEm
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}
