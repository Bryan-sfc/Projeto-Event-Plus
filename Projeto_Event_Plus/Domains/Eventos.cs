using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Event_Plus.Domains
{
    [Table("Eventos")]
    public class Eventos
    {
        [Key]
        public Guid EventosID { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome do evento é obrigatório!")]
        public string? Evento { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data do evento é obrigatório!")]
        public DateTime? DataEvento { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A data do evento é obrigatório!")]
        public string? Descricao { get; set; }

        /// <summary>
        /// Rerencia as demais tabelas
        /// </summary>
        public Guid TipoEventoID { get; set; }
        [ForeignKey("TipoEventoID")]
        public TipoEvento? TipoEvento { get; set; }

        public Guid InstituicaoID { get; set; }
        [ForeignKey("InstituicaoID")]
        public Instituicao? Intituicao { set; get; }
    }
}
