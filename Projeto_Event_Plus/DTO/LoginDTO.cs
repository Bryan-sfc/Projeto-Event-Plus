using System.ComponentModel.DataAnnotations;

namespace Projeto_Event_Plus.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "O email é obrigatório")]
        public string? Email { get; set; }


        [Required(ErrorMessage = "A senha é obrigatório")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "A senha deve conter no mínimo de 6 caracteres e no máximo 60")]
        public string? Senha { get; set; }
    }
}
