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

            userDto = new UserDto
            {
                Name = UserName,
                Id = UserId,
                Email = UserEmail
            };

            userDtoCreate = new UserDtoCreate
            {
                Email = UserEmail,
                Name = UserName
            };

            userDtoCreateResult = new UserDtoCreateResult
            {
                CreateAt = DateTime.UtcNow,
                Email = UserEmail,
                Id = Guid.NewGuid(),
                Name = UserName
            };

            userDtoUpdate = new UserDtoUpdate
            {
                Email = UserEmailAltered,
                Name = UserNameAltered,
                Id = Guid.NewGuid()
            };

            userDtoUpdateResult = new UserDtoUpdateResult
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
        public UserDto userDto;
        public UserDtoCreate userDtoCreate;
        public UserDtoCreateResult userDtoCreateResult;
        public UserDtoUpdate userDtoUpdate;
        public UserDtoUpdateResult userDtoUpdateResult;
    }
}