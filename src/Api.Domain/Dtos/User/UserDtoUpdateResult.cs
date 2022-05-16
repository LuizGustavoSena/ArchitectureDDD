using System;

namespace Api.Domain.Dtos.User
{
    public class UserDtoUpdateResult
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}