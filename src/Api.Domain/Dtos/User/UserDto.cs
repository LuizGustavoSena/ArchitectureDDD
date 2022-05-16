using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.User
{
    public class UserDto
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(60, ErrorMessage = "Deve conter no máximo 60 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [StringLength(100, ErrorMessage = "Deve conter no máximo 100 caracteres")]
        public string Email { get; set; }
    }
}