using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donde.SpokenPast.Web.ViewModels
{
    public class UserViewModel
    {
        public Guid? Id { set; get; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }
    }
}
