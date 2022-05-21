using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.Mappings
{
    public class UserMapper : BaseTestService
    {
        [Fact(DisplayName = "Should Currect Mappers")]
        public void Mappers()
        {
            var userModel = new UserModel
            {
                CreateAt = DateTime.UtcNow,
                Email = "Any_Email",
                Name = "Any_Name",
                Id = Guid.NewGuid(),
                UpdateAt = DateTime.UtcNow
            };

            var entity = Mapper.Map<UserEntity>(userModel);
            Assert.NotNull(entity);
            Assert.Equal(entity.Id, userModel.Id);
            Assert.Equal(entity.CreateAt, userModel.CreateAt);
            Assert.Equal(entity.Email, userModel.Email);
            Assert.Equal(entity.UpdateAt, userModel.UpdateAt);
            Assert.Equal(entity.Name, userModel.Name);

            var userDto = Mapper.Map<UserDto>(entity);
            Assert.NotNull(userDto);
            Assert.Equal(userDto.Id, entity.Id);
            Assert.Equal(userDto.CreateAt, entity.CreateAt);
            Assert.Equal(userDto.Email, entity.Email);
            Assert.Equal(userDto.Name, entity.Name);

            var listEntity = new List<UserEntity>();
            for (int i = 0; i < 5; i++)
            {
                listEntity.Add(new UserEntity
                {
                    Name = $"Any_Name{i}",
                    Id = Guid.NewGuid(),
                    Email = $"Any_Email{i}",
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                });
            }

            var listUserDto = Mapper.Map<List<UserDto>>(listEntity);
            Assert.NotNull(listUserDto);
            Assert.NotEmpty(listUserDto);
            Assert.True(listUserDto.Count() == listEntity.Count());
            for (int i = 0; i < listEntity.Count(); i++)
            {
                Assert.Equal(listUserDto[i].Id, listEntity[i].Id);
                Assert.Equal(listUserDto[i].Name, listEntity[i].Name);
                Assert.Equal(listUserDto[i].Email, listEntity[i].Email);
                Assert.Equal(listUserDto[i].CreateAt, listEntity[i].CreateAt);
            }

            var userDtoCreateResult = Mapper.Map<UserDtoCreateResult>(entity);
            Assert.NotNull(userDtoCreateResult);
            Assert.Equal(userDtoCreateResult.Id, entity.Id);
            Assert.Equal(userDtoCreateResult.CreateAt, entity.CreateAt);
            Assert.Equal(userDtoCreateResult.Email, entity.Email);
            Assert.Equal(userDtoCreateResult.Name, entity.Name);

            var userDtoUpdateResult = Mapper.Map<UserDtoUpdateResult>(entity);
            Assert.NotNull(userDtoUpdateResult);
            Assert.Equal(userDtoUpdateResult.Email, entity.Email);
            Assert.Equal(userDtoUpdateResult.Name, entity.Name);
            Assert.Equal(userDtoUpdateResult.UpdateAt, entity.UpdateAt);

            var convertUserModel = Mapper.Map<UserModel>(userDto);
            Assert.NotNull(convertUserModel);
            Assert.Equal(convertUserModel.Id, userDto.Id);
            Assert.Equal(convertUserModel.CreateAt, userDto.CreateAt);
            Assert.Equal(convertUserModel.Email, userDto.Email);
            Assert.Equal(convertUserModel.Name, userDto.Name);

            var userDtoCreate = Mapper.Map<UserDtoCreate>(convertUserModel);
            Assert.NotNull(userDtoCreate);
            Assert.Equal(userDtoCreate.Email, convertUserModel.Email);
            Assert.Equal(userDtoCreate.Name, convertUserModel.Name);

            var userDtoUpdate = Mapper.Map<UserDtoUpdate>(convertUserModel);
            Assert.NotNull(userDtoUpdate);
            Assert.Equal(userDtoUpdate.Email, convertUserModel.Email);
            Assert.Equal(userDtoUpdate.Name, convertUserModel.Name);
            Assert.Equal(userDtoUpdate.Id, convertUserModel.Id);
        }
    }
}