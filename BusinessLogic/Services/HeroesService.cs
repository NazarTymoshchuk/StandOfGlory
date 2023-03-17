using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using BusinessLogic.Specifications;

namespace BusinessLogic.Services
{
    public class HeroesService : IHeroesService
    {
        private readonly IRepository<Hero> heroesService;
        private readonly IRepository<Card> cardsService;
        private readonly IMapper mapper;

        public HeroesService(IRepository<Hero> heroesService, IMapper mapper, IRepository<Card> cardsService)
        {
            this.heroesService = heroesService;
            this.mapper = mapper;
            this.cardsService = cardsService;
        }

        public async Task Create(HeroDto heroDto)
        {
            /*
             {
  "name": "aaa",
  "birthDate": "2022-03-15T18:34:53.768Z",
  "dateOfDeath": "2025-02-15T18:34:53.768Z",
  "story": "Lorem",
  "imagePath": "https://www.google.com",
  "cityId": 2,
  "battalionId": 1,
  "card": "423423432423"
}*/


            Card card = null;
            
            if (heroDto.CardNumber != null) 
            {
                card = new Card()
                {
                    Number = heroDto.CardNumber
                };
                await cardsService.Insert(card);
                await cardsService.Save();
            }

            var hero = mapper.Map<Hero>(heroDto);
            hero.CardId = card?.Id;

            await heroesService.Insert(hero);
            await heroesService.Save();
        }

        public async Task Delete(int id)
        {
            if (await heroesService.GetById(id) == null)
                return;

            await heroesService.Delete(id);
            await heroesService.Save();
        }

        public async Task Edit(HeroDto heroDto)
        {
            await heroesService.Update(mapper.Map<Hero>(heroDto));
            await heroesService.Save();
        }

        public async Task<IEnumerable<HeroDto>> GetAll()
        {
            var result = await heroesService.GetListBySpec(new Heroes.GetAll());

            return mapper.Map<IEnumerable<HeroDto>>(result);
        }

        public async Task<HeroDto?> GetById(int id)
        {
            Hero? hero = await heroesService.GetItemBySpec(new Heroes.GetById(id));

            if (hero == null)
                throw new Exception();

            return mapper.Map<HeroDto>(hero);
        }

        public async Task<IEnumerable<HeroDto>> GetAllByCity(string city)
        {
            var result = await heroesService.GetListBySpec(new Heroes.FilterByCity(city));

            return mapper.Map<IEnumerable<HeroDto>>(result);
        }

        public async Task<IEnumerable<HeroDto>> GetAllByBattalion(string battalion)
        {
            var result = await heroesService.GetListBySpec(new Heroes.FilterByBattalion(battalion));

            return mapper.Map<IEnumerable<HeroDto>>(result);
        }

        public async Task<IEnumerable<HeroDto>> GetAllByName(string name)
        {
            var result = await heroesService.GetListBySpec(new Heroes.FilterByName(name));

            return mapper.Map<IEnumerable<HeroDto>>(result);
        }
    }
}
