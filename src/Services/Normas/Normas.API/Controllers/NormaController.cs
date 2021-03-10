using Microsoft.AspNetCore.Mvc;
using SIGO.Normas.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SIGO.Normas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //    [Authorize(Roles = Autorizacao.Grupo.ADMIN)]
    public class NormaController : ControllerBase
    {
        private readonly IServiceNorma _normaService;

        public NormaController(IServiceNorma normaService)
        {
            _normaService = normaService;
        }

        // GET: api/<NormaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var normas = await _normaService.ObterNormas();

                if (normas != null)
                {
                    return Ok(normas);
                }
                else
                {
                    return Ok("Nenhuma norma cadastrada!");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao comunicar com a base de dados!");
            }
        }

        /*
        // GET api/<NormaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NormaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<NormaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NormaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
