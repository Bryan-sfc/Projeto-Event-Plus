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
            try
            {
                TipoEvento tipoBuscado = _context.TipoEvento.Find(id)!;

                if (tipoBuscado != null)
                {
                    tipoBuscado.TituloTipoEvento = tipoEventos.TituloTipoEvento;
                }

                _context.TipoEvento.Update(tipoBuscado!);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TipoEvento BuscarPorId(Guid id)
        {
            try
            {
                return _context.TipoEvento.Find(id)!;
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
                tipoEventos.TipoEventoID = Guid.NewGuid();

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
                TipoEvento tipoBuscado = _context.TipoEvento.Find(id)!;

                if (tipoBuscado != null)
                {
                    _context.TipoEvento.Remove(tipoBuscado);
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
            try
            {
                return _context.TipoEvento
                    .OrderBy(tp => tp.TituloTipoEvento)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
