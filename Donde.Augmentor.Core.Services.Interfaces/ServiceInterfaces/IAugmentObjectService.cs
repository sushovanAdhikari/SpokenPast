using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Donde.SpokenPast.Core.Domain.Dto;
using Donde.SpokenPast.Core.Domain.Models;

namespace Donde.SpokenPast.Core.Service.Interfaces.ServiceInterfaces
{
    public interface IAugmentObjectService
    {
        Task<IEnumerable<AugmentObjectDto>> GetClosestAugmentObjectsByRadius(double latitude, double longitude, int radiusInMeters);
        Task<AugmentObject> CreateAugmentObjectAsync(AugmentObject entity);
        Task<AugmentObject> UpdateAugmentObjectAsync(Guid id, AugmentObject entity);
    }
}
