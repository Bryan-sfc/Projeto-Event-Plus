using Microsoft.EntityFrameworkCore;
using Projeto_Event_Plus.Context;
using Projeto_Event_Plus.Domains;
using Projeto_Event_Plus.Interfaces;

namespace Projeto_Event_Plus.Repositories
{
    public class TipoEventoRepository : ITipoEvento
    {
        private readonly Events_Plus_Context _context;

        public TipoEventoRepository(Events_Plus_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, TipoEvento tipoEvento)
        {
            try
            {
                TipoEvento eventoBuscado = _context.TipoEvento.Find(id)!;

                if (eventoBuscado != null)
                {
                    eventoBuscado.TituloTipoEvento = tipoEvento.TituloTipoEvento;
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Domains.TipoEvento BuscarPorID(Guid id)
        {
            try
            {
                TipoEvento eventoBuscado = _context.TipoEvento.Find(id)!;

                if (eventoBuscado != null)
                {
                    eventoBuscado.TipoEventoID = eventoBuscado.TituloTipoEvento;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(TipoEvento novoEvento)
        {
            try
            {
                _context.TipoEvento.Add(novoEvento);

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
                TipoEvento eventoBuscado = _context.TipoEvento.Find(id)!;

                if (eventoBuscado != null)
                {
                    _context.TipoEvento.Remove(eventoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Domains.TipoEvento> Listar()
        {
            try
            {
                List<TipoEvento> ListaDeEventos = _context.TipoEvento.Include(g => g.TituloTipoEvento).ToList();

                return ListaDeEventos;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
