using System;
using Api.Domain.Dtos.State;

namespace Api.Domain.Dtos.City
{
    public class CityDtoComplete
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }

        public Guid StateId { get; set; }
        public StateDto State { get; set; }
    }
}