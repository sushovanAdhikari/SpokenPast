using Donde.SpokenPast.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Donde.SpokenPast.Core.Domain.Models
{
    public class Audio : IDondeModel, IAuditFieldsModel
    {
        public Guid Id { get; set; }
        public string title { get; set; }
        public User poster { get; set; }
        public char permission { get; set; }
        public List<User> allowedUsers { get; set; }
        public string path { get; set; }
        public string description { get; set; }
        public byte[] data { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime IsActive { get; set; }  
    }
}
