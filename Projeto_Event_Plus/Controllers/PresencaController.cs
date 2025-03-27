using Microsoft.AspNetCore.Mvc;
using Projeto_Event_Plus.Domains;
using Projeto_Event_Plus.Interfaces;

namespace Projeto_Event_Plus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PresencaController : Controller
    {
        private readonly IPresencaEventosRepository _presencaEventosRepository;

        public PresencaController(IPresencaEventosRepository presencaEventosRepository)
        {
            _presencaEventosRepository = presencaEventosRepository;
        }

        /// <summary>
        /// Endpoint  para Increver-se Num Evento no Banco de Dados
        /// </summary>
        /// <param name="evento"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Presenca evento)
        {
            try
            {
                _presencaEventosRepository.Inscrever(evento);

                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint  para Listar Eventos Incritos no Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Presenca> listaDePresenca = _presencaEventosRepository.Listar();

                return Ok(listaDePresenca);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint  para Atualizar Presença Incrita no Banco de Dados
        /// </summary>
        /// <param name="presencaEvento"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Presenca presencaEvento)
        {
            try
            {
                _presencaEventosRepository.Atualizar(id, presencaEvento);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint  para BuscarPresencaPorId no Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Presenca presencaBuscada = _presencaEventosRepository.BuscarPorID(id);

                return Ok(presencaBuscada);
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Endpoint  para Listar as Presencas de um Usuário no Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("ListarMinhasPresencas/{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                List<Presenca> listarMinhasPresencas = _presencaEventosRepository.ListarMinhas(id);

                return Ok(listarMinhasPresencas);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }
    }
}
