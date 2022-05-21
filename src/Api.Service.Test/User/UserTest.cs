using System;
using System.Collections.Generic;
using Api.Domain.Dtos.User;

namespace Api.Service.Test.User
{
    public class UserTest
    {
        public UserTest()
        {
            UserName = "Any_UserName";
            UserEmail = "Any_UserEmail";
            UserNameAltered = "Any_UserNameAltered";
            UserEmailAltered = "Any_UserEmailAltered";
            UserId = Guid.NewGuid();

            for (int i = 0; i < 10; i++)
            {
                ListUserDto.Add(new UserDto
                {
                    Name = $"{UserName}{i}",
                    Id = Guid.NewGuid(),
                    Email = $"{UserEmail}{i}"
                });
            }

            UserDto = new UserDto
            {
                Name = UserName,
                Id = Guid.NewGuid(),
                Email = UserEmail
            };

            UserDtoCreate = new UserDtoCreate
            {
                Email = UserEmail,
                Name = UserName
            };

            UserDtoCreateResult = new UserDtoCreateResult
            {
                CreateAt = DateTime.UtcNow,
                Email = UserEmail,
                Id = Guid.NewGuid(),
                Name = UserName
            };

            UserDtoUpdate = new UserDtoUpdate
            {
                Email = UserEmailAltered,
                Name = UserNameAltered,
                Id = Guid.NewGuid()
            };

            UserDtoUpdateResult = new UserDtoUpdateResult
            {
                Email = UserEmailAltered,
                Name = UserNameAltered,
                UpdateAt = DateTime.UtcNow,
            };
        }
        public static string UserName { get; set; }
        public static string UserEmail { get; set; }
        public static string UserNameAltered { get; set; }
        public static string UserEmailAltered { get; set; }
        public Guid UserId { get; set; }
        public List<UserDto> ListUserDto = new List<UserDto>();
        public UserDto UserDto;
        public UserDtoCreate UserDtoCreate;
        public UserDtoCreateResult UserDtoCreateResult;
        public UserDtoUpdate UserDtoUpdate;
        public UserDtoUpdateResult UserDtoUpdateResult;
    }
}