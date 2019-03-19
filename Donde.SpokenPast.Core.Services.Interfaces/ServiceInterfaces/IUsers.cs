using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Donde.SpokenPast.Core.Domain.Models;

namespace Donde.SpokenPast.Core.Service.Interfaces.ServiceInterfaces
{
   public interface IUsersServices
    {
        Task<User> GetUserById(Guid Id);

    }
}
