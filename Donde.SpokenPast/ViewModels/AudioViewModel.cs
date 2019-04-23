using Donde.SpokenPast.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donde.SpokenPast.Web.ViewModels
{
    public class AudioViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public User Poster { get; set; }

        public char Permission { get; set; }

        public List<User> AllowedUsers { get; set; }

        public string Path { get; set; }

        public string Description { get; set; }

        public byte[] Data { get; set; }
    }
}
