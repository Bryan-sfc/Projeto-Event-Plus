using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Event_Plus.Domains
{
    [Table("Comentario")]
    public class Comentario
    {
        [Key]
        public Guid ComentarioID { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        [Required(ErrorMessage = "A descrição do evento é ")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Defina se o comentário poderá ser exibido ou não!")]
        public bool Exibe { get; set; }

        public Guid? UsuarioID { get; set; }
        [ForeignKey("UsuarioID")]
        public Usuario? Usuario { get; set; }

        public Guid? EventoID { get; set; }
        [ForeignKey("EventoID")]
        public Eventos? Eventos { get; set; }
    }
}
