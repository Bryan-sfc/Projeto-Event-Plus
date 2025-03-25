using Projeto_Event_Plus.Domains;

namespace Projeto_Event_Plus.Interfaces
{
    public interface IPresencaEventosRepository
    {
        void Deletar(Guid id);

        List<Presenca> Listar();

        Presenca BuscarPorID(Guid id);

        void Atualizar(Guid id, Presenca presencaEventos);

        List<Presenca> ListarMinhas(Guid id);

        void Inscrever(Presenca evento);
    }
}
