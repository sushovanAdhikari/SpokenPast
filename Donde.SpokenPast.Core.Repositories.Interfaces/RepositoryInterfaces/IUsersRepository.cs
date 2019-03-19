using Donde.SpokenPast.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Donde.SpokenPast.Core.Repositories.Interfaces.RepositoryInterfaces
{
    interface IUsersRepository
    {
        Task<User> GetUserAsync(Guid id);
    }
}
