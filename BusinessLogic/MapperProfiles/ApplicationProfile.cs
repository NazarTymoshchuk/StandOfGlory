using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Entities;

namespace BusinessLogic.MapperProfiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            //CreateMap<HeroDto, Hero>().ForMember(x => x.CardId, opt => opt.MapFrom(x => x.));

            CreateMap<CityDto, City>().ReverseMap();

            CreateMap<BattalionDto, Battalion>().ReverseMap();

            CreateMap<HeroDto, Hero>();

            CreateMap<CreateHeroDto, Hero>();

            CreateMap<Hero, CreateHeroDto>()
                .ForMember(x => x.CardNumber, opt => opt.MapFrom(x => x.Card.Number));

            CreateMap<Hero, HeroDto>()
                .ForMember(x => x.CardNumber, opt => opt.MapFrom(x => x.Card.Number));
        }
    }
}
