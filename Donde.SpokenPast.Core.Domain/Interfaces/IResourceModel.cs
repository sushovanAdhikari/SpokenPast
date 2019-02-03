using System;

namespace Donde.SpokenPast.Core.Domain.Interfaces
{
    public interface IResourceModel
    {
        string Name { get; set; }
        string Url { get; set; }
        Guid OrganizationId { get; set; }
    }
}
