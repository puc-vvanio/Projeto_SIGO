using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGO.Normas.Domain.DTO.Normas;
using SIGO.Normas.Domain.Entities;
using SIGO.Normas.API.Helpers;
using SIGO.Normas.API.Messages;
using SIGO.Normas.Domain.Interfaces.Services;
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

        private RabbitmqConfig _rabbitConfig;
        private ISendEndpointProvider _sendEndpoint;
        private IPublishEndpoint _publishEndPoint;

        public NormaController(IServiceNorma normaService,
                               IServiceRepositorioExterno repositorioExternoService
                               //IOptions<RabbitmqConfig> rabbitConfig,
                               //ISendEndpointProvider sendEndpoint,
                               //IPublishEndpoint publish
                               )
        {
            _normaService = normaService;
            _repositorioExternoService = repositorioExternoService;

            //_rabbitConfig = rabbitConfig.Value;
            //_sendEndpoint = sendEndpoint;
            //_publishEndPoint = publish;
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

                        NormasExibir contratoExibir = new NormasExibir()
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

                        normaslist.Add(contratoExibir);
                    }

                    return Ok(normaslist);
                    //return Ok(normas);
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
        [HttpGet("verificar")]
        [Authorize(Roles = "Admin,Gerente,Colaborador")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var norma = await _repositorioExternoService.GetNormaInfo(id, "http://162.243.37.75/normas");

                if (norma != null)
                {
                    if (norma.Nome == null)
                        norma.Nome = id;
                    /*
                    await SendMessage(new SubscribeToNormasCommand
                    {
                        Norma = norma.Nome,
                        Status = norma.Status,
                        Data = norma.Data
                    }, "normasService");
                    */
                    return Ok(norma);
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
