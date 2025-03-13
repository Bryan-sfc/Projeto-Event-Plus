using api_filmes_senai.Domains;
using Projeto_Event_Plus.Domains;

namespace Projeto_Event_Plus.Interfaces
{
    public interface IEventoRepository
    {
        void Cadastrar(Eventos novoEvento);

        void Deletar(Guid id);

        List<Eventos> Listar();

        List<Eventos> ListarPorID(Guid id);

        Eventos ProximosEventos();

        TipoEvento BuscarPorID(Guid id);

        void Atualizar(Guid id, Eventos evento);
    }
}
