using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class CityEntity : BaseEntity
    {
        [Required]
        [MaxLength(60)]
        public string name { get; set; }
        public int Cod { get; set; }
        [Required]
        public Guid StateId { get; set; }
        public StateEntity State { get; set; }
        public IEnumerable<ZipCodeEntity> ZipCode { get; set; }
    }
}