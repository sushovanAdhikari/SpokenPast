using Donde.SpokenPast.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Donde.SpokenPast.Core.Service.Interfaces.ServiceInterfaces
{
    public interface IAudioService
    {
        Task<IEnumerable<Audio>> GetAudiosAsync();
        Task<Audio> CreateAudio(Audio entity);
        Task<Audio> UpdateAudio(Guid id, Audio entity);
        Task<Audio> GetAudioByIdAsync(Guid id);
    }
}
