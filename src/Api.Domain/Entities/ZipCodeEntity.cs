using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class ZipCodeEntity : BaseEntity
    {
        [Required]
        [MaxLength(10)]
        public int Code { get; set; }
        [Required]
        [MaxLength(60)]
        public string Street { get; set; }
        [MaxLength(10)]
        public int Number { get; set; }
        [Required]
        public Guid CityId { get; set; }
        public CityEntity City { get; set; }
    }
}