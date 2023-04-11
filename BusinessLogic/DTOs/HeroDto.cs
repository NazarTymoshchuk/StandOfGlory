namespace BusinessLogic.DTOs
{
    public class HeroDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public string Story { get; set; }
        public string? ImagePath { get; set; }
        public CityDto? City { get; set; }
        public BattalionDto? Battalion { get; set; }
        public string? CardNumber { get; set; }
    }
}
