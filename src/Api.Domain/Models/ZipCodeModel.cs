using System;

namespace Api.Domain.Models
{
    public class ZipCodeModel : BaseModel
    {
        private int _code;
        public int Code
        {
            get { return _code; }
            set { _code = value; }
        }

        private string _street;
        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }

        private string _number;
        public string Number
        {
            get { return _number; }
            set { _number = string.IsNullOrEmpty(value) ? "S/N" : value; }
        }

        private Guid _cityId;
        public Guid CityId
        {
            get { return _cityId; }
            set { _cityId = value; }
        }

    }
}