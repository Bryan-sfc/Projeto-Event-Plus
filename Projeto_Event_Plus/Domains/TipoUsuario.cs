using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Projeto_Event_Plus.Domains
{
    [Table("TipoUsuario")]
    [Index(nameof(Email), IsUnique = true)]
    public class TipoUsuario
    {
        [Key]
        public Guid TipoUsuarioID { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O titulo de usuario é ")]
        public string? TituloTipoUsuario { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O email do usuario é ")]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "A senha é obrigatório")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "A senha deve conter no mínimo de 6 caracteres e no máximo 60")]
        public string? Senha { get; set; }
    }
}
