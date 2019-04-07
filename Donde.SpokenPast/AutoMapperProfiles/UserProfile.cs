using AutoMapper;
using Donde.SpokenPast.Core.Domain.Helpers;
using Donde.SpokenPast.Core.Domain.Models;
using Donde.SpokenPast.Infrastructure.Repositories;
using Donde.SpokenPast.Web.ViewModels;
using System;

namespace Donde.SpokenPast.Web.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>()
                .ForMember(x => x.Id, src => src.Ignore())
                .ForMember(x => x.AddedDate, src => src.Ignore())
                 .ForMember(x => x.UpdatedDate, src => src.Ignore());


        }
    }
}
