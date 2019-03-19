using Donde.SpokenPast.Core.Domain.Dto;
using Donde.SpokenPast.Core.Domain.Models;
using Donde.SpokenPast.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Donde.SpokenPast.Core.Repositories.Interfaces.RepositoryInterfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDto>> GetUsers();
        Task<IEnumerable<IAsyncResult>> CreateUserAsync(User entity);
        Task<User> UpdateUserAsync(Guid id, User entity);
        Task<IEnumerable<UserDto>> GetUserByIdAsync(Guid id);
    }
}
