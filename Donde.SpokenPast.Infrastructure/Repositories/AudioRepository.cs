using Donde.Augmentor.Infrastructure.Repositories;
using Donde.SpokenPast.Core.Domain.Interfaces;
using Donde.SpokenPast.Core.Domain.Models;
using Donde.SpokenPast.Core.Repositories.Interfaces.RepositoryInterfaces;
using Donde.SpokenPast.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donde.SpokenPast.Infrastructure.Repositories
{
    public class AudioRepository : GenericRepository, IAudioRepository
    {
        public AudioRepository (DondeContext dbContext) : base(dbContext)
        {

        }

        public Task<Audio> CreateAudiosAsync(Audio entity)
        {
            return CreateAsync<Audio>(entity);
        }

        public Task<Audio> GetAudioByIdAsync(Guid id)
        {
            return GetByIdAsync<Audio>(id);
        }

        public IQueryable<Audio> GetAudios()
        {
            return GetAll<Audio>();
        }

        public Task<Audio> UpdateAudioAsync(Guid id, Audio entity)
        {
            return UpdateAsync<Audio>(id, entity);
        }

    }
}
