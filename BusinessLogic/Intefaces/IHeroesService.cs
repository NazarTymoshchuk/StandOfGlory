using BusinessLogic.DTOs;

namespace BusinessLogic.Interfaces
{
    public interface IHeroesService
    {
        Task<IEnumerable<HeroDto>> GetAll();
        Task<HeroDto?> GetById(int id);
        Task Create(HeroDto heroDto);
        Task Edit(HeroDto heroDto);
        Task Delete(int id);
    }
}
