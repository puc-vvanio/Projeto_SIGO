using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGO.Normas.Domain.DTO.Normas;
using SIGO.Normas.Domain.Entities;
using SIGO.Normas.Domain.Interfaces.Services;
using SIGO.Normas.Infrastructure.CrossCutting.EventBus.Senders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SIGO.Normas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class NormaController : ControllerBase
    {
        private readonly IServiceNorma _normaService;
        private readonly IServiceRepositorioExterno _repositorioExternoService;
        private readonly INormaUpdateSender _normaUpdateSender;

        public NormaController(IServiceNorma normaService,
                               IServiceRepositorioExterno repositorioExternoService,
                               INormaUpdateSender normaUpdateSender
                               )
        {
            _normaService = normaService;
            _repositorioExternoService = repositorioExternoService;
            _normaUpdateSender = normaUpdateSender;
        }

        // GET: api/<NormaController>
        [HttpGet]
        [Authorize(Roles = "Admin,Gerente,Colaborador")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var normas = await _normaService.ObterNormas();

                if (normas != null)
                {
                    List<NormasExibir> normaslist = new List<NormasExibir>();

                    foreach (Norma normaitem in normas)
                    {

                        NormasExibir norma = new NormasExibir()
                        {
                            Id = normaitem.Id,
                            Nome = normaitem.Nome,
                            Descricao = normaitem.Descricao,
                            NomeArquivo = normaitem.NomeArquivo,
                            Tipo = normaitem.Tipo.ToString(),
                            Status = normaitem.Status.ToString(),
                            DataCriacao = normaitem.DataCriacao,
                            DataAtualizacao = normaitem.DataAtualizacao
                        };

                        normaslist.Add(norma);
                    }

                    return Ok(normaslist);
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

        // GET: api/<NormaController>
        [HttpGet]
        [Route("{normaId}")]
        [Authorize(Roles = "Admin,Gerente,Colaborador")]
        public async Task<IActionResult> Get(int normaId)
        {
            try
            {
                var norma = await _normaService.ObterNorma(normaId);

                if (norma != null)
                {
                    NormasExibir normaExibir = new NormasExibir()
                    {
                        Id = norma.Id,
                        Nome = norma.Nome,
                        Descricao = norma.Descricao,
                        NomeArquivo = norma.NomeArquivo,
                        Tipo = norma.Tipo.ToString(),
                        Status = norma.Status.ToString(),
                        DataCriacao = norma.DataCriacao,
                        DataAtualizacao = norma.DataAtualizacao
                    };

                    return Ok(normaExibir);
                }
                else
                {
                    return Ok("Norma não encontrada!");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao comunicar com a base de dados!");
            }
        }

        // GET: api/<NormaController>
        [HttpGet("verificar/{norma}")]
        [Authorize(Roles = "Admin,Gerente,Colaborador")]
        public async Task<IActionResult> Get(string norma)
        {
            try
            {
                var normaVerificada = await _repositorioExternoService.GetNormaInfo(norma, "http://162.243.37.75/normas");

                if (normaVerificada != null)
                {
                    Console.WriteLine($"Nome da Norma: {normaVerificada.Nome}");

                    if (normaVerificada.Nome == null)
                        normaVerificada.Nome = norma;

                    var TipoEventoID = 0;
                    if (normaVerificada.Status == "Atualizada")
                        TipoEventoID = 1;
                    if (normaVerificada.Status == "Cancelada")
                        TipoEventoID = 2;

                    NormaEvento normaEvento = new NormaEvento()
                    {
                        Nome = string.Concat("Norma ", normaVerificada.Status),
                        Descricao = string.Concat("Norma: ", normaVerificada.Nome, " - Status: ", normaVerificada.Status, " - Data: ", normaVerificada.Data),
                        Sistema = 1,
                        TipoEventoID = TipoEventoID

                    };

                    _normaUpdateSender.EnviarNormaAtualizada(normaEvento);

                    return Ok(normaVerificada);
                }
                else
                {
                    return Ok("Nenhuma informação encontrada!");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao comunicar com o repositório externo!");
            }
        }

        /*
        public async Task SendMessage<T>(T message, string targetEndPoint)
        {
            var endpoint = $"rabbitmq://{_rabbitConfig.Host}:{_rabbitConfig.Port}/{targetEndPoint}?durable={_rabbitConfig.DurableQueue}";
            var finalEndpoint = await _sendEndpoint.GetSendEndpoint(new Uri(endpoint));
            await finalEndpoint.Send(message);
        }
        */

        /*
        // GET api/<NormaController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Gerente,Colaborador")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NormaController>
        [HttpPost]
        [Authorize(Roles = "Admin,Gerente,Colaborador")]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<NormaController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Gerente,Colaborador")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NormaController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Gerente,Colaborador")]
        public void Delete(int id)
        {
        }
        */
    }
}
