using Projeto_Event_Plus.Domains;

namespace Projeto_Event_Plus.Interfaces
{
    public interface IPresencaEventosRepository
    {
        void Deletar(Guid id);

        List<IPresencaEventosRepository> Listar();

        IPresencaEventosRepository BuscarPorID(Guid id);

        void Atualizar(Guid id, IPresencaEventosRepository presencaEventos);

        List<IPresencaEventosRepository> ListarMinhas(Guid id);

        void Inscrever(Presenca evento);
    }
}
