using Azure;
using Azure.AI.ContentSafety;
using Microsoft.AspNetCore.Mvc;
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
        private readonly ContentSafetyClient _contentSafetyClient;

        public ComentariosEventosController(ContentSafetyClient contentSafetyClient,IComentariosEventosRepository comentariosEventosRepository)
        {
            _comentariosEventosRepository = comentariosEventosRepository;
            _contentSafetyClient = contentSafetyClient;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ComentariosEventos comentario)
        {
            try
            {
                if (string.IsNullOrEmpty(comentario.Descricao))
                {
                    return BadRequest("O texto a ser moderado não pode estar vazio! Seu Merda!");
                }

                //Criar objeto de análise do content safety
                var request = new AnalyzeTextOptions(comentario.Descricao);

                //Chamar a API do Content Safety
                Response<AnalyzeTextResult> response = await _contentSafetyClient.AnalyzeTextAsync(request);

                //Verificar se o texto analisado sem alguma severidade
                bool temConteudoImproprio = response.Value.CategoriesAnalysis.Any(c => c.Severity > 0);

                //se o conteúdo for impróprio, não exibe, caso contrário, exibe
                comentario.Exibe = !temConteudoImproprio;

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
