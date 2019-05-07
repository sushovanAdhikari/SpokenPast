using System;
using System.Collections.Generic;
using System.Text;

namespace Donde.SpokenPast.Core.Domain.Models
{
    public class Video
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public DateTime UploadedDate { get; set; }
    }
}
