using Projeto_Event_Plus.Domains;
using Microsoft.EntityFrameworkCore;

namespace Projeto_Event_Plus.Context
{
    public class Events_Plus_Context : DbContext
    {
        public Events_Plus_Context()
        {
        }

        public Events_Plus_Context(DbContextOptions<Events_Plus_Context> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Eventos> Eventos { get; set; }
        public DbSet<Presenca> Presenca { get; set; }
        public DbSet<ComentarioEvento> Comentario { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }
        public DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public DbSet<TipoEvento> TipoEvento {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=NOTE06-S28\\SQLEXPRESS;Database=EventsPlus;User ID=sa;Password=Senai@134;TrustServerCertificate=true");
            }
        }
    }
}
