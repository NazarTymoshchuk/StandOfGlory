using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public string Story { get; set; }
        public string? ImagePath { get; set; }
        public City? City { get; set; }
        public int? CityId { get; set; }
        public Battalion? Battalion { get; set; }
        public int? BattalionId { get; set; }
        public Card? Card { get; set; }
        public int? CardId { get; set; }
    }
}
