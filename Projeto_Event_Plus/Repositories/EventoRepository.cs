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
            try
            {
                Eventos eventoBuscado = _context.Eventos.Find(id)!;

                if (eventoBuscado != null)
                {
                    eventoBuscado.DataEvento = evento.DataEvento;
                    eventoBuscado.Evento = evento.Evento;
                    eventoBuscado.Descricao = evento.Descricao;
                    eventoBuscado.TipoEventoID = evento.TipoEventoID;
                }

                _context.Eventos.Update(eventoBuscado!);

                _context.SaveChanges();
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
                // Verifica se a data do evento é maior que a data atual
                if (novoEvento.DataEvento < DateTime.Now)
                {
                    throw new ArgumentException("A data do evento deve ser maior ou igual a data atual.");
                }

                novoEvento.EventosID = Guid.NewGuid();

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
            try
            {
                return _context.Eventos
                    .Select(e => new Eventos
                    {
                        EventosID = e.EventosID,
                        Evento = e.Evento,
                        Descricao = e.Descricao,
                        DataEvento = e.DataEvento,
                        TipoEventoID = e.TipoEventoID,
                        TipoEvento = new TipoEvento
                        {
                            TipoEventoID = e.TipoEventoID,
                            TituloTipoEvento = e.TipoEvento!.TituloTipoEvento
                        },
                        InstituicaoID = e.InstituicaoID,
                        Intituicao = new Instituicao
                        {
                            InstituicaoID = e.InstituicaoID,
                            NomeFantasia = e.Intituicao!.NomeFantasia
                        }
                    }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Eventos> ListarPorID(Guid id)
        {
            try
            {
                List<Eventos> listaEvento = _context.Eventos.Where(p => p.EventosID == id).ToList();
                return listaEvento;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Eventos> ListarProximosEventos()
        {
            try
            {
                return _context.Eventos
                    .Select(e => new Eventos
                    {
                        EventosID = e.EventosID,
                        Evento = e.Evento,
                        Descricao = e.Descricao,
                        DataEvento = e.DataEvento,
                        TipoEventoID = e.TipoEventoID,
                        TipoEvento = new TipoEvento
                        {
                            TipoEventoID = e.TipoEventoID,
                            TituloTipoEvento = e.TipoEvento!.TituloTipoEvento
                        },
                        InstituicaoID = e.InstituicaoID,
                        Intituicao = new Instituicao
                        {
                            InstituicaoID = e.InstituicaoID,
                            NomeFantasia = e.Intituicao!.NomeFantasia
                        }

                    })
                    .Where(e => e.DataEvento >= DateTime.Now)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}