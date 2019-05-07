using Donde.SpokenPast.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Donde.SpokenPast.Core.Service.Interfaces.ServiceInterfaces
{
    public interface IVideoService
    {
        List<Video> GetAllVideos(String searchterm);
        void SaveVideo(Video vid);
    }
}
