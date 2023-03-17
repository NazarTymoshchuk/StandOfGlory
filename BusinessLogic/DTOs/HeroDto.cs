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
        public int? CityId { get; set; }
        public int? BattalionId { get; set; }
        public string? CardNumber { get; set; }
    }
}
