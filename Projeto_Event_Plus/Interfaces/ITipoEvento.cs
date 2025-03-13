using Projeto_Event_Plus.Domains;

namespace Projeto_Event_Plus.Interfaces
{
    public interface ITipoEvento
    {
        void Cadastrar(TipoEvento tipoEvento);

        void Deletar(Guid id);

        List<TipoEvento> Listar();

        TipoEvento BuscarPorID(Guid id, TipoEvento tipoEvento);

        void Atualizar(Guid id, TipoEvento tipoEvento);
    }
}
