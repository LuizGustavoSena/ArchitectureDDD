using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Service.User;
using Api.Domain.Repository;
using Api.Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Api.Service.Service
{
    public class LoginService : ILoginService
    {
        private IUserRepository _repositoy;
        private SigningConfigurations _signingConfigurations;
        private TokenConfigurations _tokenConfigurations;
        private IConfiguration _configuration;

        public LoginService(IUserRepository repository,
                            SigningConfigurations signingConfigurations,
                            TokenConfigurations tokenConfigurations,
                            IConfiguration configuration)
        {
            _repositoy = repository;

            _signingConfigurations = signingConfigurations;

            _tokenConfigurations = tokenConfigurations;

            _configuration = configuration;
        }

        public async Task<object> FindByLogin(LoginDto user)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.Email))
                return null;

            var baseUser = await _repositoy.FindByEmal(user.Email);

            if (baseUser == null)
                return new
                {
                    Authenticated = false,
                    Message = "Falha na autenticação"
                };

            var identity = new ClaimsIdentity(
                new GenericIdentity(baseUser.Email),
                new[]{
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName, baseUser.Email)
                }
            );

            var createDate = DateTime.Now;
            var expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

            var handler = new JwtSecurityTokenHandler();
            var token = CreateToken(identity, createDate, expirationDate, handler);

            return SuccessObject(createDate, expirationDate, token, baseUser);
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });

            return handler.WriteToken(securityToken);
        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token, UserEntity user)
        {
            return new
            {
                authenticated = true,
                created = createDate.ToString("YYYY/MM/dd HH:mm:ss"),
                expiration = expirationDate.ToString("YYYY/MM/dd HH:mm:ss"),
                accessToken = token,
                user = new
                {
                    name = user.Name,
                    Email = user.Email
                },
                message = "Usuário logado",
            };
        }
    }
}