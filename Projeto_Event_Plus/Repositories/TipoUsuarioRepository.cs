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
            try
            {
                TipoUsuario tipoBuscado = _context.TipoUsuario.Find(id)!;

                if (tipoBuscado != null)
                {
                    tipoBuscado.TituloTipoUsuario = tipoUsuario.TituloTipoUsuario;
                }

                _context.TipoUsuario.Update(tipoBuscado!);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TipoUsuario BuscarPorID(Guid id)
        {
            try
            {
                return _context.TipoUsuario.Find(id)!;
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
                novoTipoUsuario.TipoUsuarioID = Guid.NewGuid();

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
                TipoUsuario tipoBuscado = _context.TipoUsuario.Find(id)!;

                if (tipoBuscado != null)
                {
                    _context.TipoUsuario.Remove(tipoBuscado);
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
            try
            {
                return _context.TipoUsuario.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
