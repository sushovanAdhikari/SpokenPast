using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Donde.SpokenPast.Core.Domain.Dto;
using Donde.SpokenPast.Core.Domain.Models;
using Donde.SpokenPast.Infrastructure.Repositories;

namespace Donde.SpokenPast.Core.Service.Interfaces.ServiceInterfaces
{
    public interface IUserService
    {
        IQueryable<User> GetUsers();
        Task<User> CreateUserAsync(User entity);
        Task<User> UpdateUserAsync(Guid id, User entity);
        Task<User> GetUserByIdAsync(Guid id);
        bool DoesUserNotExist(string email);
        Task<User> AuthenticateUser(String email, String password);
    }
}
