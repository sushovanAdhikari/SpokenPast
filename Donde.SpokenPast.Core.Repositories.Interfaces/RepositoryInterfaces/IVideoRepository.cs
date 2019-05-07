using Donde.SpokenPast.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Donde.SpokenPast.Core.Repositories.Interfaces.RepositoryInterfaces
{
    public interface IVideoRepository
    {
        List<Video> GetVideos(String searchterm);
        void SaveVideoToDb(Video vid);
    }
}
