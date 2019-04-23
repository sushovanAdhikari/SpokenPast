using Donde.SpokenPast.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donde.SpokenPast.Core.Repositories.Interfaces.RepositoryInterfaces
{
    public interface IAudioRepository
    {
        IQueryable<Audio> GetAudios();
        Task<Audio> CreateAudiosAsync(Audio entity);
        Task<Audio> UpdateAudioAsync(Guid id, Audio entity);
        Task<Audio> GetAudioByIdAsync(Guid id);
    }
}
