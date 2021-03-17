using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGO.Consultorias.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SIGO.Consultorias.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        private readonly IServiceContrato _contratoService;

        public ContratoController(IServiceContrato contratoService)
        {
            _contratoService = contratoService;
        }

        // GET: api/<ContratoController>
        [HttpGet]
        [Authorize(Roles = "Admin,Gerente")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var contratos = await _contratoService.ObterContratos();

                if (contratos != null)
                {
                    return Ok(contratos);
                }
                else
                {
                    return Ok("Nenhum contrato cadastrada!");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao comunicar com a base de dados!");
            }
        }

        /*
        // GET api/<ContratoController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Gerente")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ContratoController>
        [HttpPost]
        [Authorize(Roles = "Admin,Gerente")]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ContratoController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Gerente")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ContratoController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Gerente")]
        public void Delete(int id)
        {
        }
        */
    }
}
