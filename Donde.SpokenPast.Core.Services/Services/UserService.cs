using Donde.SpokenPast.Core.Domain.Dto;
using Donde.SpokenPast.Core.Domain.Models;
using Donde.SpokenPast.Core.Repositories.Interfaces.RepositoryInterfaces;
using Donde.SpokenPast.Core.Service.Interfaces.ServiceInterfaces;
using Donde.SpokenPast.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Donde.SpokenPast.Core.Services.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> CreateUserAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDto>> GetUserById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            return await _userRepository.GetUsers();
        }

        public Task<User> UpdateUserAsync(Guid id, User entity)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<UserDto>> IUserService.GetUserById(Guid id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }
    }
}