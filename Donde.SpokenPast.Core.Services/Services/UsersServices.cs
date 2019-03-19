using Donde.SpokenPast.Core.Domain.Models;
using Donde.SpokenPast.Core.Service.Interfaces.ServiceInterfaces;
using Donde.SpokenPast.Core.Repositories.Interfaces.RepositoryInterfaces;
using Donde.SpokenPast.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Donde.SpokenPast.Core.Services.Services
{
    public class UsersServices : IUsersServices
    {
        private IUsersRepository _userRepository;

        public UsersServices(IUsersRepository UserRepository)
        {
            _userRepository = UserRepository;
        }


        public async Task<User> CreateUserByIdAsync(User entity)
        {
            return await _userRepository.CreateUserByIdAsync(entity);
        }

        public Task<User> CreateUserByIdAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserById(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
