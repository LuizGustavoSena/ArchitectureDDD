using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.ZipCode
{
    public class ZipCodeDtoUpdate
    {
        [Required(ErrorMessage = "Campo Id é obrigatório")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Campo Code é obrigatório")]
        public int Code { get; set; }
        [Required(ErrorMessage = "Campo Street é obrigatório")]
        public string Street { get; set; }
        public string Number { get; set; }
        [Required(ErrorMessage = "Campo CityId é obrigatório")]
        public Guid CityId { get; set; }
    }
}