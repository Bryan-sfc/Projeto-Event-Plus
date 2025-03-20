using Projeto_Event_Plus.Context;
using Projeto_Event_Plus.Interfaces;
using Projeto_Event_Plus.Domains;

namespace Projeto_Event_Plus.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {           
        private readonly Events_Plus_Context _context;

        public TipoEventoRepository(Events_Plus_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, TipoEvento tipoEventos)
        {
            TipoEvento eventoBuscado = _context.TipoEvento.Find(id)!;

            if (eventoBuscado != null)
            {
                eventoBuscado.TituloTipoEvento = tipoEventos.TituloTipoEvento;
            }
            _context.SaveChanges();
        }

        public TipoEvento BuscarPorId(Guid id)
        {
            try
            {
                TipoEvento tipoEventoBuscado = _context.TipoEvento.Find(id)!;

                if (tipoEventoBuscado != null)
                {
                    return tipoEventoBuscado;
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(TipoEvento tipoEventos)
        {
            try
            {
                _context.TipoEvento.Add(tipoEventos);

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
                TipoEvento tipoEventoBuscado = _context.TipoEvento.Find(id)!;

                if (tipoEventoBuscado != null)
                {
                    _context.TipoEvento.Remove(tipoEventoBuscado);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public List<TipoEvento> Listar()
        {
            List<TipoEvento> ListaTipoEvento = _context.TipoEvento.ToList();
            return ListaTipoEvento;
        }
    }
}
