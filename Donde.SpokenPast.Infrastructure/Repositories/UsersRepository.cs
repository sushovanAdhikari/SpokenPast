using Donde.Augmentor.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Donde.SpokenPast.Core.Repositories.Interfaces.RepositoryInterfaces;
using Donde.SpokenPast.Infrastructure.Database;
using Donde.SpokenPast.Core.Domain.Models;
using System.Threading.Tasks;

namespace Donde.SpokenPast.Infrastructure.Repositories
{
    public class UsersRepository : GenericRepository, IGenericRepository
    {

        public UsersRepository(DondeContext dbContext) : base(dbContext)
        {

        }

        public async Task<User> GetUserAsync(Guid Id)
        {
            return await GetByIdAsync<User>(Id);
        }
    }
   
}
