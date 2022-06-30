using AnimeFlix.App.Models;
using AnimeFlix.Business.Entities;
using AutoMapper;

namespace AnimeFlix.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Anime, AnimeViewModel>()
                .ReverseMap();

            CreateMap<Session, SessionViewModel>()
                .ReverseMap();
        }
    }
}
