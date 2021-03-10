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
    public class AutenticacaoController : ControllerBase
    {
        private readonly IServiceAutenticacao _autenticacaoService;

        public AutenticacaoController(IServiceAutenticacao autenticacaoService)
        {
            _autenticacaoService = autenticacaoService;
        }

        // GET: api/<AutenticacaoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var autenticacao = await _autenticacaoService.ObterAutenticacao();

                if (autenticacao != null)
                {
                    return Ok(autenticacao);
                }
                else
                {
                    return Ok("Nenhuma autenticacao cadastrada!");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao comunicar com a base de dados!");
            }
        }

        /*
        // GET api/<AutenticacaoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AutenticacaoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AutenticacaoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AutenticacaoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
