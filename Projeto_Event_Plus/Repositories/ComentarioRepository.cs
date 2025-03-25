using Projeto_Event_Plus.Context;
using Projeto_Event_Plus.Domains;
using Projeto_Event_Plus.Interfaces;

namespace Projeto_Event_Plus.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly Events_Plus_Context _context;

        public ComentarioRepository(Events_Plus_Context context)
        {
            _context = context;
        }

        public void Cadastrar(ComentarioEvento comentarioEvento)
        {
            try
            {
                comentarioEvento.ComentarioID= Guid.NewGuid();

                _context.Comentario.Add(comentarioEvento);

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
                ComentarioEvento comentarioEventoBuscado = _context.Comentario.Find(id)!;

                if (comentarioEventoBuscado != null)
                {
                    _context.Comentario.Remove(comentarioEventoBuscado);
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
