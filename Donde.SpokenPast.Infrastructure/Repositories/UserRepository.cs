using Dapper;
using Donde.Augmentor.Infrastructure.Repositories;
using Donde.SpokenPast.Core.Domain.Dto;
using Donde.SpokenPast.Core.Domain.Models;
using Donde.SpokenPast.Core.Repositories.Interfaces.RepositoryInterfaces;
using Donde.SpokenPast.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donde.SpokenPast.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository, IUserRepository
    {
        public UserRepository(DondeContext dbContext) : base(dbContext)
        {

        }
        
        public IQueryable<User> GetUsers()
        {
             return GetAll<User>();
        }

        public Task<User> UpdateUserAsync(Guid id, User entity)
        {
            throw new NotImplementedException();
        }

        Task<User> IUserRepository.CreateUserAsync(User entity)
        {
            throw new NotImplementedException();
        }

        Task<User> IUserRepository.GetUserByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}