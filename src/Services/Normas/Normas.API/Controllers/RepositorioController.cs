﻿using Microsoft.AspNetCore.Mvc;
using SIGO.Normas.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SIGO.Normas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //    [Authorize(Roles = Autorizacao.Grupo.ADMIN)]
    public class RepositorioController : ControllerBase
    {
        private readonly IServiceRepositorio _repositorioService;

        public RepositorioController(IServiceRepositorio repositorioService)
        {
            _repositorioService = repositorioService;
        }

        // GET: api/<RepositorioController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var repositorios = await _repositorioService.ObterRepositorios();

                if (repositorios != null)
                {
                    return Ok(repositorios);
                }
                else
                {
                    return Ok("Nenhum repositorio cadastrado!");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao comunicar com a base de dados!");
            }
        }

        /*
        // GET api/<RepositorioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RepositorioController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RepositorioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RepositorioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
