using api_filmes_senai.Domains;
using Projeto_Event_Plus.Domains;

namespace Projeto_Event_Plus.Interfaces
{
    public interface ITipoUsuario
    {
        void Cadastrar(TipoUsuario novoTipoUsuario);

        void Deletar(Guid id);

        List<TipoUsuario> Listar();

        TipoUsuario BuscarPorID(Guid id);

        void Atualizar(Guid id, TipoUsuario tipoUsuario);
    }
}
