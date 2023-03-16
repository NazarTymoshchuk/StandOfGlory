using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StandOfGlory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly IHeroesService heroesService;

        public HeroesController(IHeroesService heroesService)
        {
            this.heroesService = heroesService;
        }

        [HttpGet]                   // GET: ~/api/movies
        //[HttpGet("collection")]   // GET: ~/api/movies/collection
        //[HttpGet("/movies")]      // GET: ~/movies
        public async Task<IActionResult> Get()
        {
            return Ok(await heroesService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id) // FromQuery, FromRoute
        {
            var item = await heroesService.GetById(id);

            return Ok(item); // JSON
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] HeroDto movie)
        {
            if (!ModelState.IsValid) return BadRequest();

            await heroesService.Create(movie);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] HeroDto movie)
        {
            if (!ModelState.IsValid) return BadRequest();

            await heroesService.Edit(movie);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await heroesService.Delete(id);

            return Ok();
        }
    }
}
