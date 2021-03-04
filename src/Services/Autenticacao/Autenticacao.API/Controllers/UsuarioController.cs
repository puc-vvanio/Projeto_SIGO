namespace Sigo.Autenticacao.API.Controllers
{
    /*
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AutenticacaoContext _context;

        public UsuarioController(AutenticacaoContext context)
        {
            _context = context;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var listaDeUsuarios = _context.Usuarios.ToList();

                if (listaDeUsuarios != null)
                {
                    //var resposta = JsonConvert.SerializeObject(listaDeNormas);
                    return Ok(listaDeUsuarios);
                }
                else
                {
                    return Ok("Nenhuma usuario cadastrado!");
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
                    var usuario = _context.Usuarios.FirstOrDefault(m => m.Id == id);

                    if (usuario != null)
                    {
                        //var normaResposta = JsonConvert.SerializeObject(norma);
                        return Ok(usuario);
                    }
                    else
                    {
                        return Ok("Usuario não encontrada!");
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
    }*/
}
