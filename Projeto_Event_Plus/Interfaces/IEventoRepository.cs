using Projeto_Event_Plus.Domains;

namespace Projeto_Event_Plus.Interfaces
{
    public interface IEventoRepository
    {
        void Atualizar(Guid id, Eventos evento);

        void Cadastrar(Eventos novoEvento);

        void Deletar(Guid id);

        List<Eventos> Listar();

        List<Eventos> ListarPorID(Guid id);

        List<Eventos> ListarProximosEventos();
    }
}
