using System;

namespace Api.Domain.Dtos.ZipCode
{
    public class ZipCodeDtoUpdateResult
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public Guid CityId { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}