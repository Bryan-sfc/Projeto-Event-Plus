using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Projeto_Event_Plus.Domains;

namespace api_filmes_senai.Domains
{
    [Table("Usuario")]
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
        [Required(ErrorMessage = "A senha é obrigatória")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "A senha deve conter entre 3 e 30 caracteres.")]
        public string? Senha { get; set; }

        [Required(ErrorMessage = "O tipo de usuario é obtigaório!")]

        /// <summary>
        /// Referencia da tabela TipoUsuario
        /// </summary>
        public Guid TipoUsuarioID { get; set; }

        [ForeignKey("TipoUsuarioID")]
        public TipoUsuario? TipoUsuario { get; set; }
    }
}
