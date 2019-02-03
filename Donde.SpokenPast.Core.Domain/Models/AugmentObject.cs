﻿using Donde.SpokenPast.Core.Domain.Interfaces;
using System;

namespace Donde.SpokenPast.Core.Domain.Models
{
    public class AugmentObject : IDondeModel, IAuditFieldsModel
    {
        public Guid Id { get; set; }

        public Guid AvatarId { get; set; }
        public Guid AudioId { get; set; }
        public Guid AugmentImageId { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Guid OrganizationId { get; set; }

        public DateTime AddedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime IsActive { get; set; }
    }
}
