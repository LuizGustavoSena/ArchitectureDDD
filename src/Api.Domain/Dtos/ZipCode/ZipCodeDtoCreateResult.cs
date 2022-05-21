using System;

namespace Api.Domain.Dtos.ZipCode
{
    public class ZipCodeDtoCreateResult
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public Guid CityId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}