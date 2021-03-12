using AutoMapper;
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
        private readonly IMapper _mapper;

        public UsuarioController(IServiceUsuario usuarioService, IServiceToken tokenService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        // GET: api/<UsuarioController>
        [AllowAnonymous]
        [HttpPost("autenticar")]
        public IActionResult Autenticar([FromBody] UsuarioAutenticar usuarioAutenticar)
        {
            try
            {
                var usuario = _usuarioService.Autenticar(usuarioAutenticar.Email, usuarioAutenticar.Senha);

                // usuario não autenticado
                if (usuarioAutenticar == null)
                    return BadRequest("Email e/ou Senha não está(ão) correto(s)");

                // TODO: no retorno, deve trazer os dados de autorização do usuário
                var usuarioAutenticado = _mapper.Map<Usuario>(usuario);
                var token = _tokenService.GerarToken(usuarioAutenticado);

                TokenDTO tokenDTO = new TokenDTO()
                {
                    Usuario = usuarioAutenticado.Email,
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
                    var usuarioExibir = _mapper.Map<UsuarioExibir>(usuario); 
                    return Ok(usuarioExibir);
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
