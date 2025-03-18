using Projeto_Event_Plus.Domains;

namespace Projeto_Event_Plus.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario novoUsuario);

        Usuario BuscarPorID(Guid id);

        Usuario BuscarPorEmailESenha(string Email, string Senha);
    }
}
