using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGO.ProcessoIndustrial.Domain.DTO.Eventos;
using SIGO.ProcessoIndustrial.Domain.Entities;
using SIGO.ProcessoIndustrial.API.Helpers;
using SIGO.ProcessoIndustrial.API.Messages;
using SIGO.ProcessoIndustrial.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SIGO.ProcessoIndustrial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class EventoController : ControllerBase
    {
        private readonly IServiceEvento _eventoService;
        private readonly IServiceTipoEvento _tipoEventoService;

        private RabbitmqConfig _rabbitConfig;
        private ISendEndpointProvider _sendEndpoint;
        private IPublishEndpoint _publishEndPoint;

        public EventoController(IServiceEvento eventoService,
                                IServiceTipoEvento tipoEventoService
                               //IOptions<RabbitmqConfig> rabbitConfig,
                               //ISendEndpointProvider sendEndpoint,
                               //IPublishEndpoint publish
                               )
        {
            _eventoService = eventoService;
            _tipoEventoService = tipoEventoService;

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
                var eventos = await _eventoService.ObterEventos();

                if (eventos != null)
                {
                    List<EventoExibir> eventoslist = new List<EventoExibir>();

                    foreach (Evento evento in eventos)
                    {
                        var tipoEvento = await _tipoEventoService.ObterTipoEvento(evento.TipoEventoID);

                        EventoExibir eventoExibir = new EventoExibir()
                        {
                            Id = evento.Id,
                            Nome = evento.Nome,
                            Descricao = evento.Descricao,
                            Sistema = evento.Sistema.ToString(),
                            TipoEventoID = evento.TipoEventoID,
                            TipoEvento = tipoEvento.Nome,
                            DataCriacao = evento.DataCriacao,
                            DataAtualizacao = evento.DataAtualizacao
                        };

                        eventoslist.Add(eventoExibir);
                    }

                    return Ok(eventoslist);
                }
                else
                {
                    return Ok("Nenhum evento cadastrado!");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao comunicar com a base de dados!");
            }
        }

        // GET: api/<NormaController>
        [HttpGet]
        [Authorize(Roles = "Admin,Gerente,Colaborador")]
        [Route("TipoEvento/Ultimo/{tipoEventoId}")]
        public async Task<IActionResult> Get_UltimoEvento(int tipoEventoId)
        {
            try
            {
                var evento = await _eventoService.ObterUltimoEvento(tipoEventoId);

                if (evento != null)
                {
                    var tipoEvento = await _tipoEventoService.ObterTipoEvento(evento.TipoEventoID);

                    EventoExibir eventoExibir = new EventoExibir()
                    {
                        Id = evento.Id,
                        Nome = evento.Nome,
                        Descricao = evento.Descricao,
                        Sistema = evento.Sistema.ToString(),
                        TipoEventoID = evento.TipoEventoID,
                        TipoEvento = tipoEvento.Nome,
                        DataCriacao = evento.DataCriacao,
                        DataAtualizacao = evento.DataAtualizacao
                    };

                    return Ok(eventoExibir);
                }
                else
                {
                    return Ok("Nenhum evento encontrado !");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao comunicar com a base de dados!");
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
