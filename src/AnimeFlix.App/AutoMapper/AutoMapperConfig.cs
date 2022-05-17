using AnimeFlix.App.Areas.Dashboard.Models;
using AnimeFlix.Business.Models;
using AutoMapper;

namespace AnimeFlix.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Anime, AnimeViewModel>().ReverseMap();
        }
    }
}
