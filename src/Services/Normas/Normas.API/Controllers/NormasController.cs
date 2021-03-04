using Microsoft.AspNetCore.Mvc;
using Sigo.Normas.API.Infrasctructure;
using System;
using System.Linq;

namespace Sigo.Normas.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class NormasController : ControllerBase
    {
        private readonly NormaContext _context;

        public NormasController(NormaContext context)
        {
            _context = context;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var listaDeNormas = _context.Norma.ToList();

                if (listaDeNormas != null)
                {
                    //var resposta = JsonConvert.SerializeObject(listaDeNormas);
                    return Ok(listaDeNormas);
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

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id > 0)
                {
                    var norma = _context.Norma.FirstOrDefault(m => m.Id == id); ;

                    if (norma != null)
                    {
                        //var normaResposta = JsonConvert.SerializeObject(norma);
                        return Ok(norma);
                    }
                    else
                    {
                        return Ok("Norma não encontrada!");
                    }
                }
                else
                {
                    return BadRequest("ID inválido! Tente novamente.");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao comunicar com a base de dados!");
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
