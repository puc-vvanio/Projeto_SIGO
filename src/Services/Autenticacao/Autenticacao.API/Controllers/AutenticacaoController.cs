using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sigo.Autenticacao.API.Infrasctructure;
using Sigo.Autenticacao.API.Model;
using System;
using System.Linq;

namespace Sigo.Autenticacao.API.Controllers
{
    [Route("api/v1/[controller]/Login")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly UsuarioContext _context;

        public AutenticacaoController(UsuarioContext context)
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
                            //var normaResposta = JsonConvert.SerializeObject(norma);
                            return Ok(usuario);
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

        private UsuarioContext context()
        {
            throw new NotImplementedException();
        }
    }
}
