using System;
using Donde.SpokenPast.Core.Domain.Interfaces;

namespace Donde.SpokenPast.Core.Domain.Models
{
    public class User : IDondeModel, IAuditFieldsModel
    {
        public Guid Id { set; get; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public Guid OrganizationId { get; set; }



        public DateTime AddedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime IsActive { get; set; }
    }
}
