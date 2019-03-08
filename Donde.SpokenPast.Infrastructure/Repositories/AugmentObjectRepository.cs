﻿using Dapper;
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
    public class AugmentObjectRepository : GenericRepository, IAugmentObjectRepository
    {
        public AugmentObjectRepository(DondeContext dbContext) : base(dbContext)
        {

        }

        public async Task<AugmentObject> CreateAugmentObjectAsync(AugmentObject entity)
        {
            return await CreateAsync(entity);
        }

        public async Task<AugmentObject> UpdateAugmentObjectAsync(Guid id, AugmentObject entity)
        {
            return await UpdateAsync(id, entity);
        }

        public async Task<IEnumerable<AugmentObjectDto>> GetClosestAugmentObjectsByRadius(double latitude, double longitude, int radiusInMeters)
        {
            string objectsByDistanceQuery = $@"with AugmentObjectWithDistance as 

                    (
                        SELECT 
                        st_distance(ST_Transform(CONCAT('SRID=4326;POINT(',""Longitude"",' ', ""Latitude"",')')::geometry, 3857), ST_Transform('SRID=4326;POINT({longitude} {latitude})':: geometry, 3857)) as Distance,
                        ""Id"",
                        ""AvatarId"",
                        ""AudioId"",
                        ""AugmentImageId"",
                        ""Description"",
                        ""Latitude"",
                        ""Longitude"",
                        ""OrganizationId"",
                        ""AddedDate"",
                        ""UpdatedDate"",
                        ""IsActive""
                        from ""AugmentObjects""
                    )

                    SELECT 
                        *
                    FROM 
                        AugmentObjectWithDistance
                    WHERE
                        Distance < @RadiusInMeters
                    ORDER BY
                        Distance";

            var connection = _dbContext.Database.GetDbConnection();

            var result = await connection.QueryAsync<AugmentObjectDto>
            (
                objectsByDistanceQuery,
                new
                {
                    Longitude = longitude,
                    Latitude = latitude,
                    RadiusInMeters = radiusInMeters
                }
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
