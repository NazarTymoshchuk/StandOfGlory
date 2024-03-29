﻿using BusinessLogic.DTOs;

namespace BusinessLogic.Interfaces
{
    public interface IHeroesService
    {
        Task<IEnumerable<HeroDto>> GetAll();
        Task<IEnumerable<HeroDto>> GetAllByCity(string city);
        Task<IEnumerable<HeroDto>> GetAllByBattalion(string battalion);
        Task<IEnumerable<HeroDto>> GetAllByName(string name);
        Task<IEnumerable<CityDto>> GetAllCities();
        Task<IEnumerable<BattalionDto>> GetAllBattalions();

        Task<HeroDto?> GetById(int id);
        Task Create(CreateHeroDto heroDto);
        Task Edit(HeroDto heroDto);
        Task Delete(int id);
    }
}
