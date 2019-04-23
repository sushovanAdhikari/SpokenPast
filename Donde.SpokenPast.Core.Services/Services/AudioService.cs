using Donde.SpokenPast.Core.Domain.Dto;
using Donde.SpokenPast.Core.Domain.Helpers;
using Donde.SpokenPast.Core.Domain.Models;
using Donde.SpokenPast.Core.Repositories.Interfaces.RepositoryInterfaces;
using Donde.SpokenPast.Core.Service.Interfaces.ServiceInterfaces;
using Donde.SpokenPast.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donde.SpokenPast.Core.Services.Services
{
    public class AudioService
    {
        private IAudioRepository _audioRepository;

        public AudioService(IAudioRepository audioRepository)
        {
            _audioRepository = audioRepository;
        }

        public async Task<Audio> CreateAudioAsync(Audio entity)
        {
            entity.Id = SequentialGuidGenerator.GenerateComb();

            // validate the user entity. Use fluent validaiton with asp.net core.

            return await _audioRepository.CreateAudiosAsync(entity);
            
        }

        public Task<Audio> GetUserByIdAsync(Guid id)
        {
            return _audioRepository.GetAudioByIdAsync(id);
        }

        public IQueryable<Audio> GetAudios()
        {
            return _audioRepository.GetAudios();
        }

        public Task<User> UpdateUserAsync(Guid id, Audio entity)
        {
            throw new NotImplementedException();
        }
    }
}