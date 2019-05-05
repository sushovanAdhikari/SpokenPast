using Dapper;
using Donde.Augmentor.Infrastructure.Repositories;
using Donde.SpokenPast.Core.Domain.Dto;
using Donde.SpokenPast.Core.Domain.Models;
using Donde.SpokenPast.Core.Repositories.Interfaces.RepositoryInterfaces;
using Donde.SpokenPast.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Donde.SpokenPast.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository, IUserRepository
    {
        private readonly DondeContext dondeContext;
        public UserRepository(DondeContext dbContext) : base(dbContext)
        {
            dondeContext = dbContext;
        }

        public IQueryable<User> GetUsers()
        {
             return GetAll<User>();
        }

        public Task<User> UpdateUserAsync(Guid id, User entity)
        {
            throw new NotImplementedException();
        }

        async Task<User> IUserRepository.CreateUserAsync(User entity)
        {
            try
            {
                    await dondeContext.Set<User>().AddAsync(entity);
                    await dondeContext.SaveChangesAsync();

                    return entity;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        async Task<User> IUserRepository.GetUserByIdAsync(Guid id)
        {
            var user = dondeContext.Set<User>().Where(x => x.Id == id).FirstOrDefault();
            return user;
        }

        public bool DoesUserNotExist(string Email) => _dbContext.Set<User>()
                   .AsNoTracking()
                   .FirstOrDefaultAsync(e => e.Email == Email).Result == null;

        async Task<User> IUserRepository.AuthenticateUser(String email, String password)
        {
            var loggedInUser = dondeContext.Set<User>().Where(x => x.Email == email && x.Password == password).FirstOrDefault();
            if (loggedInUser == null)
            {
                return new User();
            }

            return loggedInUser;
        }
    }
}