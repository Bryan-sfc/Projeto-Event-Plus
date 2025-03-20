using Microsoft.AspNetCore.Mvc;
using Projeto_Event_Plus.Interfaces;

namespace Projeto_Event_Plus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentarioEventoController : Controller
    {
        private readonly IComentarioRepository _comentarioRepository;

        public ComentarioEventoRepository(IComentarioRepository comentarioRepository)
        {
            _comentarioRepository = comentarioRepository;
        }

        /// <summary>
        /// Endpoint  para Cadastrar um Novo Comentário no Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]


        public IActionResult Index()
        {
            return View();
        }
    }
}
