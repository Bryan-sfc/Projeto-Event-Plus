using Projeto_Event_Plus.Context;
using Projeto_Event_Plus.Domains;
using Projeto_Event_Plus.Interfaces;

namespace Projeto_Event_Plus.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly Events_Plus_Context _context;

        public EventoRepository(Events_Plus_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, Eventos evento)
        {
            Eventos eventoBuscado = _context.Eventos.Find(id)!;

            if (eventoBuscado != null)
            {
                eventoBuscado.Evento = evento.Evento;
            }
            _context.SaveChanges();    
        }

        public Eventos BuscarPorID(Guid id)
        {
            try
            {
                Eventos eventoBuscado = _context.Eventos.Find(id)!;

                if (eventoBuscado != null)
                {
                    return eventoBuscado;
                }
                return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Eventos novoEvento)
        {
            try
            {
                _context.Eventos.Add(novoEvento);

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
                Eventos eventoBuscado = _context.Eventos.Find(id)!;

                if (eventoBuscado != null)
                {
                    _context.Eventos.Remove(eventoBuscado);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Eventos> Listar()
        {
            List<Eventos> listaDeEventos = _context.Eventos.ToList();
            return listaDeEventos;
        }

        public List<Eventos> ListarPorID(Guid id)
        {
            throw new NotImplementedException();
        }

        public Eventos ProximosEventos()
        {
            throw new NotImplementedException();
        }
    }
}
