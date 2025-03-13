using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api_filmes_senai.Domains;

namespace Projeto_Event_Plus.Domains
{
    [Table("Presenca")]
    public class Presenca
    {
        [Key]
        public Guid PresencaID { get; set; }

        public Guid Situcao { get; set; }

        public Guid UsuarioID { get; set; }
        [ForeignKey("UsuarioID")]
        public Usuario? Usuario { get; set; }

        public Guid EventoID { get; set; }
        [ForeignKey("EventoID")]
        public Eventos? Eventos { get; set; }
    }
}
