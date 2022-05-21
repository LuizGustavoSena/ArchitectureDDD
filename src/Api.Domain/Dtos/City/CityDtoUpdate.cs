using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.City
{
    public class CityDtoUpdate
    {
        [Required(ErrorMessage = "Campo Id é obrigatório")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Campo Name é obrigatório")]
        [MaxLength(60, ErrorMessage = "Campo Name deve conter no máximo {1} caracteres")]
        public string Name { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Campo Cod inválido")]
        public int Cod { get; set; }
        [Required(ErrorMessage = "Campo StateId é obrigatório")]
        public Guid StateId { get; set; }
    }
}