using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Donde.SpokenPast.Core.Domain.Dto;
using Donde.SpokenPast.Core.Domain.Models;
using Donde.SpokenPast.Infrastructure.Repositories;

namespace Donde.SpokenPast.Core.Service.Interfaces.ServiceInterfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task<IEnumerable<UserDto>> GetUserById(Guid id);
        Task<User> CreateUserAsync(User entity);
        Task<User> UpdateUserAsync(Guid id, User entity);
    }
}
