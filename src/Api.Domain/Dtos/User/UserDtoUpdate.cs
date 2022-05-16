using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.User
{
    public class UserDtoUpdate
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(60, ErrorMessage = "Deve conter no máximo 60 caracteres")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [StringLength(100, ErrorMessage = "Deve conter no máximo 100 caracteres")]
        public string Email { get; set; }
    }
}