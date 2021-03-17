﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGO.Consultorias.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SIGO.Consultorias.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //    [Authorize(Roles = Autorizacao.Grupo.ADMIN)]
    public class ConsultoriaController : ControllerBase
    {
        private readonly IServiceConsultoria _consultoriaService;

        public ConsultoriaController(IServiceConsultoria consultoriaService)
        {
            _consultoriaService = consultoriaService;
        }

        // GET: api/<ConsultoriaController>
        [HttpGet]
        [Authorize(Roles = "Gerente")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var consultorias = await _consultoriaService.ObterConsultorias();

                if (consultorias != null)
                {
                    return Ok(consultorias);
                }
                else
                {
                    return Ok("Nenhuma consultoria cadastrada!");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao comunicar com a base de dados!");
            }
        }

        /*
        // GET api/<ConsultoriaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ConsultoriaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ConsultoriaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ConsultoriaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
