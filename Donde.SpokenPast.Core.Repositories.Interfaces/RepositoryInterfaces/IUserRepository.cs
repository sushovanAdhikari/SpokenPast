using Donde.SpokenPast.Core.Domain.Dto;
using Donde.SpokenPast.Core.Domain.Models;
using Donde.SpokenPast.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donde.SpokenPast.Core.Repositories.Interfaces.RepositoryInterfaces
{
    public interface IUserRepository
    {
        IQueryable<User> GetUsers();
        Task<User> CreateUserAsync(User entity);
        Task<User> UpdateUserAsync(Guid id, User entity);
        Task<User> GetUserByIdAsync(Guid id);
        bool DoesUserNotExist(String email);
        Task<User> AuthenticateUser(string email, string password);
    }
}
