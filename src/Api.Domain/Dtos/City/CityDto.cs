using System;

namespace Api.Domain.Dtos.City
{
    public class CityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }

        public Guid StateId { get; set; }
    }
}