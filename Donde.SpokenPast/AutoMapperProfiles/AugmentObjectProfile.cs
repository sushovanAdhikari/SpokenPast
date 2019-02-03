using AutoMapper;
using Donde.SpokenPast.Core.Domain.Dto;
using Donde.SpokenPast.Web.ViewModels;

namespace Donde.SpokenPast.Web.AutoMapperProfiles
{
    public class AugmentObjectProfile : Profile
    {
        public AugmentObjectProfile()
        {
            CreateMap<AugmentObjectDto, AugmentObjectViewModel>();
        }
    }
}
