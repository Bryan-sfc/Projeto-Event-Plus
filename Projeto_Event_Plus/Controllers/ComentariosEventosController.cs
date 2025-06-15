using Azure;
using Azure.AI.ContentSafety;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.Contexts;
using webapi.event_.Domains;
using webapi.event_.Interfaces;

namespace webapi.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentariosEventosController : ControllerBase
    {
        private readonly IComentariosEventosRepository _comentariosEventosRepository;
        private readonly ContentSafetyClient _contentsafetyclient;
        private readonly Context _contexto;

        public ComentariosEventosController(ContentSafetyClient contentsafetyclient, IComentariosEventosRepository comentariosEventosRepository, Context contexto)
        {
            _comentariosEventosRepository = comentariosEventosRepository;
            _contentsafetyclient = contentsafetyclient;
            _contexto = contexto;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ComentariosEventos comentario)
        {
            try
            {
                Eventos? eventoBuscado = _contexto.Eventos.FirstOrDefault(e => e.IdEvento == comentario.IdEvento);

                if (eventoBuscado == null)
                {
                    return NotFound("Evento não encontrado");
                }

                if (eventoBuscado.DataEvento >= DateTime.UtcNow)
                {
                    return BadRequest("Não é possivel comentar um evento que ainda não aconteceu!");
                }


                if (string.IsNullOrEmpty(comentario.Descricao))
                {
                    return BadRequest("O texto a ser moderado nao pode estar vazio");
                }
                //criar objeto de analise do content safety
                var request = new AnalyzeTextOptions(comentario.Descricao);

                //chamar a API do content safety
                Response<AnalyzeTextResult> response = await _contentsafetyclient.AnalyzeTextAsync(request);

                //verifica se o texto analisado tem alguma severidade
                bool temConteudoIproprio = response.Value.CategoriesAnalysis.Any(c => c.Severity > 0);

                comentario.Exibe = !temConteudoIproprio;

                _comentariosEventosRepository.Cadastrar(comentario);
                return Ok();

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _comentariosEventosRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ListarSomenteExibe")]
        public IActionResult GetExibe(Guid id)
        {
            try
            {
                return Ok(_comentariosEventosRepository.ListarSomenteExibe(id));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok(_comentariosEventosRepository.Listar(id));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("BuscarPorIdUsuario")]
        public IActionResult GetByIdUser(Guid idUsuario, Guid idEvento)
        {
            try
            {
                return Ok(_comentariosEventosRepository.BuscarPorIdUsuario(idUsuario, idEvento));
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}