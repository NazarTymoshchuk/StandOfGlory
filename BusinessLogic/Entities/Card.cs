namespace BusinessLogic.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public ICollection<Hero>? Heroes { get; set; }
    }
}
