﻿using Donde.SpokenPast.Core.Domain.Dto;
using Donde.SpokenPast.Core.Domain.Helpers;
using Donde.SpokenPast.Core.Domain.Models;
using Donde.SpokenPast.Core.Repositories.Interfaces.RepositoryInterfaces;
using Donde.SpokenPast.Core.Service.Interfaces.ServiceInterfaces;
using Donde.SpokenPast.Infrastructure.Repositories;
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

        public Task<User> CreateUserAsync(User entity)
        {
            entity.Id = SequentialGuidGenerator.GenerateComb();
            entity.AddedDate = DateTime.UtcNow;
            entity.UpdatedDate = DateTime.UtcNow;
            // validate the user entity. Use fluent validaiton with asp.net core.
            throw new NotImplementedException();
        }

        public Task<User> GetUserByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public Task<User> UpdateUserAsync(Guid id, User entity)
        {
            throw new NotImplementedException();
        }
    }
}