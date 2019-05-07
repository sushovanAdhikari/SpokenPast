using Donde.SpokenPast.Core.Domain.Dto;
using Donde.SpokenPast.Core.Domain.Helpers;
using Donde.SpokenPast.Core.Domain.Models;
using Donde.SpokenPast.Core.Repositories.Interfaces.RepositoryInterfaces;
using Donde.SpokenPast.Core.Service.Interfaces.ServiceInterfaces;
using Donde.SpokenPast.Infrastructure.Repositories;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<User> CreateUserAsync(User entity)
        {
            try
            {
                if (_userRepository.DoesUserNotExist(entity.Email))
                {
                    entity.Id = SequentialGuidGenerator.GenerateComb();
                    entity.AddedDate = DateTime.Now;
                    entity.UpdatedDate = DateTime.Now;
                    entity.IsActive = DateTime.Now;
                    await _userRepository.CreateUserAsync(entity);

                    return entity;
                }

                return new User();
            } catch (Exception ex)
            {
                return new User();
            }
        }

        public Task<User> GetUserByIdAsync(Guid id)
        {
            return _userRepository.GetUserByIdAsync(id);
        }

        public IQueryable<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public User UpdateUserAsync(Guid id, User entity)
        {
            return _userRepository.UpdateUserAsync(id, entity);
        }

        public bool DoesUserNotExist(string email)
        {
            return _userRepository.DoesUserNotExist(email);
        }

        public Task<User> AuthenticateUser(String email, String password)
        {
            return _userRepository.AuthenticateUser(email, password);
        }
    }
}