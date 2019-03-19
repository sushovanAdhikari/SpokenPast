using AutoMapper;
using Donde.SpokenPast.Core.Domain.Models;
using Donde.SpokenPast.Infrastructure.Repositories;

namespace Donde.SpokenPast.Web.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>();
        }
    }
}
