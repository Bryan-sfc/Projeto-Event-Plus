using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Projeto_Event_Plus.Domains;

namespace api_filmes_senai.Domains
{
    [Table("Usuarios")]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O email é obrigatório")]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "A senha é obrigatório")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "A senha deve conter no mínimo de 6 caracteres e no máximo 60")]
        public string? Senha { get; set; }

        /// <summary>
        /// Referencia da tabela TipoUsuario
        /// </summary>
        public Guid TipoUsuarioID { get; set; }

        [ForeignKey("TipoUsuarioID")]
        public TipoUsuario? TipoUsuario { get; set; }
    }
}
