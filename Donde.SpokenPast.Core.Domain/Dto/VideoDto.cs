using Donde.SpokenPast.Core.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;


    public class VideoDto : Video
    {
        public String Author { get; set; }
        public IFormFile Body { get; set; }
    }

