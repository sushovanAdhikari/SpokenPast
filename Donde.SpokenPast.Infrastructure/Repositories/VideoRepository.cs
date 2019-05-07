using Donde.Augmentor.Infrastructure.Repositories;
using Donde.SpokenPast.Core.Domain.Interfaces;
using Donde.SpokenPast.Core.Domain.Models;
using Donde.SpokenPast.Core.Repositories.Interfaces.RepositoryInterfaces;
using Donde.SpokenPast.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Donde.SpokenPast.Infrastructure.Repositories
{
    public class VideoRepository : GenericRepository, IVideoRepository
    {
        private readonly DondeContext dondeContext;
        public VideoRepository(DondeContext dbContext) : base(dbContext)
        {
            dondeContext = dbContext;
        }

        public List<Video> GetVideos(String searchterm)
        {
            return _dbContext.Set<Video>().AsNoTracking().Where(x => x.Name.ToLower().Contains(searchterm.ToLower())).ToList();
        }

        public void SaveVideoToDb(Video vid)
        {
            _dbContext.Set<Video>().Add(vid);
            _dbContext.SaveChanges();
        }
    }
}
