using Dapper;
using Donde.Augmentor.Infrastructure.Repositories;
using Donde.SpokenPast.Core.Domain.Dto;
using Donde.SpokenPast.Core.Domain.Models;
using Donde.SpokenPast.Core.Repositories.Interfaces.RepositoryInterfaces;
using Donde.SpokenPast.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Donde.SpokenPast.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository, IUserRepository
    {
        public UserRepository(DondeContext dbContext) : base(dbContext)
        {

        }

        public async Task<User> CreateAugmentObjectAsync(User entity)
        {
            return await CreateAsync(entity);
        }

        public async Task<User> UpdateAugmentObjectAsync(Guid id, User entity)
        {
            return await UpdateAsync(id, entity);
        }
        
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            string usersQuery = $@"SELECT ""Id"", ""Name"", ""Email"", ""Password"", ""Phone"", ""Username"", ""OrganizationId"", 
                                            ""AddedDate"", ""UpdatedDate"", ""IsActive"", ""OwnerID"", ""Status""
                                           FROM ""Users"";";

            var connection = _dbContext.Database.GetDbConnection();

            var result = await connection.QueryAsync<UserDto>
            (
                usersQuery
            );

            return result;
        }
        

        public async Task<IEnumerable<IAsyncResult>> CreateUserAsync(User entity)
        {
            string usersQuery = $@"CREATE EXTENSION ""uuid - ossp"";
                                INSERT INTO ""Users""(
                                            ""Id"", ""Name"", ""Email"", ""Password"", ""Phone"", ""OrganizationId"", 
                                            ""AddedDate"", ""UpdatedDate"", ""IsActive"")
                                    VALUES(uuid_generate_v4(), '{entity.Name}', '{entity.Email}', '{entity.Password}', '{entity.Phone}', uuid_generate_v4();";

            var connection = _dbContext.Database.GetDbConnection();

            var result = await connection.QueryAsync<IAsyncResult>
            (
                usersQuery
            );

            return result;
        }

        public Task<User> UpdateUserAsync(Guid id, User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDto>> GetUserByIdAsync(Guid id)
        {
            string usersQuery = $@"SELECT ""Id"", ""Name"", ""Email"", ""Password"", ""Phone"", ""Username"", ""OrganizationId"", 
                                            ""AddedDate"", ""UpdatedDate"", ""IsActive"", ""OwnerID"", ""Status""
                                           FROM ""Users"" WHERE ""Id""='{id}'";

            var connection = _dbContext.Database.GetDbConnection();

            var result = await connection.QueryAsync<UserDto>
            (
                usersQuery
            );

            return result;
        }

        //; with AugmentObjectWithDistance as
        //    (

        //        select st_distance(ST_Transform(CONCAT('SRID=4326;POINT(',"Longitude",' ', "Latitude",')')::geometry, 3857), ST_Transform('SRID=4326;POINT(90.1009 30.4755)':: geometry, 3857)) as Distance,
        //    	"Id",
        //    	"AvatarId",
        //    	 "AugmentImageId",
        //                            "Description",
        //                            "Latitude",
        //                            "Longitude",
        //                            "OrganizationId",
        //                            "AddedDate",
        //                            "UpdatedDate",
        //                            "IsActive"
        //    	from "AugmentObjects"
        //    )

        //    select* from AugmentObjectWithDistance
        //   where Distance< 160000

        //   order by Distance

        //CREATE EXTENSION postgis; 
    }
}