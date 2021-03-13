using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGO.Autenticacao.Domain.DTO.Users;
using SIGO.Autenticacao.Domain.Entities;
using SIGO.Autenticacao.Domain.Interfaces.Services;
using SIGO.Autenticacao.Domain.Models.Users;
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
        private readonly IServiceToken _tokenService;

        public UsuarioController(IServiceUsuario usuarioService, IServiceToken tokenService)
        {
            _usuarioService = usuarioService;
            _tokenService = tokenService;
        }

        // GET: api/<UsuarioController>
        [AllowAnonymous]
        [HttpPost("autenticar")]
        public async Task<IActionResult> AutenticarAsync([FromBody] UsuarioAutenticar usuarioAutenticar)
        {
            try
            {
                if (string.IsNullOrEmpty(usuarioAutenticar.Email) || string.IsNullOrEmpty(usuarioAutenticar.Senha))
                {
                    return BadRequest("Email e/ou Senha não está(ão) correto(s)");
                }
                
                var usuarioAutenticado = await _usuarioService.Autenticar(usuarioAutenticar.Email, usuarioAutenticar.Senha);

                // usuario não autenticado
                if (usuarioAutenticado == null)
                {
                    return BadRequest("Email e/ou Senha não está(ão) correto(s)");
                }

                // TODO: no retorno, deve trazer os dados de autorização do usuário
                var token = _tokenService.GerarToken(usuarioAutenticado);

                TokenDTO tokenDTO = new TokenDTO()
                {
                    Usuario = usuarioAutenticar.Email,
                    Token = token
                };

                return Ok(tokenDTO);

            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao comunicar com a base de dados!");
            }
        }

        
        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var usuario = await _usuarioService.ObterUsuario(id);

                if (usuario != null)
                {
                    return Ok(usuario);
                }
                else
                {
                    return Ok("Usuario não encontrado!");
                }

            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao comunicar com a base de dados!");
            }
        }

        /*
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
