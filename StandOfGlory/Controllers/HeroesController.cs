using BusinessLogic.DTOs;
using BusinessLogic.Intefaces;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace StandOfGlory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly IHeroesService heroesService;
        private readonly IMailService mailService;

        private string UserEmail => User.FindFirstValue(ClaimTypes.Email);

        public HeroesController(IHeroesService heroesService, IMailService mailService)
        {
            this.heroesService = heroesService;
            this.mailService = mailService;
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
        [Authorize]
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

        [HttpPost("OfferANewHero")]
        public async Task<IActionResult> OfferANewHero([FromBody] string story)
        {
            await mailService.SendMailAsync("Offer", story, UserEmail);

            return Ok();
        }
    }
}
