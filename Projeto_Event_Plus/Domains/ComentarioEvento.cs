using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api_filmes_senai.Domains;

namespace Projeto_Event_Plus.Domains
{
    [Table("Comentario")]
    public class ComentarioEvento
    {
        [Key]
        public Guid ComentarioID { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        [Required(ErrorMessage = "A descrição do evento é ")]
        public string? Descricao { get; set; }

        public bool Exibe { get; set; }

        public Guid? UsuarioID { get; set; }
        [ForeignKey("UsuarioID")]
        public Usuario? Usuario { get; set; }

        public Guid? EventoID { get; set; }
        [ForeignKey("EventoID")]
        public Eventos? Eventos { get; set; }
    }
}
