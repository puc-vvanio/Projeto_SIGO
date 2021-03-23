using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGO.Consultorias.Domain.Interfaces.Services;
using SIGO.Consultorias.Domain.DTO.Contratos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SIGO.Consultorias.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SIGO.Consultorias.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        private readonly IServiceContrato _contratoService;
         private readonly IServiceConsultoria _consultoriaService;

        public ContratoController(IServiceContrato contratoService, IServiceConsultoria consultoriaService)
        {
            _contratoService = contratoService;
            _consultoriaService = consultoriaService;
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

                    List<ContratoExibir> contratolist = new List<ContratoExibir>();

                    foreach (Contrato contrato in contratos)
                    {

                        var consultorianome = await _consultoriaService.ObterConsultoria(contrato.ConsultoriaID);
                        var nomeconsultorias = "";
                        if (consultorianome != null)
                            nomeconsultorias = consultorianome.Nome;

                        ContratoExibir contratoExibir = new ContratoExibir()
                        {
                            Id = contrato.Id,
                            Nome = contrato.Nome,
                            Descricao = contrato.Descricao,
                            Tipo = contrato.Tipo.ToString(),
                            ConsultoriaID = contrato.ConsultoriaID,
                            Consultoria = nomeconsultorias,
                            dataCriacao = contrato.DataCriacao,
                            dataAtualizacao = contrato.DataAtualizacao
                        };

                        contratolist.Add(contratoExibir);
                    }

                    //return Ok(contratos);
                    return Ok(contratolist);
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

        // GET api/<ContratoController>/Resumo
        [HttpGet()]
        [Route("Resume")]
        [Authorize(Roles = "Admin,Gerente")]
        public async Task<IActionResult> ResumeAsync()
        {
            try
            {
                var contratos = await _contratoService.ObterContratos();

                if (contratos != null)
                {

                    List<ContratoExibir> contratolist = new List<ContratoExibir>();
                    var vigentes = 0;
                    var vencer = 0;
                    var vencidos = 0;


                    foreach (Contrato contrato in contratos)
                    {
                        if (contrato.DataAtualizacao is null)
                            vigentes++;
                        else {
                            if (contrato.DataAtualizacao < DateTime.Now)
                                vencidos++;
                            else
                            {
                                if (contrato.DataAtualizacao < DateTime.Now.AddDays(-30))
                                    vencer++;
                                else
                                    vigentes++;
                            }
                        }
                    }

                    string vigentesvalor = "Nenhun contrato";
                    string vencidosvalor = "Nenhun contrato";
                    string vencervalor = "Nenhun contrato";
                    if (vigentes > 0)
                        vigentesvalor = vigentes.ToString() + "contrato(s)";
                    if (vencidos > 0)
                        vencidosvalor = vigentes.ToString() + "contrato(s)";
                    if (vencidos > 0)
                        vencervalor = vigentes.ToString() + "contrato(s)";


                    ContratoResumo contratoResumo = new ContratoResumo()
                    {
                            VigentesTitulo    = vigentesvalor + " vigente(s)",
                            VigentesDescricao = vigentesvalor + " tem vencimento igual ou superior a três meses",
                            VencerTitulo      = vencidosvalor + " próximo(s) do vencimento",
                            VencerDescricao   = vencidosvalor + " que vencerá(ão) nos próximos 30 dias",
                            VencidosTitulo    = vencervalor   + " vencido(s)",
                            VencidosDescricao = vencervalor   + " está(ão) vencido"
                    };
                    return Ok(contratoResumo);
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
