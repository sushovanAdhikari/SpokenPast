using Donde.SpokenPast.Core.Domain.Models;
using Donde.SpokenPast.Core.Repositories.Interfaces.RepositoryInterfaces;
using Donde.SpokenPast.Core.Service.Interfaces.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Donde.SpokenPast.Core.Services.Services
{
    public class VideoService : IVideoService
    {
        private IVideoRepository _videoRepository;

        public VideoService(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public List<Video> GetAllVideos(String searchterm)
        {
            return _videoRepository.GetVideos(searchterm);
        }

        public void SaveVideo(Video vid)
        {
            vid.UploadedDate = DateTime.Now;
            _videoRepository.SaveVideoToDb(vid);
        }
    }
}
