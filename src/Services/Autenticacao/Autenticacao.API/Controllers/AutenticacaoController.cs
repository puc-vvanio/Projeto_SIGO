using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGO.Autenticacao.Domain.DTO.Users;
using SIGO.Autenticacao.Domain.Interfaces.Services;
using SIGO.Autenticacao.Domain.Models.Users;
using System;
using System.Threading.Tasks;

namespace SIGO.Autenticacao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IServiceUsuario _usuarioService;
        private readonly IServiceToken _tokenService;

        public AutenticacaoController(IServiceUsuario usuarioService, IServiceToken tokenService)
        {
            _usuarioService = usuarioService;
            _tokenService = tokenService;
        }

        // GET: api/<UsuarioController>
        [AllowAnonymous]
        [HttpPost("autenticar")]
        public async Task<IActionResult> Autenticar([FromBody] UsuarioAutenticar usuarioAutenticar)
        {
            try
            {
                if (string.IsNullOrEmpty(usuarioAutenticar.Email) || string.IsNullOrEmpty(usuarioAutenticar.Senha))
                    return BadRequest("Email e/ou Senha não está(ão) correto(s)");

                var usuarioAutenticado = await _usuarioService.Autenticar(usuarioAutenticar.Email, usuarioAutenticar.Senha);

                // usuario não autenticado
                if (usuarioAutenticado == null)
                    return BadRequest("Email e/ou Senha não está(ão) correto(s)");

                var token = _tokenService.GerarToken(usuarioAutenticado);

                TokenDTO tokenDTO = new TokenDTO()
                {
                    Usuario = usuarioAutenticado.Email,
                    Perfil = usuarioAutenticado.Perfil.ToString(),
                    Token = token
                };

                return Ok(tokenDTO);

            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao comunicar com a base de dados!");
            }
        }
    }
}
