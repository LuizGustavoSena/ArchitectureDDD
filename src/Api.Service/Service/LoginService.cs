using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Interfaces.Service.User;
using Api.Domain.Repository;

namespace Api.Service.Service
{
    public class LoginService : ILoginService
    {
        private IUserRepository _repositoy;

        public LoginService(IUserRepository repository)
        {
            _repositoy = repository;
        }

        public async Task<object> FindByLogin(LoginDto user)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.Email))
                return null;

            return await _repositoy.FindByEmal(user.Email);
        }
    }
}