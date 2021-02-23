using Autenticacao.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using Sigo.Autenticacao.API.Infrasctructure;
using Sigo.Autenticacao.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Sigo.Autenticacao.API.Controllers
{
    [Route("api/v1/[controller]/Login")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly AutenticacaoContext _context;

        public AutenticacaoController(AutenticacaoContext context)
        {
            _context = context;
        }

        // Usuario autenticado
        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public IActionResult Authenticated()
        {
            try
            {
                try
                {
                    var claimsIdentity = User.Identity as ClaimsIdentity;
                    var email = claimsIdentity.FindFirst(ClaimTypes.Email).Value;
                    var usuario = _context.Usuarios.FirstOrDefault(m => m.Email == email);

                    if (usuario != null)
                    {
                        var acesso = _context.Acessos.Where(a => a.Id_Usuario == usuario.Id);

                        if (acesso != null)
                        {
                            List<AcessosSistemas> acessosSistemas = new List<AcessosSistemas>();

                            foreach (var item in acesso.ToList())
                            {

                                AcessosSistemas auxacesso = new AcessosSistemas();
                                auxacesso.Sistema = item.Sistema;
                                auxacesso.Regra = item.Regra;
                                acessosSistemas.Add(auxacesso);
                            }                          

                            Autenticado autenticado = new Autenticado
                            {
                                Email = usuario.Email,
                                Nome = usuario.Nome,
                                AcessosSistemas = acessosSistemas
                            };
                            
                            return Ok(autenticado);
                        }
                        else
                            return Ok("Usuario sem acesso a Sistema!");
                    }
                    else
                    {
                        return Ok("Usuario/Senha não encontrada!");
                    }                    
                }
                catch (Exception)
                {
                    return StatusCode(500, "Erro ao comunicar com a base de dados!");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao comunicar com a base de dados!");
            }
        }
       
        // Post: api/<ValuesController>
        [HttpPost]
        public IActionResult Authenticate([FromBody] DadosAcesso model)
        {

            try
            {
                try
                {

                    if (model.Email != null && model.Senha != null)
                    {
                        var usuario = _context.Usuarios.FirstOrDefault(m => m.Email == model.Email && m.Senha == model.Senha);

                        if (usuario != null)
                        {
                            var acesso = _context.Acessos.Where(a => a.Id_Usuario == usuario.Id);

                            if (acesso != null)
                            {
                                List<AcessosSistemas> acessosSistemas = new List<AcessosSistemas>();
                                
                                foreach (var item in acesso.ToList())
                                {
                                  
                                    AcessosSistemas auxacesso = new AcessosSistemas();
                                    auxacesso.Sistema =  item.Sistema;
                                    auxacesso.Regra = item.Regra;
                                    acessosSistemas.Add(auxacesso);
                                }

                                // Gera o Token
                                Usuario usuarioToken = new Usuario
                                {
                                    Email = usuario.Email,
                                    Nome = usuario.Nome
                                };

                                var token = TokenService.GenerateToken(usuarioToken);

                                Autenticado autenticado = new Autenticado
                                {
                                    Email = usuario.Email,
                                    Nome = usuario.Nome,
                                    Token = token,
                                    AcessosSistemas = acessosSistemas
                                };
                                //var normaResposta = JsonConvert.SerializeObject(norma);
                                return Ok(autenticado);                               
                            }
                            else
                                return Ok("Usuario sem acesso a Sistema!");
                        }
                        else
                        {
                            return Ok("Usuario/Senha não encontrada!");
                        }
                    }
                    else
                    {
                        return BadRequest("Usuario/Senha inválido! Tente novamente.");
                    }
                }
                catch (Exception)
                {
                    return StatusCode(500, "Erro ao comunicar com a base de dados!");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao comunicar com a base de dados!");
            }
        }

        private AutenticacaoContext context()
        {
            throw new NotImplementedException();
        }
    }
}
