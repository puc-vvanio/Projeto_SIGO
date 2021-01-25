using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sigo.Autenticacao.API.Infrasctructure;
using Sigo.Autenticacao.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;

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

                            var acessos = _context.Acessos.FirstOrDefault(a => a.Id_Usuario == usuario.Id);

                            if (acessos != null)
                            {
                                Autenticado autenticado = new Autenticado
                                {
                                    Email = usuario.Email,
                                    Nome = usuario.Nome,
                                    Token = "Token",
                                    AcessosSistemas = new List<AcessosSistemas>
                                    {
                                        new AcessosSistemas{ Sistema = acessos.Sistema, Regra = acessos.Regra},
                                        new AcessosSistemas{ Sistema = acessos.Sistema, Regra = acessos.Regra}
                                    }
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
