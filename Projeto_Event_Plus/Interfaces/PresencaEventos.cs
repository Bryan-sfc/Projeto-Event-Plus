using api_filmes_senai.Domains;
using Projeto_Event_Plus.Domains;

namespace Projeto_Event_Plus.Interfaces
{
    public interface PresencaEventos
    {
        void Deletar(Guid id);

        List<PresencaEventos> Listar();

        PresencaEventos BuscarPorID(Guid id);

        void Atualizar(Guid id, PresencaEventos presencaEventos);

        List<PresencaEventos> ListarMinhas(Guid id);

        void Inscrever(Presenca evento);
    }
}
