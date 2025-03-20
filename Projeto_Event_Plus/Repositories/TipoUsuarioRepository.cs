using Microsoft.EntityFrameworkCore;
using Projeto_Event_Plus.Context;
using Projeto_Event_Plus.Domains;
using Projeto_Event_Plus.Interfaces;

namespace Projeto_Event_Plus.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly Events_Plus_Context _context;

        public TipoUsuarioRepository(Events_Plus_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            TipoUsuario usuarioBuscado = _context.TipoUsuario.Find(id)!;

            if (usuarioBuscado != null)
            {
                usuarioBuscado.TituloTipoUsuario = tipoUsuario.TituloTipoUsuario; 
            }
            _context.SaveChanges();
        }

        public TipoUsuario BuscarPorID(Guid id)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = _context.TipoUsuario.Find(id)!;

                if (tipoUsuarioBuscado != null)
                {
                    return tipoUsuarioBuscado;
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            try
            {
                _context.TipoUsuario.Add(novoTipoUsuario);

                _context.SaveChanges();
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
                TipoUsuario tipoUsuarioBuscado = _context.TipoUsuario.Find(id)!;

                if (tipoUsuarioBuscado != null)
                {
                    _context.TipoUsuario.Remove(tipoUsuarioBuscado);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TipoUsuario> Listar()
        {
            List<TipoUsuario> listaTipoUsuario = _context.TipoUsuario.ToList();
            return listaTipoUsuario;
        }
    }
}
