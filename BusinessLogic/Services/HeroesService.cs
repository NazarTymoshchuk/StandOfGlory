using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Entities;
using BusinessLogic.Intefaces;
using BusinessLogic.Interfaces;
using BusinessLogic.Specifications;

namespace BusinessLogic.Services
{
    public class HeroesService : IHeroesService
    {
        private readonly IRepository<Hero> heroesService;
        private readonly IRepository<Card> cardsService;
        private readonly IRepository<City> cityService;
        private readonly IRepository<Battalion> battalionService;
        private readonly IFileService fileService;
        private readonly IMapper mapper;

        public HeroesService(IRepository<Hero> heroesService, IMapper mapper, IRepository<Card> cardsService, IRepository<City> cityService, IRepository<Battalion> battalionService, IFileService fileService)
        {
            this.heroesService = heroesService;
            this.mapper = mapper;
            this.cardsService = cardsService;
            this.cityService = cityService;
            this.battalionService = battalionService;
            this.fileService = fileService;
        }

        public async Task Create(CreateHeroDto heroDto)
        {

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
            string imagePath = null;
            if (heroDto.Image != null)
                imagePath = fileService.SaveProductImage(heroDto.Image);

            var hero = mapper.Map<Hero>(heroDto);
            hero.CardId = card?.Id;
            hero.ImagePath = imagePath;

            await heroesService.Insert(hero);
            await heroesService.Save();
        }

        public async Task Delete(int id)
        {
            if (await heroesService.GetById(id) == null)
                return;

            fileService.DeleteProductImage(heroesService.GetById(id).Result.ImagePath);
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
        public async Task<IEnumerable<BattalionDto>> GetAllBattalions()
        {
            var result = await battalionService.GetAll();
            return mapper.Map<IEnumerable<BattalionDto>>(result);
        }
        public async Task<IEnumerable<CityDto>> GetAllCities()
        {
            var result = await cityService.GetAll();
            return mapper.Map<IEnumerable<CityDto>>(result);
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
