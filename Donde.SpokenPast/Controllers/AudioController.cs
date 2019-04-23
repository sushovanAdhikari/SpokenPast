using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Donde.SpokenPast.Core.Domain.Models;
using Donde.SpokenPast.Core.Service.Interfaces.ServiceInterfaces;
using Donde.SpokenPast.Core.Services.Services;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;

namespace Donde.SpokenPast.Web.Controllers
{
    [ApiVersion("1.0")]
    [ODataRoutePrefix("Audio")]
    public class AudioController : ODataController
    {
        private readonly IAudioService _audioService;

        [HttpGet]
        [ODataRoute("{Id}")]
        public async Task<ActionResult> GetAudioByIdAsync([FromODataUri]Guid id)
        {
            try
            {
                Audio audio = await _audioService.GetAudioByIdAsync(id);
                byte[] bytes = audio.data;

                return File(bytes, "audio/mpeg", audio.title);
            } catch(Exception e)
            {
                throw e;
            }
        }



        [HttpGet]
        [ODataRoute]
        public async Task<IEnumerable<Audio>> GetAudiosAsync()
        {
            return await _audioService.GetAudiosAsync();
        }

        [HttpPost]
        [ODataRoute]
        public async Task<Audio> CreateAudioAsync([FromBody]Audio entity)
        {
            return await _audioService.CreateAudio(entity);
        }
    }
}