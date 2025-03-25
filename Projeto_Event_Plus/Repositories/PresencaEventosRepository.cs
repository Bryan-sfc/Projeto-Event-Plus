using Projeto_Event_Plus.Context;
using Projeto_Event_Plus.Domains;
using Projeto_Event_Plus.Interfaces;

namespace Projeto_Event_Plus.Repositories
{
    public class PresencaEventosRepository : IPresencaEventosRepository
    {
        private readonly Events_Plus_Context _context;

        public PresencaEventosRepository(Events_Plus_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, Presenca presencaEventos)
        {
            try
            {
                Presenca presencaEventoBuscado = _context.Presenca.Find(id)!;

                if (presencaEventoBuscado != null)
                {
                    if (presencaEventoBuscado.Situcao)
                    {
                        presencaEventoBuscado.Situcao = false;
                    }
                    else
                    {
                        presencaEventoBuscado.Situcao = true;
                    }
                }
                _context.Presenca.Update(presencaEventoBuscado!);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Presenca BuscarPorID(Guid id)
        {
            try
            {
                return _context.Presenca
                    .Select(p => new Presenca
                    {
                        PresencaID = p.PresencaID,
                        Situcao = p.Situcao,

                        Eventos = new Eventos
                        {
                            EventosID = p.EventoID!,
                            DataEvento = p.Eventos!.DataEvento,
                            Evento = p.Eventos.Evento,
                            Descricao = p.Eventos.Descricao,

                            Intituicao = new Instituicao
                            {
                                InstituicaoID = p.Eventos.Intituicao!.InstituicaoID,
                                NomeFantasia = p.Eventos.Intituicao!.NomeFantasia
                            }
                        }

                    }).FirstOrDefault(p => p.PresencaID == id)!;
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
                Presenca presencaEventoBuscado = _context.Presenca.Find(id)!;

                if (presencaEventoBuscado != null)
                {
                    _context.Presenca.Remove(presencaEventoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Inscrever(Presenca inscricao)
        {
            try
            {
                inscricao.PresencaID = Guid.NewGuid();

                _context.Presenca.Add(inscricao);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Presenca> Listar()
        {
            try
            {
                return _context.Presenca
                    .Select(p => new Presenca
                    {
                        PresencaID = p.PresencaID,
                        Situcao = p.Situcao,

                        Eventos = new Eventos
                        {
                            EventosID = p.EventoID,
                            DataEvento = p.Eventos!.DataEvento,
                            Evento = p.Eventos.Evento,
                            Descricao = p.Eventos.Descricao,

                            Intituicao = new Instituicao
                            {
                                InstituicaoID = p.Eventos.Intituicao!.InstituicaoID,
                                NomeFantasia = p.Eventos.Intituicao!.NomeFantasia
                            }
                        }

                    }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Presenca> ListarMinhas(Guid id)
        {
            return _context.Presenca
                .Select(p => new Presenca
                {
                    PresencaID = p.PresencaID,
                    Situcao = p.Situcao,
                    UsuarioID = p.UsuarioID,
                    EventoID = p.EventoID,

                    Eventos = new Eventos
                    {
                        EventosID = p.EventoID,
                        DataEvento = p.Eventos!.DataEvento,
                        Evento = p.Eventos!.Evento,
                        Descricao = p.Eventos!.Descricao,

                        Intituicao = new Instituicao
                        {
                            InstituicaoID = p.Eventos!.InstituicaoID,
                        }
                    }
                })
            .Where(p => p.UsuarioID == id)
            .ToList();
        }
    }
}
