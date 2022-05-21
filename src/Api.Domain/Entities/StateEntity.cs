using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class StateEntity : BaseEntity
    {
        [Required]
        [MaxLength(2)]
        public string Initials { get; set; }
        [Required]
        [MaxLength(45)]
        public string Name { get; set; }
        public IEnumerable<CityEntity> Cities { get; set; }
    }
}