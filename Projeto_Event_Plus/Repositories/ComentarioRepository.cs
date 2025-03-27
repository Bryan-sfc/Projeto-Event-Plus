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

        public void Cadastrar(Comentario comentarioEvento)
        {
            try
            {
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
                Comentario comentarioEventoBuscado = _context.Comentario.Find(id)!;

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

        Comentario IComentarioRepository.BuscarPorIdUsuario(Guid idUsuario, Guid idEvento)
        {
            try
            {
                return _context.Comentario
                    .Select(c => new Comentario
                    {
                        ComentarioID = c.ComentarioID,
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        UsuarioID = c.UsuarioID,
                        EventoID = c.EventoID,

                        Usuario = new Usuario
                        {
                            Nome = c.Usuario!.Nome
                        },

                        Eventos = new Eventos
                        {
                            Evento = c.Eventos!.Evento,
                        }

                    }).FirstOrDefault(c => c.UsuarioID == idUsuario && c.EventoID == idEvento)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        List<Comentario> IComentarioRepository.Listar(Guid id)
        {
            try
            {
                return _context.Comentario
                    .Select(c => new Comentario
                    {
                        ComentarioID = c.ComentarioID,
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        UsuarioID = c.UsuarioID,
                        EventoID = c.EventoID,

                        Usuario = new Usuario
                        {
                            Nome = c.Usuario!.Nome
                        },

                        Eventos = new Eventos
                        {
                            Evento = c.Eventos!.Evento,
                        }

                    }).Where(c => c.EventoID == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Comentario> ListarSomenteExibe(Guid id)
        {
            try
            {
                return _context.Comentario
                    .Select(c => new Comentario
                    {
                        ComentarioID = c.ComentarioID,
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        UsuarioID = c.UsuarioID,
                        EventoID = c.EventoID,

                        Usuario = new Usuario
                        {
                            Nome = c.Usuario!.Nome
                        },

                        Eventos = new Eventos
                        {
                            Evento = c.Eventos!.Evento,
                        }

                    }).Where(c => c.Exibe == true && c.EventoID == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
