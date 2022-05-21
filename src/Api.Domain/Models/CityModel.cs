using System;

namespace Api.Domain.Models
{
    public class CityModel : BaseModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _code;
        public int Code
        {
            get { return _code; }
            set { _code = value; }
        }

        private Guid _stateId;
        public Guid StateId
        {
            get { return _stateId; }
            set { _stateId = value; }
        }

    }
}