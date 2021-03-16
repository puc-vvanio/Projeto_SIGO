using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGO.Autenticacao.Domain.Entities;
using SIGO.Autenticacao.Domain.Interfaces.Services;
using SIGO.Autenticacao.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.Autenticacao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]   
    public class UsuarioController : ControllerBase
    {
        private readonly IServiceUsuario _usuarioService;
        private readonly IServiceToken _tokenService;

        public UsuarioController(IServiceUsuario usuarioService, IServiceToken tokenService)
        {
            _usuarioService = usuarioService;
            _tokenService = tokenService;
        }

        // GET api/<UsuarioController>/5
        
        [HttpGet("{id}")]
        [Authorize]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var usuario = await _usuarioService.ObterUsuario(id);

                if (usuario != null)
                {
                    UsuarioExibir usuarioExibir = new UsuarioExibir()
                    {
                        Id = usuario.Id,
                        Nome = usuario.Nome,
                        Email = usuario.Email,
                        Perfil = usuario.Perfil.ToString(),
                        Status = usuario.Status.ToString()
                    };

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

        // GET api/<UsuarioController>
        [HttpGet()]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var usuarios = await _usuarioService.ObterUsuarios();

                if (usuarios != null)
                {
                    List<UsuarioExibir> usuariosList = new List<UsuarioExibir>();

                    foreach (Usuario usuario in usuarios)
                    {
                        UsuarioExibir usuarioExibir = new UsuarioExibir()
                        {
                            Id = usuario.Id,
                            Nome = usuario.Nome,
                            Email = usuario.Email,
                            Perfil = usuario.Perfil.ToString(),
                            Status = usuario.Status.ToString()
                        };

                        usuariosList.Add(usuarioExibir);
                    }
                    
                    return Ok(usuariosList);
                }
                else
                {
                    return Ok("Nenhum usuario não encontrado!");
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
