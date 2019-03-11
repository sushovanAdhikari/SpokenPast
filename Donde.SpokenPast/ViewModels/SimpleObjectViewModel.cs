using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donde.SpokenPast.Web.ViewModels
{
    public class SimpleObjectViewModel
    {
        public Guid Id { get; set; }

        public Guid AvatarId { get; set; }

        public Guid AudioId { get; set; }

        public Guid AugmentImageId { get; set; }

        public string Description { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public Guid OrganizationId { get; set; }

        public double Distance { get; set; }
    }
}
