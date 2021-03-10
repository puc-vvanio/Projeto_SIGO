using Microsoft.AspNetCore.Mvc;
using SIGO.Autenticacao.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SIGO.Autenticacao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //    [Authorize(Roles = Autorizacao.Grupo.ADMIN)]
    public class UsuarioController : ControllerBase
    {
        private readonly IServiceUsuario _usuarioService;

        public UsuarioController(IServiceUsuario usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var usuarios = await _usuarioService.ObterUsuarios();

                if (usuarios != null)
                {
                    return Ok(usuarios);
                }
                else
                {
                    return Ok("Nenhum usuario cadastrada!");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao comunicar com a base de dados!");
            }
        }

        /*
        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
        */
    }
}
