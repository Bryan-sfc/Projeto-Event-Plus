using Projeto_Event_Plus.Context;
using Projeto_Event_Plus.Domains;
using Projeto_Event_Plus.Interfaces;

namespace Projeto_Event_Plus.Repositories
{
    public class ComentarioEventoRepository : IComentarioRepository
    {
        private readonly Events_Plus_Context _context;

        public ComentarioEventoRepository(Events_Plus_Context context)
        {
            _context = context;
        }

        public void Cadastrar(ComentarioEvento comentario)
        {
            try
            {
                _context.Comentario.Add(comentario);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                ComentarioEvento comentarioBuscado = _context.Comentario.Find(id)!;

                if (comentarioBuscado != null)
                {
                    _context.Comentario.Remove(comentarioBuscado);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        ComentarioEvento IComentarioRepository.BuscarPorIdUsuario(Guid idUsuario, Guid idEvento)
        {
            try
            {
                ComentarioEvento comentarioBuscado = _context.Comentario.Find(idUsuario)!;

                if (comentarioBuscado != null)
                {
                    return comentarioBuscado;
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        List<ComentarioEvento> IComentarioRepository.Listar(Guid id)
        {
            List<ComentarioEvento> listaDeComentarioa = _context.Comentario.ToList();
            return listaDeComentarioa;
        }
    }
}
