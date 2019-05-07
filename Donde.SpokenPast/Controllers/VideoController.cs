using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Donde.SpokenPast.Core.Domain.Dto;
using Donde.SpokenPast.Core.Domain.Models;
using Donde.SpokenPast.Core.Service.Interfaces.ServiceInterfaces;
using Donde.SpokenPast.Infrastructure.Database;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Donde.SpokenPast.Web.Controllers
{
    [ApiVersion("1.0")]
    [ODataRoutePrefix("Video")]
    public class VideoController : ODataController
    {
        private readonly DondeContext _context;
        private readonly IVideoService _videoService;
        private readonly IMapper _mapper;
        // private readonly object odataOptions;
        private readonly IUserService _userService;

        public VideoController(DondeContext context, IVideoService videoService, IMapper mapper, IUserService userService)
        {
            _context = context;
            _videoService = videoService;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        [ODataRoute]
        public async Task<IActionResult> GetAllVideos(String videoName)
        {
            videoName = videoName ?? "";
            var videosToSend = _videoService.GetAllVideos(videoName);
            List<VideoDto> videos = new List<VideoDto>();
            foreach(var vid in videosToSend)
            {
                var authorName = await _userService.GetUserByIdAsync(vid.UserId);
                videos.Add(new VideoDto()
                {
                    Name = vid.Name,
                    Description = vid.Description,
                    UploadedDate = vid.UploadedDate,
                    Author = authorName.Name,
                });
            }
            return new JsonResult(new { Videos = videos });
        }

        [HttpPost]
        [ODataRoute]
        public async Task<IActionResult> UploadVideo([FromBody] VideoDto vid)
        {
            //byte[] fileBytes;
            //using (var memoryStream = new MemoryStream())
            //{
            //    await vid.Body.CopyToAsync(memoryStream);
            //    fileBytes = memoryStream.ToArray();
            //}

            //var filename = vid.Body.FileName;
            //var contentType = vid.Body.ContentType;

            //return null;
            _videoService.SaveVideo(vid);
            return new JsonResult(new { Message = "Video has been successfully saved." });
        }
    }
}