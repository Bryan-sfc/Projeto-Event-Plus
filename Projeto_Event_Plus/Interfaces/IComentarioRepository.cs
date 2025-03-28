﻿using Projeto_Event_Plus.Domains;

namespace Projeto_Event_Plus.Interfaces
{
    public interface IComentarioRepository
    {
        void Cadastrar(Comentario comentario);

        void Deletar(Guid id);

        List<Comentario> Listar(Guid id);

        Comentario BuscarPorIdUsuario(Guid idUsuario, Guid idEvento);
    }
}
